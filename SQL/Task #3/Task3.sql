USE OnlineStoreDB
GO

-- Task3.Subtask2 {

CREATE PROC GenerateId(@tableName varchar(50), @outputId INT OUTPUT)
AS
BEGIN
DECLARE @sSQL nvarchar(50);
DECLARE @ParmDefinition nvarchar(50);

SELECT @sSQL = N'SELECT @retvalOUT = MAX(Id)+1 FROM ' + @tableName;  
SET @ParmDefinition = N'@retvalOUT int OUTPUT';
EXEC sp_executesql @sSQL, @ParmDefinition, @retvalOUT=@outputId OUTPUT;
IF @outputId IS NULL
SET @outputId = 1;
END
GO

-- }


-- Task3.Subtask3 {

CREATE TYPE [dbo].[ProductTableType] AS TABLE
(
    [Name] [nvarchar](50) NOT NULL,
    [Description] [nvarchar](50) NOT NULL,
    [Price] [money] NOT NULL
)
GO

CREATE PROC InsertProducts(@products ProductTableType READONLY)
AS
BEGIN
DECLARE pTT_cursor CURSOR LOCAL FOR SELECT [Name], [Description], [Price] FROM @products

OPEN pTT_cursor
DECLARE @cName nvarchar(50), @cDesc nvarchar(200), @cPrice money
FETCH NEXT FROM pTT_cursor INTO @cName, @cDesc, @cPrice
WHILE @@FETCH_STATUS=0
BEGIN
DECLARE @outputId INT
EXEC GenerateId 'Product1', @outputId OUTPUT
INSERT INTO Product1 VALUES(@outputId, @cName, @cDesc, @cPrice)
FETCH NEXT FROM pTT_cursor INTO @cName, @cDesc, @cPrice
END

CLOSE pTT_cursor
DEALLOCATE pTT_cursor

END
GO

-- }

-- Task3.Subtask4 {

CREATE TRIGGER ProductInsertTrigger
ON Product
INSTEAD OF INSERT
AS
BEGIN
DECLARE @pTableType ProductTableType;

INSERT INTO @pTableType ([Name], [Description], [Price])
SELECT [Name], [Description], [Price] FROM INSERTED

EXEC InsertProducts @pTableType -- insertion in other table
END
GO

-- }