# GSQ55

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### Practice - Update Single Record

Listen

Write a query which does the following

- Update the age to 52 for the customer with customer id 3.
- Output all the entires of the table.
- Original table has the following rows

```
┌────┬───────────────┬─────┬──────────────┬───────────────────────────┐
│ Id │     Name      │ Age │   Address    │           email           │
├────┼───────────────┼─────┼──────────────┼───────────────────────────┤
│ 1  │ John Smith    │ 25  │ 123 Main St  │ john@example.com          │
│ 2  │ Sarah Johnson │ 30  │ 456 Broadway │ sarah@example.com         │
│ 3  │ Michael Brown │ 45  │ 789 5th Ave  │ michael.brown@example.com │
│ 4  │ Jessica Davis │ 28  │ 321 Elm St   │ jessica.davis@example.com │
│ 5  │ David Lee     │ 35  │ 555 Park Ave │ David@example.com         │
└────┴───────────────┴─────┴──────────────┴───────────────────────────┘

```

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-17T17:14:57.046Z  

```sql
/* Solution as follows */

UPDATE customer
SET Age = 52
WHERE Id = 3;

select  * from customer;
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ55)