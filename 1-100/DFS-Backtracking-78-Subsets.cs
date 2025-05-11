/*
78. Subsets
Solved
Medium
Topics
Companies
Given an integer array nums of unique elements, return all possible subsets (the power set).

The solution set must not contain duplicate subsets. Return the solution in any order.

 

Example 1:

Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

*/

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        DFS(nums, 0, path, result);
        return result;
    }
    
    private void DFS(int[] nums, int start, List<int> path, List<IList<int>> result) {
        // Add the current subset to the result
        result.Add(new List<int>(path));
        
        for (int i = start; i < nums.Length; i++) {
            // Include nums[i] in the subset
            path.Add(nums[i]);
            
            // Explore further with this included
            DFS(nums, i + 1, path, result);
            
            // Backtrack - exclude nums[i]
            path.RemoveAt(path.Count - 1);
        }
    }
}

/*
Explanation
Initialization: Start with empty result list and empty current path.

Base Case: Every time we enter the DFS function, we add the current path to results (this captures subsets of all sizes).

Recursive Case:

Loop through elements starting from 'start' index

For each element:

Include it in the current subset (path)

Recursively call DFS for next elements (i+1 to avoid duplicates)

Backtrack by removing the element

Order of Operations: The recursion naturally builds all combinations:

First exclude all elements (empty set)

Then include first element and its combinations

Then include second element and its combinations with later elements, etc.

Example Walkthrough (nums = [1,2,3])
The recursion builds subsets in this order:

[] (added first)

[1] → [1,2] → [1,2,3]

Then backtrack to [1] → [1,3]

Backtrack to [] → [2] → [2,3]

Backtrack to [] → [3]

Resulting in: [[], [1], [1,2], [1,2,3], [1,3], [2], [2,3], [3]]

Complexity Analysis
Time Complexity: O(n * 2^n) - There are 2^n subsets and each takes O(n) time to copy

Space Complexity: O(n) for recursion stack (not counting output storage)

This approach efficiently generates all possible subsets without duplicates while maintaining the input order.
*/