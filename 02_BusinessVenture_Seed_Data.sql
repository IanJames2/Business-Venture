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




/*--------------------------------------------------------------------------------------------------------------------------------------------------*/


/* GetAllBusinessesByUserProfileId */
SELECT Business.Id, Business.UserProfileId, Business.Title, Business.[Location]
FROM Business
WHERE Business.UserProfileId = @userProfileId;

/* GetBusinessById */

SELECT Business.Id AS Id, UserProfile.Id, UserProfile.Name [UserProfile Name], Business.UserProfileId, Business.Title, Business.[Location], Business.Slogan, Business.Equipment, BusinessType.Type [BusinessType Type], Business.BusinessTypeId
                                        FROM Business
                                        INNER JOIN UserProfile ON Business.UserProfileId = UserProfile.Id
                                        INNER JOIN BusinessType ON Business.BusinessTypeId = BusinessType.Id
                                        WHERE Business.Id = @id

/* AddBusiness */

INSERT INTO Business (UserProfileId, BusinessTypeId, Equipment, Title, [Location], Slogan)
OUTPUT INSERTED.ID
VALUES (@UserProfileId, @BusinessTypeId, @Equipment, @Title, @Location, @Slogan);

/* UpdateBusiness */

@"
UPDATE Business
SET 
    UserProfileId = @userProfileId
    BusinessTypeId = @businessTypeId, 
    Equipment = @equipment, 
    Title = @title, 
    [Location] = @location,
    Slogan = @slogan
WHERE Id = @id"; 

/* DeleteBusiness */

DELETE FROM Business
WHERE Id = @id

/*--------------------------------------------------------------------------------------------------------------------------------------------------*/

/* GetAllProductsOrServicesByUserProfileId */

SELECT ProductOrService.Id, ProductOrService.BusinessId, Business.UserProfileId, ProductOrService.NameOfProductOrService, ProductOrService.Cost 
FROM ProductOrService
INNER JOIN Business ON ProductOrService.BusinessId = Business.Id
WHERE Business.UserProfileId = @userProfileId;

/* GetProductOrServiceById */

SELECT ProductOrService.Id, ProductOrService.BusinessId, Business.Title [Business.Title], ProductOrService.NameOfProductOrService, ProductOrService.Cost 
FROM ProductOrService
INNER JOIN Business ON ProductOrService.BusinessId = Business.Id
WHERE ProductOrService.Id = @id

/* AddProductOrService */

INSERT INTO ProductOrService (BusinessId, NameOfProductOrService, Cost)
OUTPUT INSERTED.ID
VALUES (@BusinessId, @NameOfProductOrService, @Cost);

/* UpdateProductOrService */

@"
UPDATE Product
    SET 
        BusinessId = @businessId, 
        NameOfProductOrService = @nameOfProductOrService, 
        Cost = @cost, 
    WHERE Id = @id";

/* DeleteProductOrService */

DELETE FROM ProductOrService
WHERE Id = @id

/*--------------------------------------------------------------------------------------------------------------------------------------------------*/

/* GetAllStaffByUserProfileId */

SELECT s.Id, s.[Name], s.Email, s.PhoneNumber, s.[Address], b.UserProfileId, b.Title, b.[Location], bs.Id, bs.DateEmployed, bs.positionTitle
FROM BusinessStaff bs
LEFT JOIN Business b ON bs.BusinessId = b.Id
LEFT JOIN Staff s ON s.Id = bs.StaffId
WHERE b.UserProfileId = @userProfileId;

/* GetStaffById */

SELECT s.Id, s.[Name], s.Email, s.PhoneNumber, s.[Address], b.UserProfileId, b.Title, b.[Location], bs.Id, bs.DateEmployed, bs.positionTitle
FROM BusinessStaff bs
LEFT JOIN Business b ON bs.BusinessId = b.Id
LEFT JOIN Staff s ON s.Id = bs.StaffId
WHERE s.Id = id;

/* AddStaff */

INSERT INTO Staff (Id, [Name], Email, PhoneNumber, [Address])
OUTPUT INSERTED.ID
VALUES (@Id, @Name, @Email, @PhoneNumber, @Address)


/* UpdateStaff */

@"UPDATE Staff 
	SET
		Id = @id,
		[Name] = @name,
		Email = @email,
		PhoneNumber = @phoneNumber,
		[Address] = @address
	WHERE Id = @id";



/* DeleteStaff */

DELETE FROM Staff
WHERE Id = @id;


