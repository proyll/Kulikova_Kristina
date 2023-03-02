create table Userss
(
id int primary key identity(1,1),
first_name varchar(17) not null,
user_email varchar(127) unique,
user_role varchar(17) not null,
user_passord varchar(17) not null
)
create table Filterr
(
category_id int primary key,
category_name varchar(50) not null,
subcategory_name varchar(50) not null,
product_id int not null,
name_p varchar(50) not null,
color varchar(50) NOT NULL,
popular bit not null,
material varchar(50) not null,
size varchar(5) not null,
price int not null,
sale int not null,
)
create table Product 
(
product_id int primary key identity(1,1),
category_id int not null,
name_p varchar(50) not null,
description_p varchar(127),
price int not null,
product_availability int not null, 
foreign key (category_id) references Filterr(category_id)
)

create table DescriptionProduct
(
product_id int,
customer_id int,
text_d varchar(436) null,
rating int not null,
foreign key (product_id) references Product(product_id),
foreign key (customer_id) references Userss(id),
primary key (product_id, customer_id)
)

create table Cart 
(
cart_id int primary key identity(1,1),
customer_id int not null,
foreign key (customer_id) references Userss(id)
)

create table CartItem
(
product_id int not null,
cart_id int not null,
quantity int not null,
price int, 
foreign key (product_id) references Product(product_id),
foreign key (cart_id) references Cart(cart_id),
primary key (product_id, cart_id)
)

create table Booking
(
booking_id int primary key identity(1,1), 
cart_id int not null,
price int,
status_b varchar(17) not null,
delivery varchar(50) not null,
address_b varchar(100) not null,
foreign key (cart_id) references Cart(cart_id)
)
