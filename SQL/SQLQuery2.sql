select * from UserProfile
Delete IsActive from UserProfile
Delete from week
ALTER TABLE UserProfile
drop column IsActive
Add managerId int

ALTER TABLE UserProfile
alter column type
varchar (50)

alter table week
add status varchar


insert into UserProfile(UserName, Password, type)
values ('scott', 'scott5', 'manager');

insert into UserProfile(UserName, Password, type, managerId)
values ('Mark', 'Mark5', 'employee', 12);

insert into UserProfile(UserName, Password, type, managerId)
values ('Justin', 'Justin5', 'employee', 12);

insert into UserProfile(UserName, Password, type, managerId)
values ('Tom', 'Tom5', 'employee', 12);

insert into UserProfile(UserName, Password, type)
values ('Abby', 'Abby5', 'manager');

insert into UserProfile(UserName, Password, type, managerId)
values ('Chris', 'Chris5', 'employee', 16);

insert into UserProfile(UserName, Password, type, managerId)
values ('Dave', 'Dave5', 'employee', 16);
