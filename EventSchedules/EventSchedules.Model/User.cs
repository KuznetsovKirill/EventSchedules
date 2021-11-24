using EventSchedules.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedules.Model
{
    public class User
    {
        internal User()
        { }

        public User(string email, string passWord, string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(passWord))
                throw new ArgumentNullException("something wrong");

            Email = email;
            Password = passWord;
            FirstName = firstName;
            LastName = lastName;            
        }

        public User(string email, string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;          
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Event> Events{ get; set; }
    }
}

