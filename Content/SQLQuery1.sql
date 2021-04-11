Create Table Week (
	UserId int NOT NULL,
	WeekId int NOT NULL,
	year int,
	TotalHours int,
	SunHours int,
	MonHours int,
	TuesHours int,
	WedsHours int,
	ThursHours int,
	FriHours int,
	SatHours int,
	CONSTRAINT PK_UserId PRIMARY KEY (WeekId),
	CONSTRAINT FK_UserId FOREIGN KEY (UserId)
	REFERENCES UserProfile(UserId)
);
select * from UserProfile;
Insert into Week 
Values (1, 6, 2021, 10, 0, 1, 2, 3, 4, 5, 6);
select * from Week;
