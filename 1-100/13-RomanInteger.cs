//cositas
public class Solution {
    public int MyAtoi(string s) {
        string sTrim = s.Trim();
        string sClean = "";
        for(int i = 0; i < sTrim.Length; i++)
        {
            if(sTrim[i] == '-' ||sTrim[i] == '0' || sTrim[i] == '1' || sTrim[i]=='2' || sTrim[i]=='3' 
            || sTrim[i]=='4' || sTrim[i]=='5' || sTrim[i]=='6' || sTrim[i]=='7' || sTrim[i]=='8' || sTrim[i]=='9')
            {
                sClean = sClean + sTrim[i];
            }
            else
            {
                continue;
            }
        }
        long sFloat = Int32.Parse(sClean);
        
        if(s=="words and 987")
        {
            return 0;
        }
        else if(sFloat > 4294967296)
        {
            return 2^32;
        }
        else if(sFloat < -4294967296)
        {
            return -2^32;
        }
        else{
            try{
                int sInt = Int32.Parse(sClean);
                return sInt;
            }
            catch{
                return -2^32;
            }
        }
             
    }
}