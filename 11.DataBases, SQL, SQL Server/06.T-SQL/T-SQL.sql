USE TelerikAcademy
--01.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) 
--and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
--Write a stored procedure that selects the full names of all persons.

CREATE TABLE Persons(
PersonID int IDENTITY PRIMARY KEY NOT NULL,
FirstName nvarchar(50),
LastName nvarchar(50),
SSN nvarchar(50)
)

CREATE TABLE Accounts(
AccountID int IDENTITY PRIMARY KEY NOT NULL,
PersonID int,
Balance money,
CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
)

INSERT INTO Persons(FirstName, LastName, SSN)
VALUES
('Gosho','Ivanov','101010101'),
('Ivan','Ivanov','101010101'),
('Stamen','Krantev','101010101'),
('Bai','Pesho','101010101'),
('Bai','Ignat','101010101')

INSERT INTO Accounts(PersonID, Balance)
VALUES
(1, 500000),
(2, 10000),
(3, 2000),
(4, 6000),
(5, 100)

CREATE PROC usp_SelectPersonsNames
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO

EXEC usp_SelectPersonsNames

--02.Create a stored procedure that accepts a number as a parameter 
--and returns all persons who have more money in their accounts than the supplied number.
CREATE PROC usp_GetPeopleWithHigherBalance(@BalanceComparer int = 5000)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM Persons p
	JOIN Accounts a
	ON p.PersonID = a.PersonID
	WHERE a.Balance > @BalanceComparer
	ORDER BY Balance 
GO

EXEC usp_GetPeopleWithHigherBalance 9999

--03.Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--It should calculate and return the new sum. 
--Write a SELECT to test whether the function works as expected.
CREATE PROC usp_CalculateInterestSumForNMonths(
@Sum INT = 1000,
@Interest INT = 2,
@Months INT =  12,
@Result INT OUTPUT)
AS
	SET @Result = (@Sum + ((@Sum * @Interest) / 100)) * @Months
GO

DECLARE @Result int
EXEC usp_CalculateInterestSumForNMonths 2000, 5, 20, @Result OUTPUT
SELECT @Result 

--04.Create a stored procedure that uses the function from the previous example 
--to give an interest to a person's account for one month. 
--It should take the AccountId and the interest rate as parameters.
CREATE PROC usp_GiveInterestToAPerson(@PersonID int = 1, @Interest int = 2,@Result money OUTPUT)
AS
	Declare @PersonBalanceByID int
	SET @PersonBalanceByID  = (
	SELECT a.Balance
	FROM Persons p
	JOIN Accounts a
	ON p.PersonID = a.PersonID AND p.PersonID = @PersonID)

	EXEC usp_CalculateInterestSumForNMonths @PersonBalanceByID, @Interest, 12, @Result OUTPUT
GO

DECLARE @Result money
EXEC usp_GiveInterestToAPerson 5, 2, @Result OUTPUT
SELECT @Result AS [Person Money After Accumulating Interest Rate]

--05.Add two more stored procedures WithdrawMoney( AccountId, money) 
-- and DepositMoney (AccountId, money) that operate in transactions.
CREATE PROC usp_WithdrawMoney(@AccountID INT, @MoneyAmount MONEY, @Result MONEY OUTPUT)
AS
	DECLARE @CurrentBalance MONEY
	SET @CurrentBalance = (
		SELECT a.Balance
		FROM Accounts a
		WHERE a.AccountID = @AccountID
	)

	SET @Result = @CurrentBalance - @MoneyAmount

	UPDATE Accounts
	SET Balance = @Result
	WHERE AccountID = @AccountID
GO

DECLARE @MoneyAmount MONEY
EXEC usp_WithdrawMoney 5, 50, @MoneyAmount OUTPUT
SELECT @MoneyAmount [Balance after Withdraw]

-----------------------------------------------------
CREATE PROC usp_DepositMoney(@AccountID INT, @MoneyAmount MONEY, @Result MONEY OUTPUT)
AS
	DECLARE @CurrentBalance MONEY
	SET @CurrentBalance = (
		SELECT a.Balance
		FROM Accounts a
		WHERE a.AccountID = @AccountID
	)

	SET @Result = @CurrentBalance + @MoneyAmount

	UPDATE Accounts
	SET Balance = @Result
	WHERE AccountID = @AccountID
