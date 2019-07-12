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
            c1.AboutToBlow += C1_AboutToBlow;
            c1.Exploded += C1_Exploded;

            EventHandler<CarEventArgs> d = new EventHandler<CarEventArgs>(CarExploded);
            c1.Exploded += d;

            Console.WriteLine("****** Speeding up ******");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerat(20);
            }

            Console.WriteLine("**** Anonymous Method ******\n");
            int aboutToBlowCounter = 0;
            Car c2 = new Car("Car 2", 100, 10);
            c2.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };
            c2.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Message from Car: {0}", e.msg);
            };
            c2.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };
            for (int i = 0; i < 8; i++)
            {
                c2.Accelerat(20);
            }
            Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);
            #endregion          
        }

        private static void CarExploded(object sender, CarEventArgs e)
        {
            Console.WriteLine(string.Format($"{((Car)sender).PetName} {e.msg}"));
        }

        private static void C1_Exploded(object sender, CarEventArgs e)
        {
            Console.WriteLine(string.Format($"{((Car)sender).PetName} {e.msg}"));
        }

        private static void C1_AboutToBlow(object sender, CarEventArgs e)
        {
            Console.WriteLine(string.Format($"{((Car)sender).PetName} {e.msg}"));
        }
    }
}
