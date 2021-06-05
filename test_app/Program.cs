using System;
using System.Web;
using System.Text.Encodings.Web;

namespace test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("%D0%9B%D0%A0%E2%84%96");
            Console.WriteLine(Uri.EscapeDataString("ЛР№"));
            Console.WriteLine(System.Web.HttpUtility.UrlEncode("ЛР№"));
            Console.ReadKey();
            ;
        }
    }
}
