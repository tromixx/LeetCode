/*Given an integer array nums sorted 
in non-decreasing order, remove the duplicates in-place such 
that each unique element appears only once. 
The relative order of the elements should be kept the same. 
Then return the number of unique elements in nums.*/

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }
        int j = 0;
        for(int i = 1; i < nums.Length; i++)
        {
            if(nums[j] != nums[i])
            {
                nums[++j] = nums[i];
            }
        }

        return j + 1;
        
    }
}