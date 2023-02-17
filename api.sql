create table Пользователи
(
Номер_пользователя int primary key,
Никнейм nvarchar(50) not null,
Фамилия nvarchar(50) not null,
Имя nvarchar(50) not null,
Отчество nvarchar(50) not null,
Почта nvarchar(50) not null,
Номер_телефона nvarchar(25) not null,
Дата_рождения date not null
)


create table Товар 
(
Номер_товар int primary key,
Название nvarchar(50) not null,
Цена_товара decimal(25,2) not null,
Описание_товар nvarchar(50) not null,
Артикул int not null
)


create table Сохраненные_адреса
(
ID_пользователя int,
Город nvarchar(50) not null,
Улица nvarchar(50) not null,
Дом int not null,
Построение int not null,
Квартира int not null,
Название_адреса nvarchar(100) not null,
primary key(ID_пользователя, Название_адреса), 
foreign key (ID_пользователя) references  Пользователи(Номер_пользователя)
)

create table Корзина 
(
ID_пользователя int,
Номер_корзины int,
Сумма int not null,
primary key(ID_пользователя, Номер_корзины),
foreign key (ID_пользователя) references Пользователи(Номер_пользователя),
foreign key(Номер_корзины) references Товар(Номер_товар)
)

create table Заказ
(
Номер_заказа int,
ID_пользователя int,
Номер_товара  int,
Дата_и_время_отправки datetime not null,
Статус nvarchar(50) not null,
primary key(Номер_заказа, ID_пользователя, Номер_товара),
foreign key(ID_пользователя) references Пользователи(Номер_пользователя),
foreign key(Номер_товара) references Товар(Номер_товар)
)