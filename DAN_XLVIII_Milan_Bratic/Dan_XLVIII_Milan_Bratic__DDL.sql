--Creating database only if database is not created yet
IF DB_ID('Zadatak_48') IS NULL
CREATE DATABASE Zadatak_48
GO
USE Zadatak_48;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblPrice')
drop table tblPrice;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblOrder')
drop table tblOrder;

create table tblPrice (
PriceID int identity (1,1) primary key,
Meal nvarchar (20),
Price int 
)

create table tblOrder(
OrderID int identity (1,1) primary key,
Napolitana int,
Kapricoza int,
Margarita int,
Sicilijana int,
Special int,
OrderDate nvarchar (30),
CustomerJMBG nvarchar (30),
OrderStatus nvarchar (30),
TotalAmount int
)

Insert into tblPrice values ('Napolitana',630),('Kapricoza',490),('Margarita',350),('Sicilijana',750),('Special',980);


