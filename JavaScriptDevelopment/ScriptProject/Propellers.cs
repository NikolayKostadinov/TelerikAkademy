namespace SimulateVehicles
{
    class Propellers: PropulsionUnit
    {
        private int numberOfFins = 0;
        public SpinDirections SpinDirection = SpinDirections.Clockwise;

        public double Acceleration
        {
            get
            {
                if (this.SpinDirection == SpinDirections.CounterClockwise)
                {
                    return -this.numberOfFins;
                }
                return this.numberOfFins;
            }
        }

        public Propellers(int numberOfFins, SpinDirections spinDirection)
        {
            this.numberOfFins = numberOfFins;
            this.SpinDirection = spinDirection;
        }
    }

    public enum SpinDirections
    {
        Clockwise,
        CounterClockwise
    }
}
