USE [Accounts]

GO


-- 1. Create a database with two tables: 
--		- Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--	  Insert few records for testing.


--	  I have created the database with the studio not script.
--	  Write a stored procedure that selects the full names of all persons.

CREATE PROC usp_SelectFullNames
AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM Persons p

GO

EXEC usp_SelectFullNames

GO

-- 2. Create a stored procedure that accepts a number as a parameter 
--	  and returns all persons who have more money in their accounts than the supplied number.

CREATE PROC usp_PersonsWithMoreMoneyThan (@minimalMoney money)
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
	FROM Persons p
	JOIN Accounts a
		ON p.PersonID = a.PersonID
	WHERE a.Balance > @minimalMoney

GO
	 
EXEC usp_PersonsWithMoreMoneyThan 100

GO

-- 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--	  It should calculate and return the new sum.
--	  Write a SELECT to test whether the function works as expected. 


 -- I made this to return the new sum for one month because of the next task
CREATE FUNCTION ufn_CalculateNewSum (@sum money, @yearlyInterest real, @numberOfMonths int)
	RETURNS money
AS
	BEGIN
		DECLARE @monthInteres real = @yearlyInterest/12
		DECLARE @Rise money = (@monthinteres/100) * @sum

		RETURN @sum + @Rise
	END

GO

SELECT dbo.ufn_CalculateNewSum (500, 3.5, 14) AS [New Balance]

GO


-- 4. Create a stored procedure that uses the function from the previous example
--	  to give an interest to a person's account for one month.
--	  It should take the AccountId and the interest rate as parameters.

CREATE PROC usp_NextMonthBalanceOfPerson (@AccountID int, @interestRate real)
AS
	DECLARE @currBalance money = (SELECT Balance FROM Accounts WHERE AccountID = @AccountID)
	DECLARE @newBalance money = (SELECT dbo.ufn_CalculateNewSum (@currBalance, @interestRate, 1))

	UPDATE Accounts
		SET	Balance = @newBalance
	WHERE AccountID = @AccountID

GO

EXEC usp_NextMonthBalanceOfPerson 3, 3.5

GO


-- 5. Add two more stored procedures WithdrawMoney(AccountId, money)
--	  and DepositMoney(AccountId, money) that operate in transactions.


-- Function to calculate the new balance when withdrawing money
CREATE FUNCTION usf_Withdraw (@AccountID int, @withdrawMoney money)
	RETURNS money
AS
	BEGIN
		DECLARE @currBalance money = (SELECT Balance FROM Accounts a WHERE a.AccountID = @AccountID)
		RETURN @currBalance - @withdrawMoney
	END

GO

-- Function to calculate the new balance when depositing money
CREATE FUNCTION usf_Deposit (@AccountID int, @depositMoney money)
	RETURNS money
AS
	BEGIN
		DECLARE @currBalance money = (SELECT Balance FROM Accounts a WHERE a.AccountID = @AccountID)
		RETURN @currBalance + @depositMoney 
	END

GO

-- Procedure to withdraw money
CREATE PROC usp_WithdrawMoney (@AccountID int, @Money money)
AS
	DECLARE @newBalance money = (SELECT dbo.usf_Withdraw (@AccountID, @Money))

	IF(@newBalance >= 0)
		BEGIN
			UPDATE Accounts
			SET Balance = @newBalance
			WHERE AccountID = @AccountID
		END
	ELSE
		BEGIN
			UPDATE Accounts
			SET Balance = 0
			WHERE AccountID = @AccountID
		END

GO

EXEC usp_WithdrawMoney 3, 5 -- execute the WithdrawMoney stored procedure
EXEC usp_WithdrawMoney 2, 124 -- Test if the balance goes below zero

GO

-- Procedure to deposit money
CREATE PROC usp_DepositMoney (@AccountID int, @Money money)
AS
	DECLARE @newBalance money = (SELECT dbo.usf_Deposit(@AccountID, @Money))

	UPDATE Accounts
	SET Balance = @newBalance
	WHERE AccountID = @AccountID

GO

EXEC usp_DepositMoney 3, 5 -- execute the DepositMoney stored procedure
EXEC usp_DepositMoney 2, 123 -- Rollback the test of the previos procedure

GO



-- 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
--	  Add a trigger to the Accounts table that enters a new entry into the Logs table
--	  every time the sum on an account changes.

-- Create the new table "Logs"
CREATE TABLE Logs (
	LogID int IDENTITY PRIMARY KEY,
	AccountID int NOT NULL,
	OldSum real,
	NewSum real NOT NULL
)

GO

