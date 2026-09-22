import java.util.*;

class Solution {
    public ListNode mergeKLists(ListNode[] lists) {

        // Min-heap: smallest node value comes first
        PriorityQueue<ListNode> pq =
            new PriorityQueue<>((a, b) -> a.val - b.val);

        // Put the first node of every non-empty list into the heap
        for (ListNode list : lists) {
            if (list != null) {
                pq.offer(list);
            }
        }

        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (!pq.isEmpty()) {

            // Get the smallest node
            ListNode node = pq.poll();

            // Add it to the result
            current.next = node;
            current = current.next;

            // Add the next node from the same list
            if (node.next != null) {
                pq.offer(node.next);
            }
        }

        return dummy.next;
    }
}