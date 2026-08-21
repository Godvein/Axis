using Axis.Models;

namespace Axis.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public UserSession? Login(string username, string password);
    }
}
