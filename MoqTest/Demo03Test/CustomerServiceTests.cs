using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqTest.Demo03Test
{
    using Moq;

    using MoqLearn.Demo03;

    using NUnit.Core;
    using NUnit.Framework;

    public class CustomerServiceTests
    {
        [TestFixture]
        public class When_creating_a_new_customer
        {
            [Test]
            public void an_exception_should_be_thrown_if_the_address_is_not_created()
            {
                // Arrange 
                var customerToCreateDto = new CustomerToCreateDto
                                              {
                                                  FirstName = "Bob",
                                                  LastName = "Builder"
                                              };
                var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
                var mockCustomerRepository = new Mock<ICustomerRepository>();
                mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreateDto>())).Returns(() => null);
                var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

                // Act
                TestDelegate testDelegate = () => customerService.Create(customerToCreateDto);

                // Assert
                Assert.That(testDelegate, Throws.TypeOf<InvalidCustomerMailingAddressException>());
            }

            [Test]
            public void the_customer_should_be_saved_if_the_address_was_created()
            {
                // Arrange
                var customerToCreateDto = new CustomerToCreateDto
                                              {
                                                  FirstName = "Bob",
                                                  LastName = "Builder"
                                              };
                var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
                var mockCustomerRepository = new Mock<ICustomerRepository>();

                mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreateDto>())).Returns(() => new Address());

                var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

                // Act
                customerService.Create(customerToCreateDto);

                // Assert
                mockCustomerRepository.Verify(y=>y.Save(It.IsAny<Customer>()));
            }
        }
    }
}
