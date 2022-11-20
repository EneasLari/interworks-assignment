﻿
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.UserManagement;
using interworks_assignment.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interworks_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public CustomerController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _repository.Customer.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _repository.Customer.Create(customer);
            _repository.Save();
            return Ok(_repository.Customer.GetAll());
        }

        [HttpPut]
        public IActionResult UpdateUser(Customer customer) {
            _repository.Customer.Update(customer);
            _repository.Save();
            return Ok(_repository.Customer.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Customer.DeleteCustomer(id);
            _repository.Save();
            return Ok(_repository.Customer.GetAll());
        }
    }
}
