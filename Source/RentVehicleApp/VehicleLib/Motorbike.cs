namespace VehicleLib
{
    public class Motorbike : IVehicle
    {
        #region properties
        private int fuel; // Litre
        private const int mileage = 25; // Km/Litre
        #endregion

        #region methods
        public int getFuel()
        {
            return fuel;
        }

        public void setFuel(int f)
        {
            fuel = f;
        }

        public void useFuel(int f)
        {
            fuel -= f;
        }

        public int getMileage()
        {
            return mileage;
        }
        #endregion
    }
}
