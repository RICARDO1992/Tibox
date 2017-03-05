CREATE PROC dbo.CustomerSearchByNames
@FISTNAME  NVARCHAR(40),
@LASTNAME  NVARCHAR(40)
AS 
BEGIN 

	SET NOCOUNT ON;
	SELECT 
		Id,
		FirstName,
		LastName,
		City,
		Country,
		Phone
	FROM dbo.Customer
	WHERE FirstName = @FISTNAME AND LastName = @LASTNAME
	SET NOCOUNT OFF;
END