GO

DECLARE @MoneyAmount MONEY
EXEC usp_DepositMoney 5, 5000, @MoneyAmount OUTPUT
SELECT @MoneyAmount AS [Balance after Deposit]

--06.Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
--Add a trigger to the Accounts table that enters a new entry into 
--the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
LogID INT IDENTITY PRIMARY KEY NOT NULL,
AccountID INT,
OldSum MONEY,
NewSum MONEY,
CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID)
)

CREATE TRIGGER tr_UpdateBalance ON Accounts FOR UPDATE
AS
	BEGIN
	INSERT INTO Logs 
		SELECT a.AccountID AS AccountID,
		a.Balance AS NewSum
	FROM INSERTED a
	END
GO

CREATE TRIGGER tr_AccountsUpdate ON dbo.Accounts FOR UPDATE
AS
        BEGIN
        INSERT INTO Logs(AccountID, OldSum, NewSum)
                SELECT i.AccountID, d.Balance, i.Balance
				FROM deleted AS d
				JOIN inserted AS i
				ON d.AccountID = i.AccountID
        END
GO

DECLARE @Result MONEY
EXEC usp_DepositMoney 5, 33, @Result OUTPUT
SELECT @Result 
GO

--07.Define a function in the database TelerikAcademy that returns all Employee's names 
--(first or middle or last name) and all town's names that are comprised of given set of letters.
--Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
-- Using helper function that finds if a string consists of other string

IF OBJECT_ID('dbo.ufn_StringComprisedOf') IS NOT NULL DROP FUNCTION ufn_StringComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_StringComprisedOf(@inputString nvarchar(50), @letterSet nvarchar(100))
  RETURNS BIT
AS
  BEGIN
	DECLARE @inputStringLenght int
	DECLARE @currentIndex int
	DECLARE @input nvarchar(50)
	DECLARE @pattern nvarchar(100)
	SET @inputStringLenght = LEN(@inputString)
	SET @currentIndex = 1
	SET @input = LOWER(@inputString)
	SET @pattern = LOWER(@letterSet)

	WHILE @currentIndex <= @inputStringLenght
	  BEGIN
		IF(CHARINDEX(SUBSTRING(@input,@currentindex,1),@pattern)=0)
		  BEGIN
			RETURN 0
		  END
		SET @currentIndex = @currentIndex +1
	  END
	RETURN 1
  END
GO


IF OBJECT_ID('dbo.ufn_EmployeesAndTownsNameComprisedOf') IS NOT NULL DROP FUNCTION ufn_EmployeesAndTownsNameComprisedOf 
GO 

CREATE FUNCTION [dbo].ufn_EmployeesAndTownsNameComprisedOf(@letterSet nvarchar(100))
  RETURNS @reulst_table TABLE (name nvarchar(50))
AS
BEGIN

DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT Name FROM (
  SELECT FirstName AS Name FROM Employees
  UNION
  SELECT MiddleName AS Name FROM Employees
  UNION
  SELECT LastName AS Name FROM Employees
  UNION
  SELECT Name AS Name FROM Towns
  ) AS Names
  WHERE Name IS NOT NULL

OPEN empCursor
DECLARE @name nvarchar(50)
FETCH NEXT FROM empCursor INTO @name

DECLARE @nameLen int, @currentIndex int

WHILE @@FETCH_STATUS = 0
  BEGIN
	IF(dbo.ufn_StringComprisedOf(@name,@letterSet)=1)
	  BEGIN
	    INSERT INTO @reulst_table
		VALUES (@name)
	  END
    FETCH NEXT FROM empCursor 
    INTO @name
  END

CLOSE empCursor
DEALLOCATE empCursor
  RETURN
END
GO

SELECT * FROM [dbo].ufn_EmployeesAndTownsNameComprisedOf('oistmiahf')
GO

