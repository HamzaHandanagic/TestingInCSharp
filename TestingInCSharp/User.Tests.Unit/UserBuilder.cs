using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Tests.Unit
{
    public class UserBuilder
    {
        private User user = new();

        public UserBuilder WithFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }

        public UserBuilder WithAddress(string address)
        {
            user.Address = address;
            return this;
        }

        // ...

        public User Build()
        {
            return user;
        }
    }
}
