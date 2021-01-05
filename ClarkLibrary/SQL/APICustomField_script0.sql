-- Portfolio
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.PortfolioCustomField')
		)
	DROP VIEW TRXApi.[PortfolioCustomField]
GO

CREATE VIEW [TRXApi].[PortfolioCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.PortfolioExtCustomField')
		)
	DROP VIEW TRXApi.PortfolioExtCustomField
GO

CREATE VIEW [TRXApi].[PortfolioExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Customer
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.CustomerCustomField')
		)
	DROP VIEW TRXApi.[CustomerCustomField]
GO

CREATE VIEW [TRXApi].[CustomerCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.CustomerExtCustomField')
		)
	DROP VIEW TRXApi.[CustomerExtCustomField]
GO

CREATE VIEW [TRXApi].[CustomerExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Order
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.OrderCustomField')
		)
	DROP VIEW TRXApi.[OrderCustomField]
GO

CREATE VIEW [TRXApi].[OrderCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.OrderExtCustomField')
		)
	DROP VIEW TRXApi.[OrderExtCustomField]
GO

CREATE VIEW [TRXApi].[OrderExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Saving plans
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.SavingCustomField')
		)
	DROP VIEW TRXApi.[SavingCustomField]
GO

CREATE VIEW [TRXApi].[SavingCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.SavingSellExtCustomField')
		)
	DROP VIEW TRXApi.[SavingSellExtCustomField]
GO

CREATE VIEW [TRXApi].[SavingSellExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Saving plan sell
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.SavingSellCustomField')
		)
	DROP VIEW TRXApi.[SavingSellCustomField]
GO

CREATE VIEW [TRXApi].[SavingSellCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.SavingExtCustomField')
		)
	DROP VIEW TRXApi.[SavingExtCustomField]
GO

CREATE VIEW [TRXApi].[SavingExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'CashOrderCustomField' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Periodics
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.PeriodicCustomField')
		)
	DROP VIEW TRXApi.[PeriodicCustomField]
GO

CREATE VIEW [TRXApi].[PeriodicCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.PeriodicExtCustomField')
		)
	DROP VIEW TRXApi.[PeriodicExtCustomField]
GO

CREATE VIEW [TRXApi].[PeriodicExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Product
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.ProductCustomField')
		)
	DROP VIEW TRXApi.[ProductCustomField]
GO

CREATE VIEW [TRXApi].[ProductCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.ProductExtCustomField')
		)
	DROP VIEW TRXApi.[ProductExtCustomField]
GO

CREATE VIEW [TRXApi].[ProductExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

-- Cash orders
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.CashOrderCustomField')
		)
	DROP VIEW TRXApi.[CashOrderCustomField]
GO

CREATE VIEW [TRXApi].[CashOrderCustomField]
AS
SELECT 0 PrimaryId
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,0 HideFromExternalDistributor
	,0 IsRequired
	,'' ViewName
	,'' Type
FROM TRX_CUSTOMER
WHERE 1 = 0
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'TRXApi.CashOrderExtCustomField')
		)
	DROP VIEW TRXApi.CashOrderExtCustomField
GO

CREATE VIEW [TRXApi].[CashOrderExtCustomField]
AS
SELECT 0 PrimaryId
	,0 RowId
	,'' TableName
	,'' ColumnName
	,'' FieldName
	,'' DataType
	,'' Value
	,'' Type
	,'' [Group]
FROM TRX_CUSTOMER
WHERE 1 = 0
GO


