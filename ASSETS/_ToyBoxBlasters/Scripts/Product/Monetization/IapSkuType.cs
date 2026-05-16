namespace ToyBoxBlasters.Product.Monetization
{
    public enum IapSkuType
    {
        NoAds = 0,
        StarterPack = 1,
        CoinPack = 2,
        GemPack = 3,
        CosmeticBundle = 4,

        /// <summary>Document-only for V1; enabled in config with <c>enabledInV1 = false</c>.</summary>
        BattlePass = 5
    }
}
