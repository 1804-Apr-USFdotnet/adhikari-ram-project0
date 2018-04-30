--create database Anything;
--go

use Anything;
go


--CREATE SCHEMA Challenge;
--go

--CREATE TABLE Challenge.Customers (
--	CustomerId int identity(1,1) NOT NULL primary key,
--	FirstName nvarchar(100) NOT NULL,
--	LastName nvarchar(250) NOT NULL,
--	CardNumber nvarchar(50) NOT NULL
--);

--CREATE TABLE Challenge.Products(
--	ProductId int identity(1,1) NOT NULL primary key,
--	[Name] nvarchar(200) NOT NULL,
--	Price float NOT NULL 
--);

--CREATE TABLE Challenge.Orders (
--	OrderId int identity(1,1) NOT NULL primary key,
--	CustomerId int NOT NULL foreign key references Challenge.Customers(CustomerId),
--	ProductId int NOT NULL foreign key references Challenge.Products(ProductId)
--);

--INSERT INTO Challenge.Customers (FirstName, LastName, CardNumber)
--VALUES ('Who1', 'Me1', '12345');

--INSERT INTO Challenge.Customers (FirstName, LastName, CardNumber)
--VALUES ('Who2', 'Me2', '54321');

--INSERT INTO Challenge.Customers (FirstName, LastName, CardNumber)
--VALUES ('Who3', 'Me3', '56789');

--select * from Challenge.Customers;

--INSERT INTO Challenge.Products ([Name], Price)
--VALUES ('Laptop', '1000');

--INSERT INTO Challenge.Products ([Name], Price)
--VALUES ('Mouse', '30');

--INSERT INTO Challenge.Products ([Name], Price)
--VALUES ('Keyboard', '20');

--select * from Challenge.Products;

--INSERT INTO Challenge.Orders (CustomerId, ProductId)
--VALUES (1, 1);

--INSERT INTO Challenge.Orders (CustomerId, ProductId)
--VALUES (2, 2);

--INSERT INTO Challenge.Orders (CustomerId, ProductId)
--VALUES (3, 3);

--select * from Challenge.Orders;

--INSERT INTO Challenge.Products ([Name], Price)
--VALUES ('iPhone', '200');


--INSERT INTO Challenge.Customers (FirstName, LastName, CardNumber)
--VALUES ('Tina', 'Smith', '11111');

--INSERT INTO Challenge.Orders (CustomerId, ProductId)
--VALUES (4, 4);

--select * from Challenge.Orders
--where CustomerId = 4;

--select sum(Price) from Challenge.Products
--where LastName = 'Smith';

--UPDATE Challenge.Products
--SET Price = 250
--WHERE ProductId = 4;










