USE [BusinessVenture]
GO


SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [Email], [FirebaseUserId], [Name])
VALUES (1, 'ianjames2@protonmail.com', '4NQRFRQaiFM9j9B4NCEgFAs38IV2', 'Ian James II' ),
	   (2, 'ianjms81@gmail.com', 's0XYzSfH7AMC8cYGy4EtrjbiSLJ3', 'Ian James II');
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [BusinessType] ON
INSERT INTO [BusinessType] (
	[Id], [Type])
VALUES (1, 'Sole Proprietorship'),
	   (2, 'Partnership'),
       (3, 'Limited Partnership'),
       (4, 'Corporation'),
       (5, 'LLC'),
       (6, 'Non-Profit'),
       (7, 'Co-op');
SET IDENTITY_INSERT [BusinessType] OFF

SET IDENTITY_INSERT [Business] ON
INSERT INTO [Business] (
	[Id], [UserProfileId], [businessTypeId], [Equipment], [Title], [Location], [Slogan])
VALUES (1, 2, 5, 'Desktop Computers, Furniture, Food', 'Grocery Store', 'Nashville', 'Ill never own a grocery store'),
	   (2, 1, 6, 'Desktop Computers, Furniture, Test', 'Test', 'Antioch', 'Testing');
SET IDENTITY_INSERT [Business] OFF

SET IDENTITY_INSERT [ProductOrService] ON
INSERT INTO [ProductOrService] (
	[Id], [BusinessId], [NameOfProductOrService], [Cost])
VALUES (1, 1, 'Grapes', 7),
	   (2, 2, 'Test', 100);
SET IDENTITY_INSERT [ProductOrService] OFF

SET IDENTITY_INSERT [Staff] ON
INSERT INTO [Staff] (
	[Id], [Name], [Email], [PhoneNumber], [Address])
VALUES (1, 'Joe Shepherd', 'JoeShepherd@nss.com', '6153308004', '118 Broadway Street'),
	   (2, 'Christina Ashworth', 'ChristinaAshworth@nss.com', '6154548475', '2827 Space Park BLVD');
SET IDENTITY_INSERT [Staff] OFF

SET IDENTITY_INSERT [BusinessStaff] ON
INSERT INTO [BusinessStaff] (
	[Id], [BusinessId], [StaffId], [DateEmployed], [PositionTitle])
    /*Fix The Date*/
VALUES (1, 2, 2, '2021-10-21 00:00:00', 'Mid-Level Software Engineer'),
       (2, 1, 1, '2021-10-21 00:00:00', 'Senior Software Engineer')
SET IDENTITY_INSERT [BusinessStaff] OFF
