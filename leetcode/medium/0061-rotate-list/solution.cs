public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        // Empty list or only one node
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }

        // Find length and last node
        int length = 1;
        ListNode tail = head;

        while (tail.next != null)
        {
            tail = tail.next;
            length++;
        }

        // Remove unnecessary full rotations
        k = k % length;

        if (k == 0)
        {
            return head;
        }

        // Make the list circular
        tail.next = head;

        // Find the new tail
        int steps = length - k;

        ListNode newTail = head;

        for (int i = 1; i < steps; i++)
        {
            newTail = newTail.next;
        }

        // New head is after new tail
        ListNode newHead = newTail.next;

        // Break the circle
        newTail.next = null;

        return newHead;
    }
}