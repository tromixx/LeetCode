using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int finalNumber = 25;
        int[] finalArray = Enumerable.Range(1,finalNumber).ToArray();

        foreach(int i in finalArray)
        {
            if(i%3==0 && i%5==0)
            {
                Console.WriteLine("FizzBuzz");
            }
            if(i%3==0)
            {
                Console.WriteLine("Fizz");
            }
            if(i%5==0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
        
    }
}