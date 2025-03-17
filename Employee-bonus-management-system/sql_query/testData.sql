SELECT u.Id,r.[Name], u.FirstName, u.LastName, u.Salary, u.Email,  
							u.DateOfBirth, u.HireDate AS Role 
				            FROM AspNetUsers u
				            LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
				            LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id;



INSERT INTO [BonusSystem].[dbo].[Departments] (
    Id, Name, CreateByUserId, CreateDate, IsActive
)
VALUES
-- Department 1: HR
(NEWID(), 'Human Resources', '3F2504E0-4F89-41D3-9A0C-0305E82C3301', '2023-01-15', 1),

-- Department 2: IT
(NEWID(), 'Information Technology', '3F2504E0-4F89-41D3-9A0C-0305E82C3302', '2023-02-10', 1),

-- Department 3: Finance
(NEWID(), 'Finance', '3F2504E0-4F89-41D3-9A0C-0305E82C3303', '2023-03-20', 1),

-- Department 4: Marketing
(NEWID(), 'Marketing', '3F2504E0-4F89-41D3-9A0C-0305E82C3304', '2023-04-05', 1),

-- Department 5: Sales
(NEWID(), 'Sales', '3F2504E0-4F89-41D3-9A0C-0305E82C3305', '2023-05-12', 1);

-- test data 
INSERT INTO [BonusSystem].[dbo].[AspNetUsers] (
    Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, 
    PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, 
    TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, 
    DateOfBirth, DepartmentId, FirstName, HireDate, IsActive, LastName, 
    PersonalNumber, RecommenderEmployeeId, Salary
)
VALUES
-- User 1
(NEWID(), 'johndoe', 'JOHNDOE', 'johndoe@example.com', 'JOHNDOE@EXAMPLE.COM', 1,
'hashedpassword123', 'securitystamp1', NEWID(), '1234567890', 1,
0, NULL, 1, 0,
'1990-05-15', '2FAF1AE6-2C5E-4F46-8EFB-797D52777882', 'John', '2022-01-10', 1, 'Doe',
'12345678901', NULL, 5000.00),

-- User 2
(NEWID(), 'janedoe', 'JANEDOE', 'janedoe@example.com', 'JANEDOE@EXAMPLE.COM', 1,
'hashedpassword456', 'securitystamp2', NEWID(), '0987654321', 1,
0, NULL, 1, 0,
'1995-08-22', '2FAF1AE6-2C5E-4F46-8EFB-797D52777882', 'Jane', '2021-06-15', 1, 'Doe',
'98765432109', NULL, 5200.00),

-- User 3
(NEWID(), 'alexsmith', 'ALEXSMITH', 'alexsmith@example.com', 'ALEXSMITH@EXAMPLE.COM', 1,
'hashedpassword789', 'securitystamp3', NEWID(), '1112223333', 1,
0, NULL, 1, 0,
'1988-11-30', '2FAF1AE6-2C5E-4F46-8EFB-797D52777882', 'Alex', '2020-03-20', 1, 'Smith',
'56789012345', NULL, 4800.00),

-- User 4
(NEWID(), 'emilyjones', 'EMILYJONES', 'emilyjones@example.com', 'EMILYJONES@EXAMPLE.COM', 1,
'hashedpassword101', 'securitystamp4', NEWID(), '4445556666', 1,
0, NULL, 1, 0,
'1992-07-12', '2FAF1AE6-2C5E-4F46-8EFB-797D52777882', 'Emily', '2019-11-05', 1, 'Jones',
'67890123456', NULL, 5300.00),

-- User 5
(NEWID(), 'michaelbrown', 'MICHAELBROWN', 'michaelbrown@example.com', 'MICHAELBROWN@EXAMPLE.COM', 1,
'hashedpassword202', 'securitystamp5', NEWID(), '7778889999', 1,
0, NULL, 1, 0,
'1985-02-25', '2FAF1AE6-2C5E-4F46-8EFB-797D52777882', 'Michael', '2018-08-12', 1, 'Brown',
'78901234567', NULL, 5500.00);


INSERT INTO [BonusSystem].[dbo].[AspNetUserRoles] (
    UserId, RoleId
)
VALUES   ('1111', 'B2A0E6F1-1E30-4D4B-97E1-5B3F0A5D6A10')