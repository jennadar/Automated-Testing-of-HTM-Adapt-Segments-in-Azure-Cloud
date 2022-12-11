namespace VehicleLib
{
    public class Car : IVehicle
    {
        #region properties
        private int fuel; // Litre
        private const int mileage = 10; // Km/Litre
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
