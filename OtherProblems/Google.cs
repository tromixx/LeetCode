/*1. Minimum Window Substring (Sliding Window)
Problem: Given two strings s and t, find the smallest substring in s that contains all characters of t.
Solution (Sliding Window Technique)
*/
public string MinWindow(string s, string t) 
{
    if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) 
        return "";

    var targetMap = new Dictionary<char, int>();
    foreach (char c in t) {
        if (targetMap.ContainsKey(c)) targetMap[c]++;
        else targetMap[c] = 1;
    }

    int left = 0, right = 0;
    int required = targetMap.Count;
    int formed = 0;
    var windowMap = new Dictionary<char, int>();
    int[] result = { -1, 0, 0 }; // length, left, right

    while (right < s.Length) {
        char current = s[right];
        if (windowMap.ContainsKey(current)) windowMap[current]++;
        else windowMap[current] = 1;

        if (targetMap.ContainsKey(current) && windowMap[current] == targetMap[current]) {
            formed++;
        }

        while (left <= right && formed == required) {
            if (result[0] == -1 || right - left + 1 < result[0]) {
                result[0] = right - left + 1;
                result[1] = left;
                result[2] = right;
            }

            char leftChar = s[left];
            windowMap[leftChar]--;
            if (targetMap.ContainsKey(leftChar) {
                if (windowMap[leftChar] < targetMap[leftChar]) {
                    formed--;
                }
            }
            left++;
        }
        right++;
    }

    return result[0] == -1 ? "" : s.Substring(result[1], result[2] - result[1] + 1);
}
/*
Approach
Sliding Window (Two Pointers: left and right) to dynamically adjust the window.
Hash Maps to track character frequencies.
Time Complexity: O(|S| + |T|), Space Complexity: O(|S| + |T|).
2. Course Schedule (Topological Sort - DFS)
Problem: Given numCourses and prerequisites, determine if you can finish all courses.

Solution (DFS Cycle Detection)
*/
public bool CanFinish(int numCourses, int[][] prerequisites) 
{
    var graph = new List<int>[numCourses];
    for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();
    foreach (var p in prerequisites) graph[p[1]].Add(p[0]);

    var visited = new int[numCourses]; // 0=unvisited, 1=visiting, 2=visited
    for (int i = 0; i < numCourses; i++) 
    {
        if (HasCycle(graph, visited, i)) return false;
    }
    return true;
}

private bool HasCycle(List<int>[] graph, int[] visited, int node) 
{
    if (visited[node] == 1) return true; // Cycle detected
    if (visited[node] == 2) return false;

    visited[node] = 1; // Mark as visiting
    foreach (var neighbor in graph[node]) {
        if (HasCycle(graph, visited, neighbor)) return true;
    }
    visited[node] = 2; // Mark as visited
    return false;
}
/*
Approach
DFS with Cycle Detection (3-state marking: unvisited, visiting, visited).
Time Complexity: O(V + E), Space Complexity: O(V + E).
*/