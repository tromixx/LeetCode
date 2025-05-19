/*
Problem: Find two numbers that add up to a target.
Solution (One-Pass Hash Map)
*/
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
/*
Approach
Hash Map for O(1) lookups.
Time Complexity: O(N), Space Complexity: O(N).
*/




/*
2. Merge k Sorted Lists (Min-Heap)
Problem: Merge k sorted linked lists into one.

Solution (Priority Queue)
*/
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
/*
Approach
Min-Heap (Priority Queue) to always pick the smallest node.
Time Complexity: O(N log K), Space Complexity: O(K).
*/