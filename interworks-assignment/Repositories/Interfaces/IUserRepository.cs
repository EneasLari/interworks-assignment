using interworks_assignment.Models.UserManagement;

namespace interworks_assignment.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        public User GetUserByEmail(string email);

        void DeleteUser(int id);
    }
}

