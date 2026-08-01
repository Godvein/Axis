Insert into Roles values ('Admin'), ('Employee');
go

insert into Departments (DepartmentName) values ('HR'), ('Development'), ('Infrastructure');
go

insert into Users (Username, PasswordHash, FullName, Email, RoleId, IsActive) values ('Admin', '$2a$11$j6AFwsZlt9hh8dPLplsM6ulPWlk0tuwplUecWOGK.n9TbMylJGhMe',
'TestAdmin', 'admin@gmail.com', 1, 1);
go
