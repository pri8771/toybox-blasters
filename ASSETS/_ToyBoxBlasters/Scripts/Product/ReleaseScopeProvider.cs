namespace ToyBoxBlasters.Product
{
    public sealed class ReleaseScopeProvider : IReleaseScopeProvider
    {
        readonly ReleaseScopeConfig _config;

        public ReleaseScopeProvider(ReleaseScopeConfig config)
        {
            _config = config;
            IsValid = _config != null && ReleaseScopeValidator.Validate(_config, out _);
        }

        public ReleaseScopeConfig Config => _config;
        public bool IsValid { get; }
    }
}
