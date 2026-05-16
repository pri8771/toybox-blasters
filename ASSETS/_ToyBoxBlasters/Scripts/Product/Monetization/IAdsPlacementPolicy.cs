namespace ToyBoxBlasters.Product.Monetization
{
    /// <summary>
    /// Phase 1 stub — no AdMob/AppLovin SDK. Implement in soft launch with session state + Remote Config.
    /// </summary>
    public interface IAdsPlacementPolicy
    {
        bool CanShowInterstitial(AdPlacementId placementId, int completedRunsThisSession, int totalRunsLifetime);

        bool CanShowRewarded(AdPlacementId placementId, int rewardedShownToday);

        float SecondsUntilNextInterstitialAllowed(float secondsSinceLastInterstitial);
    }
}
