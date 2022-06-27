CREATE TABLE Customers (
	Id INT NOT NULL,
	Name VARCHAR(50) NULL
)
CREATE TABLE Orders (
    Id INT NOT NULL,
    CustomerId INT NOT NULL
)

SELECT Customers.Name as "Customers" FROM Customers
WHERE NOT EXISTS (SELECT Id FROM Orders WHERE Orders.CustomerId = Customers.Id)
