﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEvent
{
    class Car
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        public delegate void CarEngineHandler(object sender, CarEventArgs e);
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        private CarEngineHandler listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        public void Accelerat(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded?.Invoke(this, new CarEventArgs("Sorry? this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                if(10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
