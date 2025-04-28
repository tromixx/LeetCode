public class Solution 
{
    public int Search(int[] nums, int target) 
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;

            // Determine which half is sorted
            if (nums[left] <= nums[mid]) // Left half is sorted
            {
                if (target >= nums[left] && target < nums[mid]) 
                    right = mid - 1; // Search in left half
                else 
                    left = mid + 1; // Search in right half
            }
            else // Right half is sorted
            {
                if (target > nums[mid] && target <= nums[right]) 
                    left = mid + 1; // Search in right half
                else 
                    right = mid - 1; // Search in left half
            }
        }
        return -1; // Target not found
    }
}
