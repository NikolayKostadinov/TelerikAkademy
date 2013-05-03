using System.Collections.Generic;

namespace SimulateVehicles
{
    class LandVehicle:Vehicle
    {
        public LandVehicle(int speed, int wheelRadius)
        {
            PropulsionUnit[] propulsionUnits = new PropulsionUnit[4];
            propulsionUnits[0] = new Wheel(wheelRadius);
            propulsionUnits[1] = new Wheel(wheelRadius);
            propulsionUnits[2] = new Wheel(wheelRadius);
            propulsionUnits[3] = new Wheel(wheelRadius);
            new Vehicle(speed, propulsionUnits);
        }
        public LandVehicle(int speed, PropulsionUnit[] propulsionUnits)
            : base(speed, propulsionUnits)
        {
            //add 4 
        }
    }
}
