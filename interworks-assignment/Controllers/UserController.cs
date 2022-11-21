using interworks_assignment.Data;
using interworks_assignment.Models.UserManagement;
using interworks_assignment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public UserController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repository.User.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _repository.User.CreateUser(user);
            _repository.Save();
            return Ok(_repository.User.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateUser(User user) {
            _repository.User.Update(user);
            _repository.Save();
            return Ok(_repository.User.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _repository.User.DeleteUser(id);
            _repository.Save();
            return Ok(_repository.User.GetAll());
        }
    }
}
