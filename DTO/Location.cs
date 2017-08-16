using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }


        //Navigation Property
        public ICollection<Deal> Deals { get; set; }
    }
}
