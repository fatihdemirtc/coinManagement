using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinManagement.Models.Cex
{
    public class Currency
    {
        public string symbol1 { get; set; }
        public string symbol2 { get; set; }
        public string lprice { get; set; }
    }

    public class USDInfo
    {
        public string e { get; set; }
        public string ok { get; set; }
        public List<Currency> data { get; set; }
    }
}
