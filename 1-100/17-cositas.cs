/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. 
Return the answer in any order.

A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.
*/

public class Solution {        
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> result = new List<string>();
            if(string.IsNullOrEmpty(digits))
                return result;

            private void Backtrack(IList<string> result, string current, string digits, int inderx){
                if (index == digits.Length){
                    result.Add(current);
                    return;
                }
            }
        }
    }
}