using System;
using System.Threading.Tasks;

namespace EngineTester
{
    class Program
    {
        static Tester tester = new Tester();

        static void Main(string[] args)
        {
            double x = StartTest().Result;
            Console.WriteLine("Двигатель перегрелся за {0} секунд",x);
            Console.ReadKey();
        }

        async static Task<double> StartTest() 
        {
            return await tester.StartTest();
        }
    }
}
