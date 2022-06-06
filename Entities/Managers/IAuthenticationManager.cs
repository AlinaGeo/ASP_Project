using ASP_Project.Models;
using System.Threading.Tasks;

namespace ASP_Project.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(SignupUserModel signupUserModel);
        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}
