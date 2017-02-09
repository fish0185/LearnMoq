using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqLearn.Demo03
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Address MailingAddress { get; set; }

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
