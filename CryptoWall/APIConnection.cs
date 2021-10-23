using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace CryptoWall
{
    class LunarCrush
    {
        //GET request to website
        public HttpClient client { get; set; }
        public LunarCrush()
        {
            client = new HttpClient();
        }

        //specifies which API to connect to through the hhtps link (Lunarcrush)
        public async Task<string> Connect()
        {
            string res = await client.GetStringAsync("https://api.lunarcrush.com/v2?data=meta&key=ngpdegtqbakoto3idhlxbc&type=price");
            return res;
        }

        //Deserializes Root to json type
        public Root transfert(string json){
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            return myDeserializedClass;
        }

        //init the data for each cryptocurrency : name of the cryptocurrency, stock symbol, price, price compared to the bitcoin price, market capitalization
        //market cap: Market capitalization refers to the total dollar market value of a company's outstanding shares of stock
        public class CryptoData
        {
            public string name { get; set; }
            public string symbol { get; set; }
            public double? price { get; set; }
            public double? price_btc { get; set; }
            public object market_cap { get; set; }
        }

        //list of cryptocurrencies
        public class Root
        {
            public List<CryptoData> data { get; set; }
        }

    }    
     
}   

