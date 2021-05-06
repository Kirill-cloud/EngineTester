using System;
using System.Threading.Tasks;

namespace EngineTester
{
    class Program
    {
        static Tester tester = new Tester();

        static void Main(string[] args)
        {
            StartTest();
            Console.ReadKey();
        }

        async static Task StartTest() 
        {
            await tester.StartTest();
        }
    }
}
