# Rotate List

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

Given the `head` of a linked list, rotate the list to the right by `k` places.

 

 **Example 1:** 

```
Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]

```

 **Example 2:** 

```
Input: head = [0,1,2], k = 4
Output: [2,0,1]

```

 

 **Constraints:** 

- The number of nodes in the list is in the range [0, 500].
- -100 <= Node.val <= 100
- 0 <= k <= 2 * 109

## Solution

**Language:** C#  
**Runtime:** 0 ms (beats 100.00%)  
**Memory:** 42.9 MB (beats 34.48%)  
**Submitted:** 2026-09-27T17:28:16.948Z  

```cs
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
```

---

[View on LeetCode](https://leetcode.com/problems/rotate-list/)