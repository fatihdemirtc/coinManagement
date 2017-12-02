using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinManagement.Models
{
    public class MarketModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Market> result { get; set; }
    }
    public class Market
    {
        public string MarketCurrency { get; set; }
        public string BaseCurrency { get; set; }
        public string MarketCurrencyLong { get; set; }
        public string BaseCurrencyLong { get; set; }
        public double MinTradeSize { get; set; }
        public string MarketName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public object Notice { get; set; }
        public object IsSponsored { get; set; }
        public string LogoUrl { get; set; }
    }
}
