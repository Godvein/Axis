using Axis.Models;

namespace Axis.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        public (UserSession user, string returnMsg) Login(string username);
    }
}
