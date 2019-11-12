create procedure GetUserById
@userId uniqueidentifier
as
begin

	select * from dbo.Users where USR_Id = @userId

end

go


create procedure AddUser
@email nvarchar(256),
@password nvarchar(max)
as
begin

	select * from dbo.Users where USR_Id = @userId

end

go

create procedure AddUser
@email nvarchar(256),
@password nvarchar(max)
as
begin
declare @newId uniqueidentifier = newid()

if not exists(select * from dbo.Users where USR_Email = @email)
	insert into dbo.Users values(newid(),@email,@password,getdate(),0)

select * from dbo.Users where USR_Id = @newId
end