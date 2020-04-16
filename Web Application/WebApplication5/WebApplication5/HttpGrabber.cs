using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5
{
    public class HttpGrabber
    {
        public static async Task<double> KursEuro()
        {
            string BaseAddress = "http://api.nbp.pl/api/exchangerates/rates/a/eur/?format=json";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(BaseAddress))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        var dataObj = JObject.Parse(data);
                        Waluta waluta = new Waluta(kurs: $"{dataObj["rates"]}");
                        string JsonString = waluta.Kurs.ToString();
                        JsonString = JsonString.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                        var dataObj2 = JObject.Parse(JsonString);
                        Waluta waluta2 = new Waluta(kurs: $"{dataObj2["mid"]}");
                        double wartosc = Convert.ToDouble(waluta2.Kurs);
                        return wartosc;
                    }
                }
            }
        }
    }
}