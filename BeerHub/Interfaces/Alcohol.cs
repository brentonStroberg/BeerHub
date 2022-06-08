using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerHub.Interfaces
{
    public class Alcohol
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public List<string>? Ingredients { get; set; }
    }
}
