using System;
using System.Collections.Generic;
using System.Text;

namespace ORMDAL
{
    public partial class Game
    {
        public int id { get; set; }
        public int score { get; set; }
        public DateTime? playDate { get; set; }
        public int? userID { get; set; }
        public virtual User user { get; set; }
    }
}
