/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
*/

/*The problem requires generating all possible letter combinations that can be formed from a given sequence of digits, just like on a telephone keypad. To achieve this, we can use a backtracking approach to explore all possible combinations recursively.

Approach
We define a mapping array that holds the letters corresponding to each digit on a telephone keypad.
We initialize an empty list to store the final result.
We start the backtracking process by calling the recursive Backtrack function with initial parameters.
In the Backtrack function, we check if the index is equal to the length of the input digits. 
If it is, we have formed a valid combination and add it to the result list.
Otherwise, we get the letters corresponding to the current digit and loop through each letter.
For each letter, we append it to the current combination and make a recursive call with the updated combination and index+1.
The recursion will explore all possible combinations, and each time it reaches the end of the digits, it adds the formed combination to the result list.
Complexity
Time complexity:
The time complexity of this backtracking approach is O(4^N * N), where N is the length of the input digits. The maximum number of combinations that can be formed for a single digit is 4 (for digits 7, 9) since they have four letters associated with them. For other digits, there are three letters. So, in the worst case, there can be 4^N combinations, and for each combination, we copy it to the result list in O(N) time.

Space complexity:
The space complexity is O(N) as we use a recursive approach, and at any point in the recursion, the maximum depth of the call stack is equal to the length of the input digits (N). Additionally, the space used for the result list is also O(N) as it stores all the possible combinations.*/

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