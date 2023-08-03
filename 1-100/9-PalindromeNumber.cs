//Given an integer x, return true if x is a palindrome, and false otherwise.
//Int to String to Int
public class Solution {
    public bool IsPalindrome(int x) {

        string reverseX = "";
        string stringX = x.ToString();

        for(int i = stringX.Length - 1; i > -1; i--)
        {
            if(stringX[i] == '-')
            {
                continue;
            }else
            {
                reverseX += stringX[i];
            }
        }
        long reverseInt = long.Parse(reverseX);
        if(reverseInt == x)
        {
            return true;
        }
        else
        return false;
    }
}