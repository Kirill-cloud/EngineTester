using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    public class SpeedNotDefinedExeption : Exception
    {
        new public string Message { get; set; }
        public SpeedNotDefinedExeption(double leftBorder, double rightBorder, double exactValue)
        {
            Message = String.Format("Значение должно находиться в пределах ({0};{1}) , значение : {2}", leftBorder, rightBorder, exactValue);
        }
    }
}
