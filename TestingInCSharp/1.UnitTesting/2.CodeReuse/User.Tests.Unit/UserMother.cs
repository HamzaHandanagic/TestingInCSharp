using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Tests.Unit
{
    public class UserMother
    {
        public static User CreateValidUser()
        {
            return new User
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "johndoe",
                Address = "123 Main St",
                Phone = "555-1234",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non justo ac libero fermentum cursus.",
                ProfileImageUrl = "https://example.com/profile-image.jpg",
                Interests = "Sport, hiking, photography..."
            };
        }

        public static User CreateEmptyUser()
        {
            return new User(); // Create a user with no properties set
        }

        // Add other preconfigured user creation methods as needed
    }
}
