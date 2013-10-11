--task1--
CREATE DATABASE Customers
GO
 
USE Customers
 
CREATE TABLE People
(
        PersonId INT IDENTITY,
           CONSTRAINT PK_Persons PRIMARY KEY(PersonId),
        FirstName VARCHAR(30),
        LastName VARCHAR(30),
        SSN VARCHAR(10),
)
 
CREATE TABLE Accounts
(
        AccountId INT IDENTITY,
                CONSTRAINT PK_Accounts PRIMARY KEY(AccountId),
        Balance MONEY NOT NULL,
        PersonId INT NOT NULL,
                CONSTRAINT FK_Accounts_Persons FOREIGN KEY (PersonId)
                        REFERENCES People(PersonId)
)
 
INSERT INTO People (FirstName, LastName, SSN)
VALUES
        ('Pesho', 'Peshev', '1234123456'),
        ('Gosho', 'Goshov', '5511235796'),
        ('Ivan', 'Ivanov', '2984179551'),
        ('George', 'Georgiev', '9180041249')
 
INSERT INTO Accounts (Balance, PersonId)
VALUES
        (40000, 1),
        (50000, 1),
        (60000, 2),
        (99000.99, 3)
 
CREATE PROCEDURE usp_SelectPersonsFullName AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM People
GO
 
EXEC usp_SelectPersonsFullName

--task2--
GO
 
CREATE PROCEDURE usp_PersonsWithMoreMoneyThan @minBalance MONEY
AS
        SELECT FirstName + ' ' + LastName AS [Full Name], SUM(Balance) AS [Money]
        FROM People p JOIN Accounts a ON p.PersonId = a.PersonId
        GROUP BY p.PersonId,  FirstName + ' ' + LastName
        HAVING SUM(Balance) > @minBAlance
GO
 
EXEC usp_PersonsWithMoreMoneyThan 55000

--task3--

CREATE FUNCTION ufn_CalculateRemunerated2(@sum money, @interestRate int,
@months int)
RETURNS money
AS
BEGIN
DECLARE @result money
SET @result = @sum + (@months/12.0)*((@interestRate*@sum)/100)
return @result
END
GO


SELECT dbo.ufn_CalculateRemunerated2(100, 10, 110) AS [new sum]
GO

--task4--
CREATE PROC usp_UpdatePersonsBalance(@AccountID int,
@interestRate int)
AS
BEGIN
DECLARE @sum money
SET @sum = (SELECT Balance
FROM Accounts
WHERE AccountId = CAST(@AccountID AS int))

DECLARE @updatedSum money
SET @updatedSum = dbo.ufn_CalculateRemunerated2(@sum, @interestRate, 1)

UPDATE Accounts
SET Balance = CAST(@updatedSum AS money)
WHERE AccountId = CAST(@AccountID AS int)

END
GO

--before update--
SELECT Balance
FROM Accounts
WHERE AccountId = 1

EXEC usp_UpdatePersonsBalance 1, 500

--after update
SELECT Balance
FROM Accounts
WHERE AccountId = 1
GO

--task5--
GO
 
--WithdrawMoney( AccountId, money)--
CREATE PROCEDURE usp_WithdrawMoney
        @accountId INT, @moneyToDraw MONEY
AS
        BEGIN TRANSACTION
        DECLARE @availableMoney MONEY =
                (Select Balance
                From Accounts
                WHERE AccountId = @accountId)
 
        IF (@availableMoney >= @moneyToDraw)
        BEGIN
                UPDATE Accounts
                SET Balance = Balance - @moneyToDraw
                WHERE AccountId = @accountId
                COMMIT
        END
        ELSE
        BEGIN
                RAISERROR ('Not enough money in account.', 16, 1)
                ROLLBACK TRAN
        END
GO
 
EXEC usp_WithdrawMoney 1, 20000
 
--DepositMoney (AccountId, money)--
GO
 
CREATE PROCEDURE usp_DepositMoney
        @accountId INT, @moneyToDeposit MONEY
AS
        BEGIN TRANSACTION
        IF (@moneyToDeposit >= 0)
        BEGIN
                UPDATE Accounts
                SET Balance = Balance + @moneyToDeposit
                WHERE AccountId = @accountId
                COMMIT
        END
        ELSE
        BEGIN
                RAISERROR('Deposit money cannott be negative.', 16, 1)
                ROLLBACK TRAN
        END
GO
 
EXEC usp_DepositMoney 1, 20000

--task6--
CREATE TABLE Logs(
LogID INT IDENTITY,
AccountID INT,
OldSum money,
NewSum money
CONSTRAINT PK_LogID PRIMARY KEY(logID)
CONSTRAINT FK_AccountID FOREIGN KEY(AccountID)
REFERENCES Accounts(AccountId))
GO
 
GO
 
CREATE TRIGGER tr_AccountUpdate ON Accounts FOR UPDATE
AS
        DECLARE deletedCursor CURSOR READ_ONLY FOR
                SELECT Balance, AccountId FROM deleted
        DECLARE insertedCursor CURSOR READ_ONLY FOR
                SELECT Balance FROM inserted
 
        OPEN deletedCursor
        OPEN insertedCursor
 
        DECLARE @oldSum MONEY, @accountId INT
        FETCH NEXT FROM deletedCursor INTO @oldSum, @accountId
 
        DECLARE @newSum MONEY
        FETCH NEXT FROM insertedCursor INTO @newSum
 
        WHILE @@FETCH_STATUS = 0
        BEGIN
                INSERT INTO Logs (OldSum, NewSum, AccountId)
                VALUES (@oldSum, @newSum, @accountId)
                FETCH NEXT FROM deletedCursor INTO @oldSum, @accountId
                FETCH NEXT FROM insertedCursor INTO @newSum
        END
 
        CLOSE deletedCursor
        DEALLOCATE deletedCursor
        CLOSE insertedCursor
        DEALLOCATE insertedCursor
GO
 
UPDATE Accounts
SET Balance = Balance + Balance * 0.1
WHERE AccountId = 1 OR AccountId = 2

