using ASP_Project.Entities;
using System.Threading.Tasks;

namespace ASP_Project.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
