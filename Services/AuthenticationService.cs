using Axis.Models;
using Axis.Repositories;

namespace Axis.Services 
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _repository;
        public AuthenticationService(IAuthenticationRepository repository)
        {
            this._repository = repository;
        }

        #region Login Service
        public UserSession? Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var result = _repository.Login(username);
                if (result.returnMsg == "ok")
                {
                    return result.user;
                }
            }
            return null;
        }
        #endregion
    }
}
