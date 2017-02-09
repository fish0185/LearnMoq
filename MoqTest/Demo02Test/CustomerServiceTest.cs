using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest.Demo02Test
{
    using Moq;

    using MoqLearn.Demo02;

    using NUnit.Framework;

    [TestFixture]
    public class CustomerServiceTest
    {
        [Test]
        public void the_customer_repository_should_be_called_once_per_customer()
        {
            // Arrange 
            var listOfCustomerDtos = new List<CustomerToCreateDto>
                                         {
                                             new CustomerToCreateDto
                                                 {
                                                     FirstName = "Sam",
                                                     LastName = "Sampson"
                                                 },
                                             new CustomerToCreateDto
                                                 {
                                                     FirstName = "Bob",
                                                     LastName = "Builder"
                                                 },
                                             new CustomerToCreateDto
                                                 {
                                                     FirstName = "Doug",
                                                     LastName = "Digger"
                                                 }
                                         };

            var mockCustomerRepository = new Mock<ICustomerRepository>();

            //mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(mockCustomerRepository.Object);

            // Act
            customerService.Create(listOfCustomerDtos);

            // Assert
            mockCustomerRepository.Verify(x=>x.Save(It.IsAny<Customer>()), Times.Exactly(listOfCustomerDtos.Count));
        }
    }
}
