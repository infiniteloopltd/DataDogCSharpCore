using System;
using System.IO;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DataDog
{
    class Program
    {
        static void Main(string[] args)
        {
            

            const string key = "f15d23159b008e325e2cf65a04502c05";
            var url = "https://api.datadoghq.eu/api/v1/events?api_key=" + key; // EU api endpoint
            var oReq = new
            {
                text= "This is the event body",
                title = "This is the event title"
            };
            var strReq = JsonConvert.SerializeObject(oReq);
            var wc = new WebClient();
            
            
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
