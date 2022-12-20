using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Game
    {
        public int id { get; set; }
        public int? userID { get; set; }
        public int score { get; set; }
        public DateTime? playDate { get; set; }
    }
}
