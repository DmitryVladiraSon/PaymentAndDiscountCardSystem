using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.Models
{
    internal class User
    {
        public User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
