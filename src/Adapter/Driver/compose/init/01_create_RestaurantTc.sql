CREATE DATABASE RestaurantTc;

USE RestaurantTc;

CREATE table Customer(
	CustomerId bigint not null AUTO_INCREMENT,
	Name varchar(200) not null,
	Email varchar(200) not null,
	CPF varchar(20) not null unique,
	primary key(CustomerId)
);

CREATE TABLE Product(
	ProductId bigint not null AUTO_INCREMENT,
	Name varchar(200) not null,
	Description varchar(200) not null,
	Price decimal(10,2) not null,
	Category int not null,
	IsActive tinyint not null,
	primary key (ProductId)
);

CREATE TABLE Ordered(
	OrderedId varchar(36) not null primary key,
	RequestDate datetime not null,
	TotalPrice decimal(10,2) not null,
	OrderStatus int not null,
	CustomerId bigint null,
	IsActive tinyint not null,
	foreign key(CustomerId) REFERENCES Customer(CustomerId)
);

CREATE TABLE ProductOrdered(
	OrderedId varchar(36) not null,
	ProductId bigint not null,
	CONSTRAINT pk_ProductOrdered primary key (OrderedId, ProductId),
	CONSTRAINT fk_ProductOrdered_ordered foreign key (OrderedId) references Ordered(OrderedId),
	CONSTRAINT fk_ProductOrdered_product foreign key (ProductId) references Product(ProductId)
);