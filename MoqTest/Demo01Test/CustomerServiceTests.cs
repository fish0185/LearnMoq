using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest.Demo01Test
{
    using Moq;

    using MoqLearn.Demo01;

    using NUnit.Framework;

    [TestFixture]
    public  class CustomerServiceTests
    {
        [Test]
        public void the_repository_save_should_be_called()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();

            // Expect save method to get call
            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(mockRepository.Object);

            // Act
            customerService.Create(new CustomerToCreateDto());

            // verify all is saying that everything that we have done in the arrange 
            // area as a setup should be checked to see if it occurred.
            // Assert
            mockRepository.VerifyAll();
        }
    }
}
