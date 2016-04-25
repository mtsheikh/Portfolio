drop proc GetCustomers
go
create proc GetCustomers
(
@filter varchar(25) = ''
)
as
begin
select CustomerID, CompanyName
from dbo.Customers
where CompanyName like '%' + @filter + '%'

end 
go

