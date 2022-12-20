using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDAL
{
    public partial class User
    {
        public User()
        {
            game = new HashSet<Game>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime creationDate { get; set; }
        public virtual ICollection<Game> game { get; set; }
    }
}
