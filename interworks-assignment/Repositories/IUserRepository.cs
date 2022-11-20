using interworks_assignment.Models.UserManagement;

namespace interworks_assignment.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);

        void DeleteUser(int id);
    }
}

