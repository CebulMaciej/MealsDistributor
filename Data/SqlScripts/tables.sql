﻿

create table Users
(
	USR_Id uniqueidentifier primary key,
	USR_Email nvarchar(256) unique not null,
	USR_Password nvarchar(max) not null,
	USR_CreationDate datetime not null,
	USR_Role int not null
)

create table Restaurants
(
	RST_Id uniqueidentifier primary key,
	RST_Name nvarchar(1024) not null,
	RST_PhoneNumber nvarchar(12) not null,
	RST_IsPyszne bit not null, 
	RST_MinOrderCost decimal(15,2),
	RST_DeliveryCost decimal(15,2),
	RST_MaxPaidOrderValue decimal(15,2)
)

create table Meals
(
	MLS_Id uniqueidentifier primary key,
	MLS_Name nvarchar(1024) not null,
	MLS_Description nvarchar(max) not null,
	MLS_Price decimal(15,2) not null,
	MLS_StartDate date default null,
	MLS_EndDate date default null,
	MLS_RestaurantId uniqueidentifier not null references Restaurants(RST_Id)
)

create table DeliveryHours
(
	DH_Id uniqueidentifier primary key,
	DH_RestaurantId uniqueidentifier not null references Restaurants(RST_Id),
	DH_Day int not null,
	DH_StartTime time not null,
	DH_EndTime time not null
)

create table OrderPositions
(
	OP_Id uniqueidentifier primary key,
	OP_CreationDate datetime not null,
	OP_UserId uniqueidentifier not null references Users(USR_Id),
	OP_MealId uniqueidentifier not null references Meals(MLS_Id)
)

create table Orders
(
	ORD_Id uniqueidentifier primary key,
	ORD_CreationDate datetime not null,
	ORD_OrderBoyId uniqueidentifier not null references Users(USR_Id),
	ORD_IsOrdered bit not null default 0
)

create table [Configurations]
(
	CON_Key uniqueidentifier primary key,
	CON_Value nvarchar(max)
)

