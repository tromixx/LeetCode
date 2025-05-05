public class Solution {
    public void MoveZeroes(int[] nums) {
        int k = 0; // Slow pointer for non-zero elements
        
        for (int i = 0; i < nums.Length; i++) 
        {
            if (nums[i] != 0) {
                // Swap nums[i] and nums[k]
                int temp = nums[k];
                nums[k] = nums[i];
                nums[i] = temp;
                k++;
            }
        }
    }
}