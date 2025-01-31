public class Solution 
{
    public int LongestValidParentheses(string s) 
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(-1); // Base case for calculating length
        int maxLength = 0;

        for (int i = 0; i < s.Length; i++) 
        {
            if (s[i] == '(') 
            {
                stack.Push(i);
            } 
            else 
            {
                stack.Pop();
                if (stack.Count > 0)
                {
                    maxLength = Math.Max(maxLength, i - stack.Peek());
                }
                else 
                {
                    stack.Push(i);
                }
            }
        }
        return maxLength;
    }
}
