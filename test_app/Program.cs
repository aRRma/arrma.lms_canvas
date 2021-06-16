using System;
using System.Linq;
using System.Web;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CanvasEFCoreDb;

namespace test_app
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var data = Enumerable.Range(0, 42);
            for (int i = 1; i < 5; i++)
            {
                string str = string.Join(' ', data.Skip(50 * (i - 1)).Take(50).ToArray());
                Console.WriteLine(str + "\n");
            }

            Console.ReadKey();
        }
    }
}
