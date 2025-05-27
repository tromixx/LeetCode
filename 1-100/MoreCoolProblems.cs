/*
✅ 1. Binary Search
🔹 Problem: Find Minimum in Rotated Sorted Array
📍 LeetCode #153
📌 Used by: Facebook, Google
🔍 Description: Given a rotated sorted array with unique elements, find the minimum element.
*/

public int FindMin(int[] nums) {
    int left = 0, right = nums.Length - 1;

    while (left < right) {
        int mid = left + (right - left) / 2;
        if (nums[mid] > nums[right]) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }

    return nums[left];
}



/*
✅ 2. DFS (Depth-First Search)
🔹 Problem: Word Search
📍 LeetCode #79
📌 Used by: Amazon, Microsoft
🔍 Description: Given a grid of letters and a word, return true if the word exists in the grid via adjacent cells.
*/

public bool Exist(char[][] board, string word) {
    for (int i = 0; i < board.Length; i++) {
        for (int j = 0; j < board[0].Length; j++) {
            if (DFS(board, word, i, j, 0)) return true;
        }
    }
    return false;
}

private bool DFS(char[][] board, string word, int i, int j, int index) {
    if (index == word.Length) return true;
    if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index]) return false;

    char temp = board[i][j];
    board[i][j] = '#'; // mark as visited

    bool found = DFS(board, word, i + 1, j, index + 1)
              || DFS(board, word, i - 1, j, index + 1)
              || DFS(board, word, i, j + 1, index + 1)
              || DFS(board, word, i, j - 1, index + 1);

    board[i][j] = temp;
    return found;
}



/*
✅ 3. Sliding Window
🔹 Problem: Longest Substring Without Repeating Characters
📍 LeetCode #3
📌 Used by: Google, Facebook, Amazon
🔍 Description: Given a string, find the length of the longest substring without repeating characters.
*/

public int LengthOfLongestSubstring(string s) {
    var set = new HashSet<char>();
    int left = 0, maxLength = 0;

    for (int right = 0; right < s.Length; right++) {
        while (set.Contains(s[right])) {
            set.Remove(s[left]);
            left++;
        }
        set.Add(s[right]);
        maxLength = Math.Max(maxLength, right - left + 1);
    }

    return maxLength;
}

/*
✅ 4. Dynamic Programming (DP)
🔹 Problem: House Robber
📍 LeetCode #198
📌 Used by: Amazon, Microsoft
🔍 Description: Maximize money you can rob from houses without robbing two adjacent ones.
*/

public int Rob(int[] nums) {
    if (nums.Length == 0) return 0;
    if (nums.Length == 1) return nums[0];

    int prev1 = 0, prev2 = 0;

    foreach (int num in nums) {
        int temp = prev1;
        prev1 = Math.Max(prev2 + num, prev1);
        prev2 = temp;
    }

    return prev1;
}

/*
✅ 5. Two Pointers
🔹 Problem: Two Sum II - Input Array is Sorted
📍 LeetCode #167
📌 Used by: Google, Facebook, Bloomberg
🔍 Description: Given a sorted array, return indices of two numbers such that they add up to a target.
*/

public int[] TwoSum(int[] numbers, int target) {
    int left = 0, right = numbers.Length - 1;

    while (left < right) {
        int sum = numbers[left] + numbers[right];

        if (sum == target) return new int[] { left + 1, right + 1 };
        else if (sum < target) left++;
        else right--;
    }

    return new int[0];
}