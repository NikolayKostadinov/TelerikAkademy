using System.Collections.Generic;

namespace SimulateVehicles
{
    class WaterVehicle:Vehicle
    {
        public WaterVehicle(int speed, PropulsionUnit[] propulsionUnits)
            : base(speed, propulsionUnits)
        {
        }

        public void ChangeSpinDirection()
        {
            for (int i = 0; i < this.PropulsionUnits.Length; i++)
            {
                var pu = this.PropulsionUnits[i] as Propellers;
                if (pu != null)
                {
                    switch (pu.SpinDirection)
                    {
                        case SpinDirections.Clockwise:
                            pu.SpinDirection = SpinDirections.CounterClockwise;
                            break;
                        default:
                            pu.SpinDirection = SpinDirections.Clockwise;
                            break;
                    }
                }
            }
        }
    }
}
