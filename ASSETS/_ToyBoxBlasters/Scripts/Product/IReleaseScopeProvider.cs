namespace ToyBoxBlasters.Product
{
    public interface IReleaseScopeProvider
    {
        ReleaseScopeConfig Config { get; }
        bool IsValid { get; }
    }
}
