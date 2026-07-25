-- User Login SP
create proc usp_Login 
@Username varchar(100),
@returnMsg varchar(50) out
as
begin
if exists (select 1 from Users where Username = @Username)
begin 
select UserId, Username, FullName, RoleId, IsActive 
from Users where Username = @Username  
set @returnMsg = 'ok'
end
else
begin
set @returnMsg = 'wrong username or password'
end
end
go

-- Get User SP
create proc usp_GetUsers
@UserId int,
@flag int
as
begin
if @flag = 0
begin
select Username, FullName, Email, RoleId, DepartmentId, IsActive, CreatedAt from Users
where UserId = @UserId
end
if @flag = 1
begin
select u.UserId, u.Username, u.FullName, r.RoleName, d.DepartmentName, u.IsActive from Users u
left join Roles r on u.RoleId = r.RoleId left join Departments d on u.DepartmentId = d.DepartmentId
end
end

go

-- Create Task SP
create proc usp_CreateTask
@Title varchar(100),
@Description varchar(max),
@Priority varchar(50),
@Status varchar(50),
@DueDate datetime,
@AssignedTo int,
@CreatedBy int

as
begin
insert into Tasks (Title, Description, Priority, Status, DueDate, AssignedTo, CreatedBy)
values (@Title, @Description, @Priority, @Status, @DueDate, @AssignedTo, @CreatedBy)
end
go

-- Update Task SP
create proc usp_UpdateTask
@TaskId int,
@Title varchar(100),
@Description varchar(max),
@Priority varchar(50),
@Status varchar(50),
@DueDate datetime,
@AssignedTo int,
@CreatedBy int

as
begin
update Task set Title = @Title, Description = @Description, Priority = @Priority,
Status = @Status, DueDate = @DueDate, AssignedTo = @AssignedTo, CreatedBy = @CreatedBy
where TaskId = @TaskId
end
go

-- Delete Task SP
create proc usp_DeleteTask
@TaskId int

as
begin
delete from Task where TaskId = @TaskId
end
go

-- Get Task SP
create proc usp_GetTasks
@TaskId int,
@flag int

as
begin
if @flag = 0
begin
select TaskId, Title, Description, Priority, Status, DueDate, AssignedTo,
CreatedBy, CreatedAt, UpdatedAt from Tasks
end

if @flag = 1
begin
select * from Tasks where TaskId = @TaskId
end
end
go

-- Admin Dashboard Info SP
create proc usp_AdminDashboardInfo 
@UsersCount int out,
@TasksCount int out,
@RolesCount int out,
@DepartmentsCount int out
as
begin
set @UsersCount = (select count(UserId) as UsersCount from Users)
set @TasksCount = (select count(TaskId) as TasksCount from Tasks)
set @RolesCount = (select count(RoleId) as RolesCount from Roles)
set @DepartmentsCount = (select count(DepartmentId) as DepartmentsCount from Departments)
end
go

-- Get Roles SP
create proc usp_GetRoles 
as
begin

set nocount on
select * from Roles
end
go

-- Get Departments SP
create proc usp_GetDepartments
as
begin

set nocount on
select * from Departments
end
go

-- Create User SP
create proc usp_CreateUser
@Username varchar(100),
@PasswordHash varchar(255),
@FullName varchar(100),
@Email varchar(100),
@RoleId int,
@DepartmentId int
as
begin
insert into Users (Username, PasswordHash, FullName, Email, RoleId, IsActive, DepartmentId)
values (@Username, @PasswordHash, @FullName, @Email, @RoleId, '1', @DepartmentId);
end
go

-- Delete User SP
create proc usp_DeleteUser 
@UserId int
as
begin
delete from Users where UserId = @UserId
end
go

-- Edit User SP
create proc usp_UpdateUser
@UserId int,
@Username varchar(100),
@FullName varchar(100),
@Email varchar(100),
@RoleId int,
@DepartmentId int,
@IsActive bit

as
begin
update Users set Username = @Username, FullName = @FullName,
Email = @Email, RoleId = @RoleId, DepartmentId = @DepartmentId, IsActive = @IsActive
where UserId = @UserId
end
go
