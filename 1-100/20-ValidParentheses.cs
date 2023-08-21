/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
*/

/*
Example 1:

Input: s = "()"
Output: true
Example 2:

Input: s = "()[]{}"
Output: true
*/

//First Solution incompleted

public class Solution {
    public bool IsValid(string s) {
        var p = s.Length;
        if(p%2 == 1)
        {
            return false;
        }
        while(p != 0)
        {
            if(s.[p-1] == ']' &&  s.[p-2] == '[')
            {
                if(p >= 2)
                {
                    p = p -2;
                    continue;
                }
                else
                {
                    return true;
                }  
            }
            else if(s.[p-1] == ')' &&  s.[p-2] == '(')
            {
                if(p >= 2)
                {
                    p = p -2;
                    continue;
                }
                else
                {
                    return true;
                }
            }
            else if(s.[p-1] == '}' &&  s.[p-2] == '{')
            {
                if(p >= 2)
                {
                    p = p -2;
                    continue;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}



//Second Solution

public class Solution 
{
    public bool IsValid(string s) 
    {
        var p = s.Length;
        if(p%2 == 1)
        {
            return false;
        }
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
        }

        return s.Length == 0;
    }
}
