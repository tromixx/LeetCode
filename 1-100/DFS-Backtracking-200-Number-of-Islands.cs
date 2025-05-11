/*
200. Number of Islands
Solved
Medium
Topics
Companies
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.

An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

 

Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

*/

public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        
        int islands = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == '1') {
                    islands++;
                    OptimizedDFS(grid, r, c, rows, cols);
                }
            }
        }
        
        return islands;
    }
    
    private void OptimizedDFS(char[][] grid, int r, int c, int rows, int cols) {
        // Use a stack of ValueTuple for better performance
        var stack = new Stack<(int, int)>();
        stack.Push((r, c));
        grid[r][c] = '0'; // Mark immediately when pushing
        
        while (stack.Count > 0) {
            var (row, col) = stack.Pop();
            
            // Check neighbors in a specific order that's often optimal
            // Right
            if (col + 1 < cols && grid[row][col + 1] == '1') {
                grid[row][col + 1] = '0';
                stack.Push((row, col + 1));
            }
            // Down
            if (row + 1 < rows && grid[row + 1][col] == '1') {
                grid[row + 1][col] = '0';
                stack.Push((row + 1, col));
            }
            // Left
            if (col - 1 >= 0 && grid[row][col - 1] == '1') {
                grid[row][col - 1] = '0';
                stack.Push((row, col - 1));
            }
            // Up
            if (row - 1 >= 0 && grid[row - 1][col] == '1') {
                grid[row - 1][col] = '0';
                stack.Push((row - 1, col));
            }
        }
    }
}


/*
# Comprehensive Explanation of DFS and Number of Islands Solution

## Understanding Depth-First Search (DFS)

DFS is an algorithm for traversing or searching tree/graph data structures by exploring as far as possible along each branch before backtracking. For grid problems like Number of Islands:

1. **Concept**: Explore all connected land cells ('1's) from a starting point
2. **Behavior**: Goes deep into one direction before exploring others
3. **Implementation**: Can be done recursively or with an explicit stack

## Problem Breakdown: Number of Islands

**Objective**: Count groups of adjacent '1's (horizontally or vertically connected)

### Key Observations:
1. Each '1' not yet visited is part of a new island
2. All connected '1's should be marked as visited to avoid double-counting
3. Diagonal connections don't count as part of the same island

## Solution Walkthrough

### 1. Grid Traversal
```csharp
for (int r = 0; r < rows; r++) {
    for (int c = 0; c < cols; c++) {
        if (grid[r][c] == '1') {
            islands++;
            OptimizedDFS(grid, r, c, rows, cols);
        }
    }
}
```
- We scan every cell in row-major order
- When finding unvisited land ('1'), we:
  - Increment our island count
  - Initiate DFS to mark all connected land

### 2. DFS Implementation
```csharp
var stack = new Stack<(int, int)>();
stack.Push((r, c));
grid[r][c] = '0'; // Mark immediately
```

**Initialization**:
- Stack stores coordinates to visit
- Immediately mark starting cell as visited ('0')

### 3. Neighbor Processing
```csharp
while (stack.Count > 0) {
    var (row, col) = stack.Pop();
    
    // Check all 4 directions
    if (col + 1 < cols && grid[row][col + 1] == '1') {
        grid[row][col + 1] = '0';
        stack.Push((row, col + 1));
    }
    // Similar checks for other directions...
}
```

**Key Aspects**:
1. **Direction Order**: Right → Down → Left → Up (optimized for cache locality)
2. **Immediate Marking**: Cells are marked when pushed to stack (not when popped)
3. **Boundary Checks**: Incorporated directly in each direction check

## Critical Optimizations

1. **Explicit Stack vs Recursion**
   - Avoids recursion overhead and potential stack overflow
   - More control over memory usage

2. **Immediate Marking**
   ```csharp
   stack.Push((r, c));
   grid[r][c] = '0'; // Mark immediately
   ```
   - Prevents the same cell from being pushed multiple times
   - Reduces stack operations by up to 4x

3. **Direction Processing Order**
   - Right/Down first takes advantage of:
     - Cache locality (memory is row-major ordered)
     - Typically finds more land cells earlier in traversal

4. **Pre-Passed Dimensions**
   - Passing `rows` and `cols` avoids repeated calls to `grid.Length`

5. **Value Tuples**
   - Using `(int, int)` is more efficient than custom structs/classes

6. **Integrated Boundary Checks**
   - Combined with the land check in a single condition
   - Reduces number of conditional checks

## Why This Approach is Optimal

1. **Time Complexity**: O(M×N) - Each cell visited exactly once
2. **Space Complexity**: O(min(M,N)) - Stack size limited by grid dimensions
3. **Practical Performance**:
   - Minimal memory allocations
   - Cache-friendly access patterns
   - Reduced conditional branching
   - Early elimination of visited cells

## Alternative Considerations

While this is already highly optimized, you might see small improvements by:

1. **Using a Pre-Allocated Array as Stack**
   - Could be faster for very large grids
   - But adds complexity and only helps in extreme cases

2. **BFS Variation**
   - Might perform better for some specific island shapes
   - Generally comparable in performance

3. **Parallel Processing**
   - Only beneficial for enormous grids
   - Adds significant complexity

This implementation represents an excellent balance between code clarity and performance optimization for typical LeetCode test cases. The micro-optimizations collectively push it into the top performance tier while maintaining readable code.
*/