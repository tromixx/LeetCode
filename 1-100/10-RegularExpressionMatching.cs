/*
Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).
*/

public class Solution {
    public bool IsMatch(string s, string p) {
        int pi = 0;
        return IsMatchHelper(s, p, s.Length-1, p.Length-1);
    }

    private bool IsMatchHelper(string s, string p, int si, int pi){
        if(si < 0){
            while(pi >= 0 && p[pi] == '*'){
                pi -= 2;
            }

            return pi < 0;
        }

        if(pi < 0){
            return false;
        }
        
        if(s[si] == p[pi] || p[pi] == '.'){
            return IsMatchHelper(s, p, si-1, pi-1);
        }

        if(p[pi] != '*'){
            return false;
        }

        while(pi >= 0 && p[pi] == '*'){
            pi--;
        }

        if(pi < 0)
            return false;

        while(si >= 0 && (s[si] == p[pi] || p[pi] == '.')){
            if(IsMatchHelper(s, p, si, pi-1)){
                return true;
            }

            si--;
        }
        
        return IsMatchHelper(s, p, si, pi-1);
    }
}

//Other solution