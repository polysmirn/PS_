using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Model.Entities
{
    public class Photographer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price_for_hour { get; set; }
        public int Experience { get; set; }
        public byte[] Image { get; set; }
    }
}
