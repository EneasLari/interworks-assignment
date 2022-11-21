using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public DiscountTypeController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDiscountTypes()
        {
            var customers = _repository.DiscountType.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateDiscountType(DiscountType discountType)
        {
            _repository.DiscountType.Create(discountType);
            _repository.Save();
            return Ok(_repository.DiscountType.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateDiscountType(DiscountType discountType) {
            _repository.DiscountType.Update(discountType);
            _repository.Save();
            return Ok(_repository.DiscountType.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteDiscountType(int id)
        {
            _repository.DiscountType.DeleteDiscountType(id);
            _repository.Save();
            return Ok(_repository.DiscountType.GetAll());
        }
    }
}
