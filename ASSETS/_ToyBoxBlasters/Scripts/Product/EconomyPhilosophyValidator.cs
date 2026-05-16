using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyBoxBlasters.Product
{
    public static class EconomyPhilosophyValidator
    {
        static readonly string[] RequiredCoinSourceIds =
        {
            "coin_source_level_complete",
            "coin_source_obstacle_break",
            "coin_source_enemy_kill",
            "coin_source_boss_bonus",
            "coin_source_daily_login",
            "coin_source_rewarded_ad_2x",
            "coin_source_achievements"
        };

        static readonly string[] RequiredCoinSinkIds =
        {
            "coin_sink_upgrade_damage",
            "coin_sink_upgrade_fire_rate",
            "coin_sink_upgrade_starting_squad",
            "coin_sink_gate_reroll",
            "coin_sink_continue_run"
        };

        static readonly string[] RequiredGemSourceIds =
        {
            "gem_source_iap_packs",
            "gem_source_battle_pass",
            "gem_source_level_milestones",
            "gem_source_event_rewards"
        };

        static readonly string[] RequiredGemSinkIds =
        {
            "gem_sink_cosmetic_skins",
            "gem_sink_trail_vfx",
            "gem_sink_no_ads_partial",
            "gem_sink_event_shop",
            "gem_sink_revive_convenience"
        };

        static readonly CurrencyKind[] RequiredCurrencies =
        {
            CurrencyKind.SoftCoins,
            CurrencyKind.PremiumGems,
            CurrencyKind.EventBedroomTokens
        };

        public static bool Validate(EconomyPhilosophyConfig config, out string report)
        {
            var errors = new List<string>();
            if (config == null)
            {
                report = "EconomyPhilosophyConfig is null.";
                return false;
            }

            RequireNonEmpty(errors, "Task id", config.TaskId);
            RequireNonEmpty(errors, "Philosophy version", config.PhilosophyVersion);
            RequireNonEmpty(errors, "Philosophy summary", config.PhilosophySummary);

            ValidateCurrencies(errors, config);
            RequireFlowIds(errors, config.CoinSources, RequiredCoinSourceIds, "coin source");
            RequireFlowIds(errors, config.CoinSinks, RequiredCoinSinkIds, "coin sink");
            RequireFlowIds(errors, config.GemSources, RequiredGemSourceIds, "gem source");
            RequireFlowIds(errors, config.GemSinks, RequiredGemSinkIds, "gem sink");

            if (config.EventCurrencyFlows == null || config.EventCurrencyFlows.Count < 2)
                errors.Add("At least 2 event currency flows required (source + sink/burn).");

            if (config.IapOffers == null || config.IapOffers.Count < 4)
                errors.Add("At least 4 IAP ladder entries required.");

            ValidateAdPolicy(errors, config);
            ValidateAntiInflation(errors, config);
            ValidateGemsNotRequired(errors, config);

            if (errors.Count == 0)
            {
                report = "Economy philosophy validation passed (Task 006). " +
                         $"Currencies={config.Currencies?.Count ?? 0}, " +
                         $"Coin sources={config.CoinSources?.Count ?? 0}, sinks={config.CoinSinks?.Count ?? 0}.";
                return true;
            }

            var sb = new StringBuilder();
            foreach (var e in errors)
                sb.AppendLine("- ").Append(e);
            report = sb.ToString();
            return false;
        }

        static void ValidateCurrencies(List<string> errors, EconomyPhilosophyConfig config)
        {
            if (config.Currencies == null || config.Currencies.Count < 3)
            {
                errors.Add("Exactly 3 currency definitions required (coins, gems, event).");
                return;
            }

            foreach (var kind in RequiredCurrencies)
            {
                if (!config.Currencies.Any(c => c != null && c.Kind == kind))
                    errors.Add($"Missing currency definition for {kind}.");
            }

            if (!config.TryGetCurrency(CurrencyKind.SoftCoins, out var coins) ||
                coins.FirstImplementedPhase != ReleasePhase.Mvp)
                errors.Add("Coins must be implemented in MVP phase.");

            if (!config.TryGetCurrency(CurrencyKind.PremiumGems, out var gems) ||
                gems.RequiredToProgressV1)
                errors.Add("Gems must NOT be required to progress V1.");

            if (!config.TryGetCurrency(CurrencyKind.EventBedroomTokens, out var tokens) ||
                !tokens.ExpiresAfterEvent)
                errors.Add("Event Bedroom Tokens must expire after event.");

            if (tokens != null &&
                tokens.DisplayName.IndexOf("Bedroom", System.StringComparison.OrdinalIgnoreCase) < 0)
                errors.Add("Event currency display name should reference Bedroom Tokens.");
        }

        static void ValidateAdPolicy(List<string> errors, EconomyPhilosophyConfig config)
        {
            if (config.RewardedCoinBonusPercentMin < 50f || config.RewardedCoinBonusPercentMax > 100f)
                errors.Add("Rewarded coin bonus should be 50–100% range (design band).");

            if (config.RewardedCoinBonusPercentMin > config.RewardedCoinBonusPercentMax)
                errors.Add("Rewarded coin bonus min must be <= max.");

            if (config.RewardedDailyCapMin < 5 || config.RewardedDailyCapMax > 8)
                errors.Add("Rewarded daily cap band should be 5–8 (min/max fields).");

            if (config.RewardedDailyCapMin > config.RewardedDailyCapMax)
                errors.Add("Rewarded daily cap min must be <= max.");

            if (!config.RewardedOffersRevive && !config.RewardedOffersCoinDouble)
                errors.Add("Rewarded ads must offer revive and/or coin double.");

            if (string.IsNullOrWhiteSpace(config.InterstitialPlacementRule) ||
                config.InterstitialPlacementRule.IndexOf("between", System.StringComparison.OrdinalIgnoreCase) < 0)
                errors.Add("Interstitial placement rule must state between-runs only.");
        }

        static void ValidateAntiInflation(List<string> errors, EconomyPhilosophyConfig config)
        {
            if (config.AntiInflationPrinciples == null || config.AntiInflationPrinciples.Count < 5)
                errors.Add("At least 5 anti-inflation principles required.");
        }

        static void ValidateGemsNotRequired(List<string> errors, EconomyPhilosophyConfig config)
        {
            var iapText = string.Join(" ", config.IapOffers?.Select(o => o?.DisplayName ?? "") ?? Enumerable.Empty<string>());
            if (iapText.IndexOf("pay", System.StringComparison.OrdinalIgnoreCase) >= 0 &&
                iapText.IndexOf("win", System.StringComparison.OrdinalIgnoreCase) >= 0)
                errors.Add("IAP ladder must not include pay-to-win power bundles in V1.");
        }

        static void RequireFlowIds(
            List<string> errors,
            IReadOnlyList<EconomyFlowEntry> flows,
            string[] requiredIds,
            string label)
        {
            if (flows == null)
            {
                errors.Add($"No {label} flows defined.");
                return;
            }

            var ids = flows.Where(f => f != null).Select(f => f.FlowId).ToHashSet();
            foreach (var required in requiredIds)
            {
                if (!ids.Contains(required))
                    errors.Add($"Missing {label}: {required}.");
            }
        }

        static void RequireNonEmpty(List<string> errors, string label, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                errors.Add($"{label} is empty.");
        }
    }
}
