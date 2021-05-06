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
        //double ModalTime = 0.5; //время в секундах ме
        public async Task<double> StartTest(IEngine engine) 
        {

            double time = 0;
            engine.Start(); 

            while (Test(engine))
            {
                time+=0.5;
                await Task.Delay(1);
                Console.WriteLine("Температура двигателя на "+time +"c : "+engine.Temperature);
            }
            engine.Stop();
            return time;
        }
    }
}
