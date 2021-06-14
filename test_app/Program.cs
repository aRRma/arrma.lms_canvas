using System;
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

            await new CanvasEFCore().UpdDbDataAsync();
            
            Console.ReadKey();
        }
    }
}
