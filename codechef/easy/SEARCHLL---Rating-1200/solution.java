
static int getMiddleElement(Node head) {
    if (head == null) {
        return -1; // Return -1 for empty list
    }
    
    Node slow = head;
    Node fast = head;
    
    while (fast != null && fast.next != null) {
        slow = slow.next;
        fast = fast.next.next;
    }
    
    return slow.val;
}
