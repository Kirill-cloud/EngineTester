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
        IEngine engine = new InternalCombustionEngine(20,110);
        public async Task<double> StartTest() 
        {
            return await behavior.StartTest(engine);
        }
    }
}
