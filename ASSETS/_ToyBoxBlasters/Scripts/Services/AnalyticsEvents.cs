namespace ToyBoxBlasters.Services
{
    /// <summary>
    /// Firebase Analytics event names (Task 009 taxonomy).
    /// </summary>
    public static class AnalyticsEvents
    {
        public const string AppOpen = "app_open";
        public const string LevelStart = "level_start";
        public const string LevelComplete = "level_complete";
        public const string LevelFail = "level_fail";
        public const string AdImpression = "ad_impression";
        public const string IapPurchase = "iap_purchase";

        public const string ParamLevelId = "level_id";
        public const string ParamAttempt = "attempt";
        public const string ParamDurationSeconds = "duration_s";
        public const string ParamCoins = "coins";
        public const string ParamPlacement = "placement";
        public const string ParamFormat = "format";
        public const string ParamProductId = "product_id";
        public const string ParamPriceTier = "price_tier";
        public const string ParamSessionCount = "session_count";
        public const string ParamFailReason = "reason";
    }
}
