using MyLib;
String selectInput = "";
int dimA = 0, dimB = 0, dimC = 0;
int volume = 0;
bool runningFlag = true;
var volumeCalculator = new MyVolumeCalculator();


while (runningFlag)
{
    Console.WriteLine("calculate volume section (0:Exit, 1:cube, 2:pyramid)");
    selectInput = Console.ReadLine();

    switch (selectInput)
    {
        case "0":
            runningFlag = false;

            break;

        case "1":

            Console.WriteLine("Dimension: ");
            dimA = Convert.ToInt32(Console.ReadLine());
            volume = volumeCalculator.calculateCubeVolume(dimA);

            Console.WriteLine($"The volume is {volume}");

            break;


        case "2":

            Console.WriteLine("Width: ");
            dimA = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Length: ");
            dimB = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Height: ");
            dimC = Convert.ToInt32(Console.ReadLine());

            volume = volumeCalculator.calculatePyramidVolume(dimA, dimB, dimC);

            Console.WriteLine($"The volume is {volume}");

            break;

        default:

            Console.WriteLine("Input is not correct, try again");

            break;


    }
    Console.WriteLine("Program has ended");
}