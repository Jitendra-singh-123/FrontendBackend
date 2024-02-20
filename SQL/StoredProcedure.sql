CREATE TABLE Employee(
EmployeeId INT PRIMARY KEY Identity(1,1),
Name NVARCHAR(50),
Gender NVARCHAR(5),
Salary money,
DepartmentId INT FOREIGN KEY(DepartmentId) REFERENCES Department ON DELETE CASCADE ON UPDATE CASCADE
);




--Stored Procedure: it is a group of transact SQl. it is having statements which compiles ones and can be used as many times as we want

CREATE TABLE Department(
	DepartmentId INT PRIMARY KEY IDENTITY(1,1),
	DeptName NVARCHAR(50),
);
drop table Department
drop table Employee
INSERT INTO Department VALUEs('Mechanical'),('Electrical'),('Software Engineer'),('Data Analytics')
INSERT INTO Employee VALUES('Rahul','M',45000,2),('Kriti','F',35000,1),('Rohini','F',32000,4)

CREATE Procedure spGetEmployee
AS
BEGIN
SELECT * FROM Employee
END

spGetEmployee

CREATE OR ALTER Procedure spGetEmployeeByGenderAndDepartment (@Gender nvarchar(5),@DepartmentId INT )
AS
BEGIN
 SELECT Name,Gender, DepartmentId FROM Employee WHERE Gender =@Gender
 AND DepartmentId=@DepartmentId
 END

 spGetEmployeeByGenderAndDepartment @Gender='M',@DepartmentID=2
 spGetEmployeeByGenderAndDepartment @DepartmentID=2,@Gender='M'
 spGetEmployeeByGenderAndDepartment 'M',2


 --give text of stored procdure
 
 sp_helptext spGetEmployeeByGenderAndDepartment

 --don't use underscore while writing your own stored procdure as it conflicts with the predefined stored procedure

 --Altering the procedure
 ALTER Procedure spGetEmployeeByGenderAndDepartment (@Gender nvarchar(5),@DepartmentId INT )
AS
BEGIN
 SELECT Name,Gender, DepartmentId FROM Employee WHERE Gender =@Gender
 AND DepartmentId=@DepartmentId Order BY Name
 END

 spGetEmployeeByGenderAndDepartment @Gender='M',@DepartmentID=2

 --To drop procedure
 DROP Proc spGetEmployee

 --We can Encrypt the procedure
 ALTER Procedure spGetEmployeeByGenderAndDepartment 
 @Gender nvarchar(5),
 @DepartmentId INT 
 WITH Encryption
AS
BEGIN
 SELECT Name,Gender, DepartmentId FROM Employee WHERE Gender =@Gender
 AND DepartmentId=@DepartmentId
 END

  --The text for object 'spGetEmployeeByGenderAndDepartment' is encrypted.
 sp_helptext spGetEmployeeByGenderAndDepartment

 spGetEmployeeByGenderAndDepartment @Gender='M',@DepartmentID=2


 --Stored Procedure with output 
 CREATE Procedure spGetEmployeeByCountByGender 
 @Gender nvarchar(5),
 @EmployeeCount INT OUTPUT
AS
BEGIN
	SELECT @EmployeeCount=COUNT(EmployeeId) FROM Employee WHERE Gender = @Gender
 END

 DECLARE @TotalCount INT
 EXECUTE spGetEmployeeByCountByGender 'M', @TotalCount OUTPUT
 PRINT @TotalCount 
 IF(@TotalCount is null)
	PRINT '@TotalCount is NULL'
else
	PRINT '@TotalCount is not NULL'


sp_help spGetEmployeeByCountByGender
sp_help Employee
Employee --Alt+F1


 --Stored Procedure with return
CREATE Proc spGetTotalCount
AS
BEGIN
	return (SELECT COUNT(EmployeeId) FROM Employee)
END

DECLARE @Total int
EXECUTE @Total = spGetTotalCount 
PRINT  @Total


