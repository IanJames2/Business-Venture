CREATE TABLE [User] (
  [id] int PRIMARY KEY NOT NULL,
  [Email] varcharacter NOT NULL,
  [FirebaseUserId] varcharacter NOT NULL,
  [Name] varcharacter NOT NULL
)
GO

CREATE TABLE [Business] (
  [id] int PRIMARY KEY,
  [userId] int(fk),
  [businessTypeId] int(fk),
  [equipment] varcharacter,
  [logo] varcharacter,
  [title] varcharacter,
  [location] varcharacter,
  [slogan] varcharacter
)
GO

CREATE TABLE [BusinessType] (
  [id] int PRIMARY KEY,
  [type] varcharacter
)
GO

CREATE TABLE [ProductOrService] (
  [id] int PRIMARY KEY,
  [businessId] int(fk),
  [nameOfProductOrService] varcharacter,
  [cost] int
)
GO

CREATE TABLE [Staff] (
  [id] int PRIMARY KEY,
  [name] varcharacter,
  [email] varcharacter,
  [phoneNumber] int,
  [address] varcharacter
)
GO

CREATE TABLE [BusinessStaff] (
  [id] int PRIMARY KEY,
  [businessId] int(fk),
  [staffId] int(fk),
  [dateEmployed] date,
  [positionTitle] varcharacter
)
GO

ALTER TABLE [Business] ADD FOREIGN KEY ([userId]) REFERENCES [User] ([id])
GO

ALTER TABLE [Business] ADD FOREIGN KEY ([businessTypeId]) REFERENCES [BusinessType] ([id])
GO

ALTER TABLE [Staff] ADD FOREIGN KEY ([id]) REFERENCES [BusinessStaff] ([staffId])
GO

ALTER TABLE [Business] ADD FOREIGN KEY ([id]) REFERENCES [BusinessStaff] ([businessId])
GO

ALTER TABLE [Business] ADD FOREIGN KEY ([id]) REFERENCES [ProductOrService] ([businessId])
GO
