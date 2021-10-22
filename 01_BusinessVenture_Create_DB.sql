code Use[master]

IF db_id('BusinessVenture') IS NOT NULL
	DROP DATABASE [BusinessVenture];
GO

CREATE DATABASE [BusinessVenture]
GO

USE [BusinessVenture];
GO

DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [BusinessType];
DROP TABLE IF EXISTS [Business];
DROP TABLE IF EXISTS [ProductOrService];
DROP TABLE IF EXISTS [Staff];
DROP TABLE IF EXISTS [BusinessStaff];

GO


CREATE TABLE [UserProfile] (
    [Id] INTEGER Primary Key IDENTITY,
    [Email] NVARCHAR(50) NOT NULL,
    [FirebaseUserId] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [BusinessType] (
    [Id] INTEGER Primary Key IDENTITY,
    [Type] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Business] (
    [Id] INTEGER Primary Key IDENTITY,
    [UserProfileId] INTEGER NOT NULL,
    [BusinessTypeId] INTEGER NOT NULL,
    [Equipment] NVARCHAR(255) NOT NULL,
    [Title] NVARCHAR(50) NOT NULL,
    [Location] NVARCHAR(50) NOT NULL,
    [Slogan] NVARCHAR(255) NOT NULL,

    CONSTRAINT [FK_Business_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id]),
    CONSTRAINT [FK_Business_BusinessType] FOREIGN KEY ([BusinessTypeId]) REFERENCES [BusinessType] ([Id])

)

CREATE TABLE [ProductOrService] (
    [Id] INTEGER Primary Key IDENTITY,
    [BusinessId] INTEGER NOT NULL,
    [NameOfProductOrService] NVARCHAR(255) NOT NULL,
    [Cost] INTEGER NOT NULL,

    CONSTRAINT [FK_ProductOrService_Business] FOREIGN KEY ([BusinessId]) REFERENCES [Business] ([Id])
)

CREATE TABLE [Staff] (
    [Id] INTEGER Primary Key IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(50) NOT NULL,
    [PhoneNumber] NVARCHAR(50) NOT NULL,
    [Address] NVARCHAR(100) NOT NULL 
)

CREATE TABLE [BusinessStaff] (
    [Id] INTEGER Primary Key IDENTITY,
    [BusinessId] INTEGER NOT NULL,
    [StaffId] INTEGER NOT NULL,
    [DateEmployed] DATETIME NOT NULL,
    [PositionTitle] NVARCHAR(50),

    CONSTRAINT [FK_BusinessStaff_Business] FOREIGN KEY ([BusinessId]) REFERENCES [Business] ([Id]),
    CONSTRAINT [FK_BusinessStaff_Staff] FOREIGN KEY ([StaffId]) REFERENCES [Staff] ([Id])

)

/*From DBDiagram*/
ALTER TABLE [Business] ADD FOREIGN KEY ([userProfileId]) REFERENCES [UserProfile] ([id])
GO

ALTER TABLE [Business] ADD FOREIGN KEY ([businessTypeId]) REFERENCES [BusinessType] ([id])
GO

ALTER TABLE [BusinessStaff] ADD FOREIGN KEY ([staffId]) REFERENCES [Staff] ([id])
GO

ALTER TABLE [BusinessStaff] ADD FOREIGN KEY ([businessId]) REFERENCES [Business] ([id])
GO

/*I do not understand why dbdiagram did this like this*/
ALTER TABLE [ProductOrService] ADD FOREIGN KEY ([businessId]) REFERENCES [Business] ([id])
GO




