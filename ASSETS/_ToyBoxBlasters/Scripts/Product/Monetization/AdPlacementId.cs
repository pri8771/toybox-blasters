namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>Stable placement ids for analytics and policy checks.</summary>
    public enum AdPlacementId
    {
        Unknown = 0,

        // Rewarded (V1)
        EndRun2xCoins = 10,
        ReviveOncePerRun = 11,
        DailyBonusChest = 12,

        /// <summary>Post-V1 — optional gate preview reroll.</summary>
        GatePreviewReroll = 13,

        // Interstitial (soft launch+)
        FailScreenContinueHome = 20,
        VictoryReturnToMenu = 21
    }
}
