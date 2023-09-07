/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode dummyHead = new ListNode(-1); 
        // Create a dummy node as the starting point
        ListNode current = dummyHead; 
        // Pointer to keep track of the current node

        while (list1 != null && list2 != null) {
            if (list1.val <= list2.val) {
                current.next = list1;
                list1 = list1.next;
            } else {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        // Attach the remaining nodes if any
        if (list1 != null) {
            current.next = list1;
        } else {
            current.next = list2;
        }

        return dummyHead.next; 
        // Return the merged list starting from the node after the dummy head

    }
}