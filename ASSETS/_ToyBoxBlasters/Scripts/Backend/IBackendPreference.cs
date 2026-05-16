namespace ToyBoxBlasters.Backend
{
    /// <summary>
    /// Documents Task 001 backend preference. Implementations use Firebase by default.
    /// </summary>
    public interface IBackendPreference
    {
        string ProviderName { get; }
    }
}
