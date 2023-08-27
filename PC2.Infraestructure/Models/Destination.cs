using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace si730pc2u201624050.Infraestructure.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int maxUsers { get; set; }
        public int isRisky { get; set; }
    }
}
