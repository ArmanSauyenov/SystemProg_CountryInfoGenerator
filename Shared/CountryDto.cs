using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CountryDto
    {
        public string Name { get; set; }
        public string Alpha3Code { get; set; }
        public string Capital { get; set; }
        public double Gini { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
