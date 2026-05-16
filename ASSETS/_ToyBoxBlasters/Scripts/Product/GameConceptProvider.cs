namespace ToyBoxBlasters.Product
{
    public sealed class GameConceptProvider : IGameConceptProvider
    {
        readonly GameConceptConfig _config;

        public GameConceptProvider(GameConceptConfig config)
        {
            _config = config;
            IsValid = _config != null && GameConceptValidator.Validate(_config, out _);
        }

        public GameConceptConfig Config => _config;
        public bool IsValid { get; }
    }
}
