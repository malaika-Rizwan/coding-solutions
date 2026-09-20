# GSQ27

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### Debug this query

Listen

Let us now debug a query which tests what we learnt in this sub-module -  **AND, OR & LIKE**.

You are given a query which is trying to output entries that meets both the conditions

- Passenger gender - Female AND
- Flight destination - Delhi

```
Expected Output
┌──────────────┬────────────────┬────────┬────────┬─────────────┐
│ Passenger_id │ Passenger_name │ Gender │ Origin │ Destination │
├──────────────┼────────────────┼────────┼────────┼─────────────┤
│ 10002        │ Riya           │ Female │ Mumbai │ Delhi       │
└──────────────┴────────────────┴────────┴────────┴─────────────┘

```

However - the query is giving an incorrect output. Fix the query to solve the problem.

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-20T15:50:04.065Z  

```sql
select *from flights
where Gender='Female'
and destination like'delhi'
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ27)