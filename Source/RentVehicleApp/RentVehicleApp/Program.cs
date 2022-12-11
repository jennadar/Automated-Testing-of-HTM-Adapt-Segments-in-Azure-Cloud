// See https://aka.ms/new-console-template for more information
using VehicleLib;

Console.WriteLine("-----------------------------------");
Console.WriteLine("Hello, welcome to RentVehicle App. ");
Console.WriteLine("-----------------------------------");

string vehicle_type = "";
bool isInputInvalid = true;
IVehicle v;
while (isInputInvalid)
{
    Console.WriteLine("Which vehicle would you like to rent? ");
    vehicle_type = Console.ReadLine();

    if ((vehicle_type == "car") | (vehicle_type == "motorbike"))
        isInputInvalid = false;
}

if (vehicle_type == "car")
    v = new Car();
else
    v = new Motorbike();

Console.WriteLine("How much fuel would you need? (Litre)");
string str_fuel = Console.ReadLine();
int fuel = Convert.ToInt32(str_fuel);
v.setFuel(fuel);

Console.WriteLine("-----------------------------------");
Console.WriteLine($"Your vehicle choice: {vehicle_type}");
Console.WriteLine($"Vehicle Fuel : {v.getFuel()} Litre");
Console.WriteLine($"Vehicle Mileage : {v.getMileage()} km / L");
Console.WriteLine("-----------------------------------");

string str_dist = "";
int dist = 0, requiredFuel;
double requiredFuelDouble;
while (v.getFuel() > 0)
{
    Console.WriteLine("How far would you like to travel? (km) or type 0 to finish jouney");
    str_dist = Console.ReadLine();
    dist = Convert.ToInt32(str_dist);

    if (dist == 0)
        break;

    // calculate fuel comsumption
    requiredFuelDouble = calculateFuelConsumpsion(dist, v.getMileage());
    requiredFuel = Convert.ToInt32(requiredFuelDouble);

    if (requiredFuel > v.getFuel())
        Console.WriteLine($"Sorry you do not have enough fuel. You have only {v.getFuel()} Litre");
    else
    {
        v.useFuel(requiredFuel);
        Console.WriteLine($"You have travelled {dist}, you have {v.getFuel()} Litre left");
    }
}

Console.WriteLine("You have finished your journey!! Good Bye! ");
Console.ReadLine();

double calculateFuelConsumpsion(int distance, int mileage)
{
    return distance / mileage;
}