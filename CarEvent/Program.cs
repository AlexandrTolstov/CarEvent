using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Event handlers
            Console.WriteLine("****** Fun with Event ******\n");
            Car c1 = new Car("SlugBug", 100, 10);
            c1.AboutToBlow += new Car.CarEngineHandler(CarIsAlmostDoomed);
            c1.AboutToBlow += new Car.CarEngineHandler(CarAboutToBlow);

            Car.CarEngineHandler d = new Car.CarEngineHandler(CarExploded);
            c1.Exploded += d;

            Console.WriteLine("****** Speeding up ******");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerat(20);
            }
            c1.Exploded -= d;

            Console.WriteLine("\n****** Speeding up ******");
            for (int i = 0; i < 6; i++)
                c1.Accelerat(20);
            Console.ReadLine();
            #endregion

            
        }
        public static void CarAboutToBlow(string msg) { Console.WriteLine(msg); }
        public static void CarIsAlmostDoomed(string msg)
        { Console.WriteLine("=> Critical Message from Car: {0}", msg); }
        public static void CarExploded(string msg)
        { Console.WriteLine(msg); }
        public static void HookIntoEvents()
        {
            Car newCar = new Car();
            newCar.AboutToBlow += NewCar_AboutToBlow;
        }

        private static void NewCar_AboutToBlow(string msgForCaller)
        {
            throw new NotImplementedException();
        }
    }
}
