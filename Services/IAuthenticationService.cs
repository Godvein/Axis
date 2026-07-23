using Axis.Models;

namespace Axis.Services
{
    public interface IAuthenticationService
    {
        public UserSession? Login(string username, string password);
    }
}
