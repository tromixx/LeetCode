## **Google Assessments**

### **1. Minimum Window Substring (Sliding Window)**
**Problem**: Given two strings `s` and `t`, find the smallest substring in `s` that contains all characters of `t`.

#### **Solution (Sliding Window Technique)**
```csharp
public string MinWindow(string s, string t) {
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
```
#### **Approach**
- **Sliding Window** (Two Pointers: `left` and `right`) to dynamically adjust the window.
- **Hash Maps** to track character frequencies.
- **Time Complexity**: O(|S| + |T|), **Space Complexity**: O(|S| + |T|).

---

### **2. Course Schedule (Topological Sort - DFS)**
**Problem**: Given `numCourses` and prerequisites, determine if you can finish all courses.

#### **Solution (DFS Cycle Detection)**
```csharp
public bool CanFinish(int numCourses, int[][] prerequisites) {
    var graph = new List<int>[numCourses];
    for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();
    foreach (var p in prerequisites) graph[p[1]].Add(p[0]);

    var visited = new int[numCourses]; // 0=unvisited, 1=visiting, 2=visited
    for (int i = 0; i < numCourses; i++) {
        if (HasCycle(graph, visited, i)) return false;
    }
    return true;
}

private bool HasCycle(List<int>[] graph, int[] visited, int node) {
    if (visited[node] == 1) return true; // Cycle detected
    if (visited[node] == 2) return false;

    visited[node] = 1; // Mark as visiting
    foreach (var neighbor in graph[node]) {
        if (HasCycle(graph, visited, neighbor)) return true;
    }
    visited[node] = 2; // Mark as visited
    return false;
}
```
#### **Approach**
- **DFS with Cycle Detection** (3-state marking: unvisited, visiting, visited).
- **Time Complexity**: O(V + E), **Space Complexity**: O(V + E).

---

## **Microsoft Assessments**

### **1. Reverse Words in a String (Two Pointers)**
**Problem**: Reverse the order of words in a string (with trimmed spaces).

#### **Solution (Two Pointers + String Builder)**
```csharp
public string ReverseWords(string s) {
    var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(words);
    return string.Join(" ", words);
}
```
#### **Optimized Approach (In-Place for C++) but C# uses Split**
- **Time Complexity**: O(N), **Space Complexity**: O(N).

---

### **2. LRU Cache (Hash Map + Doubly Linked List)**
**Problem**: Design an LRU cache with O(1) `get` and `put`.

#### **Solution (Hash Map + Linked List)**
```csharp
public class LRUCache {
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<(int Key, int Value)>> _map;
    private readonly LinkedList<(int Key, int Value)> _list;

    public LRUCache(int capacity) {
        _capacity = capacity;
        _map = new Dictionary<int, LinkedListNode<(int, int)>>();
        _list = new LinkedList<(int, int)>();
    }

    public int Get(int key) {
        if (!_map.TryGetValue(key, out var node)) return -1;
        _list.Remove(node);
        _list.AddFirst(node);
        return node.Value.Value;
    }

    public void Put(int key, int value) {
        if (_map.TryGetValue(key, out var node)) {
            node.Value = (key, value);
            _list.Remove(node);
            _list.AddFirst(node);
        } else {
            if (_map.Count >= _capacity) {
                var last = _list.Last;
                _map.Remove(last.Value.Key);
                _list.RemoveLast();
            }
            var newNode = _list.AddFirst((key, value));
            _map[key] = newNode;
        }
    }
}
```
#### **Approach**
- **Hash Map** for O(1) access.
- **Doubly Linked List** to maintain order.
- **Time Complexity**: O(1) for both operations.

---

## **Amazon Assessments**

### **1. Two Sum (Hash Map)**
**Problem**: Find two numbers that add up to a target.

#### **Solution (One-Pass Hash Map)**
```csharp
public int[] TwoSum(int[] nums, int target) {
    var map = new Dictionary<int, int>();
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        if (map.ContainsKey(complement)) {
            return new[] { map[complement], i };
        }
        map[nums[i]] = i;
    }
    return Array.Empty<int>();
}
```
#### **Approach**
- **Hash Map** for O(1) lookups.
- **Time Complexity**: O(N), **Space Complexity**: O(N).

---

### **2. Merge k Sorted Lists (Min-Heap)**
**Problem**: Merge `k` sorted linked lists into one.

#### **Solution (Priority Queue)**
```csharp
public ListNode MergeKLists(ListNode[] lists) {
    var pq = new PriorityQueue<ListNode, int>();
    foreach (var list in lists) {
        if (list != null) pq.Enqueue(list, list.val);
    }

    var dummy = new ListNode();
    var current = dummy;

    while (pq.Count > 0) {
        var node = pq.Dequeue();
        current.next = node;
        current = current.next;

        if (node.next != null) {
            pq.Enqueue(node.next, node.next.val);
        }
    }

    return dummy.next;
}
```
#### **Approach**
- **Min-Heap (Priority Queue)** to always pick the smallest node.
- **Time Complexity**: O(N log K), **Space Complexity**: O(K).

---

### **Summary of Techniques Used**
| Problem | Technique | Time Complexity |
|---------|-----------|-----------------|
| Min Window Substring | Sliding Window | O(S + T) |
| Course Schedule | DFS + Topological Sort | O(V + E) |
| Reverse Words | Two Pointers | O(N) |
| LRU Cache | Hash Map + Linked List | O(1) |
| Two Sum | Hash Map | O(N) |
| Merge k Sorted Lists | Min-Heap | O(N log K) |
