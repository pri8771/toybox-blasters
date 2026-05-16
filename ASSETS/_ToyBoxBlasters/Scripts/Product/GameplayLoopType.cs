namespace ToyBoxBlasters.Product
{
    /// <summary>
    /// Ten canonical gameplay loop layers (Task 005). Validator requires exactly one entry per value.
    /// </summary>
    public enum GameplayLoopType
    {
        MomentToMoment = 0,
        Level = 1,
        Session = 2,
        LongTermProgression = 3,
        RewardTiming = 4,
        FailureRetry = 5,
        Upgrade = 6,
        AdReward = 7,
        Cosmetic = 8,
        LiveOps = 9
    }
}
