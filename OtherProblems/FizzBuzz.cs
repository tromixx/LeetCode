using System;
using System.Linq; // for Enumerable

public class Program
{
    static void Main() 
    {
        //int[] TheArray = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        int number = 25;
        int[] TheArray = Enumerable.Range(1,number).ToArray();
        
        foreach (int i in TheArray)
        {
            if(i%5 == 0 && i%3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if(i%3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if(i%5 == 0)
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