/*
Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.

Return the sum of the three integers.

You may assume that each input would have exactly one solution.


Example 1:

Input: nums = [-1,2,1,-4], target = 1
Output: 2
Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
*/

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
       int n=nums.Length;
       int minAns=int.MaxValue;
       int result=0;
       Array.Sort(nums);
       for(int i=0;i<n-2;i++)
       {
           int left=i+1;
           int right=n-1;
           while(left<right)
           {
               int values=nums[i]+nums[left]+nums[right];
               int diffOfValAndTarget=Math.Abs(values-target);
               if(minAns>diffOfValAndTarget)
                  {
                      result=values;
                      minAns=diffOfValAndTarget;
                  }
              if(values>target)
               right--;
               else
               left++;
            }
       }
       return result;
    }
}