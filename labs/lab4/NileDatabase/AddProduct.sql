CREATE TABLE [dbo].[AddProduct]
(
	[@name] TEXT NOT NULL , 
    [@price] DECIMAL NOT NULL, 
    [@description] TEXT NOT NULL, 
    [@isDiscontinued] BIT NOT NULL, 
    PRIMARY KEY ([@name])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Name of the Product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AddProduct',
    @level2type = N'COLUMN',
    @level2name = N'@name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Price of the Product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AddProduct',
    @level2type = N'COLUMN',
    @level2name = N'@price'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Optional description of the product',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AddProduct',
    @level2type = N'COLUMN',
    @level2name = N'@description'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indicates if the Product is discontinued',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'AddProduct',
    @level2type = N'COLUMN',
    @level2name = N'@isDiscontinued'