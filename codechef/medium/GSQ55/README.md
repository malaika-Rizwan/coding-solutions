# GSQ55

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

_Description not available._

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-17T17:14:45.127Z  

```sql
/* Solution as follows */

ALTER TABLE customer
ADD COLUMN email TEXT;
INSERT INTO customer(Id,Name,Age,Address,email)
VALUES(1, 'John Smith', 25,  'Main St','john@ex.com'),
(2, 'Sarah Johnson', 30,'Broadway','sarah@ex.com');

select  * from customer;
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ55)