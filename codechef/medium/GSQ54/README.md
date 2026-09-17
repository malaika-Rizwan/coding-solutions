# GSQ54

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### Practice - Alter Table and Insert Data

Listen

Existing table - 'customer' with column headers and 0 rows.

```
┌────┬───────────────┬─────┬──────────┐
│ Id │     Name      │ Age │ Address  │
└────┴───────────────┴─────┴──────────┘

```

### Task

Write a query which does the following

- Take the table given above and add an additional column 'email' to the table 'customer'.
- Consider the table 'customer' to be empty and insert the below data
- Output all the entires in the table.
### Expected output

```
┌────┬───────────────┬─────┬──────────┬──────────────┐
│ Id │     Name      │ Age │ Address  │    email     │
├────┼───────────────┼─────┼──────────┼──────────────┤
│ 1  │ John Smith    │ 25  │ Main St  │ john@ex.com  │
│ 2  │ Sarah Johnson │ 30  │ Broadway │ sarah@ex.com │
└────┴───────────────┴─────┴──────────┴──────────────┘

```

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-17T17:14:03.288Z  

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

[View on CodeChef](https://www.codechef.com/problems/GSQ54)