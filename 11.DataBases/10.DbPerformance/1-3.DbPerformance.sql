CREATE TABLE Logs(
  Id int NOT NULL IDENTITY PRIMARY KEY,
  LogDate datetime,
  MsgText nvarchar(300),
)

GO

--01.Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).

CREATE PROC usp_Add1MilionLogs
AS
DECLARE @counter int
	SET @counter = 1;
WHILE(@counter < 1000000)
	BEGIN
	  DECLARE @Date datetime
		SET @Date = DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
		INSERT INTO Logs (LogDate, MsgText)
		VALUES(@Date, 'SomeText')
		SET @counter = @counter + 1;
	END
GO

EXEC usp_Add1MilionLogs

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) > 2000 AND YEAR(l.LogDate) < 2010
-- The elapsed time is around 10 secs.

--02.Add an index to speed-up the search by date. 
--Test the search speed (after cleaning the cache).

CREATE INDEX IX_Logs_LogDate ON Logs(LogDate)

SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
-- There is no significant difference(1,2 secs)

--03.Add a full text index for the text column. 
--Try to search with and without the full-text index and compare the speed.

DROP INDEX Logs.IX_Logs_LogDate
CREATE INDEX IDX_Logs_MsgText ON Logs(MsgText)

SELECT l.MsgText
FROM Logs l
WHERE YEAR(l.LogDate) < 2012 AND YEAR(l.LogDate) > 2001
-- There is no difference with or without MsgText index(again around 1,2 secs)