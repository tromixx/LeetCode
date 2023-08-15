/*
Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

0 <= a, b, c, d < n
a, b, c, and d are distinct.
nums[a] + nums[b] + nums[c] + nums[d] == target
You may return the answer in any order.

 

Example 1:

Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]

*/

public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        IList<IList<int>> answer = new List<IList<int>>();
        for (int start = 0; start < nums.Length - 3; start++)
        {
            for (int start2 = start + 1; start2 < nums.Length - 2; start2++)
            {
                int left = start2 + 1;
                int right = nums.Length - 1;

                while (right > left)
                {
                    long sum = (long)nums[left] + (long)nums[right] + (long)nums[start2] + (long)nums[start];
                    if (sum == target)
                    {
                        answer.Add(new List<int>() { nums[left], nums[right], nums[start2], nums[start] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (right > left && nums[right] == nums[right - 1]) right--;
                        while (start < nums.Length - 1 && nums[start] == nums[start + 1]) start++;
                        while (start2 < nums.Length - 1 && nums[start2] == nums[start2 + 1]) start2++;
                        right--;
                        left++;
                    }
                    else if (sum > target)
                    {
                        right--;
                    }
                    else
                    {
                        left++;
                    }
                }
            }
        }
        return answer;
    }
}