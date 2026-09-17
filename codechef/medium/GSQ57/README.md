# GSQ57

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### Practice - Create Table with Constraints

Listen

The Query written in the console is trying to create a table and add data to the same.
 **Debug this query**  to execute it successfully!

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-17T17:16:31.191Z  

```sql
/* Solution as follows */

CREATE TABLE customer
(
  Id INT PRIMARY KEY,
  Name VARCHAR(30),
  Age INT,
  Address VARCHAR(30),
  email VARCHAR(30) UNIQUE
);
INSERT INTO customer(Id,Name,Age,Address,email)
VALUES  (1, 'John Smith', 25,  '123 Main St','john@example.com'),
        (2, 'Sarah Johnson', 30,'456 Broadway','sarah@example.com'),
        (3, 'Michael Brown', 45,  '789 5th Ave','michael@example.com'),
        (4, 'Jessica Davis', 28,  '321 Elm St','vy@example.com');
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ57)