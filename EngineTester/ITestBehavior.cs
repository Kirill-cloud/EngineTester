using System.Threading.Tasks;

namespace EngineTester
{
    internal interface ITestBehavior
    {
        public Task<double> StartTest(IEngine engine);
    }
}