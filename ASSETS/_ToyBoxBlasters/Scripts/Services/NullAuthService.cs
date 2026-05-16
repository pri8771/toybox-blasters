using System.Threading;
using System.Threading.Tasks;

namespace ToyBoxBlasters.Services
{
    public sealed class NullAuthService : IAuthService
    {
        public bool IsSignedIn { get; private set; }
        public string UserId { get; private set; } = "local_dev_user";

        public Task InitializeAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public Task SignInAnonymouslyAsync(CancellationToken cancellationToken = default)
        {
            IsSignedIn = true;
            return Task.CompletedTask;
        }

        public Task SignOutAsync(CancellationToken cancellationToken = default)
        {
            IsSignedIn = false;
            return Task.CompletedTask;
        }
    }
}
