namespace BadSample
{
    internal class Program
    {
        static List<string> names= new List<string>();
        static List<string> kinds = new List<string>();
        static List<int> legs = new List<int>();
        static List<int> wings = new List<int>();
        static List<int> sleepHours = new List<int>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the name of the animal");
                string name = Console.ReadLine()!;

                Console.WriteLine("Please enter the kind/type of the animal");
                string kind = Console.ReadLine()!;

                Console.WriteLine("Please enter the number of legs of the animal");
                int numLegs = 4;
                string numOffLegs = Console.ReadLine()!;
                int.TryParse(numOffLegs, out numLegs);

                names.Add(name);
                kinds.Add(kind);
                legs.Add(numLegs);

                if (kind == "bird")
                {
                    Console.WriteLine("Please enter the number of wings of the bird");
                    int numWings = 4;
                    string numOffwings = Console.ReadLine()!;
                    int.TryParse(numOffwings, out numWings);
                    wings.Add(numWings);
                }
                else
                    wings.Add(-1);

             
                Console.WriteLine("Please enter 'n' for next animal or 'e' for exit.");
                var userRes = Console.ReadLine()!;
                if (userRes == "e" || userRes == "exit")
                    break;              
            }

            printAnimals();
        }

        private void Sleep(int id, int numOfSleepingHours)
        {
            if (sleepHours.Count < id)
            {
                sleepHours[id] += numOfSleepingHours;
            }
            else
                throw new ArgumentException($"No animal with specified id = {id}");
        }
        private static void printAnimals()
        {
            Console.WriteLine("\r\n----------------------------------\r\n");

            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine($"Id: {i}");
                Console.WriteLine($"Name: {names[i]}");
                Console.WriteLine($"Kind: {kinds[i]}");
                Console.WriteLine($"Legs: {legs[i]}");
                Console.WriteLine();
            }
        }
    }
}