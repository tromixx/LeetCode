//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.

/*Example
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
*/

using System;
using System.Collections.Generic;

public class Solution 
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0) 
    {
        if(l1 == null && l2 == null && carry == 0) return null;

        int total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
        carry = total / 10;
        return new ListNode(total % 10,  AddTwoNumbers(l1?.next, l2?.next, carry));
    }
}