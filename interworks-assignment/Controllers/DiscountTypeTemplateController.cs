using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountTypeTemplateController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public DiscountTypeTemplateController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllDiscountTypeTemplates()
        {
            var customers = _repository.DiscountTypeTemplate.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateDiscountTypeTemplate(DiscountTypeTemplate discountTypeTemplate)
        {
            _repository.DiscountTypeTemplate.Create(discountTypeTemplate);
            _repository.Save();
            return Ok(_repository.DiscountTypeTemplate.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateDiscountType(DiscountTypeTemplate discountTypeTemplate) {
            _repository.DiscountTypeTemplate.Update(discountTypeTemplate);
            _repository.Save();
            return Ok(_repository.DiscountTypeTemplate.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteDiscountType(int id)
        {
            _repository.DiscountTypeTemplate.DeleteDiscountTypeTemplate(id);
            _repository.Save();
            return Ok(_repository.DiscountTypeTemplate.GetAll());
        }
    }
}
