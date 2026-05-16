namespace ToyBoxBlasters.Services
{
    /// <summary>
    /// Documents preferred backend provider (Firebase by default). Task 009.
    /// </summary>
    public interface IBackendPreference
    {
        string ProviderName { get; }
    }
}
