using interworks_assignment.Models.DiscountManagement;
using interworks_assignment.Models.OrderManagement;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public OrderController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var order = _repository.Order.GetAll();
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(NewOrderDto neworder)
        {
            _repository.Order.CreateNewOrder(neworder);
            _repository.Save();
            return Ok(_repository.Order.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateOrder(Order order) {
            _repository.Order.Update(order);
            _repository.Save();
            return Ok(_repository.Order.GetAll());
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            _repository.Order.DeleteOrder(id);
            _repository.Save();
            return Ok(_repository.Order.GetAll());
        }
    }
}
