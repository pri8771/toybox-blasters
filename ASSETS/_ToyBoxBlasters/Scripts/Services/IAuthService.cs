using System.Threading;
using System.Threading.Tasks;

namespace ToyBoxBlasters.Services
{
    public interface IAuthService
    {
        bool IsSignedIn { get; }
        string UserId { get; }

        Task InitializeAsync(CancellationToken cancellationToken = default);
        Task SignInAnonymouslyAsync(CancellationToken cancellationToken = default);
        Task SignOutAsync(CancellationToken cancellationToken = default);
    }
}
