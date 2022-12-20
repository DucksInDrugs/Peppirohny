using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime creationDate { get; set; }
    }
}
