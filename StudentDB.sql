create database StudentDB;


use StudentDB
go


create table Student 
(
	id_student int not null identity(1,1) primary key,
	SSurName nvarchar(50) check (SSurName <> '') not null,
	SName nvarchar(50) check (SName  <> '') not null,
	SAge int not null
);
go

insert into Student values
('Кириленко', 'Жора', 22),
('Сидоренко', 'Світлана', 25);
go