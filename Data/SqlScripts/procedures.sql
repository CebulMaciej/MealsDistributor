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

go

create procedure UpdateUser
@id uniqueidentifier,
@email nvarchar(256),
@password nvarchar(max)
as
begin

if not exists(select * from dbo.Users where USR_Id = @id)
	select Result = 2
else
if  exists(select * from dbo.Users where USR_Email = @email and USR_Id <> @id)
	select Result = 1
else
begin
	update dbo.Users
	set USR_Password = isnull(@password,USR_Password),
		USR_Email = isnull(@email,USR_Email)

	select * from dbo.Users where USR_Id = @id
end
end