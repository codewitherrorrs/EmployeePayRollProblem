use Payroll_Service;
select  * from Employee_Payroll;

--update employee salary
alter PROCEDURE spUpdateEmployee
@Name nvarchar(200),
@Id int,
@Basic_Pay float
AS
update Employee_PayRoll set Basic_Pay=@Basic_Pay where Name=@Name and Id= @Id;

