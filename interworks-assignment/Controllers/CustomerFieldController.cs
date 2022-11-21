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
        public IActionResult GetAllCustomerFields()
        {
            var customerfields = _repository.CustomerField.GetAll();
            return Ok(customerfields);
        }

        [HttpGet("[action]")]
        public IActionResult GetHistory(string guid)
        {
            var customerfields = _repository.CustomerField.GetHistoryByGuid(guid);
            return Ok(customerfields);
        }

        [HttpPost]
        public IActionResult CreateCustomerField(NewCustomerFieldDto custfield)
        {
            _repository.CustomerField.CreateNewCustomerField(custfield);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateCustomerField(UpdateCustomerFieldDto custfield) {
            _repository.CustomerField.UpdateCustomerField(custfield);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteCustomerField(int id)
        {
            _repository.CustomerField.DeleteCustomerField(id);
            _repository.Save();
            return Ok(_repository.CustomerField.GetAll());
        }
    }
}
