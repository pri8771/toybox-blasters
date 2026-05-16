namespace ToyBoxBlasters.Product
{
    public interface ITargetAudienceProvider
    {
        TargetAudienceConfig Config { get; }
        bool IsValid { get; }
    }
}
