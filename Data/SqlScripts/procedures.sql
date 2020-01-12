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
@endDate datetime
as
begin

	

	
	update Meals 
	set 
	MLS_Id =@mealId,
	MLS_Name=@name,
	MLS_Description = @description,
	MLS_Price = @price,
	MLS_StartDate = @startDate,
	MLS_EndDate = @endDate
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

create procedure GetUserByLoginAndPassword
@login nvarchar(max),
@password nvarchar(max)
as
begin

	select USR_Id ,
	USR_Email,
	USR_Password,
	USR_CreationDate,
	USR_Role
	from Users where USR_Email = @login and USR_Password = @password

end

go

create procedure GetOrders
as
begin

select ORD_Id,
       ORD_CreationDate,
	   ORD_OrderBoyId,
	   ORD_RestaurantId,
	   ORD_IsOrdered
from Orders

end

go

create procedure GetOrderById
@orderId uniqueidentifier
as
begin

select ORD_Id,
       ORD_CreationDate,
	   ORD_OrderBoyId,
	   ORD_RestaurantId,
	   ORD_IsOrdered

from Orders

where ORD_Id = @orderId

end

go

create procedure GetOrderPositionsByOrderId
@orderId uniqueidentifier
as
begin
	select OP_Id,
		   OP_CreationDate,
		   OP_UserId,
		   OP_MealId,
		   OP_OrderId 

	from OrderPositions 

	where OP_OrderId = @orderId
end

go


create procedure GetOrderPositionsByUserId
@userId uniqueidentifier
as
begin
	select OP_Id,
		   OP_CreationDate,
		   OP_UserId,
		   OP_MealId,
		   OP_OrderId 

	from OrderPositions 

	where OP_UserId = @userId
end


go


create procedure GetOrderPropositions
as
begin
	select 
		   OrdProp_Id,
	       OrdProp_CreationDate,
	       OrdProp_TimeToOrdering,
		   OrdProp_CreatorId,
		   OrdProp_RestaurantId,
		   OrdProp_OrderingStopped 

	from OrdersPropositions 

	where OrdProp_OrderingStopped = 0
end

go

create procedure GetOrderPropositionsInWhichUserHasAvailableOffer
@userId uniqueidentifier
as
begin
	select distinct OrdProp_Id,
	       OrdProp_CreationDate,
	       OrdProp_TimeToOrdering,
		   OrdProp_CreatorId,
		   OrdProp_RestaurantId,
		   OrdProp_OrderingStopped 

	from OrdersPropositions op
		join OrdersPropositionsPositions opp on op.OrdProp_Id = opp.Opp_OrderPropositionId
	
	where OPP_UserId = @userId
end

go


create procedure CreateOrderProposition
@userId uniqueidentifier,
@timeToOrdering datetime,
@restaurantId uniqueidentifier
as
begin
	 
	 if exists(select * from OrdersPropositions where OrdProp_OrderingStopped = 0)
	 begin
		select ResultCode = 1
	 end
	 else
		begin
		    select ResultCode = 0

			declare @newOrderPropositionId uniqueidentifier

			select @newOrderPropositionId = newId()

			insert into OrdersPropositions values(@newOrderPropositionId,getdate(),@timeToOrdering,@userId,@restaurantId,0)
		    
			select OrdProp_Id,
				   OrdProp_CreationDate,
				   OrdProp_TimeToOrdering,
				   OrdProp_CreatorId,
				   OrdProp_RestaurantId,
				   OrdProp_OrderingStopped  
			from OrdersPropositions 
			where OrdProp_Id = @newOrderPropositionId

		end

end

go

create procedure GetOrderPropositionPositionsByPropositionOrderId
@orderPropositionId uniqueidentifier
as
begin

		select * from OrdersPropositionsPositions where OPP_OrderPropositionId = @orderPropositionId

end

go

create procedure CreateOrderPropositionPosition
@userId uniqueidentifier,
@mealId uniqueidentifier,
@orderPropositionId uniqueidentifier
as
begin
	 
			declare @newOrderPropositionPositionId uniqueidentifier

			select @newOrderPropositionPositionId = newId()

			insert into OrdersPropositionsPositions values(@newOrderPropositionPositionId,getdate(),@userId,@mealId,@orderPropositionId)
		    
			select * from OrdersPropositionsPositions where OPP_Id = @newOrderPropositionPositionId

end

go

create procedure GetOrderPropositionById
@orderPropositionId uniqueidentifier
as
begin
 select * from OrdersPropositions where OrdProp_Id = @orderPropositionId
end

go

create procedure CreateOrderFromOrderProposition
@orderPropositionId uniqueidentifier 
as
begin

	begin transaction

		declare @orderBoyId uniqueidentifier

		select top 1 @orderBoyId = OPP_UserId 
		from OrdersPropositionsPositions 
		where Opp_OrderPropositionId = @orderPropositionId 
		order by newId()

		declare @orderId uniqueidentifier = newId()

		insert into dbo.Orders(ORD_Id,ORD_CreationDate,ORD_OrderBoyId,ORD_RestaurantId,ORD_IsOrdered)
		(select @orderId,getdate(),@orderBoyId,z.OrdProp_RestaurantId,1 from dbo.OrdersPropositions z where OrdProp_Id = @orderPropositionId)

		insert into dbo.OrderPositions(OP_Id,OP_CreationDate,OP_UserId,OP_MealId,OP_OrderId)
		(select newId(),getdate(),OPP_UserId,OPP_MealId,@orderId from dbo.OrdersPropositionsPositions where OPP_OrderPropositionId = @orderPropositionId) 

		delete from dbo.OrdersPropositionsPositions where Opp_OrderPropositionId = @orderPropositionId
		delete from dbo.OrdersPropositions where OrdProp_Id = @orderPropositionId

		exec GetOrderById @orderId


	commit transaction

end

go

create procedure MarkOrderAsOrdered
@orderId uniqueidentifier 
as
begin

update Orders
Set ORD_IsOrdered = 1
where ORD_Id = @orderId

end