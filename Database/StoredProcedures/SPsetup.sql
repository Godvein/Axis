-- User Login SP
create proc usp_Login 
@Username varchar(100),
@PasswordHash varchar(255),
@returnMsg varchar(50) out
as
begin
if exists (select 1 from Users where Username = @Username and PasswordHash = @PasswordHash)
begin 
select UserId, Username, FullName, RoleId, IsActive 
from Users where Username = @Username and PasswordHash = @PasswordHash 
set @returnMsg = 'ok'
end
else
begin
set @returnMsg = 'wrong username or password'
end
end
go

-- Get User by Id SP
create proc usp_GetUsers
@UserId int,
@flag int
as
begin
if @flag = 0
begin
select Username, FullName, Email, RoleId, IsActive, CreatedAt from Users
where UserId = @UserId
end
if @flag = 1
begin
select Username, FullName, RoleId from Users
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
