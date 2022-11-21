using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("[action]")]
        public IActionResult GetDiscountsByOrderId(int orderId)
        {
            var discounts = _repository.Discount.GetDiscountsByOrderId(orderId);
            return Ok(discounts);
        }

        [HttpPost]
        public IActionResult CreateDiscount(Discount discount)
        {
            _repository.Discount.Create(discount);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateDiscount(Discount discount) {
            _repository.Discount.Update(discount);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            _repository.Discount.DeleteDiscount(id);
            _repository.Save();
            return Ok(_repository.Discount.GetAll());
        }
    }
}
