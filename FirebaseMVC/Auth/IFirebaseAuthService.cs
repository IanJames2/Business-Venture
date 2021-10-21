using System.Threading.Tasks;
using BusinessVenture.Auth.Models;

namespace BusinessVenture.Auth
{
    public interface IFirebaseAuthService
    {
        Task<FirebaseUser> Login(Credentials credentials);
        Task<FirebaseUser> Register(Registration registration);
    }
}