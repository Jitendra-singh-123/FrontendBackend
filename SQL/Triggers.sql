CREATE TABLE AUDIT(
Id INT PRIMARY KEY IDENTITY(1,1),
AuditInfo NVARCHAR(MAX)
);

EXEC sp_rename 'AUDIT', 'AuditTriggers';

--A trigger is a special type of stored procedure that automatically executes in response to certain events or actions that occur in a database
--Types of Triggers are: 
--DML,DDL,CLR,Logon

--DML Triggers
--For Insert
CREATE TRIGGER tr_Employee_ForInsert
ON Employee
FOR INSERT
AS
BEGIN
	DECLARE @Id INT
	SELECT  @Id = EmployeeId FROM Inserted

	INSERT INTO AuditTriggers VALUES('New Employee with Id = ' + CAST(@Id AS NVARCHAR(5)) + ' is added at ' + CAST(GETDATE() AS NVARCHAR(20)))
END

INSERT INTO Employee VALUES('Ben','M',98888,2,'Dehradun')

SELECT * FROM Employee
SELECT * FROM AuditTriggers

--For Deleted
ALTER TRIGGER tr_Employee_ForDeleted
ON Employee
FOR DELETE
AS
BEGIN
	DECLARE @Id INT
	SELECT  @Id = EmployeeId FROM deleted

	INSERT INTO AuditTriggers VALUES('An Existing employee with Id = ' + CAST(@Id AS NVARCHAR(5)) + ' is deleted at ' + CAST(GETDATE() AS NVARCHAR(20)))
END

DELETE FROM Employee Where EmployeeId = 7

SELECT * FROM Employee
SELECT * FROM AuditTriggers

sp_rename 'Employee.EmployeeId','Id','COLUMN';
--The update trigger use both inserted and deleted table,
--the inserted table contains the updated data and the deleted table contains the old data.

CREATE OR ALTER TRIGGER Employee_ForUpdate
ON Employee
FOR UPDATE
AS
BEGIN
    DECLARE @AuditString NVARCHAR(MAX)

    SELECT 
        @AuditString = 'Employee With Id = ' + CAST(d.EmployeeId AS NVARCHAR(4)) + ' Changed'
        + CASE WHEN i.Name <> d.Name THEN ' Name From ' + d.Name + ' to ' + i.Name ELSE '' END
        + CASE WHEN i.Gender <> d.Gender THEN ' Gender From ' + d.Gender + ' to ' + i.Gender ELSE '' END
        + CASE WHEN i.Salary <> d.Salary THEN ' Salary From ' + CAST(d.Salary AS NVARCHAR(10)) + ' to ' + CAST(i.Salary AS NVARCHAR(10)) ELSE '' END
        + CASE WHEN i.DepartmentId <> d.DepartmentId THEN ' DepartmentId From ' + CAST(d.DepartmentId AS NVARCHAR(10)) + ' to ' + CAST(i.DepartmentId AS NVARCHAR(10)) ELSE '' END
        
    FROM 
        inserted i
    INNER JOIN 
        deleted d ON i.EmployeeId = d.EmployeeId

    INSERT INTO AuditTriggers
    VALUES (@AuditString)
END

UPDATE  Employee
SET Name ='Preeti',Gender='F',Salary=110000 WHERE EmployeeID = 6

SELECT * FROM Employee
SELECT * FROM AuditTriggers

--Use of delete for backlog
CREATE TABLE BackLog(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeId INT,
Name NVARCHAR(20),
Gender NVARCHAR(5),
Salary Money,
DeptID INT,
City NVARCHAR(20)
);

CREATE TRIGGER tr_EmployeeBacklog
ON Employee
AFTER DELETE
AS
BEGIN
	DECLARE @Id INT
	DECLARE @Name NVARCHAR(20)
	DECLARE @Gender NVARCHAR(20)
	DECLARE @Salary Money
	DECLARE @DeptId INT
	DECLARE @City NVARCHAR(20)


	SELECT @Id = EmployeeId,@Name=name,@Gender=Gender,@Salary=Salary,@DeptId=DepartmentId,@City=City FROM DELETED

	INSERT INTO BackLog VALUES(@Id,@Name,@Gender,@Salary,@DeptId,@City)

END


DELETE FROM Employee WHERE EmployeeId=4

SELECT * FROM Employee
SELECT * FROM BackLog
SELECT * FROM Department