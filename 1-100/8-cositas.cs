//cositas
public class Solution {
    public int MyAtoi(string s) {
        //trim
        string sTrim = s.Trim();
        string sClean = "";
        //var sClean = new StringBuilder();
        
        // + - o nada
        for(i=0,sTrim.Length>0;i++)
        {
            if(sTrim[i]=="0" || sTrim[i]=="1" || sTrim[i]=="2" || sTrim[i]=="2" || sTrim[i]=="3" || sTrim[i]=="4" || sTrim[i]=="5" || sTrim[i]=="6" || sTrim[i]=="7" || sTrim[i]=="8" || sTrim[i]=="9")
            {
                sClean = sClean + sTrim[i];
                //sClean.Append(sTrim[i]);
            }
            else
            {
                continue;
            }
        }

        //var sSuperClean = sClean.ToString();

        int sInt = ToInt32(sClean);
        
    }
}