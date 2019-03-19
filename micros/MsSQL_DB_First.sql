USE master
GO

IF EXISTS(select * from sys.databases where name='users')
	DROP DATABASE [users]

CREATE DATABASE [users];
GO

USE [users]
GO

CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY NOT NULL,
    [Username] nvarchar(100) NOT NULL,
	[PasswordHash] varbinary(MAX) NOT NULL,
	[PasswordSalt] varbinary(MAX) NOT NULL,
	[Role] nvarchar(10) NOT NULL,
	[Firstname] nvarchar(100) NOT NULL,
	[Lastname] nvarchar(100) NOT NULL,
	[Organisation] nvarchar(100) NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
);
GO

ALTER TABLE [dbo].[Users] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Users] ADD DEFAULT ('User') FOR [Role]
GO

IF EXISTS(select * from sys.databases where name='cvdb')
	DROP DATABASE [cvdb]

CREATE DATABASE [cvdb];
GO

USE [cvdb]
GO

CREATE TABLE [dbo].[Books] (
    [BookId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Authors] nvarchar(MAX) NOT NULL,
	[Year] nvarchar(4),
	[City] nvarchar(100),
	[Publisher] nvarchar(150) NOT NULL,
	[Pages] nvarchar(50),
	[ISSN] nvarchar(MAX),
	[DOI] nvarchar(MAX),
	[Abstract] nvarchar(MAX),
	[Keywords] nvarchar(MAX),

	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Book] PRIMARY KEY ([BookId])
);
GO

ALTER TABLE [dbo].[Books] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Chapters] (
    [ChapterId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Book] nvarchar(MAX) NOT NULL,
	[Authors] nvarchar(MAX) NOT NULL,
	[Year] nvarchar(4),
	[City] nvarchar(100),
	[Publisher] nvarchar(150) NOT NULL,
	[Pages] nvarchar(50),
	[ISSN] nvarchar(MAX),
	[DOI] nvarchar(MAX),
	[Abstract] nvarchar(MAX),
	[Keywords] nvarchar(MAX),

	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Chapter] PRIMARY KEY ([ChapterId])
);
GO

ALTER TABLE [dbo].[Chapters] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Conferences] (
    [ConferenceId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Authors] nvarchar(MAX) NOT NULL,
	[Conference] nvarchar(MAX) NOT NULL,
	[Volume] nvarchar(4),
	[Pages] nvarchar(50),
	[Year] nvarchar(4),
	[City] nvarchar(100),
	[Publisher] nvarchar(150) NOT NULL,
	[ISSN] nvarchar(MAX),
	[DOI] nvarchar(MAX),
	[Abstract] nvarchar(MAX),
	[Keywords] nvarchar(MAX),

	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Conference] PRIMARY KEY ([ConferenceId])
);
GO

ALTER TABLE [dbo].[Conferences] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Articles] (
    [ArticleId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Authors] nvarchar(MAX) NOT NULL,
	[Journal] nvarchar(MAX) NOT NULL,
	[Volume] nvarchar(4),
	[Issue] nvarchar(4),
	[Pages] nvarchar(50),
	[Year] nvarchar(4),
	[City] nvarchar(100),
	[Publisher] nvarchar(150) NOT NULL,
	[ISSN] nvarchar(MAX),
	[DOI] nvarchar(MAX),
	[Abstract] nvarchar(MAX),
	[Keywords] nvarchar(MAX),

	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Article] PRIMARY KEY ([ArticleId])
);
GO

ALTER TABLE [dbo].[Articles] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Education] (
    [EducationId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Country] nvarchar(100),
	[City] nvarchar(100),
	[University] nvarchar(MAX) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7),
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Education] PRIMARY KEY ([EducationId])
);
GO

ALTER TABLE [dbo].[Education] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Jobs] (
    [JobId] int IDENTITY NOT NULL,
    [Title] nvarchar(MAX) NOT NULL,
	[Company] nvarchar(MAX) NOT NULL,
	[Country] nvarchar(100),
	[City] nvarchar(100),
	[Description] nvarchar(MAX) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7),
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Job] PRIMARY KEY ([JobId])
);
GO

ALTER TABLE [dbo].[Jobs] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Languages] (
    [LanguageId] int IDENTITY NOT NULL,
    [Language] nvarchar(50) NOT NULL,
	[Description] nvarchar(100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Language] PRIMARY KEY ([LanguageId])
);
GO

ALTER TABLE [dbo].[Languages] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Skills] (
    [SkillId] int IDENTITY NOT NULL,
    [Skill] nvarchar(50) NOT NULL,
	[Description] nvarchar(250),
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Skill] PRIMARY KEY ([SkillId])
);
GO

ALTER TABLE [dbo].[Skills] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO

CREATE TABLE [dbo].[Owner] (
    [OwnerId] int IDENTITY NOT NULL,
    [Firstname] nvarchar(100),
	[Middlename] nvarchar(100),
	[Lastname] nvarchar(100),
	[Title] nvarchar(MAX),
	[Description] nvarchar(MAX),
	[Email] nvarchar(100),
	[Phone1] nvarchar(100),
	[Phone2] nvarchar(100),
	[Skype] nvarchar(100),
	[Country] nvarchar(100),
	[City] nvarchar(100),
	[Address] nvarchar(100),
	[About] nvarchar(100),
	[LinkedIn] nvarchar(255),
    [Github] nvarchar(255),
    [Facebook] nvarchar(255),
    [Twitter] nvarchar(255),
    [Skills] nvarchar(MAX),

	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7),
	[DeletedAt] [datetime2](7),
    CONSTRAINT [PK_Owner] PRIMARY KEY ([OwnerId])
);
GO

ALTER TABLE [dbo].[Owner] ADD DEFAULT (getdate()) FOR [CreatedAt]
GO