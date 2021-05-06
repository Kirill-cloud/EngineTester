using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    interface IEngine : ITemperaturable
    {
        public Task<bool> Start();
        public bool Stop();
    }
}
