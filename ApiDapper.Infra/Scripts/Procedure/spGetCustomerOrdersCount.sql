CREATE PROCEDURE spGetCustomerOrdersCount
    @Document Char(11)
AS
  SELECT c.[Id],
         CONCAT(c.[FirstName], ' ', c.[LastName]) AS [Name],
         c.[Document],
         COUNT(O.Id) AS [Orders]
  FROM
    [Customer] c INNER JOIN [Order] o ON o.[CustomerId] = c.[Id]
  WHERE
    c.[Document] = @Document
  GROUP BY
    c.[Id],
    c.[FirstName],
    c.[LastName],
    c.[Document]