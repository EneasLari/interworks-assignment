using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public FieldController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllFields()
        {
            var customers = _repository.Field.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateField(Field field)
        {
            _repository.Field.Create(field);
            _repository.Save();
            return Ok(_repository.Field.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateField(Field field) {
            _repository.Field.Update(field);
            _repository.Save();
            return Ok(_repository.Field.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteField(int id)
        {
            _repository.Field.DeleteField(id);
            _repository.Save();
            return Ok(_repository.Field.GetAll());
        }
    }
}
