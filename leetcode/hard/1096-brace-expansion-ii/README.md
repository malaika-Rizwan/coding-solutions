# Brace Expansion II

![Difficulty](https://img.shields.io/badge/Difficulty-Hard-red)

## Problem

Under the grammar given below, strings can represent a set of lowercase words. Let `R(expr)` denote the set of words the expression represents.

The grammar can best be understood through simple examples:

- Single letters represent a singleton set containing that word. R("a") = {"a"} R("w") = {"w"}
- When we take a comma-delimited list of two or more expressions, we take the union of possibilities. R("{a,b,c}") = {"a","b","c"} R("{{a,b},{b,c}}") = {"a","b","c"} (notice the final set only contains each word at most once)
- When we concatenate two expressions, we take the set of possible concatenations between two words where the first word comes from the first expression and the second word comes from the second expression. R("{a,b}{c,d}") = {"ac","ad","bc","bd"} R("a{b,c}{d,e}f{g,h}") = {"abdfg", "abdfh", "abefg", "abefh", "acdfg", "acdfh", "acefg", "acefh"}

Formally, the three rules for our grammar:

- For every lowercase letter x, we have R(x) = {x}.
- For expressions e1, e2,..., ek with k >= 2, we have R({e1, e2,...}) = R(e1) ∪ R(e2) ∪...
- For expressions e1 and e2, we have R(e1 + e2) = {a + b for (a, b) in R(e1) × R(e2)}, where + denotes concatenation, and × denotes the cartesian product.

Given an expression representing a set of words under the given grammar, return  *the sorted list of words that the expression represents*.

 

 **Example 1:** 

```
Input: expression = "{a,b}{c,{d,e}}"
Output: ["ac","ad","ae","bc","bd","be"]

```

 **Example 2:** 

```
Input: expression = "{{a,z},a{b,c},{ab,z}}"
Output: ["a","ab","ac","z"]
Explanation: Each distinct word is written only once in the final answer.

```

 

 **Constraints:** 

- 1 <= expression.length <= 60
- expression[i] consists of '{', '}', ','or lowercase English letters.
- The given expression represents a set of words based on the grammar given in the description.

## Solution

**Language:** Java  
**Runtime:** 10 ms (beats 68.80%)  
**Memory:** 47.1 MB (beats 64.00%)  
**Submitted:** 2026-09-25T14:26:52.155Z  

```java
import java.util.*;

class Solution {

    private String expression;
    private int index;

    public List<String> braceExpansionII(String expression) {
        this.expression = expression;
        this.index = 0;

        Set<String> result = parseExpression();

        List<String> answer = new ArrayList<>(result);
        Collections.sort(answer);

        return answer;
    }

    // Handles UNION:
    // expr = term { ',' term }
    private Set<String> parseExpression() {
        Set<String> result = parseTerm();

        while (index < expression.length()
                && expression.charAt(index) == ',') {

            index++; // skip ','

            Set<String> next = parseTerm();
            result.addAll(next);
        }

        return result;
    }

    // Handles CONCATENATION:
    // term = factor factor factor ...
    private Set<String> parseTerm() {
        Set<String> result = new HashSet<>();
        result.add("");

        while (index < expression.length()
                && expression.charAt(index) != '}'
                && expression.charAt(index) != ',') {

            Set<String> next = parseFactor();

            result = concatenate(result, next);
        }

        return result;
    }

    // Handles:
    // - single letter
    // - {...}
    private Set<String> parseFactor() {

        // Single lowercase letter
        if (Character.isLetter(expression.charAt(index))) {

            Set<String> result = new HashSet<>();

            result.add(String.valueOf(expression.charAt(index)));

            index++;

            return result;
        }

        // Braced expression
        index++; // skip '{'

        Set<String> result = parseExpression();

        index++; // skip '}'

        return result;
    }

    // Cartesian product + concatenation
    private Set<String> concatenate(Set<String> a, Set<String> b) {

        Set<String> result = new HashSet<>();

        for (String x : a) {
            for (String y : b) {
                result.add(x + y);
            }
        }

        return result;
    }
}
```

---

[View on LeetCode](https://leetcode.com/problems/brace-expansion-ii/)