using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    interface ITemperaturable
    {
        public double Temperature { get; }
        public double MaxTemperature { get; }
    }
}
