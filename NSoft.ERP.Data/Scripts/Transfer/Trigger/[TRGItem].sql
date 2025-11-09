USE [NERP]
GO

/****** Object:  Trigger [dbo].[TRGItem]    Script Date: 27/07/2018 06:24:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[TRGItem] 
   ON  [dbo].[Item]
   AFTER INSERT,UPDATE
AS 
BEGIN

	SET NOCOUNT ON
	
	IF OBJECT_ID('tempdb..#TItem') IS NOT NULL
		DROP TABLE #TItem

	select * into #TItem
    from inserted 

	
	INSERT INTO [dbo].[ItemSync]
           ([ItemID]
           ,[ItemCode]
           ,[BarCode]
           ,[ReferenceCode]
           ,[ItemName]
           ,[NameOnInvoice]
           ,[CategoryID]
           ,[SubCategory1ID]
           ,[SubCategory2ID]
           ,[BrandID]
           ,[ReOrderLevel]
           ,[ReOrderQty]
           ,[SellingPrice]
           ,[CostPrice]
           ,[MarginPercentage]
           ,[MaximumPrice]
           ,[MinimumPrice]
           ,[FixedDiscountPercentage]
           ,[ItemImage]
           ,[IsActive]
           ,[IsDelete]
           ,[GroupOfCompanyID]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[ModifiedUser]
           ,[ModifiedDate])
	SELECT
	[ItemID]
           ,[ItemCode]
           ,[BarCode]
           ,[ReferenceCode]
           ,[ItemName]
           ,[NameOnInvoice]
           ,[CategoryID]
           ,[SubCategory1ID]
           ,[SubCategory2ID]
           ,[BrandID]
           ,[ReOrderLevel]
           ,[ReOrderQty]
           ,[SellingPrice]
           ,[CostPrice]
           ,[MarginPercentage]
           ,[MaximumPrice]
           ,[MinimumPrice]
           ,[FixedDiscountPercentage]
           ,[ItemImage]
           ,[IsActive]
           ,[IsDelete]
           ,[GroupOfCompanyID]
           ,[CreatedUser]
           ,[CreatedDate]
           ,[ModifiedUser]
           ,[ModifiedDate]
	  FROM #TItem

	IF OBJECT_ID('tempdb..#TItem') IS NOT NULL
		DROP TABLE #TItem

END

GO

ALTER TABLE [dbo].[Item] ENABLE TRIGGER [TRGItem]
GO


