# LINKLEN - Rating 1100

![Difficulty](https://img.shields.io/badge/Difficulty-Easy-green)

## Problem

_Description not available._

## Solution

**Language:** Java  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-21T16:01:18.881Z  

```java

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

```

---

[View on CodeChef](https://www.codechef.com/problems/LINKLEN)