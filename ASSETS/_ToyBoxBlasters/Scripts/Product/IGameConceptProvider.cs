namespace ToyBoxBlasters.Product
{
    public interface IGameConceptProvider
    {
        GameConceptConfig Config { get; }
        bool IsValid { get; }
    }
}
