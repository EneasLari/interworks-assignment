using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public DiscountController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDiscounts()
        {
            var customers = _repository.Discount.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Discount discount)
        {
            _repository.Discount.Create(discount);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateUser(Discount discount) {
            _repository.Discount.Update(discount);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Discount.DeleteDiscount(id);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }
    }
}
