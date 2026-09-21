
class Solution {
    public static Node detectCycle(Node head) {
        if (head == null || head.next == null) {
            return null;
        }
        
        Node slow = head;
        Node fast = head;
        boolean hasCycle = false;
        
        // Detect cycle using Floyd's cycle-finding algorithm
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
            
            if (slow == fast) {
                hasCycle = true;
                break;
            }
        }
        
        // If no cycle is found, return null
        if (!hasCycle) {
            return null;
        }
        
        // Find the start of the cycle
        slow = head;
        while (slow != fast) {
            slow = slow.next;
            fast = fast.next;
        }
        
        return slow;
    }
}
