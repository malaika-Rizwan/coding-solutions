# Median of Two Sorted Arrays

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Given two sorted arrays `nums1` and `nums2` of size `m` and `n` respectively, return  **the median**  of the two sorted arrays.

The overall run time complexity should be `O(log (m+n))`.

 

 **Example 1:** 

```
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

```

 **Example 2:** 

```
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

```

 

 **Constraints:** 

- nums1.length == m
- nums2.length == n
- 0 <= m <= 1000
- 0 <= n <= 1000
- 1 <= m + n <= 2000
- -106 <= nums1[i], nums2[i] <= 106

## Solution

**Language:** Java  
**Runtime:** 1 ms (beats 100.00%)  
**Memory:** 49 MB (beats 32.31%)  
**Submitted:** 2026-09-22T15:22:29.277Z  

```java
class Solution {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {

        // Always perform binary search on the smaller array
        if (nums1.length > nums2.length) {
            return findMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.length;
        int n = nums2.length;

        int left = 0;
        int right = m;

        while (left <= right) {

            // Partition nums1
            int partition1 = (left + right) / 2;

            // Partition nums2
            int partition2 = (m + n + 1) / 2 - partition1;

            // Left and right values around the partitions
            int maxLeft1 = (partition1 == 0)
                    ? Integer.MIN_VALUE
                    : nums1[partition1 - 1];

            int minRight1 = (partition1 == m)
                    ? Integer.MAX_VALUE
                    : nums1[partition1];

            int maxLeft2 = (partition2 == 0)
                    ? Integer.MIN_VALUE
                    : nums2[partition2 - 1];

            int minRight2 = (partition2 == n)
                    ? Integer.MAX_VALUE
                    : nums2[partition2];

            // Correct partition found
            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1) {

                // Total length is odd
                if ((m + n) % 2 == 1) {
                    return Math.max(maxLeft1, maxLeft2);
                }

                // Total length is even
                int leftMax = Math.max(maxLeft1, maxLeft2);
                int rightMin = Math.min(minRight1, minRight2);

                return (leftMax + rightMin) / 2.0;
            }

            // partition1 is too far right
            else if (maxLeft1 > minRight2) {
                right = partition1 - 1;
            }

            // partition1 is too far left
            else {
                left = partition1 + 1;
            }
        }

        return 0.0;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/median-of-two-sorted-arrays/)