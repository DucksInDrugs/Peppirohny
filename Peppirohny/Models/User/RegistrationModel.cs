using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peppirohny.Models.User
{
    public class RegistrationModel
    {
        public int id { get; set; }
        public string FIO { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime registrationDate { get; set; }
    }
}
