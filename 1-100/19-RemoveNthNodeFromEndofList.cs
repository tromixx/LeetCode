/*
Given the head of a linked list, 
remove the nth node from the end of the list and return its head.

Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
Example 2:

Input: head = [1], n = 1
Output: []
*/

public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        //var finalNode ,
        //foreach(i...) (if ListNode[i]){skip, otherwise save to finalNode}
        
        List<int> list = new List<int>();

        while (head != null){
            list.Add(head.val);
            head = head.next;
        }
        int removeIndex = list.Count() - n;
        list.RemoveAt(removeIndex);

        ListNode prev = new ListNode();
        var dummy = prev;
        foreach (int i in list){
            dummy.next = new ListNode(i);
            dummy = dummy.next;
        }
        return prev.next;        
    }
}
