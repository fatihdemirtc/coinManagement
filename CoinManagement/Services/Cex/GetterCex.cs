using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoinManagement.Models.Cex;
using Newtonsoft.Json;

namespace CoinManagement.Services.Cex
{
    public class GetterCex
    {
        public USDInfo getCoinUSD()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cex.io/api/last_prices/USD/");
            request.Headers.Add("ContentType", "application/xml");
            request.Method = WebRequestMethods.Http.Get;
            request.AllowAutoRedirect = true;
            request.Proxy = null;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(stream);
            string jsonResponse = streamreader.ReadToEnd();
            USDInfo mm = JsonConvert.DeserializeObject<USDInfo>(jsonResponse);
            return mm;
        }
    }
}
