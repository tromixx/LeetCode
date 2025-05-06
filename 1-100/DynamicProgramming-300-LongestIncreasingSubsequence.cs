public class Solution {
    public int LengthOfLIS(int[] nums) {
        List<int> tails = new List<int>();
        
        foreach (int num in nums) {
            int left = 0, right = tails.Count;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (tails[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            
            if (left == tails.Count) {
                tails.Add(num);
            } else {
                tails[left] = num;
            }
        }
        
        return tails.Count;
    }
}