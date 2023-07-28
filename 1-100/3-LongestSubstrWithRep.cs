//Longest Substring Without Repeating Characters
/*
Given a string s, find the length of the longest substring without repeating characters.

Example:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
*/
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var charSet = new HashSet<char>();
        int left = 0, right = 0, maxLength = 0;
        while(right < s.Length)
        {
            if(!charSet.Contains(s[right]))
            {
                charSet.Add(s[right]);
                right++;
                maxLength = Math.Max(maxLength, charSet.Count);
            }
            else
            {
                charSet.Remove(s[left]);
                left++;
            }        
        }
        return maxLength;
    }
}