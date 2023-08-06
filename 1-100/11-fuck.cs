/*
You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container, such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.
*/

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