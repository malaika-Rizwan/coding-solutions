/* Solution as follows */

ALTER TABLE customer
ADD COLUMN email TEXT;
INSERT INTO customer(Id,Name,Age,Address,email)
VALUES(1, 'John Smith', 25,  'Main St','john@ex.com'),
(2, 'Sarah Johnson', 30,'Broadway','sarah@ex.com');

select  * from customer;