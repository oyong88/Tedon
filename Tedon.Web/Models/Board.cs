using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tedon.Web.Models
{
    public class Board
    {
        public int Idx { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime RegDt { get; set; }
    }
}
