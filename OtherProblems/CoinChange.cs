/*
Problem: Given a list of available coin denominations and an amount, find the minimum number of coins needed to make the change.

Example:

Coins: [1, 5, 10, 25] (representing cents)

Amount: 30

Output: 2 (one 25 cent coin + one 5 cent coin)
*/

using System;

class CoinChange
{
    public static int GetMinimumCoins(int[] coins, int amount)
    {
        // Initialize the dp array with a value greater than any possible result
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        // Dynamic Programming - Bottom-Up Approach
        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (i >= coin)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        // If the amount is not achievable, return -1
        return dp[amount] > amount ? -1 : dp[amount];
    }

    static void Main(string[] args)
    {
        int[] coins = { 1, 5, 10, 25 };
        int amount = 30;

        int result = GetMinimumCoins(coins, amount);

        Console.WriteLine(result == -1 
            ? "Change cannot be made with the given coins." 
            : $"Minimum coins needed: {result}");
    }
}

/*
Optimal Approach: Dynamic Programming (DP)
Use a DP array where each index represents the minimum number of coins needed to achieve that amount.

The formula:

csharp
Copy
Edit
dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
This ensures that for each coin, you check if using it minimizes the number of coins for the current amount.


*/