USE OnlineStoreDB
GO

CREATE PROC AddOrUpdateProducts(@Request XML)
AS
BEGIN
BEGIN TRANSACTION
BEGIN TRY
DECLARE @hDoc as int

EXEC sp_xml_preparedocument @hDoc OUTPUT, @Request


MERGE Product AS target
USING (SELECT [Id], [Name], [Description], [Price]
FROM OPENXML(@hDoc, '/ROOT/Product')
			WITH 
			(
			Id int,
			[Name] [varchar](50),
			[Description] [varchar](200),
			Price [money]
			)
      ) AS source ([Id], [Name],[Description], [Price])
ON (target.Id = source.Id)
WHEN MATCHED AND (target.[Name] != source.[Name] OR target.[Description] != source.[Description] OR target.[Price] != source.[Price])
    THEN UPDATE SET target.[Name] = source.[Name], target.[Description] = source.[Description], target.[Price] = source.[Price]
WHEN NOT MATCHED
    THEN INSERT ([Id], [Name], [Description], Price) VALUES(source.[Id], source.[Name], source.[Description], source.[Price])
OUTPUT $action, inserted.*, deleted.*;

EXEC sp_xml_removedocument @hDoc
COMMIT
END TRY
BEGIN CATCH
EXEC sp_xml_removedocument @hDoc
ROLLBACK
END CATCH
END
GO