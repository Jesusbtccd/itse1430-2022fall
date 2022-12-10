CREATE TABLE [dbo].[UpdateProduct]
(
	[@Id] INT NOT NULL PRIMARY KEY, 
    [@name] TEXT NOT NULL, 
    [@price] DECIMAL NOT NULL, 
    [@description] TEXT NOT NULL, 
    [@isDiscontinued] BIT NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Id of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UpdateProduct',
    @level2type = N'COLUMN',
    @level2name = N'@Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Name of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UpdateProduct',
    @level2type = N'COLUMN',
    @level2name = N'@name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'price of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UpdateProduct',
    @level2type = N'COLUMN',
    @level2name = N'@price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'optional description of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UpdateProduct',
    @level2type = N'COLUMN',
    @level2name = N'@description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indicates if he product is discontinued',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'UpdateProduct',
    @level2type = N'COLUMN',
    @level2name = N'@isDiscontinued'