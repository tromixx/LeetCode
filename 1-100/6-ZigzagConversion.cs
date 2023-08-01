/*
The string [input]"PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this:

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: [output]"PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
*/
//Time complexity: O(n)
//Space complexity: O(n)

public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1)
            return s;

        var result = new StringBuilder();
        var perIter = numRows*2 - 2;
        for (int row = 0; row < numRows; row++){
            int i = 0;
            while ((i+row) < s.Length){
                result.Append(s[i+row]);
                if (row != 0  && row != numRows-1){
                    if((i + perIter - row) < s.Length){
                        result.Append(s[i + perIter - row]);
                    }
                }

                i += perIter;
            }
        }
        return result.ToString();
    }
}