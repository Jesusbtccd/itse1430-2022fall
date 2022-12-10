CREATE TABLE [dbo].[Parameters]
(
	[@id] INT NOT NULL PRIMARY KEY
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Parameters',
    @level2type = N'COLUMN',
    @level2name = N'@id'