using interworks_assignment.Data;
using interworks_assignment.Models.UserManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace interworks_assignment.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public IEnumerable<User> GetAllUsers() { 
            return GetAll().OrderBy(c=>c.Name);
        }

        public void CreateUser(User user) {
            Create(user);
        }

        public void DeleteUser(int id)
        {
            User user=GetById(id);
            Delete(user);
        }
    }
}
