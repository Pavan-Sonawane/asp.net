using Personal_Details_Card_With_Image.Models;
using Personal_Details_Card_With_Image.Models.MainDbContext;

namespace Personal_Details_Card_With_Image.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task CreateUser(UserDTO userDTO);
        Task UpdateUser(int id, UserDTO userDTO);
        Task DeleteUser(int id);
    }
}
