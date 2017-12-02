using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoinManagement.Models.Koineks;
using Newtonsoft.Json;

namespace CoinManagement.Services.Koineks
{
    public class GetterKoineks
    {
        public TLValues getKoineksData()
        {
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("https://koineks.com/ticker");
            request2.Headers.Add("ContentType", "application/xml");
            request2.Method = WebRequestMethods.Http.Get;
            request2.AllowAutoRedirect = true;
            request2.Proxy = null;
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            Stream stream2 = response2.GetResponseStream();
            StreamReader streamreader2 = new StreamReader(stream2);
            string jsonResponse2 = streamreader2.ReadToEnd();
            TLValues mm2 = JsonConvert.DeserializeObject<TLValues>(jsonResponse2);
            decimal usd2Tl = Convert.ToDecimal(ForexService.getForex(), new CultureInfo("en-US"));
            mm2.BTC.bidUSD = (Convert.ToDecimal(mm2.BTC.bid, new CultureInfo("en-US")) / usd2Tl).ToString();
            mm2.ETH.bidUSD = (Convert.ToDecimal(mm2.ETH.bid, new CultureInfo("en-US")) / usd2Tl).ToString();
            mm2.DASH.bidUSD = (Convert.ToDecimal(mm2.DASH.bid, new CultureInfo("en-US"))/ usd2Tl).ToString();

            return mm2;


            //switch (coin)
            //{
            //    case "btc":
            //        usdValue=Convert.ToDecimal(mm2.BTC.bid, new CultureInfo("en-US")) / Convert.ToDecimal(usd2tl, new CultureInfo("en-US"));  
            //        break;
            //    case "eth":
            //        usdValue = Convert.ToDecimal(mm2.ETH.bid, new CultureInfo("en-US")) / Convert.ToDecimal(usd2tl, new CultureInfo("en-US"));
            //        break;
            //    case "dash":
            //        usdValue = Convert.ToDecimal(mm2.DASH.bid, new CultureInfo("en-US")) / Convert.ToDecimal(usd2tl, new CultureInfo("en-US"));
            //        break;
            //}



        }
    }
}

