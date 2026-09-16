/* Solution as follows */ 

 CREATE TABLE  employee(
     employee_id INTEGER PRIMARY KEY,
     employee_Name TEXT UNIQUE,
     department TEXT NOT NULL CHECK (department IN ('Sales', 'Finance', 'Operations'))
  );