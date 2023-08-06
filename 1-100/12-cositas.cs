public class Solution {
    public string IntToRoman(int num) {
        /*
        I             1
        V             5
        X             10
        L             50
        C             100
        D             500
        M             1000

        3999 max
        */
        var numStr = ToString(num);
        var leng = numStr.Length() ;
        var finalString = "";

        while(leng != -1)
        {
            //for 1000 - 3000
            if(leng == 3)
            {
                if(numStr[leng] == 1)
                {
                    finalString =+ 'M';
                }

                else if(numStr[leng] == 2)
                {
                    finalString =+ 'M' + 'M';
                }

                else
                {
                    finalString =+ 'M' + 'M' + 'M';
                }
            }

            //for 1-9
            if(leng == 0)
            {
                if(numStr[leng] == 1)
                {
                    finalString =+ 'I';
                }

                else if(numStr[leng] == 2)
                {
                    finalString =+ 'I' + 'I';
                }

                else if(numStr[leng] == 3)
                {
                    finalString =+ 'I' + 'I' + 'I';
                }

                else if(numStr[leng] == 4)
                {
                    finalString =+ 'I' + 'I' + 'I' + 'I';
                }

                else if(numStr[leng] == 5)
                {
                    finalString =+ 'V';
                }

                else if(numStr[leng] == 6)
                {
                    finalString =+ 'V' + 'I';
                }

                else if(numStr[leng] == 7)
                {
                    finalString =+ 'V' + 'I' + 'I';
                }

                else if(numStr[leng] == 8)
                {
                    finalString =+ 'V' + 'I' + 'I' + 'I';
                }

                else if(numStr[leng] == 9)
                {
                    finalString =+ 'V' + 'I' + 'I' + 'I' + 'I';
                }
            }
            leng--;
        }
    }
}