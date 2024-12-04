-- 1
CREATE TABLE SalesSummary(
	SummaryID INT IDENTITY(1,1),
	SalesPersonID INT ,
	TotalSales FLOAT,
	ReportDate DATE
	CONSTRAINT u_summary_id UNIQUE (SummaryID)
)

--1.1
ALTER TABLE SalesSummary
ADD Comment VARCHAR(255)

--2.1
SELECT *
FROM Production.Product product
WHERE product.Name LIKE '%Bike%'

--2.2
SELECT *
FROM Person.Person
WHERE BusinessEntityID BETWEEN 10 AND 50

--2.3
SELECT EmailAddress
FROM Sales.vIndividualCustomer
WHERE EmailAddress LIKE '%gmail.com'

--3.1
SELECT header.SalesPersonID, COUNT(header.SalesPersonID) 'Orders'
FROM Sales.SalesOrderHeader header
GROUP BY header.SalesPersonID

--3.2
SELECT teritory.TerritoryID, SUM(teritory.SalesYTD + teritory.SalesLastYear) 'Teritory total sales'
FROM Sales.SalesTerritory teritory
GROUP BY teritory.TerritoryID

--3.3
SELECT 
	CASE WHEN TotalDue >5000 THEN 'Haut'
	WHEN TotalDue BETWEEN 1000 AND 5000 THEN 'Moyen'
	ELSE 'Bas'
	END
FROM Sales.SalesOrderHeader 

--4.1
SELECT 
	ProductID,COUNT(OrderQty) 'Total Qty'
FROM Sales.SalesOrderDetail
GROUP BY ProductID
HAVING COUNT(OrderQty) >50

--5.1
SELECT 
	(customer.FirstName+ ' ' +customer.LastName) 'Fullname',
	SUM(header.TotalDue) 'Somme commandes'
FROM Sales.SalesOrderHeader header
JOIN Sales.PersonCreditCard cc
ON cc.CreditCardID = header.CreditCardID
JOIN Sales.vIndividualCustomer customer
ON cc.BusinessEntityID = customer.BusinessEntityID
GROUP BY header.CustomerID,customer.FirstName,customer.LastName

--5.2
SELECT 
	ProductID
FROM Production.Product
UNION
SELECT 
	ProductID
FROM Production.ProductInventory

--6.1
SELECT 
	cc.BusinessEntityID
FROM Sales.SalesOrderHeader header
JOIN Sales.PersonCreditCard cc
ON cc.CreditCardID = header.CreditCardID
LEFT JOIN Sales.vIndividualCustomer customer
ON cc.BusinessEntityID = customer.BusinessEntityID
WHERE customer.BusinessEntityID IS NULL

--6.2
SELECT 
	DISTINCT person.FirstName,person.LastName,p.Name
FROM Sales.SalesOrderDetail d
JOIN Production.Product p 
ON p.ProductID = d.ProductID
JOIN Sales.SalesOrderHeader h 
ON h.SalesOrderID = d.SalesOrderID
JOIN Sales.PersonCreditCard cc
ON cc.CreditCardID = h.CreditCardID
JOIN Person.Person person
ON cc.BusinessEntityID = person.BusinessEntityID
WHERE p.Name LIKE '%Mountain%'

--7.1
INSERT INTO SalesSummary (SalesPersonID,TotalSales,ReportDate) 
VALUES (27, 55.55, '2024-05-14 00:00:00');

--7.2
UPDATE SalesSummary
SET Comment = 'Performance exceptionnelle'
WHERE TotalSales > 10000

--7.3
DELETE FROM SalesSummary
WHERE TotalSales IS NULL

--8.1
SELECT 
	CHARINDEX('pro',Name) 'index'
FROM Production.Product
WHERE Name LIKE '%Pro%'

--8.2
UPDATE Production.Product 
SET Name = REPLACE(Name,'Mountain','Hill')
WHERE Name LIKE '%Mountain%'

--8.3
SELECT GETDATE() 'Datetime'

--9.1

/* Using IN
SELECT *
	FROM Sales.SalesOrderDetail s
WHERE s.ProductID IN (
	SELECT 
		ProductID
	FROM Production.ProductInventory
	WHERE Quantity = 0
) AND s.OrderQty >0
*/


