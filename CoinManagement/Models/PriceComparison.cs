using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinManagement.Models
{
    public class PriceComparison
    {
        public string Currency { get; set; }
        public string Exchange { get; set; }
        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
        public decimal Disparity { get; set; }
    }
}
