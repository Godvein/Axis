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
@CreatedBy int,
@Completed bit

as
begin
insert into Tasks (Title, Description, Priority, Status, DueDate, AssignedTo, CreatedBy, Completed)
values (@Title, @Description, @Priority, @Status, @DueDate, @AssignedTo, @CreatedBy, @Completed)
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
update Tasks set Title = @Title, Description = @Description, Priority = @Priority,
Status = @Status, DueDate = @DueDate, AssignedTo = @AssignedTo, CreatedBy = @CreatedBy
where TaskId = @TaskId
end
go

-- Delete Task SP
create proc usp_DeleteTask
@TaskId int

as
begin
delete from Tasks where TaskId = @TaskId
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
select t.TaskId, t.Title, t.Priority, t.Status, t.DueDate, assigned.Username as AssignedTo,
created.Username as CreatedBy, t.Completed from Tasks t 
left join Users assigned on assigned.UserId = t.AssignedTo
left join Users created on created.UserId = t.CreatedBy
end

if @flag = 1
begin
select t.TaskId, t.Title, t.Description, t.Priority, t.Status, t.AssignedTo, t.DueDate
, u.Username as CreatedBy, t.CreatedAt from Tasks t left join Users u 
on u.UserId = t.CreatedBy where TaskId = @TaskId
end
if @flag = 2
begin
select t.TaskId, t.Title, t.Description, t.Priority, t.Status,
t.AssignedTo, u2.Username as CreatedBy, t.CreatedBy,
t.UpdatedAt, t.DueDate, t.Completed from Tasks t left join Users u1
on u1.UserId = t.AssignedTo left join Users u2 on u2.UserId = t.CreatedBy 
where t.TaskId = @TaskId 
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

-- User DashboardInfo SP
CREATE PROC usp_UserDashboardInfo
    @UserId INT,
    @AssignedTasks INT OUT,
    @CompletedTasks INT OUT,
    @PendingTasks INT OUT
AS
BEGIN
    SET NOCOUNT ON;

      SELECT 
        @AssignedTasks = COUNT(TaskId),
        @CompletedTasks = SUM(CASE WHEN Completed = 1 THEN 1 ELSE 0 END),
        @PendingTasks =  ISNULL(
    SUM(CASE WHEN Completed = 0 THEN 1 ELSE 0 END),
    0),
        @OverdueTasks = ISNULL(
    SUM(CASE
        WHEN Completed = 0
         AND DueDate < GETDATE()
        THEN 1
        ELSE 0
    END),
    0
)
    FROM Tasks
    WHERE AssignedTo = @UserId;
 select t.TaskId, t.Title, t.Priority, t.Status, t.DueDate, assigned.Username as AssignedTo,
    created.Username as CreatedBy, t.Completed from Tasks t 
    left join Users assigned on assigned.UserId = t.AssignedTo
    left join Users created on created.UserId = t.CreatedBy where assigned.UserId = @UserId
END
go

create proc usp_MarkTaskCompleted
@id int

as
begin
update Tasks set Completed = 1 where TaskId = @id
end
go
