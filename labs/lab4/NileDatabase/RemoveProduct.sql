CREATE TABLE [dbo].[RemoveProduct]
(
	[@id] INT NOT NULL PRIMARY KEY
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ID of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'RemoveProduct',
    @level2type = N'COLUMN',
    @level2name = N'@id'