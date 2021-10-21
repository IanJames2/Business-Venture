USE [Master]
GO

IF db_id('FirebaseMVC') IS NULL
	CREATE DATABASE [FirebaseMVC]
GO

USE [FirebaseMVC]
GO

DROP TABLE IF EXISTS [UserProfile];

CREATE TABLE [UserProfile] (
	[Id] INTEGER IDENTITY NOT NULL,
	[Email] NVARCHAR(255) NOT NULL,
	[FirebaseUserId] NVARCHAR(28) NOT NULL,

	CONSTRAINT [UQ_FirebaseUserId] UNIQUE([FirebaseUserId])
)

INSERT INTO UserProfile (Email, FirebaseUserId) VALUES ('ianjames2@protonmail.com', '4NQRFRQaiFM9j9B4NCEgFAs38IV2');
INSERT INTO UserProfile (Email, FirebaseUserId) VALUES ('ianjms81@gmail.com', 's0XYzSfH7AMC8cYGy4EtrjbiSLJ3');