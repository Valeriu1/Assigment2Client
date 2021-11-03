using System.Threading.Tasks;

namespace Assigment1.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}