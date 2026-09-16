# GSQ13

![Difficulty](https://img.shields.io/badge/Difficulty-Medium-yellow)

## Problem

### Constraints

Listen

 **Constraints**  provide details about the usage of a column and are applied after specifying the column's data type.
They enable the database to reject any inserted data that violates a particular constraint.
The following statement is used to impose constraints on the "student" table.

Below is the query to create a table student with a set of constraints.

```
     CREATE TABLE  student(
     student_id INTEGER PRIMARY KEY,
     student_Name TEXT UNIQUE,
     department TEXT NOT NULL CHECK (department IN ('CSE', 'ECE', 'EEE'))); 

```

- PRIMARY KEY can be utilized to uniquely identify a row in a table. When attempting to insert a row with the same value as an existing row in the table, a constraint violation will occur, preventing the insertion of the new row.
- UNIQUE columns contain distinct values for each row, similar to "PRIMARY KEY" columns, but unlike primary key columns, a table can have multiple unique columns..
- NOT NULL columns must have a value assigned to them. When attempting to insert a row without providing a value for a "NOT NULL" column, a constraint violation will occur, preventing the insertion of the new row.
- CHECK constraint is used to enforce specific conditions on column values in a table. It ensures that only valid data that meets the defined condition can be inserted or updated in the column. If a value violates the condition, the database rejects the operation. Example: department TEXT CHECK (department IN ('CSE', 'ECE', 'EEE')) This ensures that the department column can only contain the values 'CSE', 'ECE', or 'EEE'. Any attempt to insert or update a value outside this list will result in an error.
### Task

Write a query to create a table employee with the mentioned constraints on the columns :

- employee_id - INTEGER PRIMARY KEY,
- employee_Name - TEXT UNIQUE,
- department - TEXT NOT NULL CHECK (department IN ('Sales', 'Finance', 'Operations'))

## Solution

**Language:** SQL  
**Runtime:** N/A  
**Memory:** N/A  
**Submitted:** 2026-09-16T14:53:08.112Z  

```sql
/* Solution as follows */ 

 CREATE TABLE  employee(
     employee_id INTEGER PRIMARY KEY,
     employee_Name TEXT UNIQUE,
     department TEXT NOT NULL CHECK (department IN ('Sales', 'Finance', 'Operations'))
  );
```

---

[View on CodeChef](https://www.codechef.com/problems/GSQ13)