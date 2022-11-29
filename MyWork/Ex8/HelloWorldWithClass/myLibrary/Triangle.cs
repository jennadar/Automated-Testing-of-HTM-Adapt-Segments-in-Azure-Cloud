namespace myLibrary
{
    public class Triangle : Area
    {

        public void Area(double h, double w)
        {
            Console.WriteLine("Triangle Area: {0}", h * w / 2.0);
        }
    }
}