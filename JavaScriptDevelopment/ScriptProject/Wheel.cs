using System;

namespace SimulateVehicles
{
    class Wheel: PropulsionUnit
    {
        private int radius = 0;

        public double Acceleration
        {
            get
            {
                return (2 * Math.PI * this.radius);
            }
        }

        public Wheel(int radius)
        {
            this.radius = radius;
        }
    }
}
