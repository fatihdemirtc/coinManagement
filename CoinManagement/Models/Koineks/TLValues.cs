using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinManagement.Models.Koineks
{
    public class TLValues
    {
        public BTC BTC { get; set; }
        public ETH ETH { get; set; }
        public LTC LTC { get; set; }
        public DASH DASH { get; set; }
        public DOGE DOGE { get; set; }
    }

    public class BTC
    {
        public string short_code { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string current { get; set; }
        public string change_amount { get; set; }
        public string change_percentage { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public double volume { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string bidUSD { get; set; }
        public string timestamp { get; set; }
    }

    public class ETH
    {
        public string short_code { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string current { get; set; }
        public string change_amount { get; set; }
        public string change_percentage { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public double volume { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string bidUSD { get; set; }
        public string timestamp { get; set; }
    }

    public class LTC
    {
        public string short_code { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string current { get; set; }
        public string change_amount { get; set; }
        public string change_percentage { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public double volume { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string bidUSD { get; set; }
        public string timestamp { get; set; }
    }

    public class DASH
    {
        public string short_code { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string current { get; set; }
        public string change_amount { get; set; }
        public string change_percentage { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public double volume { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string bidUSD { get; set; }
        public string timestamp { get; set; }
    }

    public class DOGE
    {
        public string short_code { get; set; }
        public string name { get; set; }
        public string currency { get; set; }
        public string current { get; set; }
        public string change_amount { get; set; }
        public string change_percentage { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public double volume { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string bidTL { get; set; }
        public string timestamp { get; set; }
    }
}
