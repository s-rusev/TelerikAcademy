CREATE TABLE DateAndText(
  DateAndTextId int NOT NULL PRIMARY KEY IDENTITY,
  Date datetime,
  Text ntext
)

DECLARE @Counter int = 0
DECLARE @date datetime = GETDATE()
WHILE (SELECT COUNT(*) FROM DateAndText) < 1000000
BEGIN
  INSERT INTO DateAndText(Date, Text)
  VALUES (@date, 'Text' + CONVERT(varchar, @Counter))
  SET @Counter = @Counter + 1
  SET @date = DATEADD(DAY, 1, @date)
END

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM DateAndText
WHERE Date BETWEEN DATEADD(DAY, 1000, @date) AND DATEADD(DAY, 1500, @date)
GO

--------------------------------------------------------------
--2
DECLARE @date datetime = GETDATE()
CREATE INDEX IDX_DateAndText_Date ON DateAndText(Date)
CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache
SELECT * FROM DateAndText
WHERE Date BETWEEN DATEADD(DAY, 1000, @date) AND DATEADD(DAY, 1500, @date)

--------------------------------------------------------------
--3
SELECT Text FROM DateAndText
WHERE Text = 'Text12'

--

CREATE FULLTEXT CATALOG FullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON DateAndText(Text)
KEY INDEX DateAndTextId
ON MessagesFullTextCatalog
WITH CHANGE_TRACKING AUTO

SELECT Text FROM DateAndText
WHERE Text = 'Text12'