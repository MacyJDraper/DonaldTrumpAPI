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
            string quote = JObject.Parse(jsonString).GetValue("message").ToString();

            Console.WriteLine("\nTrum quote:");

            int maxCharacterCount = Console.WindowWidth;
            string[] quoteWords = quote.Split(' ');
            string currentLine = "";

            foreach (string word in quoteWords)
            {
                if ((currentLine + word).Length >= maxCharacterCount) 
                {
                    Console.WriteLine(currentLine);
                    currentLine = word;
                }
                else
                {
                    if (currentLine.Length == 0)
                        currentLine = word;
                    else
                        currentLine += " " + word;
                }
            }
            Console.WriteLine(currentLine);
        }
    }
}
