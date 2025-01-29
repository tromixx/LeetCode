/*
31. Next Permutation
Medium
Topics
Companies
A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

For example, for arr = [1,2,3], the following are all the permutations of arr: [1,2,3], [1,3,2], [2, 1, 3], [2, 3, 1], [3,1,2], [3,2,1].
The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

For example, the next permutation of arr = [1,2,3] is [1,3,2].
Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
Given an array of integers nums, find the next permutation of nums.

The replacement must be in place and use only constant extra memory.

Example 1:

Input: nums = [1,2,3]
Output: [1,3,2]
Example 2:

Input: nums = [3,2,1]
Output: [1,2,3]
Example 3:

Input: nums = [1,1,5]
Output: [1,5,1]
 

Constraints:

1 <= nums.length <= 100
0 <= nums[i] <= 100
*/

/*
How to solve it:
Find the first decreasing element (pivot): Traverse the array from right to left to find the first index i such that nums[i] < nums[i + 1]. If no such index exists, the array is sorted in descending order, and we simply reverse it to get the lowest possible order.

Find the element to swap with the pivot: From right to left, find the smallest element that is greater than nums[i] and swap it with nums[i].

Reverse the suffix: Reverse the elements after index i to get the smallest lexicographical order.
*/
public class Solution 
{
    public void NextPermutation(int[] nums) 
    {
        int n = nums.Length;
        int i = n - 2;
        // Step 1: Find the first decreasing element
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }
        
        if (i >= 0) // if array is not in descending order
        {
            int j = n - 1;
            while (nums[j] <= nums[i])
            {
                j--;
            }
            Swap(nums, i, j);
        }

        Reverse(nums, i + 1, n - 1);
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    private void Reverse(int[] nums, int start, int end)
    {
        while (start < end)
        {
            Swap(nums, start, end);
            start++;
            end--;
        }
    }
}