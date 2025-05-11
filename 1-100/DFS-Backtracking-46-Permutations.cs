public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        var path = new List<int>();
        var used = new bool[nums.Length];
        DFS(nums, used, path, result);
        return result;
    }
    
    private void DFS(int[] nums, bool[] used, List<int> path, List<IList<int>> result) {
        if (path.Count == nums.Length) {
            result.Add(new List<int>(path)); // Add a copy of the current path
            return;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (!used[i]) {
                // Choose
                used[i] = true;
                path.Add(nums[i]);
                
                // Explore
                DFS(nums, used, path, result);
                
                // Unchoose (backtrack)
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
    }
}