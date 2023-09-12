using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Interests { get; set; }

        public string Fullname
        {
            get { return $"{FirstName?.Trim()} {LastName?.Trim()}".Trim(); }
        }
    }
}
