public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 0) return 0;
        if (nums.Length == 1) return nums[0];
        
        int prev2 = nums[0];                  // Represents dp[i-2]
        int prev1 = Math.Max(nums[0], nums[1]); // Represents dp[i-1]
        int current = prev1;
        
        for (int i = 2; i < nums.Length; i++) {
            current = Math.Max(nums[i] + prev2, prev1);
            prev2 = prev1;
            prev1 = current;
        }
        
        return current;
    }
}