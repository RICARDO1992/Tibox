
ALTER PROC dbo.OrderByOrderNumber
@OrderNumber  NVARCHAR(10)
AS 
BEGIN 

	SET NOCOUNT ON;
	SELECT 
		Id,
		OrderDate,
		OrderNumber,
		CustomerId,
		TotalAmount
	FROM [dbo].[Order]
	WHERE OrderNumber = @OrderNumber

	SET NOCOUNT OFF;
END