use Payroll_Service;
select  * from Employee_Payroll;

--update employee salary
alter PROCEDURE spUpdateEmployee
@Name nvarchar(200),
@Id int,
@Basic_Pay float
AS
update Employee_PayRoll set Basic_Pay=@Basic_Pay where Name=@Name and Id= @Id;

use Payroll_Service;
select  * from Employee_Payroll;

--update employee salary
alter PROCEDURE spUpdateEmployee
@Name nvarchar(200),
@Id int,
@Basic_Pay float
AS
update Employee_PayRoll set Basic_Pay=@Basic_Pay where Name=@Name and Id= @Id;

---Add new employee data
--Create PROCEDURE spAddNewEmployee

Alter PROCEDURE spAddNewEmployee
@Name nvarchar(200),
@Basic_Pay float,
@Phone_Number bigInt,
@Address varchar(200),
@Department varchar(100)
AS
insert into Employee_PayRoll(Name,Basic_Pay,Phone_Number,Address,Department)values (@Name,@Basic_Pay,@Phone_Number,@Address,@Department);


