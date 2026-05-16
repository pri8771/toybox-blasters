namespace ToyBoxBlasters.Services
{
    public sealed class FirebaseBackendPreference : IBackendPreference
    {
        public const string ProviderId = "Firebase";
        public string ProviderName => ProviderId;
    }
}
