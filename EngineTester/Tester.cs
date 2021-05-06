using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    class Tester
    {
        ITestBehavior behavior = new TemperatureTestBehavior();
        IEngine engine;
        public async Task<double> StartTest() 
        {
            double envTemp;
            Console.WriteLine("Введите окружающую температуру");
            while(!double.TryParse(Console.ReadLine(), out envTemp)) 
            {
                Console.WriteLine("Не удалось распознать");
                Console.WriteLine("Введите окружающую температуру");
            }

            engine = new InternalCombustionEngine(envTemp, 110);
            
            return await behavior.StartTest(engine);
        }
    }
}
