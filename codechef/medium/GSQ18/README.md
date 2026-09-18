# GSQ18

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### DISTINCT

Listen

In the  **Flights**  table, what all 'Origins' exist? The following query should give us the result.

```
     Select Origin 
     from Flights;

```

However, if we want to find the  **unique**  origin locations, we will use the  **DISTINCT**  syntax in the following format.

```
     Select Distinct Origin 
     from Flights;

```

Write the above query in the IDE to get the  **unique**  origin locations.
Code it out in the IDE.

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-18T16:33:28.342Z  

```sql
/* Solution as follows */

select DISTINCT Origin 
from Flights;

```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ18)