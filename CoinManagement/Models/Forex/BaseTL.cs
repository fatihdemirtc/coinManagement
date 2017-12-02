using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinManagement.Models.Forex
{
    public class BaseTL
    {
        public string date { get; set; }
        public string time { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value
    {
        public double oran { get; set; }
        public string type { get; set; }
        public string adi { get; set; }
        public string key { get; set; }
        public string alis { get; set; }
        public string satis { get; set; }
        public int upDown { get; set; }
    }
}
