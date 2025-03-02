USE HRManagement;

-- Insert Departments
INSERT INTO Departments ([Name], CreateByUserId) VALUES 
('Human Resources', NULL),
('IT', NULL),
('Finance', NULL),
('Marketing', NULL),
('Sales', NULL);

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, PersonalNumber, BirthDate, Email, Salary, HireDate, UserName, [Password], CreateByUserId, DepartmentId, RecommenderEmployeeId) VALUES 
('John', 'Doe', '123456789', '1990-05-14', 'john.doe@example.com', 5000.00, GETDATE(), 'johndoe', 'password123', NULL, 1, NULL),
('Alice', 'Smith', '987654321', '1985-08-22', 'alice.smith@example.com', 7000.00, GETDATE(), 'alicesmith', 'password123', NULL, 2, NULL),
('Bob', 'Johnson', '456789123', '1992-11-30', 'bob.johnson@example.com', 6000.00, GETDATE(), 'bobjohnson', 'password123', NULL, 3, NULL),
('Emma', 'Brown', '321654987', '1995-07-10', 'emma.brown@example.com', 5500.00, GETDATE(), 'emmabrown', 'password123', NULL, 4, NULL),
('Michael', 'Williams', '159753486', '1988-04-25', 'michael.williams@example.com', 8000.00, GETDATE(), 'michaelw', 'password123', NULL, 5, NULL);

-- Assign creator IDs to departments
UPDATE Departments SET CreateByUserId = 1 WHERE Id = 1;
UPDATE Departments SET CreateByUserId = 2 WHERE Id = 2;
UPDATE Departments SET CreateByUserId = 3 WHERE Id = 3;
UPDATE Departments SET CreateByUserId = 4 WHERE Id = 4;
UPDATE Departments SET CreateByUserId = 5 WHERE Id = 5;

-- Insert Bonuses
INSERT INTO Bonuses (EmployeeId, Amount, Reason, CreateByUserId) VALUES 
(1, 500.00, 'Performance Bonus', 1),
(2, 700.00, 'Project Completion Bonus', 2),
(3, 400.00, 'Best Employee of the Month', 3),
(4, 600.00, 'Sales Target Achieved', 4),
(5, 900.00, 'Annual Bonus', 5);

-- Assign Employees to Departments
INSERT INTO EmployeeDepartments (EmployeeId, DepartmentId) VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- Insert Recommender Employees
INSERT INTO RecommenderEmployee (EmployeeId, RecommenderEmployeeId) VALUES 
(2, 1),
(3, 2),
(4, 3),
(5, 4);
