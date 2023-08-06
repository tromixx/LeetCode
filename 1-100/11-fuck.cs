//cositas

public class Solution {
    public int MaxArea(int[] height) {
     
        int i = 0;
        int j = height.Length-1;
        int maxAmt = 0;
        int iH;
        int jH;
        int cal;
        
        while(j>i)
        {
            iH = height[i];
            jH = height[j];
            
            //Convergence back and forth
            //which is higher，than will convergence from  the other side
            if(iH>jH)
            {
                cal = jH*(j-i);
                j--;
            }
            else
            {
                cal = iH*(j-i); 
                i++;
            }
            
            if(cal>maxAmt)
                 maxAmt = cal;
            
        }
        return maxAmt;
    }
}