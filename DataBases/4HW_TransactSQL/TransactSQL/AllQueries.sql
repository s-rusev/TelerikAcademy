
--1 Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK),
-- PersonId(FK), Balance). Insert few records for testing. Write a stored procedure 
--that selects the full names of all persons.

CREATE DATABASE TSQLDatabase
GO

USE TSQLDatabase
GO

CREATE TABLE Persons(
	PersonID int IDENTITY,
	FirstName varchar(30) NOT NULL,
	LastName varchar(30) NOT NULL,
	SSN varchar(50) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(PersonID)
)
GO

CREATE TABLE Accounts(
	AccountID int IDENTITY,
	PersonID int NOT NULL,
	Balance money NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(AccountID),
	CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonID)
	REFERENCES Persons(PersonID)
)
GO

--Insert some values
INSERT INTO Persons(FirstName,LastName,SSN)
VALUES('Gorgi','Djangov','123-123-123')
GO

INSERT INTO Persons(FirstName,LastName,SSN)
VALUES('Poncho','Zimbov','143-333-133')
GO

INSERT INTO Accounts(PersonID,Balance)
VALUES(1,3000)
GO

INSERT INTO Accounts(PersonID,Balance)
VALUES(2,15333)
GO

--Create stored proc for full names
CREATE PROC spo_FullPersonsNames
AS
BEGIN
	SELECT FirstName + ' ' + LastName AS [Full Name] FROM Persons
END
GO
--Test proc
EXEC spo_FullPersonsNames
GO

--2. Create a stored procedure that accepts a number as a parameter and returns all persons
-- who have more money in their accounts than the supplied number.

CREATE PROC spo_PeopleWithMoney(@minMoney money = 0)
AS
BEGIN
	SELECT FirstName, LastName, Balance FROM 
	Persons p INNER JOIN Accounts a ON 
	p.PersonID = a.PersonID
	WHERE a.Balance > @minMoney
END
GO

--Test proc
EXEC spo_PeopleWithMoney
GO 

EXEC spo_PeopleWithMoney 4000
GO

--3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--It should calculate and return the new sum. Write a SELECT to test whether the function works as expected

DROP FUNCTION ufn_AddInterest
GO
CREATE FUNCTION ufn_AddInterest(@sum money, @yearlyInterest money, @months int)
RETURNS money
AS
BEGIN
	DECLARE @newSum money
	SET @newSum = @yearlyInterest* (@months / 12.0) * @sum + @sum
	RETURN @newSum
END
GO

DECLARE @res money
EXEC  @res = ufn_AddInterest 1000, 0.01, 12 
GO

SELECT  dbo.ufn_AddInterest(1000,0.02,1)
GO

--4. Create a stored procedure that uses the function from the previous example to give an interest 
--to a person's account for one month. It should take the AccountId and the interest rate as parameters

CREATE PROC usp_AddInterestToAccount(@accountId int, @interestRate money)
AS
BEGIN
	UPDATE Accounts
	SET Balance = dbo.ufn_AddInterest(Balance,@interestRate,1)
	WHERE AccountID = @accountId
END
GO

--Test proc
EXEC usp_AddInterestToAccount 1, 0.12
GO

SELECT * FROM Accounts WHERE AccountID = 1
GO

--5. Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney 
--(AccountId, money) that operate in transactions.

CREATE PROC usp_WithdrawMoney(@accountId int, @amount money)
AS
BEGIN
	BEGIN TRAN
	DECLARE @newBalance money
	UPDATE Accounts
	SET Balance =  Balance - @amount
	WHERE AccountID = @accountId

	SELECT @newBalance = BALANCE FROM Accounts
	WHERE AccountID = @accountId

	IF (@newBalance >= 0)
	BEGIN
		COMMIT TRAN
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
	END
END
GO

CREATE PROC usp_DepositMoney(@accountId int, @amount money)
AS
BEGIN
	BEGIN TRAN
	UPDATE Accounts
	SET Balance =  Balance + @amount
	WHERE AccountID = @accountId
	COMMIT TRAN
END
GO

--6. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs 
-- table every time the sum on an account changes.

CREATE TABLE Logs(
	LogID int IDENTITY,
	AccountID int NOT NULL,
	OldSum money,
	NewSum money,
	CONSTRAINT PK_Logs PRIMARY KEY(LogID),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID)
	REFERENCES Accounts(AccountID)
)
GO

CREATE TRIGGER t_BalanceChanged ON Accounts
FOR UPDATE 
AS
BEGIN
	INSERT INTO Logs(AccountID,OldSum,NewSum)
	SELECT d.AccountID, d.Balance,i.Balance FROM deleted d INNER JOIN inserted i
	ON d.AccountID = i.AccountID
