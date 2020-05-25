CREATE PROCEDURE spUpdateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13)
AS
    UPDATE [Customer] SET 
        [FirstName] = @FirstName, 
        [LastName] = @LastName, 
        [Document] = @Document, 
        [Email] = @Email, 
        [Phone] = @Phone
    WHERE [Id] = @Id
