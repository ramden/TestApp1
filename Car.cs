using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{
    public class Motor
    {
        bool ignitionStarted = false;
        int currentAccelleration = 0;

        private void drive()
        {
            Console.WriteLine("Driving");
        }

        private void turnOff()
        {
            Console.WriteLine("Turning off");
        }

        public void startIgnition()
        {
            Console.WriteLine("Ignition started");
            ignitionStarted = true;
        }

        public void accellerate(int accellerationStep)
        {
            if (!ignitionStarted)
            {
                Console.WriteLine("Cannot accellerate. You first have to activate ignition");
                return;
            }

            Console.WriteLine("Accelerating by " + accellerationStep);

            if (currentAccelleration == 0)
            {
                drive();
            }

            currentAccelleration += accellerationStep;
        }

        public void decellerate(int decellerationStep)
        {
            if (decellerationStep >= currentAccelleration)
            {
                Console.WriteLine("You reached 0 accelleration. The motor will now turn off");
                currentAccelleration = 0;
                ignitionStarted = false;
                turnOff();
                return;
            }

            Console.WriteLine("Decellerating by " + decellerationStep);
            currentAccelleration -= decellerationStep;
        }
    }

    public class Car
    {
        Motor motor;

        public Car(Motor motor)
        {
            this.motor = motor;
        }

        void startUp()
        {
            Console.WriteLine("[Car] Starting up car");
            motor.startIgnition();
        }

        void accellerate()
        {
            Console.WriteLine("[Car] Accellerating car");
            motor.accellerate(accellerationStep: 10);
        }

        void decellerate()
        {
            Console.WriteLine("[Car] Decellerating car");
            motor.decellerate(decellerationStep: 10);
        }
    }
}
