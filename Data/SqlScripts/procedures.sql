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

	--if( exists(select * from Restaurants where RST_Id = @restaurantId))

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

create procedure GetRestaurants
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

end

go


create procedure AddRestaurant
	@Name nvarchar(1024),
	@PhoneNumber nvarchar(12),
	@IsPyszne bit, 
	@MinOrderCost decimal(15,2),
	@DeliveryCost decimal(15,2),
	@MaxPaidOrderValue decimal(15,2)
as
begin 

declare @newId uniqueIdentifier

	select @newId = newid()

insert into Restaurants  values(@newId,@Name,@PhoneNumber,@IsPyszne,@MinOrderCost,@DeliveryCost,@MaxPaidOrderValue)

exec GetRestaurantById @newId

end

go


create procedure EditRestaurant
    @Id uniqueidentifier,
	@Name nvarchar(1024),
	@PhoneNumber nvarchar(12),
	@IsPyszne bit, 
	@MinOrderCost decimal(15,2),
	@DeliveryCost decimal(15,2),
	@MaxPaidOrderValue decimal(15,2)
as
begin 


update Restaurants set  
RST_Name = @Name,
RST_PhoneNumber = @PhoneNumber,
RST_IsPyszne = @IsPyszne,
RST_MinOrderCost = @MinOrderCost,
RST_DeliveryCost = @DeliveryCost,
RST_MaxPaidOrderValue = @MaxPaidOrderValue
where RST_Id = @Id
exec GetRestaurantById @Id

end

go


create procedure RemoveRestaurant
@restaurantId uniqueidentifier 
as 
begin

delete from Restaurants where RST_Id = @restaurantId

end

go

create procedure CreateMeal
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

create procedure UpdateMeal
@mealId uniqueidentifier,
@name nvarchar(256),
@description nvarchar(max),
@price decimal(15,2),
@startDate datetime,
@endDate datetime,
@restaurantId uniqueidentifier
as
begin

	

	
	update Meals 
	set 
	MLS_Id =@mealId,
	MLS_Name=@name,
	MLS_Description = @description,
	MLS_Price = @price,
	MLS_StartDate = @startDate,
	MLS_EndDate = @endDate,
	MLS_RestaurantId = @restaurantId
	where MLS_Id = @mealId

	exec GetMealById @mealId


end

go


create procedure RemoveMeal
@mealId uniqueidentifier
as 
begin

	delete from Meals where MLS_Id = @mealId

end
go