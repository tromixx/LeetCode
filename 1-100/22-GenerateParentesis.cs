/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

 

Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]
Example 2:

Input: n = 1
Output: ["()"]
 

Constraints:

1 <= n <= 8
*/

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        IList<string> res = new List<string>();
         helper(res,"(",1,0,n);
        return res;
    }
    public void helper(IList<string> res,string curr,int open,int close,int n)
    {
        if(curr.Length==2*n)
        {
            res.Add(curr);
            return;
        }
        if(open<n)
        {
           helper(res,curr+"(",open+1,close,n);
        }
        if(close<open)
        {
            helper(res,curr+")",open,close+1,n);
        }
    }
}