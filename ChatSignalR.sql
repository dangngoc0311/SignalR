Create table RoomChats(
Id int primary key identity,
Name nvarchar(50),
AdminId int
)
CREATE table Messages(
Id int primary key identity,
Content ntext,
Timestamp datetime,
FromUserId int,
ToRoomId int
)