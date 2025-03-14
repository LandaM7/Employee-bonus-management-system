USE BonusSystem
CREATE TABLE Departments (
	Id NVARCHAR(50) PRIMARY KEY,
	[Name] NVARCHAR(255) UNIQUE NOT NULL, 
    CreateByUserId nvarchar(450) NULL,  
    CreateDate DATE DEFAULT GETDATE(), 
    IsActive INT DEFAULT 1,  
    );
go 
CREATE TABLE Bonuses (
	Id NVARCHAR(50) PRIMARY KEY,
    EmployeeId nvarchar(450) NOT NULL, 
    Amount DECIMAL(10,2) NOT NULL, 
    BonusDate DATE DEFAULT GETDATE(),
    Reason NVARCHAR(MAX),  
    CreateByUserId nvarchar(450),  
    CONSTRAINT FK_Bonuses_Employee FOREIGN KEY (EmployeeId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);


alter table  AspNetUsers add Constraint FK_Employee_Department FOREIGN KEY (DepartmentID) REFERENCES Departments(Id)
alter table Bonuses add Constraint FK_CreateByUser_User  FOREIGN  KEY (CreateByUserId) REFERENCES AspNetUsers(Id)
alter table Departments add Constraint FK_DepartmentCreatedByUser_User  FOREIGN  KEY (CreateByUserId) REFERENCES AspNetUsers(Id)

--USE BonusSystem;
--drop table Departments
--go 
--drop table Bonuses 