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

go

create procedure GetConfiguration
@key nvarchar(256)
as
begin
	
	select CON_Key, CON_Value from [Configurations] where CON_Key = @key

end

go


create procedure UpdateConfigurationAndThenGet
@key nvarchar(256),
@value nvarchar(256)
as
begin
	
	Update [Configurations]
	set CON_Value = @value
	where CON_Key = @key

	select CON_Key, CON_Value from [Configurations] where CON_Key = @key

end

go

create procedure GetMealById
@mealId uniqueidentifier
as
begin

	select 
	MLS_Id,
	MLS_Name,
	MLS_Description,
	MLS_Price,
	MLS_StartDate,
	MLS_EndDate,
	MLS_RestaurantId
	from Meals where MLS_Id = @mealId
end

go

create procedure GetMealsByRestaurantId
@restaurantId uniqueidentifier
as
begin

	if( exists(select * from Restaurants where RST_Id = @restaurantId))

	select ExistsRestaurant = cast(case when exists(select * from Restaurants where RST_Id = @restaurantId) then 1 else 0 end as bit)

	select 
	MLS_Id,
	MLS_Name,
	MLS_Description,
	MLS_Price,
	MLS_StartDate,
	MLS_EndDate,
	MLS_RestaurantId
	from Meals
	where MLS_RestaurantId = @restaurantId
end



go

create procedure GetRestaurantById
@restaurantId uniqueidentifier
as
begin 

select RST_Id,
	RST_Name,
	RST_PhoneNumber,
	RST_IsPyszne,
	RST_MinOrderCost,
	RST_DeliveryCost,
	RST_MaxPaidOrderValue
	from Restaurants
	where RST_Id = @restaurantId

end

go

create procedure CreateMeal
@mealId uniqueidentifier,
@name nvarchar(256),
@description nvarchar(max),
@price decimal(15,2),
@startDate datetime,
@endDate datetime,
@restaurantId uniqueidentifier
as
begin

	declare @newMealId uniqueIdentifier

	select @newMealId = newid()

	
	insert into Meals values(@newMealId,@name,@description,@price,@startDate,@endDate,@restaurantId)

	exec GetMealById @newMealId


end

go
