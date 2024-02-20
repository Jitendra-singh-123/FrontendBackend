--Indexes
--An index in a table search the data very quickly as compared to table scan

CREATE INDEX IX_Employee_Salary
ON Employee (Salary ASC)

sp_helpindex Employee

drop index Employee.IX_Employee_Salary

SELECT * FROM Employee WHERE Salary > 50000


--Clustered index
--A B-Tree (computed) clustered index is the Index that will arrange the rows physically in the memory in sorted order.

--An advantage of a clustered index is that searching for a range of values will be fast.
--A clustered index is internally maintained using a B-Tree data structure leaf node of the btree of the clustered Index will contain the table data;
--you can create only one clustered Index for a table.

--A clustered index is created only when both the following conditions are satisfied:

--The data or file, that you are moving into secondary memory should be in sequential or sorted order.
--There should be a key value, meaning it can not have repeated values

--NOTE: You can have only one clustered index in one table, 
--but you can have one clustered index on multiple columns(which will affect and lose the clustering of primary key(EmployeeId)), and that type of index is called a composite index. 

SELECT * FROM Employee
--we are creating clustering for multiple columns
CREATE CLUSTERED INDEX IX_Employee_Gender_Salary
ON Employee(Gender DESC,Salary ASC)

SELECT * FROM Employee WHERE Salary = 89900




--Non clustered
--A nonclustered index is an index that will not arrange the rows physically in the memory in sorted order.
CREATE NONCLUSTERED INDEX IX_Employee_Name
ON Employee(Name ASC)

SELECT * FROM Employee WHERE Name = 'Rahul'


--Main Difference between clustering and non clustering
--1. Only one Clustered index per table,where as you can have more than one non-clustered index
--2. clustered index are faster because the non-clustered index has to refer back to the table, if the selected column is not present in the index
--non clustered index having separate table with row address pointing on main table
--CREATE NONCLUSTERED INDEX IX_Employee_Name
--ON Employee(Name ASC)

--Like on above, a separate table created having name as column and one pointer pointing to main table so that we can fetch other data associated to name




