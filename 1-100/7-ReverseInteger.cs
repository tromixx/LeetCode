//cositas
public class Solution {
    public int Reverse(int x) 
    {
        string forward = ToString(x);
        string backwards = "";

        if(x>0)
        {
            for(i = forward.Length - 1, i >= 0 ; i--)
            {
                backwards =+ forward[i];
            }
        }
        else
        {
            x = x + x + x;
            forward = ToString(x);

            for(i = forward.Length - 1, i >= 0 ; i--)
            {
                backwards =+ forward[i];
            }

        }

        int backwardsInt = Int32.Parse(backwards);

        return backwardsInt;

    }
}