--Return type of stored procedure is integer,
--returns must be used where return type is int whereas output is used for int,nvarchar
CREATE PROC spGetNameById
@Id int
as
BEGIN
	return (SELECT Name FROM Employee WHERE EmployeeId = @Id)
END

--Here error as return try to convert int to nvarchar
DECLARE @Name nvarchar(20)
EXEC @Name = spGetNameById @Id = 4
PRINT  'Name = '  + @Name


--User defined functions
CREATE OR ALTER FUNCTION fnGetEmployeeById
(@Name NVARCHAR(20))
RETURNS INT
BEGIN
	return (SELECT EmployeeId FROM Employee WHERE Name = @Name)
END

SELECT EmployeeID,Name,Salary,Gender FROM Employee 
WHERE EmployeeID  = dbo.fnGetEmployeeById('Rahul');


CREATE OR ALTER FUNCTION fnEmployee(@EmployeeId int)
RETURNS TABLE
	return (SELECT * FROM Employee WHERE EmployeeId = @EmployeeId)

SELECT * FROM dbo.fnEmployee(4);



ALter PROCEDURE spTryCatchDemo (@Id INT)
AS
BEGIN
    BEGIN TRY
        SELECT * FROM Employee WHERE EmployeeId = @Id;
    END TRY
    BEGIN CATCH
        PRINT 'An error occurred';
        PRINT 'Message: ' + ERROR_MESSAGE();
    END CATCH
END;
GO

-- To execute the stored procedure with parameter @Id = 100
EXEC spTryCatchDemo 4;

CREATE OR ALTER PROCEDURE spExample
AS
BEGIN
    BEGIN TRY
        -- Statements that may cause an error
        SELECT 10 / 0; -- This will raise a divide by zero error
    END TRY
    BEGIN CATCH
        -- Error handling logic
        PRINT 'An error occurred: ' + ERROR_MESSAGE();
    END CATCH
END;

spExample


CREATE OR ALTER PROC spExm(@EmployeeId INT = NULL)
AS
BEGIN
	IF @EmployeeId is NULL
		SELECT * FROM Employee;
	IF @EmployeeId iS NOT NULL
	BEGIN
		SELECT * FROM Employee WHERE EmployeeId = @EmployeeId;
		
	END
END
spExm 4


CREATE PROCEDURE spIf (@City nvarchar(20))
as
	IF @City = 'New Delhi'
		PRINT 'Capital of India'
GO

spIF 'New Delhi'



--Here by default value of option is select
CREATE PROCEDURE spEmployees (@option varchar(10) = 'select',
@Id int = null)
as
	IF @option = 'SELECT'
		SELECT * FROM Employee
	IF @option = 'ById'
		SELECT  * FROM	Employee	WHERE 
				EmployeeId = @Id
				
spEmployees 'ById', 4
spEmployees 

 

 --Insert
CREATE OR ALTER PROCEDURE spEmployee1 (
	@option nvarchar(10) = 'select',
	@Id int = null, 
	@Name nvarchar(60) = null, 
	@Gender nvarchar(5) = null, 
	@Salary INT = null
)
AS
	IF @option = 'select'
		SELECT * FROM Employee
	IF @option = 'ById'
		SELECT * FROM Employee WHERE EmployeeId = @Id
	IF @option = 'insert'
		INSERT INTO Employee values (@Name, @Gender, @Salary,3)
GO

spEmployee1 @option = 'select',
	@Name = 'Virat',
	@Gender = 'M',
	@Salary = 900000

CREATE OR ALTER PROC spGetByDeptId
(@option nvarchar(30)='Select',
@DeptId INT 
)
AS
BEGIN
IF @option = 'Select'
	SELECT e.EmployeeId,e.Name,e.Gender,e.Salary,e.DepartmentId,d.DeptName  FROM Employee e
	 JOIN Department d ON e.DepartmentId = @DeptId  WHERE d.DepartmentId= @DeptId;


END

spGetByDeptId 'select',2
