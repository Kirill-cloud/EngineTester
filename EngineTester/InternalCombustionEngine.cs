using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    class InternalCombustionEngine : IEngine
    {
        public double Temperature { get; private set;}
        public double MaxTemperature { get => 110; }

        public InternalCombustionEngine(double StartTemp) 
        {
            Temperature = StartTemp;
        }

        bool isStoped = false;

        public async Task<bool> Start()
        {
            isStoped = false;
            while (!isStoped)
            {
                Temperature += 0.1;
                await Task.Delay(10);
            }
            return true;
        }

        public bool Stop()
        {
            isStoped = true;
            return true;
        }
    }
}
