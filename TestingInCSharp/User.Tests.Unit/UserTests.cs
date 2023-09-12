using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace User.Tests.Unit
{
    public class UserTests
    {
        [Fact]
        public void FullName_ShouldConcatenateFirstAndLastName()
        {
            // Arrange
            User user = new User()
            {
                FirstName = "John",
                LastName = "Doe",
                Username = "John",
                Address = "BiH 77228",
                Phone = "003871212321",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non justo ac libero fermentum cursus.",
                ProfileImageUrl = "https://example.com/profile-image.jpg",
                Interests = "Sport, hiking, photography..."
                // ...
            };

            // Act
            string fullName = user.Fullname;

            // Assert
            Assert.Equal("John Doe", fullName);
        }

        /// <summary>
        /// Basic test
        /// </summary>
        [Fact]
        public void Fullname_ShouldHandleEmptyFirstName()
        {
            // Arrange
            var user = new User
            {
                FirstName = "",
                LastName = "Doe",
                Username = "John",
                Address = "BiH 77228",
                Phone = "003871212321",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non justo ac libero fermentum cursus.",
                ProfileImageUrl = "https://example.com/profile-image.jpg",
                Interests = "Sport, hiking, photography..."
            };

            // Act
            string fullName = user.Fullname;

            // Assert
            Assert.Equal("Doe", fullName);
        }

        /// <summary>
        /// Basic test
        /// </summary>
        [Fact]
        public void Fullname_ShouldHandleEmptyLastName()
        {
            // Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "",
                Username = "John",
                Address = "BiH 77228",
                Phone = "003871212321",
                Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non justo ac libero fermentum cursus.",
                ProfileImageUrl = "https://example.com/profile-image.jpg",
                Interests = "Sport, hiking, photography..."
            };

            // Act
            string fullName = user.Fullname;

            // Assert
            Assert.Equal("John", fullName);
        }
       
        /// <summary>
        /// With Mother Object pattern
        /// </summary>
        [Fact]
        public void ObjectMother_FullName_ShouldConcatenateFirstAndLastName() 
        {
            // Arrange
            User user = UserMother.CreateValidUser();
           
            // Act
            string fullName = user.Fullname;

            // Assert
            Assert.Equal("John Doe", fullName);
        }

        /// <summary>
        /// With TestBuilder pattern
        /// </summary>
        [Fact]
        public void TestBuilder_FullName_ShouldConcatenateFirstAndLastName()
        {
            // Arrange
            User user = new UserBuilder()
                         .WithFirstName("Hamza")
                         .WithLastName("Handanagic")
                         .Build();

            // Act
            string fullName = user.Fullname;

            // Assert
            Assert.Equal("Hamza Handanagic", fullName);
        }
    }
}
