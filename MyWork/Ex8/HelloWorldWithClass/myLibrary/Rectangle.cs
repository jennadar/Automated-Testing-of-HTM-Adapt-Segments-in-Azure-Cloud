namespace myLibrary
{
    class Rectangle : Area
    {
    
        public void Area(double h, double w)
        {
            Console.WriteLine("Rectangle Area: {0}", h * w);
        }
    }
}