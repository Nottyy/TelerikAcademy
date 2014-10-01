--01.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
--Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--02.Write a SQL query to find the names and salaries of the employees that have a salary
--that is up to 10% higher than the minimal salary for the company.
DECLARE @MinSalary int
SET @MinSalary = (SELECT MIN(Salary) FROM Employees)
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN @MinSalary AND @MinSalary * 1.1

--03.Write a SQL query to find the full name, salary and department of the employees 
--that take the minimal salary in their department. Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS [FULL NAME], e.Salary, d.Name
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE Salary = (SELECT MIN(Salary) FROM Employees em WHERE em.DepartmentID = e.DepartmentID)

--04.Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary)
FROM Employees
WHERE DepartmentID = 1

--05.Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--06.Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--07.Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(*)
FROM Employees e, Employees em
WHERE em.ManagerID = e.EmployeeID

--08.Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(em.FirstName) - COUNT(m.FirstName) 
FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID

--09.Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name as DepName, AVG(Salary) as [Average Salary]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS DepName, t.Name AS TownName, COUNT(*) AS EmployeeCount
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t 
ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY EmployeeCount

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT e1.FirstName, e1.LastName
FROM Employees e1
JOIN Employees e2
ON e2.ManagerID = e1.EmployeeID
GROUP BY e1.FirstName, e1.LastName
HAVING COUNT(*) = 5

--12.Write a SQL query to find all employees along with their managers.
--For employees that do not have manager display the value "(no manager)".
SELECT e1.FirstName + ' ' + e1.LastName AS EmployeeName, COALESCE(e2.FirstName + ' ' + e2.LastName, '[no manager]') AS ManagerName 
FROM Employees e1
LEFT JOIN Employees e2
ON e1.ManagerID = e2.EmployeeID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
--Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--14.Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds". 
--Search in  Google to find how to format dates in SQL Server.
SELECT Convert(nvarchar(50),GetDate(),113)

--15.Write a SQL statement to create a table Users.
-- Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields. 
-- Define a primary key column with a primary key constraint.
-- Define the primary key column as identity to facilitate inserting records. 
-- Define unique constraint to avoid repeating usernames. 
-- Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
UserID int IDENTITY NOT NULL,
UserName nvarchar(50) NOT NULL,
Password nvarchar(50) NOT NULL,
FullName nvarchar(50) NOT NULL,
LastLogin smalldatetime NOT NULL,
CONSTRAINT PK_USERS PRIMARY KEY (UserID),
CONSTRAINT UNQ_USERS UNIQUE(UserName),
CONSTRAINT CHECK_USER_PASSWORD CHECK (LEN(Password) > 5)
)

--16.Write a SQL statement to create a view that displays the users from the Users table
--that have been in the system today. Test if the view works correctly.
CREATE VIEW [Users from today] AS
SELECT * 
FROM Users
WHERE DAY(LastLogin) = DAY(getdate())

--17.Write a SQL statement to create a table Groups. 
--Groups should have unique name (use unique constraint). 
--Define primary key and identity column.
CREATE TABLE GROUPS(
GroupID int IDENTITY NOT NULL,
Name nvarchar(50) NOT NULL,
CONSTRAINT UNQ_NAME UNIQUE(Name),
CONSTRAINT PK_GROUPS PRIMARY KEY(GroupID)
)

--18.Write a SQL statement to add a column GroupID to the table Users. 
--Fill some data in this new column and as well in the Groups table. 
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE USERS
ADD GroupID int

ALTER TABLE USERS
ADD CONSTRAINT FK_Users_GROUPS FOREIGN KEY(GroupID) REFERENCES GROUPS(GroupID)

--19.Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users(UserName,Password,FullName,LastLogin,GroupID)
VALUES
('Stancho', 123456, 'StanchoStanchov',GETDATE(),1),
('Adam', 123456, 'AdamNaEva',GETDATE(),1),
('Eva', 123456, 'EvaNaAdam',GETDATE(),2),
('Asparuh', 123456, 'AsparuhNikodimov',GETDATE(),1),
('Valeri', 123456, 'ValeriBojinov',GETDATE(),4)

INSERT INTO GROUPS(Name)
VALUES
('History'),
('Geography'),
('Maths'),
('Chemistry')

--20.Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE GROUPS
SET Name = 'Physics'
WHERE Name = 'History'

UPDATE Users
SET UserName = 'Pafishaa', FullName = 'PafishaMiladinovichh', Password = 9292929292
WHERE UserName = 'Valeri'

