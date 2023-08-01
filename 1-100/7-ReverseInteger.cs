/*
Given a signed 32-bit integer x, return x with its digits reversed. 
If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:
Input: x = 123
Output: 321
*/
public class Solution 
{
    public int Reverse(int x)
    {
        var result = 0;

        while (x != 0)
        {
            var remainder = x % 10;
            var temp = result * 10 + remainder;

            // in case of overflow, the current value will not be equal to the previous one
            if ((temp - remainder) / 10 != result)
            {
                return 0;
            }

            result = temp;
            x /= 10;
        }
        
        return result;
    }
}