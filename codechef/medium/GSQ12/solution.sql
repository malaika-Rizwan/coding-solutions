/* Solution as follows */

UPDATE employee
SET Hourly_Pay = 150    -- Hourly_Pay updated here
WHERE Department = 'Hr';

Select * from employee; -- Output the entire table