--21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE
FROM GROUPS
WHERE Name = 'Grupa5'

DELETE
FROM Users
WHERE UserID = 1

--22.Write SQL statements to insert in the Users table the names of all employees
--from the Employees table. Combine the first and last names as a full name. 
--For username use the first letter of the first name + the last name (in lowercase). 
--Use the same for the password, and NULL for last login time.

INSERT INTO Users(Username, Password, FullName, LastLogin)
SELECT FirstName + ' ' + LastName, 
	   123456677, 
	   LOWER(SUBSTRING(FirstName, 0, 1) + LastName),
	   getdate()
FROM Employees

--23.Write a SQL statement that changes the password to NULL for all users that 
--have not been in the system since 10.03.2010.
UPDATE
Users
SET Password = 11111111111111111
WHERE LastLogin < CAST('10.03.2010' AS smalldatetime)

--24.Write a SQL statement that deletes all users without passwords (NULL password).
DELETE
FROM Users
WHERE Password = 11111111111111111

--25.Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS DepName, e.JobTitle, AVG(Salary)
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY DepName

--26.Write a SQL query to display the minimal employee salary by department 
--and job title along with the name of some of the employees that take it.
SELECT d.Name AS DepName, e.JobTitle, MIN(e.Salary), e.FirstName
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName
ORDER BY DepName

--27.Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(e.FirstName)
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--28.Write a SQL query to display the number of managers from each town.
SELECT t.Name as Town, COUNT(e.ManagerID) AS ManagersCount
FROM Employees e
JOIN Addresses a
ON a.AddressID = e.AddressID
JOIN Towns t
ON t.TownID = a.TownID
WHERE e.EmployeeID IN (SELECT ManagerID FROM Employees)
GROUP BY t.Name

--29.Write a SQL to create table WorkHours to store work reports for each employee 
--(employee id, date, task, hours, comments). Don't forget to define  identity, 
--primary key and appropriate foreign key. 
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours(
EmployeeID int IDENTITY,
[Date] DATETIME,
Tasks nvarchar(50),
[Hours] int,
Comments nvarchar(50),
CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours([Date], Tasks, [Hours], Comments)
VALUES
(GETDATE(),'Sample Task1', 10, 'Sample Comment1'),
(GETDATE(),'Sample Task2', 13, 'Sample Comment2'),
(GETDATE(),'Sample Task3', 12, 'Sample Comment3')

UPDATE WorkHours
SET [Hours] = 4
WHERE [Hours] = 10

UPDATE WorkHours
SET Tasks = 'Task Changed'
WHERE Tasks LIKE '%k3'

DELETE
FROM WorkHours
WHERE Comments LIKE '%ent3'

CREATE TABLE WorkHoursLog(
ID int IDENTITY PRIMARY KEY,
OldRecord nvarchar(50) NOT NULL,
NewRecord nvarchar(50) NOT NULL,
Command nvarchar(50) NOT NULL,
EmployeeID int NOT NULL
CONSTRAINT FK_WorkHoursLog_WorkHours FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

ALTER TRIGGER TR_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Tasks + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comments FROM Deleted),
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Tasks + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comments FROM Inserted),
		   'UPDATE',
		   (SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Tasks + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comments FROM Deleted),
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Tasks + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comments FROM Inserted),
		   'UPDATE',
		   (SELECT EmployeeID FROM Inserted))
GO

ALTER TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Tasks + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comments FROM Deleted),
		   ' ',
		   'DELETE',
		   (SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours([Date], Tasks, Hours, Comments)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')

DELETE FROM WorkHours
WHERE Tasks = 'Random task3'

UPDATE WorkHours
SET Tasks = 'Random task12'
WHERE EmployeeID = 8

--30.Start a database transaction, delete all employees from the 'Sales' 
--department along with all dependent records from the pother tables. At the end rollback the transaction.
BEGIN TRAN
DELETE FROM Employees
	SELECT d.Name
	FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

--TASK 31 Start a database transaction and drop the table EmployeesProjects. 
--Now how you could restore back the lost table data?
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

--TASK 32 Find how to use temporary tables in SQL Server. Using temporary tables 
--backup all records from EmployeesProjects and restore them back after dropping 
--and re-creating the table.
CREATE TABLE #TemporaryTable(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
	SELECT EmployeeID, ProjectID
	FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable