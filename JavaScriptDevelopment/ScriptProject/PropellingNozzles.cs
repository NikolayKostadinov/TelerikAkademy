namespace SimulateVehicles
{
    class PropellingNozzles: PropulsionUnit
    {
        private int power = 0;
        public bool AfterburnerSwitch = false;

        public double Acceleration
        {
            get
            {
                if (this.AfterburnerSwitch)
                {
                    return this.power*2;
                }
                return this.power;
            }
        }

        public PropellingNozzles(int power, bool afterburnerSwitch)
        {
            this.power = power;
            this.AfterburnerSwitch = afterburnerSwitch;
        }
    }
}
