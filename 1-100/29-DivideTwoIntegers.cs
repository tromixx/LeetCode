/*
Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.

Return the quotient after dividing dividend by divisor.

Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than 231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.

 

Example 1:

Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = 3.33333.. which is truncated to 3.
Example 2:

Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = -2.33333.. which is truncated to -2.
 

Constraints:

-231 <= dividend, divisor <= 231 - 1
divisor != 0
*/
public class Solution {
    public int Divide(int dividend, int divisor) {
        // Handle edge cases for overflow
        if (dividend == int.MinValue && divisor == -1) {
            return int.MaxValue; // Overflow case
        }

        // Determine the sign of the result
        bool isNegative = (dividend < 0) ^ (divisor < 0);

        // Convert both numbers to their absolute values (use long to avoid overflow)
        long absDividend = Math.Abs((long)dividend);
        long absDivisor = Math.Abs((long)divisor);

        int result = 0;

        // Perform subtraction-based division using bit shifts
        while (absDividend >= absDivisor) {
            long tempDivisor = absDivisor;
            int multiple = 1;

            // Use bit shifts to find the largest multiple of the divisor that fits
            while (absDividend >= (tempDivisor << 1)) {
                tempDivisor <<= 1;
                multiple <<= 1;
            }

            // Subtract the found multiple and add it to the result
            absDividend -= tempDivisor;
            result += multiple;
        }

        // Apply the sign to the result
        return isNegative ? -result : result;
    }
}

