--Views are Virtual table that hold data of one or more tables.
--It is just set of queries
--Views are used for security purpose i.e,Views restrict the user from viewing certain columns and rows.
--Types of view 1. User-Defined 2. System-Defined


SELECT * FROM Employee
SELECT * FROM Department

--1.User Defined Types

CREATE VIEW vwEmployee
AS
SELECT * FROM Employee

SELECT * FROM vwEmployee
--We can abstract the salary part, so that our employee salary should be visible in view
CREATE VIEW vwEmployee1
AS
SELECT Name,Gender,DepartmentId FROM Employee

SELECT * FROM vwEmployee1

--We can select columns from a table with specific conditions. The following example demonstrates that.
CREATE VIEW vwEmployee2
AS
SELECT * FROM Employee WHERE Salary>55000

SELECT * FROM vwEmployee2

--We can create a view that will hold the columns of different tables. 
CREATE OR ALTER VIEW vwEmployee3
AS
SELECT e.EmployeeId,e.Name,e.Gender,d.DeptName
FROM Employee e
JOIN Department d
ON e.DepartmentId=d.DepartmentId

SELECT * FROM vwEmployee3

DROP VIEW vwEmployee

--Rename view
Sp_Rename vwEmployee3 , vwEmployeeDepartment

Sp_Helptext vwEmployeeDepartment

--We can alter the schema or structure of a view. In other words, we can add or remove some columns or change some conditions that are applied in a predefined view.
ALTER VIEW vwEmployee3
AS
SELECT e.EmployeeId,e.Name,e.Gender,d.DeptName
FROM Employee e
JOIN Department d
ON e.DepartmentId=d.DepartmentId 
WHERE e.EmployeeId>5

SELECT * FROM vwEmployee3

--Refreshing a View in SQL Server
--Let us consider the scenario now by adding a new column to the table Employee_Details and examine the effect. We will first create a view.
CREATE VIEW vwEmployee
AS
SELECT * FROM Employee

SELECT * FROM vwEmployee

--Adding a column in base table
ALTER TABLE Employee
ADD City NVARCHAR(50)

SELECT * FROM Employee --with city column
SELECT * FROM vwEmployee --not having city column

--that means changes in base table won't reflect on the view 
--Now if we want changes in View also then we have to use 'system-defined Stored Procedure sp_refreshview'
Exec sp_refreshview vwEmployee
SELECT * FROM vwEmployee --Now you can see all the changes made in base table aslo reflects on view

-- If we want to prevent any type of change in a base table then we can use the concept of SCHEMABINDING with views
CREATE VIEW vwEmployee4
WITH SCHEMABINDING
AS
SELECT EmployeeId,Name,Gender FROM dbo.Employee

--We find that we cannot change the data type because we used the SCHEMABINDING that prevents any type of change in the base table.

--we can implement DML(INSERT,UPDATE,DELETE) queries but condition are:
--Views should not contain multiple tables,should not contain a set function,should not use distinct keyword/group by,having clauses.
--,should not contain sub query,should not use set operators


--Limitations:
--You cannot pass parameters to a view.
--Problems with DML in views
--cannot be used on temporary tables