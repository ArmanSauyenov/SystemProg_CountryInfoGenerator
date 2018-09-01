using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CountryResearchRequest
    {
        public int RequestedUserId { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string RequestedCountryCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
