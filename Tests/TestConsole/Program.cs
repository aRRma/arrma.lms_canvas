using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string url =
                @"https://lms.misis.ru/api/v1/courses/11527/search_users?per_page=50&access_token=ViNkcfTAwujXMDGHKu3N6Ag0TxYgdi6tQBdezEVBM6WReA7HECDP9h04IIjmGc9o";
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync(url);
            foreach (var item in result.Headers.Where(x => x.Key == "Link"))
            {
                var link = item.Value.FirstOrDefault();
                var links = link.Split(',');
                foreach (var linksItem in links)
                {
                    var relMatch = Regex.Match(linksItem, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                    if (relMatch.Value == "last")
                    {
                        var per_page = Regex.Match(linksItem, "(?<=per_page=).+?(?=>)", RegexOptions.IgnoreCase);
                        var pages = Regex.Match(linksItem, "(?<=page=).+?(?=&)", RegexOptions.IgnoreCase);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
