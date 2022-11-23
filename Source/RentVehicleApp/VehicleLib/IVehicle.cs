namespace VehicleLib
{
    public interface IVehicle
    {
        public int getMileage();
        public int getFuel();
        public void setFuel(int f);
        public void useFuel(int f);
        public void createWheels(int w);

    }
}