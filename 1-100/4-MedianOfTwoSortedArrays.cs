//Time complexity: O(log(n+m))O(log(n+m))O(log(n+m))
//Space complexity: O(1)O(1)O(1)
/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
The overall run time complexity should be O(log (m+n)).
*/

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        List<int> nums = nums1.ToList();
        nums.AddRange(nums2.ToList());
        nums.Sort();
        if(nums.Count % 2 == 1){
            return nums[nums.Count/2];
        }
       
        return (nums[nums.Count/2] + nums[nums.Count/2 - 1])/2.0;
    }
}

