create table Roles (
	RoleId int identity primary key,
	RoleName varchar(50),
	);
go

create table Departments (
DepartmentId int identity primary key,
DepartmentName varchar(255)
)
go

create table Users (
	UserId int identity primary key,
	Username varchar(100),
	PasswordHash varchar(255),
	FullName varchar (100),
	Email varchar(100),
	RoleId int,
	DepartmentId int,
	IsActive bit,
	CreatedAt datetime default getdate(),
	foreign key (RoleId) references Roles(RoleId),
	foreign key (DepartmentId) references Departments(DepartmentId)
);
go

Create Table Tasks (
	TaskId int identity primary key,
	Title varchar(100),
	Description varchar(max),
	Priority varchar(50),
	Status varchar(50),
	DueDate datetime,
	AssignedTo int,
	CreatedBy int,
	CreatedAt datetime default getdate(),
	UpdatedAt datetime default getdate()
	foreign key (AssignedTo) references Users(UserId),
	foreign key (CreatedBy) references Users(UserId)
	);

go