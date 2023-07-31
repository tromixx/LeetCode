//Given a string s, return the longest palindromic substring in s.
/*
1.To search the Longest Palindromic Substring, traverses the string one time with For loop
2.For Every character try expanding both side (Left and right)with while loop until you get the palindrome.
3.Once found new palindrome with grater length, just override the previous palindrome in maxLengthStr variable.
4.first while loop is for searching Odd Palindrome Ex. "aba"
5.We will now search the Palindrome in case of even length Ex. "bb"
6.Both while loop has same code and that can be extracted in some other reusable function. For easy readability of code I have written like this.
7.At last return the maxLengthStr which would be containing Longest Palindromic Sub-string.
*/
public class Solution {
    public string LongestPalindrome(string s) {
        int maxLength = 1;
        var maxLengthStr = "";

        for (int i = 0; i < s.Length; i++)
        {
            //Odd Palindrom
            int L = i; int R = i;
            while(L >= 0 && R < s.Length && s[L]== s[R];)
            {
                if (R - L + 1 > maxLength)
                {
                    maxLength = R - L + 1;
                    maxLengthStr = s.Substring(L, R - L + 1);
                }
                L--;
                R++;
            }
        }
    }
}