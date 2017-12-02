using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoinManagement.Models.Forex;
using Newtonsoft.Json;

namespace CoinManagement.Services
{
    public static class ForexService
    {
        public static string getForex()
        {
            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create("https://api.doviz.com/list/C");
            request3.Headers.Add("ContentType", "application/xml");
            request3.Method = WebRequestMethods.Http.Get;
            request3.AllowAutoRedirect = true;
            request3.Proxy = null;
            HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
            Stream stream3 = response3.GetResponseStream();
            StreamReader streamreader3 = new StreamReader(stream3);
            string jsonResponse3 = streamreader3.ReadToEnd();
            BaseTL mm3 = JsonConvert.DeserializeObject<BaseTL>(jsonResponse3);
            return mm3.value.Where(x => x.key == "USD").Select(x => x.satis).FirstOrDefault();
        }
    }
}
