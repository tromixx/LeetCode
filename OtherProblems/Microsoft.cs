/*1. Reverse Words in a String (Two Pointers)
Problem: Reverse the order of words in a string (with trimmed spaces).

Solution (Two Pointers + String Builder)
*/
public string ReverseWords(string s) {
    var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    Array.Reverse(words);
    return string.Join(" ", words);
}
/*
Optimized Approach (In-Place for C++) but C# uses Split
Time Complexity: O(N), Space Complexity: O(N).
2. LRU Cache (Hash Map + Doubly Linked List)
Problem: Design an LRU cache with O(1) get and put.

Solution (Hash Map + Linked List)
*/
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
/*
Approach
Hash Map for O(1) access.
Doubly Linked List to maintain order.
Time Complexity: O(1) for both operations.
*/