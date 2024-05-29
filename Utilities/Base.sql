-- Active: 1716769896172@@bztbie9l81xaio61vh2b-mysql.services.clever-cloud.com@3306
create table Users(
    Id int not null auto_increment,
    Names varchar(45),
    LastNames varchar(45),
    Email varchar(100),
    Password varchar (100),
    PRIMARY KEY(Id)
);

-- Insertamos datos a la tabla
insert into Users (Names, LastNames, Email, Password) values ("Fernando", "Gómez", "fjgt2000@gmail.com", "fernando123");

select * from Users;