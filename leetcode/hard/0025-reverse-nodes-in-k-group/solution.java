class Solution {
    public ListNode reverseKGroup(ListNode head, int k) {

        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode prevGroup = dummy;

        while (true) {

            // Find the kth node
            ListNode kth = prevGroup;

            for (int i = 0; i < k; i++) {
                kth = kth.next;

                // Not enough nodes for a complete group
                if (kth == null) {
                    return dummy.next;
                }
            }

            // Save the node after the group
            ListNode nextGroup = kth.next;

            // Reverse the current group
            ListNode prev = nextGroup;
            ListNode curr = prevGroup.next;

            while (curr != nextGroup) {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            // Connect previous group to reversed group
            ListNode oldStart = prevGroup.next;
            prevGroup.next = kth;

            // Move to the next group
            prevGroup = oldStart;
        }
    }
}