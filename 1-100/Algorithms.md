### **1. Binary Search**
- **What**: Efficiently finds a target in a *sorted* collection by repeatedly dividing the search space in half.
- **When to Use**:
  - Searching in sorted arrays/lists.
  - Problems with "find minimum/maximum" in monotonic functions.
- **Example**:  
  ```python
  def binary_search(arr, target):
      left, right = 0, len(arr) - 1
      while left <= right:
          mid = (left + right) // 2
          if arr[mid] == target:
              return mid
          elif arr[mid] < target:
              left = mid + 1
          else:
              right = mid - 1
      return -1
  ```
  **Input**: `arr = [1, 3, 5, 7, 9]`, `target = 5`  
  **Output**: `2` (index of 5).

---

### **2. Depth-First Search (DFS)**
- **What**: Explores as far as possible along a branch before backtracking (uses recursion/stack).
- **When to Use**:
  - Tree/graph traversal (e.g., pathfinding, permutations).
  - Problems requiring exhaustive search (e.g., backtracking).
- **Example**:  
  ```python
  def dfs(node, target):
      if not node:
          return False
      if node.val == target:
          return True
      return dfs(node.left, target) or dfs(node.right, target)
  ```
  **Input**: Binary tree with `target = 7`  
  **Output**: `True` if 7 exists in the tree.

---

### **3. Sliding Window**
- **What**: Maintains a dynamic window over a sequence to track subsets (e.g., subarrays/substrings).
- **When to Use**:
  - Contiguous subarray problems (e.g., max sum, anagrams).
  - Fixed/variable-size window problems.
- **Example**:  
  ```python
  def max_subarray(arr, k):
      window_sum = max_sum = sum(arr[:k])
      for i in range(k, len(arr)):
          window_sum += arr[i] - arr[i - k]
          max_sum = max(max_sum, window_sum)
      return max_sum
  ```
  **Input**: `arr = [2, 1, 5, 1, 3, 2]`, `k = 3`  
  **Output**: `9` (subarray `[5, 1, 3]`).

---

### **4. Dynamic Programming (DP)**
- **What**: Solves problems by breaking them into overlapping subproblems and storing results (memoization).
- **When to Use**:
  - Optimization problems (e.g., shortest path, knapsack).
  - Problems with recursive substructure (e.g., Fibonacci, grid traversal).
- **Example**:  
  ```python
  def fib(n, memo={}):
      if n in memo: return memo[n]
      if n <= 2: return 1
      memo[n] = fib(n - 1) + fib(n - 2)
      return memo[n]
  ```
  **Input**: `n = 5`  
  **Output**: `5` (Fibonacci sequence: 1, 1, 2, 3, **5**).

---

### **5. Two Pointers**
- **What**: Uses two pointers (indices) to traverse a sequence from different directions or speeds.
- **When to Use**:
  - Pair searches (e.g., two-sum in sorted arrays).
  - In-place array modifications (e.g., removing duplicates).
- **Example**:  
  ```python
  def two_sum_sorted(arr, target):
      left, right = 0, len(arr) - 1
      while left < right:
          current_sum = arr[left] + arr[right]
          if current_sum == target:
              return [left, right]
          elif current_sum < target:
              left += 1
          else:
              right -= 1
      return []
  ```
  **Input**: `arr = [1, 2, 3, 4, 6]`, `target = 6`  
  **Output**: `[1, 3]` (values `2 + 4 = 6`).

---

### **When to Choose Which Algorithm**
| Algorithm          | Best For                                      | Time Complexity (Avg) |
|--------------------|-----------------------------------------------|-----------------------|
| **Binary Search**  | Sorted data search                            | O(log n)              |
| **DFS**            | Exhaustive search (trees/graphs)              | O(V + E)              |
| **Sliding Window** | Contiguous subsequences                       | O(n)                  |
| **DP**             | Optimization with overlapping subproblems     | O(n) → O(n²)          |
| **Two Pointers**   | Pair searches or in-place array operations    | O(n)                  |

---

### **Key Takeaways**
- **Binary Search**: Think "sorted data" and "fast lookup".
- **DFS**: Think "explore all paths" or "backtracking".
- **Sliding Window**: Think "subarray/substring with constraints".
- **DP**: Think "repeated computations" or "optimal substructure".
- **Two Pointers**: Think "paired elements" or "in-place operations". 