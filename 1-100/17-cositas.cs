/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
*/

public class Solution 
{
    private readonly string[] mapping = new string[] 
    {
        "",     // 0
        "",     // 1
        "abc",  // 2
        "def",  // 3
        "ghi",  // 4
        "jkl",  // 5
        "mno",  // 6
        "pqrs", // 7
        "tuv",  // 8
        "wxyz"  // 9
    };
    public IList<string> LetterCombinations(string digits) {
        IList<string> result = new List<string>();
        if (string.IsNullOrEmpty(digits))
            return result;
        
        Backtrack(result, "", digits, 0);
        return result;
    }
    private void Backtrack(IList<string> result, string current, string digits, int index) {
        if (index == digits.Length) {
            result.Add(current);
            return;
        }
        
        int digit = digits[index] - '0';
        string letters = mapping[digit];
        
        for (int i = 0; i < letters.Length; i++) {
            Backtrack(result, current + letters[i], digits, index + 1);
        }
    }
}