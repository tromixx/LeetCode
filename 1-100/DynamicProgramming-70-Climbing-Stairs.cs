public class Solution 
{
    public int ClimbStairs(int n) 
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        
        int prev1 = 2; // Represents dp[n-1] (initially n=2)
        int prev2 = 1; // Represents dp[n-2] (initially n=1)
        int current = 0;
        
        for (int i = 3; i <= n; i++) {
            current = prev1 + prev2;
            prev2 = prev1;
            prev1 = current;
        }
        
        return current;
    }
}