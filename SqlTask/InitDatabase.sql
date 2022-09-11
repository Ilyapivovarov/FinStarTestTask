USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'FinStarTasksDb'
)
CREATE DATABASE FinStarTasksDb
GO

GO

IF OBJECT_ID('[FinStarTasksDb].[dbo].[Clients]', 'U') IS NOT NULL
DROP TABLE [FinStarTasksDb].[dbo].[Clients]

CREATE TABLE [FinStarTasksDb].[dbo].[Clients]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [ClientName] NVARCHAR(50) NOT NULL
);

IF OBJECT_ID('[dbo].[ClietnContacts]', 'U') IS NOT NULL
DROP TABLE [FinStarTasksDb].[dbo].[ClietnContacts]

CREATE TABLE [FinStarTasksDb].[dbo].[ClientContacts]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [ClientId] int FOREIGN KEY REFERENCES Clients(Id),
    [ContanctType] NVARCHAR(255) NOT NULL,
    [ContactValue] NVARCHAR(255) NOT NULL
);

IF OBJECT_ID('[FinStarTasksDb].[dbo].[ThridTask]', 'U') IS NOT NULL
DROP TABLE [FinStarTasksDb].[dbo].[ThridTask]
CREATE TABLE [FinStarTasksDb].[dbo].[ThridTask]
(
    [Index] INT NOT NULL PRIMARY KEY,
    [Id] INT NOT NULL,
    [Dt] DATE NOT NULL
);

GO

GO
USE FinStarTasksDb

INSERT INTO Clients (Id, ClientName)
VALUES  (1, 'Client1'),
        (2, 'Client2')

INSERT INTO ClientContacts (Id, ClientId, ContanctType, ContactValue)
VALUES  (1 , 1, 'Email', 'email@emali.com'), 
        (2, 1, 'Number', '123456789'), 
        (3, 1, 'Address', 'Moscow'), 
        (4, 2, 'Email', 'email@emali.com')


INSERT INTO ThridTask ("Index", Id, Dt)
VALUES  (1, 1, '2022-01-01'),
        (2, 1, '2022-01-10'),
        (3, 1, '2022-01-30'),
        (4, 2, '2022-01-15'),
        (5, 2, '2022-01-30')

GO