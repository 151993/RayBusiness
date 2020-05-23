--CREATE DATABASE DOMAIN
--USE DOMAIN

CREATE TABLE Users
(
UserId int primary key Identity(1,1)
,UserName nvarchar(50) not null
,FirstName nvarchar(50)
,LastName nvarchar(50)
,EmailId nvarchar(50)
,Alias nvarchar(50)
,Type nvarchar(50)
,Position nvarchar(50)
,ManagerId int
)

select u.FirstName as Manager, m.FirstName as Client from Users m, Users u where u.UserId= m.ManagerId and u.UserId=1

select * from Users