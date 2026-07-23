using Axis.Models;

namespace Axis.Repositories
{
    public interface IAuthenticationRepository
    {
        public (UserSession user, string returnMsg) Login(string username);
    }
}
