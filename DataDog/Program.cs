using System;
using System.IO;
using System.Net;

using Newtonsoft.Json;

namespace DataDog
{
    class Program
    {
        static void Main(string[] args)
        {
            var wc = new WebClient();
            var ip = wc.DownloadString("http://checkip.amazonaws.com");

            const string key = "f15d23159b008e325e2cf65a04502c05";
            var url = "https://api.datadoghq.eu/api/v1/events?api_key=" + key; // EU api endpoint
            var oReq = new
            {
                text= "IP:" + ip,
                title = "Some event happened."
            };
            var strReq = JsonConvert.SerializeObject(oReq);
            
            try
            {
                var response = wc.UploadString(url, strReq);
                Console.WriteLine(response);
            }
            catch (WebException wex)
            {
                var err = new StreamReader(wex.Response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(err);
            }
            
        }
    }
}
