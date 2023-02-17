create table CustomUser
(
id int primary key identity(1,1),
first_name varchar(17) not null,
user_email varchar(127) unique,
user_role varchar(17) not null,
user_passord varchar(17) not null
)

create table Category
(
category_id int primary key identity(1,1),
category_name varchar(50) not null
)

create table Product 
(
product_id int primary key identity(1,1),
category_id int not null,
product_name varchar(50) not null,
product_description varchar(127),
product_price int not null,
product_stock int not null, 
foreign key (category_id) references Category(category_id)
)

create table Review 
(
product_id int,
customer_id int,
review_text varchar(527) null,
review_rating int not null,
foreign key (product_id) references Product(product_id),
foreign key (customer_id) references CustomUser(id),
primary key (product_id, customer_id)
)

create table Cart 
(
cart_id int primary key identity(1,1),
customer_id int not null,
foreign key (customer_id) references CustomUser(id)
)

create table CartItem
(
product_id int not null,
cart_id int not null,
qty int not null,
price int, 
foreign key (product_id) references Product(product_id),
foreign key (cart_id) references Cart(cart_id),
primary key (product_id, cart_id)
)

create table Booking
(
booking_id int primary key identity(1,1), 
cart_id int not null,
booking_price int,
booking_status varchar(17) not null,
booking_delivery varchar(50) not null,
booking_address varchar(100) not null,
foreign key (cart_id) references Cart(cart_id)
)