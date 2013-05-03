using System.Collections.Generic;

namespace SimulateVehicles
{
    public class Vehicle
    {
        private int speed = 1;
        public PropulsionUnit[] PropulsionUnits;

        public Vehicle()
        {
            
        }

        public Vehicle(int speed, PropulsionUnit[] propulsionUnits)
        {
            this.speed = 1;
            this.PropulsionUnits = propulsionUnits;
        }

        public void Accelerate(int acceleration)
        {
            speed = acceleration * PropulsionUnits.Length;
        }
    }
}
