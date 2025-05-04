using System;
/*
Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
In other words, return true if one of s1's permutations is the substring of s2.
Example 1:
Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").
*/

public class Solution 
{
    public bool CheckInclusion(string s1, string s2) 
    {
        if (s1.Length > s2.Length) return false;

        int[] s1Count = new int[26]; // Frequency map for 's1'
        int[] s2Count = new int[26]; // Frequency map for current window in 's2'

        // Initialize frequency maps for 's1' and the first window in 's2'
        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        // Check if the first window is a permutation of 's1'
        if (AreEqual(s1Count, s2Count))
            return true;

        // Slide the window through 's2'
        for (int right = s1.Length; right < s2.Length; right++)
        {
            // Remove the leftmost character of the previous window
            int left = right - s1.Length;
            s2Count[s2[left] - 'a']--;

            // Add the new character to the window
            s2Count[s2[right] - 'a']++;

            // Check if current window is a permutation of 's1'
            if (AreEqual(s1Count, s2Count))
                return true;
        }

        return false;
    }

    // Helper method to compare frequency arrays
    private bool AreEqual(int[] a, int[] b)
    {
        for (int i = 0; i < 26; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
}