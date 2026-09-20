# GSQ27

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

_Description not available._

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-20T15:42:01.053Z  

```sql
/* write a query with the following conditions
- Destination city end in 'o' AND
- Origin city starts with 'M' 
*/

select *from flights
where Destination like '%o'
and Origin like 'm%'

```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ27)