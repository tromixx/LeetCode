/*
Write a function to find the longest common prefix string amongst an array of strings.
If there is no common prefix, return an empty string "".

Example 1:
Input: strs = ["flower","flow","flight"]
Output: "fl"

Example 2:
Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.

*/

public class Solution {
    public string LongestCommonPrefix(string[] strs) {

        string shortest = strs.OrderBy(s => s.Length).First();

        for (int i = 0; i < shortest.Length; i++)
        {
            if(strs.Select(s => s[i]).Distinct().Count() > 1) 
                return shortest[..i];
        }

        return shortest;
        //for loop for each word
        //string that saves result
        
    }
}