using System.Collections.Generic;

namespace SimulateVehicles
{
    class AirVehicle: Vehicle
    {
        public AirVehicle(int speed, PropulsionUnit[] propulsionUnits)
            : base(speed, propulsionUnits)
        {
        }

        public void SwitchAfterburners()
        {
            for (int i = 0; i < this.PropulsionUnits.Length; i++)
            {
                var pu = this.PropulsionUnits[i] as PropellingNozzles;
                if (pu != null)
                {
                    pu.AfterburnerSwitch = !pu.AfterburnerSwitch;
                }
            }
        }
    }
}