END
GO

--TEST
EXEC usp_WithdrawMoney 1, 4000
GO

EXEC usp_WithdrawMoney 1, 2000
GO

EXEC usp_DepositMoney 1, 5000
GO

--7.Define a function in the database TelerikAcademy that returns all
-- Employee's names (first or middle or last name) and all town's names
-- that are comprised of given set of letters. Example 'oistmiahf' will
-- return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

USE TelerikAcademy
GO

DROP FUNCTION ufn_Match
GO
CREATE FUNCTION ufn_Match(@word varchar(50), @letters varchar(50))
RETURNS bit
AS
BEGIN
	IF (@word IS NULL OR LEN(@word) = 0)
	BEGIN
		RETURN 0
	END

	DECLARE @pattern varchar(52) = '[' + @letters + ']'
	DECLARE @letter char(1)
	WHILE (LEN(@word) > 0)
	BEGIN
		SET @letter = SUBSTRING(@word,1,1)
		SET @word = SUBSTRING(@word,2,LEN(@word) - 1)
		IF (@letter NOT LIKE @pattern)
		BEGIN 
			RETURN 0
		END
	END
	RETURN 1
END
GO

CREATE FUNCTION ufn_AllNames(@pattern varchar(50))
RETURNS TABLE
AS
RETURN(
SELECT FirstName AS Name FROM Employees
WHERE dbo.ufn_Match(FirstName, @pattern) = 1

UNION

SELECT LastName AS Name FROM Employees
WHERE dbo.ufn_Match(LastName, @pattern) = 1

UNION

SELECT MiddleName AS Name FROM Employees
WHERE dbo.ufn_Match(MiddleName, @pattern) = 1

UNION 

SELECT Name FROM Towns
WHERE dbo.ufn_Match(Name,@pattern) = 1
)
GO

SELECT Name FROM dbo.ufn_AllNames('oistmiahf')


--8.Using database cursor write a T-SQL script that scans all employees and their
-- addresses and prints all pairs of employees that live in the same town.

DECLARE empAddr_cursor CURSOR READ_ONLY FOR
SELECT f.[Full Name], s.[Full Name], f.TownID FROM
(SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.TownID FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID) f
INNER JOIN (SELECT e.FirstName + ' ' + e.LastName AS [Full Name], a.TownID FROM Employees e
INNER JOIN Addresses a ON e.AddressID = a.AddressID) s
ON f.TownID = s.TownID

OPEN empAddr_cursor
DECLARE @first_name varchar(50), @second_name varchar(50), @town_id int
FETCH NEXT FROM empAddr_cursor INTO @first_name, @second_name, @town_id

WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT @first_name AS [First Employee], @second_name AS [Second Employee], @town_id AS [Town ID]
	FETCH NEXT FROM empAddr_cursor INTO @first_name, @second_name, @town_id
END

CLOSE empAddr_cursor
DEALLOCATE empAddr_cursor


--9. * Write a T-SQL script that shows for each town a list of all employees that live in it.

--Create result table
DROP TABLE TownsEmployees
CREATE TABLE TownsEmployees(
	TownID int,
	TownName nvarchar(50) NOT NULL,
	Employees varchar(max),
	CONSTRAINT PK_TownsEmployees PRIMARY KEY(TownID)
)
GO

--Create cursor
DECLARE empTowns_cursor CURSOR READ_ONLY FOR
SELECT t.TownID, t.Name, e.FirstName + ' ' + e.LastName FROM
Employees e INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns t ON a.TownID = t.TownID
GO

--Use the cursor 
OPEN empTowns_cursor
DECLARE @town_id int, @town_name varchar(50), @employee_name char(50)
FETCH FROM empTowns_cursor INTO @town_id, @town_name, @employee_name

WHILE (@@FETCH_STATUS = 0)
BEGIN
	--Update: Add employee name if town in result table
	IF (EXISTS ( SELECT TownID FROM TownsEmployees WHERE TownID = @town_id))
	BEGIN 
		UPDATE TownsEmployees
		SET Employees = RTRIM(Employees) + ', '  + @employee_name
		WHERE TownID = @town_id
	END

	--Insert: Town with current name if town not in result table
	ELSE
	BEGIN
		INSERT INTO TownsEmployees
		VALUES(@town_id,@town_name,@employee_name)
	END

	FETCH FROM empTowns_cursor INTO @town_id, @town_name, @employee_name
END

CLOSE empTowns_cursor
DEALLOCATE empTowns_cursor
GO

--Show the results
SELECT * FROM TownsEmployees
GO


--10. Define a .NET aggregate function StrConcat that takes as input
--a sequence of strings and return a single string that consists
-- of the input strings separated by ','.

GO
SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees