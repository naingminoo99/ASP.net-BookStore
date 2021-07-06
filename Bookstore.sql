Use Bookstore;

drop table OrderItems;
drop table PurchaseOrder; 
drop table Book; 
drop table Member;
drop table Customer;
drop table Author; 

Create Table Author (
	Id int identity(1,1) primary key,
	Name varchar(30),
	Profile varchar(100),
	Dob date

);

Create Table Book (
	sno int identity(1,1), 
	id as 'B'+cast(sno as varchar(9)) persisted primary key,
	AuthorId int  not null,
	Title varchar(50),
	Price money,
	ImageFile varchar(30),
	foreign key ( AuthorId ) references Author(Id),
);

Create Table Member
(	
	Email varchar(20) primary key,
	Username varchar(30),
	Password varchar(20) not null

);

Create Table Customer
(	
	Email varchar(30) primary key,
	Username varchar(30),
	Password varchar(20) not null,
	Phone varchar(30),
	Address varchar (100),
	Unitnum varchar (20),
	Zipcode int 
);

Create Table PurchaseOrder(
	OrderId int identity(1,1) primary key,
	CustomerId varchar(30) not null,
	OrderDate date,
	CreditCard varchar(20),
	Total money,
	foreign key (CustomerId) references Customer(Email)
);

Create Table OrderItems(
	OrderId int,
	BookId varchar(10), 
	primary key(OrderId, BookId),
	foreign key (BookId) references Book(Id),
	foreign key (orderId) references PurchaseOrder(OrderId)
);

--Insert Queries
insert into Author values ('Ryan', 'Profile one', '1990-1-1');
insert into Author values ('Tan', 'Profile two', '1990-2-20');
insert into Author values ('Han', 'Profile three', '1990-3-3');
insert into Author values ('Dani', 'Profile four', '1990-4-4');
insert into Author values ('Jane', 'Profile five', '1990-5-5');

insert into Book (Title, AuthorId, price, imagefile) values ('Harry Potter', 1 , 34, '1.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('JavaScript', 2 , 21, '2.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('ASP.net MVC', 3 , 53, '3.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('Flash & Zoom', 4 , 12, '4.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('BatMan', 5 , 34, '5.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('SuperMan 2', 1 , 21, '6.jpg');
insert into Book (Title, AuthorId, price, imagefile) values ('Harry Potter 2', 2, 38, '7.jpg');

insert into Member values ('ryan@gmail.com', 'Ryan', '12345');
insert into Member values ('Dani@gmail.com', 'Dani', '12345');
insert into Member values ('jacky@gmail.com', 'Jacky', '12345');

insert into Customer values('naingminoo.ryan@gmail.com','Naing Min Oo','12345','82256961','Jackson Square','11-04',3299892);
insert into Customer values('patel.yusuf99@gmail.com','Yusuf','12345','88141682','Micheal regency','11-04',328765);

--insert into PurchaseOrder values ('naingminoo.ryan@gmail.com','2019-7-1','1234567891234567',234);
--insert into PurchaseOrder values ('naingminoo.ryan@gmail.com','2019-10-2','1234567891234567',15);
--insert into PurchaseOrder values ('naingminoo.ryan@gmail.com','2019-10-6','1234567891234567',78);

--insert into	OrderItems values (1,'B3');
--insert into	OrderItems values (1,'B5');
--insert into	OrderItems values (1,'B6');
--insert into	OrderItems values (2,'B1');
--insert into	OrderItems values (2,'B3');
--insert into	OrderItems values (2,'B2');
--insert into	OrderItems values (3,'B1');
--insert into	OrderItems values (3,'B3');
--insert into	OrderItems values (3,'B2');
--insert into	OrderItems values (3,'B4');

Select * from Author;
Select * from Book;
Select * from Member;
Select * from Customer;
Select * from PurchaseOrder;
Select * from OrderItems;