-- Create the trigger
CREATE TRIGGER utr_ChangingTheSum ON Accounts FOR UPDATE
AS	
	BEGIN
		DECLARE @oldSum real = (SELECT Balance FROM deleted)

		INSERT INTO Logs (AccountID, OldSum, NewSum) 
			SELECT AccountID, @oldSum, Balance FROM inserted
	END

GO


-- test the trigger
EXEC usp_WithdrawMoney 3, 5 -- withdraw money
EXEC usp_DepositMoney 3, 5 -- return the money back

GO


-- 7. Define a function in the database TelerikAcademy that returns all Employees' names
--	  (first or middle or last name) and all towns' names that are comprised of given set of letters.
--	  Example: 'oistmiahf' will return 'Sofia', 'sSmith', … but not 'Rob' and 'Guy'.


-- I'm not sure if this works right

-- creating a function to check each name
CREATE FUNCTION usf_CheckThisName (@Name nvarchar(100), @pattern nvarchar(100))
	RETURNS int
AS
	BEGIN
		DECLARE @Counter int = 1
		DECLARE @currentCharacter char(1)

		WHILE (@Counter <= LEN(@Name))
			BEGIN
				SET @currentCharacter = SUBSTRING(@Name, @Counter, 1)
					IF(CHARINDEX(@currentCharacter, @pattern) <= 0)
						BEGIN
							RETURN 0
						END
					SET @Counter += 1
			END

		RETURN 1
	END

GO

-- Create a procedure to call this function
CREATE PROC usp_ReturnEmployeeAndTownName (@setOfLetters nvarchar(100))
AS
	BEGIN
		SELECT FirstName
			FROM Employees
			WHERE  dbo.usf_CheckThisName(FirstName,@setOfLetters) = 1
		UNION
			SELECT Name
				FROM Towns
			WHERE dbo.usf_CheckThisName(Name, @setOfLetters) = 1
	END
GO

-- execute the procedure to see the result
EXEC usp_ReturnEmployeeAndTownName 'oistmiahf'

GO

USE TelerikAcademy
GO

-- 8. Using database cursor write a T-SQL script that scans all employees 
--	  and their addresses and prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName, e.LastName, t.Name
		FROM  Employees e
			JOIN Addresses a
				ON e.AddressID = a.AddressID
			JOIN Towns t
				ON a.TownID = t.TownID

OPEN empCursor
	DECLARE @FirstName nvarchar(100), @LastName nvarchar(100), @TownName nvarchar(100)
	FETCH NEXT FROM empCursor INTO @FirstName, @LastName, @TownName

	WHILE @@FETCH_STATUS = 0
		BEGIN
			DECLARE employeeCursor CURSOR READ_ONLY FOR
					SELECT e.FirstName, e.LastName, t.Name
						FROM Employees e
							JOIN Addresses a
								ON e.AddressID = a.AddressID
							JOIN Towns t
								ON a.TownID = t.TownID

			OPEN employeeCursor
				DECLARE @FirstName_1 nvarchar(100), @LastName_1 nvarchar(100), @TownName_1 nvarchar(100)
				FETCH NEXT FROM employeeCursor INTO @FirstName_1, @LastName_1, @TownName_1

				WHILE @@FETCH_STATUS = 0
					BEGIN
						if(@TownName_1 = @TownName)
							BEGIN
								PRINT @FirstName + ' ' + @LastName + '   :   ' + @TownName + '   :   ' + @FirstName_1 + ' ' + @LastName_1
							END

						FETCH NEXT FROM employeeCursor INTO @FirstName_1, @LastName_1, @TownName_1
					END
					CLOSE employeeCursor
					DEALLOCATE employeeCursor
			FETCH NEXT FROM empCursor INTO @FirstName, @LastName, @TownName
		END
	CLOSE empCursor
	DEALLOCATE empCursor

GO



-- 9. *Write a T-SQL script that shows for each town a list of all employees that live in it.
DECLARE ETCursor CURSOR READ_ONLY FOR
	SELECT t.Name, e.FirstName + ' ' + e.LastName + ',' AS [Employee]
		FROM Towns t
			 JOIN Addresses a 
				ON	t.TownID = a.TownID
			 JOiN Employees e
				ON a.AddressID = e.AddressID

OPEN ETCursor
	DECLARE @TownName nvarchar(100), @EmployeeName nvarchar(MAX)
	FETCH NEXT FROM ETCursor INTO @TownName, @EmployeeName

	WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT @TownName + ' -> ' + @EmployeeName
				FETCH NEXT FROM ETCursor INTO @TownName, @EmployeeName
		END
CLOSE ETCursor
DEALLOCATE ETCursor

GO