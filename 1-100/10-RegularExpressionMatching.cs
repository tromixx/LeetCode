/*
Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).



Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".


*/


public class Solution {
    public bool IsMatch(string s, string p) {
        int pi = 0;
        return IsMatchHelper(s, p, s.Length-1, p.Length-1);
    }

    private bool IsMatchHelper(string s, string p, int si, int pi){
        if(si < 0){
            while(pi >= 0 && p[pi] == '*'){
                pi -= 2;
            }

            return pi < 0;
        }

        if(pi < 0){
            return false;
        }
        
        if(s[si] == p[pi] || p[pi] == '.'){
            return IsMatchHelper(s, p, si-1, pi-1);
        }

        if(p[pi] != '*'){
            return false;
        }

        while(pi >= 0 && p[pi] == '*'){
            pi--;
        }

        if(pi < 0)
            return false;

        while(si >= 0 && (s[si] == p[pi] || p[pi] == '.')){
            if(IsMatchHelper(s, p, si, pi-1)){
                return true;
            }

            si--;
        }
        
        return IsMatchHelper(s, p, si, pi-1);
    }
}

//Other solution
/*
The code uses a 2D dynamic programming approach to solve this problem. It creates a 2D array of boolean values, dp, where dp[i,j] represents if the substrings s[0...j-1] and p[0...i-1] match or not.

The code then loops through the entire dp array and fills in the values in a bottom-up manner. The rules for filling in the values are:

If i=0 and j=0, the first cell is set to true as the two empty substrings match.
If i=0, the first row is set to false as there is no string to match the pattern.
If j=0, the first column is set based on the current pattern character:
If the current pattern character is not '*', the value is set to false.
If the current pattern character is '*', the value is set to what's two cells above it in the same column.
For all other cells, the value is set based on the current pattern character and the current string character:
If the current pattern character is '', the value is set to the value two cells above it in the same column, or the value one cell to the left if the character before the '' is a '.' or matches the current string character.
If the current pattern character is '.', the value is set to the value on the diagonal.
If the current pattern character matches the current string character, the value is set to the value on the diagonal.
If the current pattern character doesn't match the current string character, the value is set to false.
Finally, the code returns the value in the bottom right cell of the dp array, which represents if the entire string s matches the pattern p.

Time complexity:
O(m∗n)

Space complexity:
O(m∗n)


*/



public class Solution {
    public bool IsMatch(string s, string p)
    {
        bool[,] dp = new bool[p.Length + 1,s.Length + 1];

        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                if(i==0 && j == 0)
                {
                    //first corner cell
                    dp[i,j] = true;
                } else if (i == 0)
                {
                    //first row
                    dp[i, j] = false;
                } else if (j == 0)
                {
                    //first column
                    //if there is no star then false else look two up
                    char pc = p[i - 1];
                    if(pc == '*')
                    {
                        //look up two rows
                        dp[i, j] = dp[i - 2, j];
                    }
                    else
                    {
                        dp[i, j] = false;
                    }
                }
                else
                {
                    //everything else
                    char pc = p[i-1];
                    char sc = s[j-1];

                    if (pc == '*')
                    {
                        //we have to look what is there two up
                        dp[i,j] = dp[i - 2, j];

                        // // now we look to the left either we have a dot or pc == sc
                        var pslc = p[i-2];
                        if(pslc == '.' || pslc == sc){
                            dp[i,j]=dp[i,j]||dp[i,j-1];
                        }
                    } else if (pc == '.')
                    {
                        //if equal we look at what is there on the diagonal
                        dp[i, j] = dp[i - 1, j - 1];

                    } else if (pc == sc)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    } else
                    {
                        dp[i, j] = false;
                    }


                }
            }
        }

        return dp[p.Length,s.Length];
    }
}