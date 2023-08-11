/*
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
Notice that the solution set must not contain duplicate triplets.

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.

*/

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) 
    {
        //We declare the list of lists that will contain our solution
            IList<IList<int>> result = new List<IList<int>>();

            //The edge case
            if (nums.Length <= 2) return result;
            
            /*For the first, we have to sort the nums*/
            Array.Sort(nums);

            /*Here we declare 3 indexes. This is how it works. 
            -4 -2 -3 -1 0 0 0 2 3 10 21
             s  l                     r 
             
             s - start index, l - left index, r - right index */
            int start = 0, left, right;

            /*The target is that the number we are looking for to be composed out of 2 numbers from our array.
            for example, if we have the startIndex at -4, we are looking for those two numbers in the given array
            which, summed up will be the oposite of -4, which is 4, cuz -4 + 4 = 0 (duh) */
            int target;

            /*The start goes from 0 to length-2 becuse look here
             -4 -2 -3 -1 0 0 0 2 3 10 21
                                 s  l  r      */
            while (start<nums.Length-2)
            {
                target = nums[start] * -1;
                left = start + 1;
                right = nums.Length - 1;

                /*Now, the start index is fixed and we move the left and right indexes to find those two number
                which summed up will be the oposite of nums[s]  */
                while (left < right)
                {
                    /*The array is sorted, so if we move to the left the right index, the sum will decrese */
                    if (nums[left] + nums[right] > target)
                    {
                        --right;
                    }

                    /*Here is the oposite, it the sum of nums[l] and nums[r] is less that what we are looking for,
                    then we move the left index, which means that the sum will increase due to the sorted array.
                    the left index will jump to a bigger value */
                    else if (nums[left] + nums[right] < target)
                    {
                        ++left;
                    }
                    /*If none of those are true, then it means that nums[l]+nums[r] = our desired value */
                    else
                    {
                        /*Here we create the solution and add it to the list of lists which contains the result. */
                        List<int> OneSolution = new List<int>() { nums[start], nums[left], nums[right] };
                        result.Add(OneSolution);

                        /*Now, in order to generate different solutions, we have to jump over
                        repetitive values in the array.  */
                        while (left < right && nums[left] == OneSolution[1])
                            ++left;
                        while (left < right && nums[right] == OneSolution[2])
                            --right;
                    }

                }
                /*Now we do the same thing to the start index. */
                int currentStartNumber = nums[start];
                while (start < nums.Length - 2 && nums[start] == currentStartNumber)
                    ++start;
            }
            return result;
    }
}
