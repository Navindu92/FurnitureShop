
DECLARE @ItemID bigint 
DECLARE @ItemCode VARCHAR(256) 
DECLARE @ItemName VARCHAR(256)
DECLARE @CategoryID bigint 
DECLARE @BrandID bigint 
DECLARE @SubCategory1ID bigint 
DECLARE @SubCategory2ID bigint 

DECLARE db_cursor CURSOR FOR 
SELECT ItemID,ItemCode,ItemName,CategoryID,BrandID,SubCategory1ID,SubCategory2ID
FROM  Item

OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @ItemID,@ItemCode,@ItemName,@CategoryID,@BrandID
,@SubCategory1ID,@SubCategory2ID

WHILE @@FETCH_STATUS = 0  
BEGIN  
    
	declare @catCode nvarchar(10),
	 @brandCode nvarchar(10),
	  @subCat1Code nvarchar(10),
	   @subCat2Code nvarchar(10),
	     @newCode nvarchar(30),
		 @maxId bigint

		 select @maxId=isnull(count(ItemID),0) from NERPWebPortal.[dbo].[ItemBk] where CategoryID=@CategoryID and BrandID=@BrandID and SubCategory1ID=@SubCategory1ID and SubCategory2ID=@SubCategory2ID

		 select @catCode=CategorycODE from Category where CategoryID=@CategoryID
		 select @brandCode=brandCode from Brand where BrandID=@BrandID
		 select @subCat1Code=SubCategory1Code from SubCategory1 where SubCategory1ID=@SubCategory1ID
		 select @subCat2Code=SubCategory2Code from SubCategory2 where SubCategory2ID=@SubCategory2ID

		 Set @newCode= @catCode+@subCat1Code++@subCat1Code+@brandCode+RIGHT('000000'+CAST(@maxId+1 AS VARCHAR(6)),6)

	INSERT INTO NERPWebPortal.[dbo].[ItemBk]
           ([ItemID]
           ,[ItemCode]
           ,[ItemName]
           ,[CategoryID]
           ,[BrandID]
           ,[SubCategory1ID]
           ,[SubCategory2ID]
           ,[ItemCodeOld])
     VALUES
           (@ItemID
           ,@newCode
           ,@ItemName
           ,@CategoryID
           ,@BrandID
           ,@SubCategory1ID
           ,@SubCategory2ID
           ,@ItemCode)


      FETCH NEXT FROM db_cursor INTO @ItemID,@ItemCode,@ItemName,@CategoryID,@BrandID
,@SubCategory1ID,@SubCategory2ID 
END 

CLOSE db_cursor  
DEALLOCATE db_cursor