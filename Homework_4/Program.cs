namespace Homework_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of students");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter the mark from 0 to 10");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            double summark = 0;
            double midmark = 0;
            int maxmark = 0;
            int minmark = 10;
            int midlevel = 0;
            for (int i = 0; i < number; i++)
            {
                summark += array[i];
                if (array[i] > maxmark)
                {
                    maxmark = array[i];
                }
                if (array[i] < minmark)
                {
                    minmark = array[i];
                }
            }
            midmark = summark / number;
            for (int i = 0; i < number; i++)
            {
                if (array[i] > midmark)
                {
                    midlevel++;
                }
            }
            Console.WriteLine("Mid mark: " + midmark);
            Console.WriteLine("Max mark: " + maxmark);
            Console.WriteLine("Min mark: " + minmark);
            Console.WriteLine("Number of mid level students: " + midlevel);
        }
    }
}
