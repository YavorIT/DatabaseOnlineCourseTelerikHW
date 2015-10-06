USE TelerikAcademy

--1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--	 Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS Name, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)


--2. Write a SQL query to find the names and salaries of the employees that have a salary 
--	 that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS Name, Salary
FROM Employees
WHERE Salary <= (SELECT MIN(Salary) + ((MIN(Salary)/100) * 10)  FROM Employees)


--3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--   Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, d.Name
FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees
	WHERE e.DepartmentID = DepartmentID)


--4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary)
FROM Employees e
WHERE e.DepartmentID = 1


--5. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary)
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT d.DepartmentID FROM Departments d
	WHERE d.Name = 'Sales')


--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*)
FROM Employees e
WHERE e.DepartmentID = 
	(SELECT d.DepartmentID FROM Departments d
	WHERE d.Name = 'Sales')


--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees
WHERE  NOT ManagerID IS NULL


--8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*)
FROM Employees
WHERE ManagerID IS NULL


--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name, AVG(e.Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name, t.Name, COUNT(*) AS [Employee Count]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY d.Name, t.Name


--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT FirstName, LastName
FROM Employees m
WHERE (SELECT COUNT(*) FROM Employees e
	   WHERE e.ManagerID = m.EmployeeID) = 5


--12. Write a SQL query to find all employees along with their managers.
--    For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS [Employee], COALESCE(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Manager]
FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID


--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
--	  Use the built-in LEN(str) function.
SELECT FirstName + ' ' + LastName AS Employee
FROM Employees
WHERE LEN(LastName) = 5


--14. Write a SQL query to display the current date and time in the following format 
--	  "day.month.year hour:minutes:seconds:milliseconds".
--	  Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(nvarchar(50), GETDATE(), 13) AS [Current Date]


--15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--	  Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--	  Define the primary key column as identity to facilitate inserting records.
--	  Define unique constraint to avoid repeating usernames.
--	  Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
	UserID int IDENTITY PRIMARY KEY,
	Username nvarchar(100) NOT NULL UNIQUE, 
	Pass nvarchar(100) NOT NULL CHECK(LEN(Pass) >= 5),
	FullName nvarchar(100) NOT NULL,
	LastLogin DATETIME
	)
GO -- The Go Statement here is to make the program not underline the next CREATE VIEW command


--16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--	  Test if the view works correctly.
CREATE VIEW [Today Logins] AS
SELECT FullName
FROM Users
WHERE LastLogin = GETDATE()

GO -- Same as the last GO statement

--17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--	  Define primary key and identity column.
CREATE TABLE [Groups] (
	GroupID int IDENTITY PRIMARY KEY,
	Name nvarchar(100) NOT NULL
)


