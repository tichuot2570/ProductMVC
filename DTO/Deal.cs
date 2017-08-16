﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Deal
    {
        public int DealId { get; set; }
        //FK
        public int LocationId { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Navigation Property
        public Location Location { get; set; }
        public Contact Contact { get; set; }
    }
}
