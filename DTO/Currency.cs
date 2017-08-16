using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Rate { get; set; }

        //Navigation Property
        public ICollection<Country> Countries { get; set; }
    }
}
