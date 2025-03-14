Create Database  HRManagement

--დეპარტამენტები
USE BonusSystem
CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(255) UNIQUE NOT NULL, 
    CreateByUserId INT NULL,  
    CreateDate DATE DEFAULT GETDATE(), 
    IsActive INT DEFAULT 1,  
    );



go

CREATE TABLE Employees  (  
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- ავტომატურად გენერირებული უნიკალური ID
    FirstName NVARCHAR(100) NOT NULL,  
    LastName NVARCHAR(100) NOT NULL,  
    PersonalNumber NVARCHAR(50) UNIQUE NOT NULL,  -- უნიკალური PersonalNumber
BirthDate DATE NOT NULL,  --  დაბადების თარიღი (აუცილებელი ველი)
Email NVARCHAR(255) UNIQUE NOT NULL,  -- უნიკალური ელ. ფოსტა (აუცილებელი ველი)
Salary DECIMAL(10,2) NOT NULL,  -- ანაზღაურება (აუცილებელი ველი)
HireDate DATE NOT NULL DEFAULT GETDATE(),  -- მუშაობის დაწყების თარიღი (აუცილებელი ველი, ნაგულისხმევად დღევანდელი)
    UserName NVARCHAR(255) UNIQUE NOT NULL,  -- უნიკალური UserName
    [Password] NVARCHAR(MAX) NOT NULL,        
    IsPasswordChanged INT DEFAULT 0,  -- 0 = პაროლი არ არის შეცვლილი, 1 = შეცვლილია
    PasswordChangeDate DATE ,  -- პაროლის შეცვლის თარიღი (NULL თუ ჯერ არ შეუცვლიათ)
    CreateByUserId INT ,  -- მომხმარებლის ID, რომელმაც შექმნა ეს ჩანაწერი
DepartmentId INT NOT NULL,  -- დეპარტამენტი (აუცილებელი ველი)
RecommenderEmployeeId INT,  --  რეკომენდატორი თანამშრომელი (შეიძლება NULL იყოს)
IsActive INT DEFAULT 1,  -- ნაგულისხმევი აქტიური მდგომარეობა (1 = აქტიური)
CreateDate DATE DEFAULT GETDATE(),  -- ჩანაწერის შექმნის თარიღი, ნაგულისხმევად დღევანდელი თარიღი
CONSTRAINT FK_Employees_Creator FOREIGN KEY (CreateByUserId) REFERENCES Employees(Id),  -- Foreign Key დამაკავშირებელი  ვინც შექმნა ჩანაწერი
    CONSTRAINT FK_Employees_Department FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),  --  კავშირი დეპარტამენტების ცხრილთან
    CONSTRAINT FK_Employees_Recommender FOREIGN KEY (RecommenderEmployeeId) REFERENCES Employees(Id)  --  კავშირი რეკომენდატორ თანამშრომელთან
);
    
go 
ALTER TABLE  Departments  add -- CONSTRAINT დამატება
CONSTRAINT FK_Departments_Creator FOREIGN KEY (CreateByUserId) REFERENCES Employees(Id)  -- კავშირი Employees ცხრილთან

go

--ბონუსები
USE HRManagement
CREATE TABLE Bonuses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,  -- ბონუსი რომელი თანამშრომლისთვის არის განკუთვნილი
    Amount DECIMAL(10,2) NOT NULL,  -- ბონუსის ოდენობა
    BonusDate DATE DEFAULT GETDATE(),  -- ბონუსის გაცემის თარიღი
    Reason NVARCHAR(MAX),  -- ბონუსის გაცემის მიზეზი
    CreateByUserId INT,  -- ვინ დაამატა ბონუსი
    CreateDate DATE DEFAULT GETDATE(),  -- ჩანაწერის შექმნის თარიღი
    CONSTRAINT FK_Bonuses_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE CASCADE,  -- თუ თანამშრომელი წაიშლება, მისი ბონუსებიც წაიშლება
    CONSTRAINT FK_Bonuses_Creator FOREIGN KEY (CreateByUserId) REFERENCES Employees(Id)  -- ვინ დაამატა ბონუსი
);


go
CREATE TABLE EmployeeDepartments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,  -- თანამშრომლის ID
    DepartmentId INT NOT NULL,  -- დეპარტამენტის ID
    AssignDate DATE DEFAULT GETDATE(),  -- როდის მიენიჭა დეპარტამენტი
    IsActive INT DEFAULT 1,  -- თანამშრომელი ამ დეპარტამენტში ჯერ კიდევ მუშაობს თუ არა
    CONSTRAINT FK_EmployeeDepartments_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ON DELETE CASCADE,  
    CONSTRAINT FK_EmployeeDepartments_Department FOREIGN KEY (DepartmentId) REFERENCES Departments(Id) ON DELETE CASCADE,  
    CONSTRAINT UQ_Employee_Department UNIQUE (EmployeeId, DepartmentId)  -- ერთი თანამშრომელი ერთ დეპარტამენტში ერთჯერ უნდა იყოს
);

CREATE TABLE RecommenderEmployee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,  -- თანამშრომლის ID
    RecommenderEmployeeId INT NOT NULL,  -- დეპარტამენტის ID
    AssignDate DATE DEFAULT GETDATE(),  -- როდის მიენიჭა დეპარტამენტი
    CONSTRAINT FK_Employee_Employee FOREIGN KEY (EmployeeId) REFERENCES Employees(Id) ,
CONSTRAINT FK_RecommenderEmployee_Employee FOREIGN KEY (RecommenderEmployeeId) REFERENCES Employees(Id),
   );

   use HRManagement
alter table Employees  add EmployeeRole NVARCHAR(100) 