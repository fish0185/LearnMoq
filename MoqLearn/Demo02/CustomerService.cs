using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqLearn.Demo02
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(IEnumerable<CustomerToCreateDto> customersToCreate)
        {
            foreach (var customerToCreateDto in customersToCreate)
            {
                _customerRepository.Save(
                    new Customer(
                        customerToCreateDto.FirstName,
                        customerToCreateDto.LastName)
                    );
            }
        }
    }
}
