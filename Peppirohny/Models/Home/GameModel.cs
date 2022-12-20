using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peppirohny.Models.Home
{
    public class GameModel
    {
        public int id { get; set; }
        public DateTime playDate { get; set; }
        public int userID { get; set; }
        public int score { get; set; }
    }
}
