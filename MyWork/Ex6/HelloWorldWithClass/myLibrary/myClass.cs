namespace myLibrary
{
    public class myClass
    {
        public double sum(double[] inputs)
        {
            int arr_size = inputs.Length;
            double output = 0;

            for (int i = 0; i < arr_size; i++) 
            {
                output  += inputs[i];
            }
        return output;

        }
    }
}