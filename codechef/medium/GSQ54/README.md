# GSQ54

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

_Description not available._

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-17T17:13:50.275Z  

```sql
/* Solution as follows */

CREATE TABLE customer
(
  Id INT,
  Name TEXT,
  Age INT,
  Address TEXT
);

INSERT INTO customer(Id,Name,Age,Address)
VALUES(1, 'John Smith', 25,  '123 Main St'),
(2, 'Sarah Johnson', 30,'456 Broadway'),
(3, 'Michael Brown', 45, '789 5th Ave'),
(4, 'Jessica Davis', 28, '321 Elm St'),
(5, 'David Lee', 35,  '555 Park Ave');


select  * from customer;
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ54)