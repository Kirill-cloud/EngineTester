using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    class TemperatureTestBehavior : ITestBehavior
    {
        public bool Test(IEngine engine)
        {
            return engine.Temperature < engine.MaxTemperature;
        }
        public async Task<double> StartTest(IEngine engine) 
        {
            double time = 0;
            engine.Start();
            while (Test(engine))
            {
                time++;
                await Task.Delay(1000);
                Console.WriteLine(time +" "+engine.Temperature);
            }
            engine.Stop();
            return time;
        }
    }
}
