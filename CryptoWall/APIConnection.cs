using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace CryptoWall
{
    class LunarCrush
    {
        public HttpClient client { get; set; }

        public LunarCrush()
        {
            client = new HttpClient();
        }

        public async Task<string> Connect()
        {
            string res =
                    await client.GetStringAsync(
                        "https://api.lunarcrush.com/v2?data=meta&key=0yhms1bivd391vg0g7klyb1&type=price");
                        return res;
        }

        public Root transfert (string json){
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }
        
        public class Datum
        {
            public string name { get; set; }
            public string symbol { get; set; }
            public double? price { get; set; }
            public double? price_btc { get; set; }
            public object market_cap { get; set; }
        }

        public class Root
        {
            public List<Datum> data { get; set; }
        }





    }    
    
    
}   