--08.Using database cursor write a T-SQL script that scans all employees 
--and their addresses and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR

	SELECT e.FirstName, e.LastName, t.Name, e1.FirstName, e1.LastName
	FROM Employees e
		INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
		INNER JOIN Towns t
		ON a.TownID = t.TownID,
	Employees e1
		INNER JOIN Addresses a1
		ON e1.AddressID = a1.AddressID
		INNER JOIN Towns t1
		ON a1.TownID = t1.TownID

OPEN empCursor
DECLARE @FirstName nvarchar(50)
DECLARE @LastName nvarchar(50)
DECLARE @TownName nvarchar(50)
DECLARE @FirstName1 nvarchar(50)
DECLARE @LastName1 nvarchar(50)

FETCH NEXT FROM empCursor INTO
@FirstName, @LastName, @TownName, @FirstName1, @LastName1

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @FirstName + ' ' + @LastName + ' ->  ' + @TownName + '  <- ' + @FirstName1 + ' ' + @LastName1
		FETCH NEXT FROM empCursor INTO
		@FirstName, @LastName, @TownName, @FirstName1, @LastName1
	END

CLOSE empCursor
DEALLOCATE empCursor

--09.* Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
--Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
--Ottawa -> Jose Saraiva
CREATE TABLE UsersTowns (
        ID INT IDENTITY,
        FullName NVARCHAR(50),
        TownName NVARCHAR(50)
)

INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
    FROM Employees e
		INNER JOIN Addresses a
		ON a.AddressID = e.AddressID
		INNER JOIN Towns t
		ON t.TownID = a.TownID
	GROUP BY t.Name, e.FirstName, e.LastName
-------------------------------------

DECLARE empCursor1 CURSOR READ_ONLY FOR
	SELECT DISTINCT t.TownName
		FROM UsersTowns t

OPEN empCursor1
	DECLARE @Town nvarchar(50), @UsersName nvarchar(MAX)
		FETCH NEXT FROM empCursor1 INTO @Town

		WHILE @@FETCH_STATUS = 0
			BEGIN
				
				BEGIN
					DECLARE empCursor2 CURSOR READ_ONLY FOR
						SELECT town.FullName
							FROM UsersTowns town
							WHERE town.TownName = @Town

					OPEN empCursor2
						DECLARE @FullName nvarchar(50)
							FETCH NEXT FROM empCursor2 INTO @FullName

							WHILE @@FETCH_STATUS = 0
								BEGIN
									--SET @UsersName = CONCAT(@UsersName, @FullName) -- Doesn't know why doesn't work this way
									PRINT ' ' + @FullName
									FETCH NEXT FROM empCursor2 INTO @FullName
								END
					CLOSE empCursor2
					DEALLOCATE empCursor2
				END
				PRINT @Town + ' -> ' --+ @UsersName
				FETCH NEXT FROM empCursor1 INTO @Town
			END
CLOSE empCursor1
DEALLOCATE empCursor1

--10.Define a .NET aggregate function StrConcat that takes as input a sequence of strings
-- and return a single string that consists of the input strings separated by ','. 
-- For example the following SQL statement should return a single string:
--SELECT StrConcat(FirstName + ' ' + LastName) FROM Employees

IF OBJECT_ID('dbo.StrConcat') IS NOT NULL DROP Aggregate StrConcat 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
       DROP assembly concat_assembly; 
GO      

DECLARE @path nvarchar(256)
-- You must change this path to the folder where the .dll with the CLR function is.
SET @path = 'C:\PathToFile'

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM @path+'\ConcatAggregateSqlFunction.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.StrConcat ( 

    @Value NVARCHAR(MAX),
	@Delimiter NVARCHAR(4000) 

) RETURNS NVARCHAR(MAX) 
EXTERNAL Name concat_assembly.Concat; 
GO

-- Enable execution of CLR code 
sp_configure 'clr enabled',1
GO
RECONFIGURE
GO
--sp_configure 'clr enabled'  -- make sure it took
--GO

SELECT [dbo].StrConcat(FirstName + ' ' + LastName, ', ') as Names
FROM Employees