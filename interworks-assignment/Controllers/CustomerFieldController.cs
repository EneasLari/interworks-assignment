using interworks_assignment.Models.CustomerFieldsManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerFieldController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public CustomerFieldController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllFields()
        {
            var customers = _repository.CustomerField.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateField(NewCustomerFieldDto custfield)
        {
            _repository.CustomerField.CreateNewCustomerField(custfield);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateField(CustomerField custfield) {
            _repository.CustomerField.Update(custfield);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteField(int id)
        {
            _repository.CustomerField.DeleteCustomerField(id);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }
    }
}
