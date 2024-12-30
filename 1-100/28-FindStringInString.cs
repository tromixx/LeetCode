/*
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, 
or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
*/

public class Solution {
    public int StrStr(string haystack, string needle) 
    {
        if(string.IsNullOrEmpty(needle))
        {
            return 0;
        }

        for(int i = 0; haystack.Length - needle.Length; i++)
        {
            /// Check if the substring from the current position matches the needle
            if(haystack.Substring(i, needle.Length) == needle) 
            /// {// Return the starting index of the match}
        }
        return -1;
    }
}
