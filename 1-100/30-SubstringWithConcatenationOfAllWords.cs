/*
30. Substring with Concatenation of All Words
Hard
Topics
Companies
You are given a string s and an array of strings words. All the strings of words are of the same length.

A concatenated string is a string that exactly contains all the strings of any permutation of words concatenated.

For example, if words = ["ab","cd","ef"], then "abcdef", "abefcd", "cdabef", "cdefab", "efabcd", and "efcdab" are all concatenated strings. "acdbef" is not a concatenated string because it is not the concatenation of any permutation of words.
Return an array of the starting indices of all the concatenated substrings in s. You can return the answer in any order.

 

Example 1:

Input: s = "barfoothefoobarman", words = ["foo","bar"]

Output: [0,9]

Explanation:

The substring starting at 0 is "barfoo". It is the concatenation of ["bar","foo"] which is a permutation of words.
The substring starting at 9 is "foobar". It is the concatenation of ["foo","bar"] which is a permutation of words.

Example 2:

Input: s = "wordgoodgoodgoodbestword", words = ["word","good","best","word"]

Output: []

Explanation:

There is no concatenated substring.

Example 3:

Input: s = "barfoofoobarthefoobarman", words = ["bar","foo","the"]

Output: [6,9,12]

Explanation:

The substring starting at 6 is "foobarthe". It is the concatenation of ["foo","bar","the"].
The substring starting at 9 is "barthefoo". It is the concatenation of ["bar","the","foo"].
The substring starting at 12 is "thefoobar". It is the concatenation of ["the","foo","bar"].

 

Constraints:

1 <= s.length <= 104
1 <= words.length <= 5000
1 <= words[i].length <= 30
s and words[i] consist of lowercase English letters.
*/
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        IList<int> result = new List<int>();
        if (s == null || words == null || words.Length == 0) return result;

        int wordLength = words[0].Length;
        int wordCount = words.Length;
        int substringLength = wordLength * wordCount;

        // Create a frequency map of the words
        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
        foreach (var word in words) {
            if (!wordFrequency.ContainsKey(word))
                wordFrequency[word] = 0;
            wordFrequency[word]++;
        }

        // Loop over each possible offset
        for (int i = 0; i < wordLength; i++) {
            int left = i, count = 0;
            Dictionary<string, int> windowFrequency = new Dictionary<string, int>();

            for (int right = i; right + wordLength <= s.Length; right += wordLength) {
                string word = s.Substring(right, wordLength);

                if (wordFrequency.ContainsKey(word)) {
                    // Add the word to the window
                    if (!windowFrequency.ContainsKey(word))
                        windowFrequency[word] = 0;
                    windowFrequency[word]++;
                    count++;

                    // Shrink the window if it exceeds wordCount
                    while (windowFrequency[word] > wordFrequency[word]) {
                        string leftWord = s.Substring(left, wordLength);
                        windowFrequency[leftWord]--;
                        count--;
                        left += wordLength;
                    }

                    // Valid window found
                    if (count == wordCount) {
                        result.Add(left);
                    }
                } else {
                    // Reset if the word is invalid
                    windowFrequency.Clear();
                    count = 0;
                    left = right + wordLength;
                }
            }
        }

        return result;
    }
}
