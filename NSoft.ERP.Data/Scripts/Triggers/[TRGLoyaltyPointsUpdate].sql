USE [NERPSUPER]
GO

/****** Object:  Trigger [dbo].[TRGLoyaltyPointsUpdate]    Script Date: 08/29/2020 00:16:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
CREATE TRIGGER [dbo].[TRGLoyaltyPointsUpdate]
   ON  [dbo].[LoyaltyTransaction]
   AFTER  INSERT
AS 
BEGIN
 
SET NOCOUNT ON;
	
SELECT LoyaltyCustomerid,TransactionType,SUM(CASE WHEN TransactionType =1 THEN Points ELSE -Points END) AS Points  into #TempLoyaltyPoints
FROM Inserted
GROUP BY LoyaltyCustomerid,TransactionType

UPDATE lc
SET lc.CurrentPoints=lc.CurrentPoints+t.Points,lc.EarnPoints=lc.EarnPoints+t.Points
FROM  LoyaltyCustomer lc INNER JOIN
#TempLoyaltyPoints t ON lc.LoyaltyCustomerid=t.LoyaltyCustomerid
WHERE t.TransactionType=1

UPDATE lc
SET lc.CurrentPoints=lc.CurrentPoints-t.Points,lc.RedeemPoints=lc.RedeemPoints+t.Points
FROM  LoyaltyCustomer lc INNER JOIN
#TempLoyaltyPoints t ON lc.LoyaltyCustomerid=t.LoyaltyCustomerid
WHERE t.TransactionType=2

DROP TABLE #TempLoyaltyPoints

END

GO


