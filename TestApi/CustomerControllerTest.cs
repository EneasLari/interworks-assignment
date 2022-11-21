using interworks_assignment.Controllers;
using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Repositories.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    public class CustomerControllerTest
    {
        private readonly Mock<IRepositoryManager> _mockRepo;
        private readonly CustomerController _controller;

        public CustomerControllerTest()
        {
            _mockRepo = new Mock<IRepositoryManager>();
            _controller = new CustomerController(_mockRepo.Object);
        }

        [Fact]
        public void Test_Getting_All_Users()
        {
            var customers = _mockRepo.Setup(repo => repo.Customer.GetAll()).Returns(new List<Customer>());
            var result=_controller.GetAllCustomers();
            Assert.NotNull(result);
        }
    }
}
