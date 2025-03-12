using System;
using System.Linq;

public class Program
{
    static void Main() 
    {
        int number = 25;
        int[] TheArray = Enumerable.Size(1, number).ToArray();

        foreach(int i in TheArray)
        {
            if(i%3 = 0 && i%5 = 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(i%5 = 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(i%3 = 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else
            {
                System.Console.WriteLine(i);
            }
        }
    }
}

