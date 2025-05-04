//O(n)
//Longest Substring Without Repeating Characters
/*
Given a string s, find the length of the longest substring without repeating characters.

Example:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
*/
using System;
using System.Collections.Generic;

public class Solution 
{
    public int LengthOfLongestSubstring(string s) 
    {
        HashSet<char> window = new HashSet<char>();
        int left = 0, maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];
            
            // If the character is already in the window, shrink from the left
            while (window.Contains(currentChar))
            {
                window.Remove(s[left]);
                left++;
            }
            
            window.Add(currentChar);
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        
        return maxLength;
    }
}