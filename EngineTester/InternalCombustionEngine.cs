using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineTester
{
    class InternalCombustionEngine : IEngine
    {
        public double Temperature { get; private set; }
        public double MaxTemperature { get; }

        public InternalCombustionEngine(double startTemp, double engineMaxTemp)
        {
            MaxTemperature = engineMaxTemp;

            Temperature = startTemp;
            EnvTempetature = startTemp;
        }

        bool isStoped = false;

        public async Task<bool> Start()
        {
            isStoped = false;
            while (!isStoped)
            {
                Heat();
                Cool();

                IncreaseSpeed();

                await Task.Delay(1);
            }
            return true;
        }

        public bool Stop()
        {
            isStoped = true;
            return true;
        }


        #region Физическое поведение двигателя

        void Heat() { Temperature += ModalTime * MbyV(Speed) * Hm + Speed * Speed * Hv; }
        void Cool() { Temperature += ModalTime * C * (EnvTempetature - Temperature); }

        double EnvTempetature;

        double ModalTime =  PhysicsSettings.ModalTime;
        double Speed =      PhysicsSettings.Speed;
        double I =          PhysicsSettings.I;
        double Hm =         PhysicsSettings.Hm;
        double Hv =         PhysicsSettings.Hv;
        double C =          PhysicsSettings.C;
        double[] M =        PhysicsSettings.M;
        double[] V =        PhysicsSettings.V;
         
        double MbyV(double v)
        {
            if (v < V[0])
            {
                throw new SpeedNotDefinedExeption(V[0], V.Last(), v);
            }

            if (v > V.Last())
            {
                return M.Last();
            }

            int i = -1;
            foreach (var item in V)
            {
                if (v >= item)
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            double m = GetYWithFunction(V[i], V[i + 1], M[i], M[i + 1], v);
            return m;
        }

        double GetYWithFunction(double x1, double x2, double y1, double y2, double x)
        {
            return (x - x1) * (y2 - y1) / (x2 - x1) + y1;
        }

        double a(double M)
        {
            return M / I;
        }
        void IncreaseSpeed()
        {
            Speed += a(MbyV(Speed)) * ModalTime;
        }
        #endregion
    }
}
