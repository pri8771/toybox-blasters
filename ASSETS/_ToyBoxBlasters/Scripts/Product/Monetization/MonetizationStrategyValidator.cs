using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBoxBlasters.Product.Monetization
{
    public static class MonetizationStrategyValidator
    {
        public const int MinimumKpiEntries = 6;
        public const int MinimumRewardedPerDay = 5;
        public const int MaximumRewardedPerDay = 8;

        public static bool Validate(MonetizationStrategyConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "MonetizationStrategyConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "Strategy summary", config.StrategySummary);
            RequireNonEmpty(errors, "Economy alignment", config.EconomyAlignmentNote);
            RequireNonEmpty(errors, "Family-friendly disclosure", config.FamilyFriendlyDisclosure);
            RequireNonEmpty(errors, "Battle pass V1 note", config.BattlePassV1Note);

            ValidateFrequencyRules(config.AdFrequencyRules, errors);
            ValidateAdPlacements(config.AdPlacements?.ToList() ?? new List<AdPlacementEntry>(), errors);
            ValidateIapSkus(config.IapSkus?.ToList() ?? new List<IapSkuEntry>(), errors);
            ValidateKpis(config.KpiTargets?.ToList() ?? new List<MonetizationKpiEntry>(), errors);

            if (errors.Count == 0)
            {
                report = BuildSuccessReport(config);
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidateFrequencyRules(AdFrequencyRules rules, List<string> errors)
        {
            if (rules == null)
            {
                errors.Add("Ad frequency rules missing.");
                return;
            }

            if (rules.MinInterstitialIntervalSeconds < 90f || rules.MinInterstitialIntervalSeconds > 120f)
                errors.Add($"Min interstitial interval must be 90–120s (actual: {rules.MinInterstitialIntervalSeconds}).");

            if (rules.MaxInterstitialIntervalSeconds < rules.MinInterstitialIntervalSeconds)
                errors.Add("Max interstitial interval must be >= min interval.");

            if (rules.MaxInterstitialsPerSession < 1)
                errors.Add("Max interstitials per session must be >= 1.");

            if (rules.MaxRewardedPerDay < MinimumRewardedPerDay || rules.MaxRewardedPerDay > MaximumRewardedPerDay)
                errors.Add($"Max rewarded per day must be {MinimumRewardedPerDay}–{MaximumRewardedPerDay}.");

            if (rules.NewPlayerGraceRunsNoInterstitial < 3)
                errors.Add("New player grace must be at least 3 runs without interstitial.");

            if (!rules.BlockInterstitialMidLevel || !rules.BlockInterstitialDuringBoss)
                errors.Add("Interstitial mid-level and boss blocks must remain enabled.");
        }

        static void ValidateAdPlacements(List<AdPlacementEntry> placements, List<string> errors)
        {
            if (placements.Count == 0)
            {
                errors.Add("Ad placements list is empty.");
                return;
            }

            var ids = new HashSet<AdPlacementId>();
            foreach (var p in placements)
            {
                if (p == null)
                {
                    errors.Add("Null ad placement entry.");
                    continue;
                }

                if (p.PlacementId == AdPlacementId.Unknown)
                    errors.Add("Ad placement with Unknown id.");
                else if (!ids.Add(p.PlacementId))
                    errors.Add($"Duplicate ad placement id: {p.PlacementId}");

                RequireNonEmpty(errors, $"Placement '{p.PlacementId}' name", p.DisplayName);
            }

            foreach (var required in MonetizationStrategyDefaults.RequiredRewardedPlacementIds)
            {
                if (!ids.Contains(required))
                    errors.Add($"Missing required rewarded placement: {required}.");
            }

            foreach (var required in MonetizationStrategyDefaults.RequiredInterstitialPlacementIds)
            {
                if (!ids.Contains(required))
                    errors.Add($"Missing required interstitial placement: {required}.");
            }

            var gateReroll = placements.FirstOrDefault(p => p?.PlacementId == AdPlacementId.GatePreviewReroll);
            if (gateReroll != null && (!gateReroll.PostV1Only || gateReroll.EnabledInV1))
                errors.Add("Gate preview reroll must be post-V1 only (postV1Only, not enabledInV1).");
        }

        static void ValidateIapSkus(List<IapSkuEntry> skus, List<string> errors)
        {
            if (skus.Count == 0)
            {
                errors.Add("IAP SKU list is empty.");
                return;
            }

            var ids = new HashSet<string>();
            IapSkuEntry noAds = null;
            IapSkuEntry starter = null;
            var coinPacks = 0;
            var gemPacks = 0;
            IapSkuEntry battlePass = null;

            foreach (var s in skus)
            {
                if (s == null)
                {
                    errors.Add("Null IAP SKU entry.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(s.SkuId))
                    errors.Add("IAP SKU with empty id.");
                else if (!ids.Add(s.SkuId.Trim()))
                    errors.Add($"Duplicate IAP sku id: {s.SkuId}");

                RequireNonEmpty(errors, $"SKU '{s.SkuId}' name", s.DisplayName);

                switch (s.SkuType)
                {
                    case IapSkuType.NoAds:
                        noAds = s;
                        break;
                    case IapSkuType.StarterPack:
                        starter = s;
                        break;
                    case IapSkuType.CoinPack:
                        coinPacks++;
                        break;
                    case IapSkuType.GemPack:
                        gemPacks++;
                        break;
                    case IapSkuType.BattlePass:
                        battlePass = s;
                        break;
                }
            }

            if (noAds == null || !Approximately(noAds.PriceUsd, MonetizationStrategyDefaults.NoAdsPriceUsd))
                errors.Add($"No-ads SKU must exist at ${MonetizationStrategyDefaults.NoAdsPriceUsd:F2}.");

            if (starter == null || !Approximately(starter.PriceUsd, MonetizationStrategyDefaults.StarterPackPriceUsd))
                errors.Add($"Starter pack must exist at ${MonetizationStrategyDefaults.StarterPackPriceUsd:F2}.");

            if (starter != null && (!starter.FirstOfferWindowOnly || starter.OfferWindowHours != MonetizationStrategyDefaults.StarterPackOfferWindowHours))
                errors.Add("Starter pack must be first-offer window only (72h).");

            if (coinPacks < 3)
                errors.Add("At least 3 coin pack SKUs required ($0.99, $4.99, $9.99 ladder).");

            if (gemPacks < 4)
                errors.Add("At least 4 gem pack SKUs required ($0.99–$19.99 ladder).");

            if (battlePass == null || battlePass.EnabledInV1)
                errors.Add("Battle pass SKU must exist with enabledInV1 = false (document-only for V1).");

            foreach (var gem in skus.Where(s => s?.SkuType == IapSkuType.GemPack && s.EnabledInV1))
            {
                if (gem.GrantCoins > 0 && gem.GrantGems == 0)
                    errors.Add($"Gem pack '{gem.SkuId}' should grant gems, not coins-only power.");
            }
        }

        static void ValidateKpis(List<MonetizationKpiEntry> kpis, List<string> errors)
        {
            if (kpis.Count < MinimumKpiEntries)
                errors.Add($"At least {MinimumKpiEntries} KPI entries required.");

            var ids = new HashSet<string>();
            foreach (var k in kpis)
            {
                if (k == null)
                {
                    errors.Add("Null KPI entry.");
                    continue;
                }

                if (string.IsNullOrWhiteSpace(k.MetricId))
                    errors.Add("KPI with empty metric id.");
                else if (!ids.Add(k.MetricId.Trim()))
                    errors.Add($"Duplicate KPI id: {k.MetricId}");

                RequireNonEmpty(errors, $"KPI '{k.MetricId}' name", k.DisplayName);
                RequireNonEmpty(errors, $"KPI '{k.MetricId}' target", k.TargetDescription);
            }
        }

        static string BuildSuccessReport(MonetizationStrategyConfig config)
        {
            var rewarded = config.AdPlacements?.Count(p => p != null && p.Kind == AdPlacementKind.Rewarded) ?? 0;
            var interstitial = config.AdPlacements?.Count(p => p != null && p.Kind == AdPlacementKind.Interstitial) ?? 0;
            var v1Skus = config.IapSkus?.Count(s => s != null && s.EnabledInV1) ?? 0;
            return
                $"Monetization strategy validation passed (Task 007).\n" +
                $"Placements: {rewarded} rewarded, {interstitial} interstitial.\n" +
                $"IAP SKUs (V1 enabled): {v1Skus}. KPIs: {config.KpiTargets?.Count ?? 0}.\n" +
                $"Interstitial cooldown: {config.AdFrequencyRules?.MinInterstitialIntervalSeconds}s; " +
                $"grace runs: {config.AdFrequencyRules?.NewPlayerGraceRunsNoInterstitial}.";
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }

        static bool Approximately(float a, float b) => System.Math.Abs(a - b) < 0.01f;
    }
}
