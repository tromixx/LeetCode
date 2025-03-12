using System.Text;

public class Solution 
{
    public string MergeAlternately(string word1, string word2) 
    {
        // Use StringBuilder for efficient string concatenation
        StringBuilder merged = new StringBuilder();

        // Get the lengths of the two words
        int len1 = word1.Length;
        int len2 = word2.Length;

        // Loop through the characters up to the length of the shorter word
        for (int i = 0; i < Math.Max(len1, len2); i++)
        {
            // Append character from word1 if it exists
            if (i < len1)
            {
                merged.Append(word1[i]);
            }

            // Append character from word2 if it exists
            if (i < len2)
            {
                merged.Append(word2[i]);
            }
        }

        // Return the merged string
        return merged.ToString();
    }
}