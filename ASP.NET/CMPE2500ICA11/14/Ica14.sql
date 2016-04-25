drop procedure DeleteOrderDetails
go
create procedure DeleteOrderDetails
(
@orderID int,
@productName varchar(40),
@result varchar(80) output
)
as
begin
declare @productID int
set @productID = (select ProductID from msheikh11_Northwind.dbo.Products
where ProductName like @productName)
Delete from [Order Details]

where OrderID = @orderID and ProductID = @productID

if (@@ROWCOUNT > 0)
	set @result = 'Record Deleted'
else
	set @result = 'No Records deleted'
end

go

----------------------------------------------------------------------------------------------------------------------------------------------------------------
if exists (select[name] from sysobjects where [name] = 'InsertOrderDetails')
drop procedure InsertOrderDetails
go
create procedure InsertOrderDetails
@orderID int,
@productID int,
@quantity int
as
begin
declare @unitPrice money
declare @rows int
--check that the productID exists and the orderID exist
--get unitprice from products table where the productID matches
if @orderID in (select orderID from orders)
begin
	if @productID in (select productID from products)
	begin
		set @unitPrice = (select UnitPrice from products
			where productID like @productID)
		insert into [Order Details]
		values (@OrderID, @ProductID, @unitPrice, @quantity, 0)
		set @rows = @@RowCOunt 
		return @rows
	end
end
end
go

----------------------------------------------------------------------------------------------------------------------------------------------------------------
drop procedure getProducts
go
create procedure getProducts
as
begin
select productID, productName
from Products
end

go
----------------------------------------------------------------------------------------------------------------------------------------------------------------
drop procedure getOrderDetails
go
create procedure getOrderDetails
(
@orderID int
)
as
begin

select od.orderID, p.ProductName,
od.UnitPrice, od.Quantity, od.Discount
from [Order Details] as od
inner join Products as p
on od.ProductID = p.ProductID
where od.OrderID = @orderID

end

----------------------------------------------------------------------------------------------------------------------------------------------------------------
execute DeleteOrderDetails 10248, 'Queso Cabrales', ''

execute getOrderDetails 10248

