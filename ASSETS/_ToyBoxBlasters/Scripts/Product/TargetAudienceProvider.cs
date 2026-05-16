namespace ToyBoxBlasters.Product
{
    public sealed class TargetAudienceProvider : ITargetAudienceProvider
    {
        readonly TargetAudienceConfig _config;

        public TargetAudienceProvider(TargetAudienceConfig config)
        {
            _config = config;
            IsValid = _config != null && TargetAudienceValidator.Validate(_config, out _);
        }

        public TargetAudienceConfig Config => _config;
        public bool IsValid { get; }
    }
}
