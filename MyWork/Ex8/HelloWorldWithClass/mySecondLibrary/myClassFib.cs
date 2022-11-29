namespace mySecondLibrary
{
    public class myClassFib
    {
        public int fibonacci(int inputs)
        {
            int n1 = 0, n2 = 1, n3, i;
            int output=0;
            if (inputs == 0) return 0; //It will return the first number of the series
            if (inputs == 1) return 1; // it will return  the second number of the series
            for (i = 2; i < inputs; i++)
            {
                n3 = n1 + n2;
                Console.Write(n3 + " ");
                n1 = n2;
                n2 = n3;
            }
            return output;

        }
    }
}