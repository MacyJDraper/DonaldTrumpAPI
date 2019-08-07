using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace DonaldTrumpAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Trump quote...");
            string url = "https://api.whatdoestrumpthink.com/api/v1/quotes/random";
            HttpClient client = new HttpClient();
            string jsonString = client.GetStringAsync(url).Result;
            Console.WriteLine("\nJson Response from API:");
            Console.WriteLine(jsonString);
            string quote = JObject.Parse(jsonString).GetValue("message").ToString();
            Console.WriteLine("\nOnly the Trum quote:");
            Console.WriteLine(quote);
        }
    }
}
