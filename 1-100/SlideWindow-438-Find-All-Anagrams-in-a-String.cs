/*
Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.

 

Example 1:

Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".
*/

using System;
using System.Collections.Generic;

public class Solution 
{
    public IList<int> FindAnagrams(string s, string p) 
    {
        List<int> result = new List<int>();
        if (s.Length < p.Length) return result;

        int[] pCount = new int[26]; // Frequency map for 'p'
        int[] sCount = new int[26]; // Frequency map for current window in 's'

        // Initialize frequency map for 'p' and first window in 's'
        for (int i = 0; i < p.Length; i++)
        {
            pCount[p[i] - 'a']++;
            sCount[s[i] - 'a']++;
        }

        // Check if the first window is an anagram
        if (AreEqual(pCount, sCount))
            result.Add(0);

        // Slide the window through 's'
        for (int right = p.Length; right < s.Length; right++)
        {
            // Remove the leftmost character of the previous window
            int left = right - p.Length;
            sCount[s[left] - 'a']--;

            // Add the new character to the window
            sCount[s[right] - 'a']++;

            // Check if current window is an anagram
            if (AreEqual(pCount, sCount))
                result.Add(left + 1);
        }

        return result;
    }

    // Helper method to compare frequency arrays
    private bool AreEqual(int[] pCount, int[] sCount)
    {
        for (int i = 0; i < 26; i++)
        {
            if (pCount[i] != sCount[i])
                return false;
        }
        return true;
    }
}