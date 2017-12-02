using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoinManagement.Models;
using CoinManagement.Models.Cex;
using CoinManagement.Models.Forex;
using CoinManagement.Models.Koineks;
using CoinManagement.Services;
using CoinManagement.Services.Cex;
using CoinManagement.Services.Koineks;
using Newtonsoft.Json;

namespace CoinManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            GetterCex gc=new GetterCex();
            GetterKoineks gk=new GetterKoineks();
            USDInfo a=gc.getCoinUSD();
            var b=gk.getKoineksData();
            decimal usd2Tl = Convert.ToDecimal(ForexService.getForex(), new CultureInfo("en-US"));
            List<PriceComparison> comparisons = new List<PriceComparison>();
            foreach (Currency currency in a.data)
            {
                if(currency.symbol1=="ZEC" || currency.symbol1 == "BCH") continue;
                PriceComparison comparison = new PriceComparison
                {
                    Currency = currency.symbol1,
                    Ask = Convert.ToDecimal(currency.lprice, new CultureInfo("en-US")),
                    Exchange = "CEX"
                };
                comparisons.Add(comparison);
            }

            comparisons.Add(new PriceComparison
            {
                Currency = b.BTC.short_code,
                Ask = Convert.ToDecimal(b.BTC.ask, new CultureInfo("en-US")) / usd2Tl,
                Bid = Convert.ToDecimal(b.BTC.bid, new CultureInfo("en-US")) / usd2Tl,
                Disparity = decimal.Parse(b.BTC.bidUSD, new NumberFormatInfo() { NumberDecimalSeparator = "," })  - Convert.ToDecimal(a.data.Where(x => x.symbol1 == "BTC").Select(x => x.lprice).FirstOrDefault(), new CultureInfo("en-US")),
                Exchange = "Koineks"
            });

            comparisons.Add(new PriceComparison
            {
                Currency = b.ETH.short_code,
                Ask = Convert.ToDecimal(b.ETH.ask, new CultureInfo("en-US")) / usd2Tl,
                Bid = Convert.ToDecimal(b.ETH.bid, new CultureInfo("en-US")) / usd2Tl,
                Disparity = decimal.Parse(b.ETH.bidUSD, new NumberFormatInfo() { NumberDecimalSeparator = "," }) - Convert.ToDecimal(a.data.Where(x => x.symbol1 == "ETH").Select(x => x.lprice).FirstOrDefault(), new CultureInfo("en-US")),
                Exchange = "Koineks"
            });

            comparisons.Add(new PriceComparison
            {
                Currency = b.DASH.short_code,
                Ask = Convert.ToDecimal(b.DASH.ask, new CultureInfo("en-US"))/ usd2Tl,
                Bid = Convert.ToDecimal(b.DASH.bid, new CultureInfo("en-US"))/ usd2Tl,
                Disparity = decimal.Parse(b.DASH.bidUSD, new NumberFormatInfo() { NumberDecimalSeparator = "," }) - Convert.ToDecimal(a.data.Where(x => x.symbol1 == "DASH").Select(x => x.lprice).FirstOrDefault(), new CultureInfo("en-US")),
                Exchange = "Koineks"
            });


            return View(comparisons);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GetResponse(Uri uri, Action<Market> callback)
        {
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += (o, a) =>
            {
                if (callback != null)
                {
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Market));
                    callback(ser.ReadObject(a.Result) as Market);
                }
            };
            wc.OpenReadAsync(uri);
        }
    }
}
