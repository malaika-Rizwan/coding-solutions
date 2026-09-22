# Swap Nodes in Pairs

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

 

 **Example 1:** 

 **Input:**  head = [1,2,3,4]

 **Output:**  [2,1,4,3]

 **Explanation:** 

 **Example 2:** 

 **Input:**  head = []

 **Output:**  []

 **Example 3:** 

 **Input:**  head = [1]

 **Output:**  [1]

 **Example 4:** 

 **Input:**  head = [1,2,3]

 **Output:**  [2,1,3]

 

 **Constraints:** 

- The number of nodes in the list is in the range [0, 100].
- 0 <= Node.val <= 100

## Solution

**Language:** Java  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 43.2 MB (beats 29.09%)  
**Submitted:** 2026-09-22T15:44:27.746Z  

```java
class Solution {
    public ListNode swapPairs(ListNode head) {

        // Dummy node makes swapping easier
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode prev = dummy;

        while (prev.next != null && prev.next.next != null) {

            // First and second nodes
            ListNode first = prev.next;
            ListNode second = first.next;

            // Swap the two nodes
            first.next = second.next;
            second.next = first;
            prev.next = second;

            // Move prev to the end of the swapped pair
            prev = first;
        }

        return dummy.next;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/swap-nodes-in-pairs/)