-- 18. Write a SQL statement to add a column GroupID to the table Users.
--	   Fill some data in this new column and as well in the `Groups table.
--	   Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users ADD GroupID int
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups (GroupID)


--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users (Username, Pass, FullName, LastLogin, GroupID)
VALUES ('J.Smith', 'MyPass', 'John Smith', 2014/05/05, 1)
	
INSERT INTO Groups (Name)
VALUES ('First')


--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users 
SET  Username = 'John S'
WHERE FullName = 'John Smith'

-- Set the first group's name to be "First"
UPDATE Groups
SET Name = 'First'
WHERE GroupID = 1
-- Ser the second groups's name to be "Second"
UPDATE Groups
SET Name = 'Second'
WHERE GroupID = 2


--21. Write SQL statements to delete some of the records from the Users and Groups tables.

-- First drop the Foreign Key constraint
ALTER TABLE Users 
DROP CONSTRAINT FK_Users_Groups

-- Then delete the data
DELETE FROM Groups
WHERE GroupID = 1

-- delete data from users
DELETE FROM Users 
WHERE FullName = 'John Smith'


--22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--    Combine the first and last names as a full name.
--    For username use the first letter of the first name + the last name (in lowercase).
--    Use the same for the password, and NULL for last login time.
INSERT INTO Users (Username, Pass, FullName)
	(SELECT LOWER (CONCAT(LEFT(FirstName, 3), LastName)), -- Username - Using 3 letter because of the unique constraint
			LOWER (CONCAT(FirstName, LastName)), -- For the password i have used more than only the first letter because of the check constraint to have more than 5 symbols but some of the names are less than that
			CONCAT(FirstName, ' ', LastName) -- FullName
	FROM Employees)


--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET Pass = NULL -- 
WHERE LastLogin <= CONVERT(DATETIME, '10.03.2010', 103)
-- Gives an error because in the create table statement i have set the pass to be not null


--24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Pass IS NULL


--25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS [Department], e.JobTitle, AVG(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle


--26. Write a SQL query to display the minimal employee salary
--	  by department and job title along with the name of some of the employees that take it.
SELECT MIN(e.Salary) AS [Minimal Salary], e.FirstName + ' ' + e.LastName AS [Employee], d.Name, e.JobTitle
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = D.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName


--27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC


--28. Write a SQL query to display the number of managers from each town.
SELECT COUNT(*) AS [Managers Count], t.Name
FROM Employees m
	JOIN Addresses a
		ON m.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
WHERE NOT m.EmployeeID IS NULL
GROUP BY t.Name


--29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--	  Don't forget to define identity, primary key and appropriate foreign key.
--	  Issue few SQL statements to insert, update and delete of some data in the table.
--	  Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--	  For each change keep the old record data, the new record data and the command (insert / update / delete).

-- Create Table
CREATE TABLE WorkHours (
	ReportID int IDENTITY PRIMARY KEY, 
	EmployeeID int,
	CurrentDate DATETIME NOT NULL,
	Task ntext NOT NULL,
	HoursWorked int,
	Comments ntext 

	CONSTRAINT FK_Employees_WorkHours 
		FOREIGN KEY (EmployeeID)
		REFERENCES Employees(EmployeeID)
)

-- Insert Data
INSERT INTO WorkHours (EmployeeID, CurrentDate, Task, HoursWorked, Comments)
VALUES (3, CONVERT(DATETIME, '06.10.2015', 104), 'Update the site', 3, 'Everything is done properly')

INSERT INTO WorkHours (EmployeeID, CurrentDate, Task, HoursWorked, Comments)
VALUES (7, 2015/11/13, 'Test Application', 2, 'Good job')

-- Update Data
UPDATE WorkHours
SET HoursWorked = 5
WHERE ReportID = 2


UPDATE WorkHours
SET EmployeeID = 16
WHERE ReportID = 1


-- Delete Data
DELETE FROM WorkHours
WHERE ReportID = 2


-- New Table 
CREATE TABLE WorkHoursLogs (
	LogID int IDENTITY PRIMARY KEY,
	OldRecordDate DATETIME,
	NewRecordDate DATETIME,
	Command nvarchar(50) NOT NULL
)

GO -- This GO statement is for the create trigger statement (Same thing as the CREATE VIEW)

-- set Triggers 

		--INSERT
CREATE TRIGGER TR_Insert ON WorkHours FOR INSERT AS
INSERT INTO WorkHoursLogs(OldRecordDate, NewRecordDate, Command)
	SELECT CurrentDate, GETDATE(), 'Insert'
	FROM inserted

GO

		--DELETE
CREATE TRIGGER TR_Delete ON WorkHours FOR DELETE AS
INSERT INTO WorkHoursLogs(OldRecordDate, NewRecordDate, Command)
	SELECT CurrentDate, GETDATE(), 'Delete'
	FROM deleted

GO

		--UPDATE
CREATE TRIGGER TR_Update ON WorkHours FOR UPDATE AS
INSERT INTO WorkHoursLogs(OldRecordDate, NewRecordDate, Command)
	SELECT CurrentDate, GETDATE(), 'Update'
	FROM Inserted

INSERT INTO WorkHoursLogs(OldRecordDate, NewRecordDate, Command)
	SELECT CurrentDate, GETDATE(), 'Update'
	FROM deleted

GO


-- Let's Test the triggers
INSERT INTO WorkHours (EmployeeID ,CurrentDate, Task, HoursWorked, Comments)
VALUES (14, CONVERT(DATETIME, '06.10.2015', 104), 'Update the news section', 1, 'Done')

-- Update gives two messages because it makes one for inserting the new data and one for deleting the old data
UPDATE WorkHours
SET HoursWorked = 2
WHERE EmployeeID = 14


DELETE FROM WorkHours
WHERE EmployeeID = 14


--30. Start a database transaction, delete all employees from the 'Sales' department 
--	  along with all dependent records from the other tables.
--	  At the end rollback the transaction.

BEGIN TRAN
ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees
DELETE FROM Employees
WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales') 
ROLLBACK TRAN



--31. Start a database transaction and drop the table EmployeesProjects.
--	  Now how you could restore back the lost table data?
BEGIN TRAN 
DROP TABLE EmployeesProjects
ROLLBACK TRAN


--32. Find how to use temporary tables in SQL Server.
--	  Using temporary tables backup all records from EmployeesProjects 
--	  and restore them back after dropping and re-creating the table.
SELECT *
	INTO #EmpProjTemp
	FROM EmployeesProjects

	DROP TABLE EmployeesProjects

SELECT *
	INTO EmployeesProjects
	FROM #EmpProjTemp

	DROP TABLE #EmpProjTemp


