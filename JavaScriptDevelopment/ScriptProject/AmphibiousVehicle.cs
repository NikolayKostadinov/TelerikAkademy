namespace SimulateVehicles
{
    class AmphibiousVehicle
    {
        private bool isLand = false;

        public void SwitchMode()
        {
            this.isLand = !this.isLand;
        }
    }
}
