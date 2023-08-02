/*
Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).

The algorithm for myAtoi(string s) is as follows:

Read in and ignore any leading whitespace.
Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
Return the integer as the final result.

*/

//Solution 1
public class Solution {
    public int MyAtoi(string s) {
        const int maxCmp = int.MaxValue / 10;
        var num = 0;
        var sign = 1;

        var idx = 0;
        while (idx < s.Length && s[idx] == ' ')
            idx++;

        if (idx < s.Length && (s[idx] == '+' || s[idx] == '-'))
            sign = s[idx++] == '-' ? -1 : 1;

        while (idx < s.Length && s[idx] > 47 && s[idx] < 58)
        {
            if (num > maxCmp || (num == maxCmp && (s[idx] - '0') > 7))
                return sign == -1 ? int.MinValue : int.MaxValue;
            num = num * 10 + (s[idx++] - '0');
        }

        return num * sign;
    }
}


//Solution 2
public class Solution {
    public int MyAtoi(string s) {
        string sTrim = s.Trim();
        string sClean = "";
        for(int i = 0; i < sTrim.Length; i++)
        {
            if(sTrim[i] == '-' ||sTrim[i] == '0' || sTrim[i] == '1' || sTrim[i]=='2' || sTrim[i]=='3' 
            || sTrim[i]=='4' || sTrim[i]=='5' || sTrim[i]=='6' || sTrim[i]=='7' || sTrim[i]=='8' || sTrim[i]=='9')
            {
                sClean = sClean + sTrim[i];
            }
            else
            {
                continue;
            }
        }
        long sFloat = Int32.Parse(sClean);
        
        if(sFloat > 4294967296)
        {
            return 2^32;
        }
        else if(sFloat < -4294967296)
        {
            return -2^32;
        }
        else{
            try{
                int sInt = Int32.Parse(sClean);
                return sInt;
            }
            catch{
                return -2^32;
            }
        }
             
    }
}