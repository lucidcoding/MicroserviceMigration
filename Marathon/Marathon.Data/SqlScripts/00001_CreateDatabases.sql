--USE [master]

--IF EXISTS (SELECT * FROM sysdatabases WHERE name='Marathon') 
--BEGIN 
--	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Marathon'
--	ALTER DATABASE [Marathon] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
--	DROP DATABASE [Marathon]
--END
--GO

--CREATE DATABASE [Marathon] 
--GO

USE [Marathon]

--IF NOT EXISTS(SELECT name FROM [master].[dbo].syslogins WHERE name = 'MarathonUser')
--BEGIN
--	CREATE LOGIN [MarathonUser] WITH PASSWORD = 'MarathonUser123' 
--END
--GO

--IF NOT EXISTS (SELECT * FROM sys.sysusers WHERE name = N'MarathonUser')
--BEGIN
--	CREATE USER [MarathonUser] FOR LOGIN [MarathonUser] WITH DEFAULT_SCHEMA=[dbo]	
--END
--GO

--IF DATABASE_PRINCIPAL_ID('AllowSelectInsertUpdate') IS NULL
--BEGIN
--	CREATE ROLE [AllowSelectInsertUpdate] 	
--END
--GO

--EXEC sp_addrolemember 'AllowSelectInsertUpdate', 'MarathonUser'
--GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Role')
BEGIN
	DROP TABLE [dbo].[Role]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Permission')
BEGIN
	DROP TABLE [dbo].[Permission]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'PermissionRole')
BEGIN
	DROP TABLE [dbo].[PermissionRole]
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'User')
BEGIN
	DROP TABLE [dbo].[User]
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Vehicle')
BEGIN
	DROP TABLE [dbo].[Vehicle]
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Booking')
BEGIN
	DROP TABLE [dbo].[Booking]
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Customer')
BEGIN
	DROP TABLE [dbo].[Customer]
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Depot')
BEGIN
	DROP TABLE [dbo].[Depot]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'MaintenanceCheck')
BEGIN
	DROP TABLE [dbo].[MaintenanceCheck]
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Invoice')
BEGIN
	DROP TABLE [dbo].[Invoice]
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Role')
BEGIN
	CREATE TABLE [dbo].[Role](
		[Id] [uniqueidentifier] NOT NULL,
		[RoleName] [nvarchar](20) NULL,
		[Description] [nvarchar](50) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	GRANT SELECT, INSERT, UPDATE ON [Role] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [Role] ([Id], [RoleName], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('80fc2a10-d07e-4e06-9b91-4ba936e335ba', 'Guest', 'Guest', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Role] ([Id], [RoleName], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('8dc59a62-a077-41cc-bac7-f8be505ae4a8', 'Admin', 'Admin User', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Role] ([Id], [RoleName], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('2C6E33B8-BD7C-492C-807D-B4B1BCAE5F4F', 'Customer', 'Admin User', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Permission')
BEGIN
	CREATE TABLE [dbo].[Permission](
		[Id] [uniqueidentifier] NOT NULL,
		[Description] [nvarchar](50) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Permission] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()
	
	INSERT INTO [Permission] ([Id], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('f76e6b28-993f-410b-82b1-d1ce2baf34a6', 'MakeBooking', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Permission] ([Id], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('1B444704-AD92-4837-9DB7-71F99C20753C', 'CollectBooking', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Permission] ([Id], [Description], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('0FC4BE24-596C-4E53-AE9A-964F603818F4', 'ReturnBooking', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'PermissionRole')
BEGIN
	CREATE TABLE [dbo].[PermissionRole](
		[Id] [uniqueidentifier] NOT NULL,
		[PermissionId] [uniqueidentifier] NULL,
		[RoleId] [uniqueidentifier] NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_PermissionRole] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [PermissionRole] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [PermissionRole] ([Id], [PermissionId], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('8dc59a62-a077-41cc-bac7-f8be505ae4a8', 'f76e6b28-993f-410b-82b1-d1ce2baf34a6', '2C6E33B8-BD7C-492C-807D-B4B1BCAE5F4F', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [PermissionRole] ([Id], [PermissionId], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('DF3965C6-C94B-4B00-B06D-28C5313B33D9', 'f76e6b28-993f-410b-82b1-d1ce2baf34a6', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [PermissionRole] ([Id], [PermissionId], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('8D0AE6FB-848B-4592-96F7-EDC3520BE390', '1B444704-AD92-4837-9DB7-71F99C20753C', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [PermissionRole] ([Id], [PermissionId], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('CF47EA3F-2A28-4F9C-BDD3-568A8A553727', '0FC4BE24-596C-4E53-AE9A-964F603818F4', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'User')
BEGIN
	CREATE TABLE [dbo].[User](
		[Id] [uniqueidentifier] NOT NULL,
		[Username] [nvarchar](50) NULL,
		[Password] [nvarchar](50) NULL,
		[RoleId] [uniqueidentifier] NULL,
		[Forename] [nvarchar](50) NULL,
		[Surname] [nvarchar](50) NULL,
		[AddressLine1] [nvarchar](50) NULL,
		[AddressLine2] [nvarchar](50) NULL,
		[AddressLine3] [nvarchar](50) NULL,
		[Town] [nvarchar](50) NULL,
		[County] [nvarchar](50) NULL,
		[PostCode] [nvarchar](10) NULL,
		[Email] [nvarchar](50) NULL,
		[TelephoneNumber] [nvarchar](50) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [User] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('188403fb-3c5e-45a3-aa39-5908e86ea372', 'Sql Initialise', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('c8238876-47fc-42af-8a32-926061097f1c', 'Application', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [User] ([Id], [Username], [RoleId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) VALUES ('3b50e7c8-c6ce-4446-9d51-6cc7a7877343', 'Test', '8dc59a62-a077-41cc-bac7-f8be505ae4a8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Depot')
BEGIN
CREATE TABLE [dbo].[Depot](
		[Id] [uniqueidentifier] NOT NULL,
		[Code] [nvarchar](3) NULL,
		[Name] [nvarchar](50) NULL,
		[Address1] [nvarchar](50) NULL,
		[Address2] [nvarchar](50) NULL,
		[Address3] [nvarchar](50) NULL,
		[Address4] [nvarchar](50) NULL,
		[PostCode] [nvarchar](10) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Depot] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Depot] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()
	INSERT INTO [Depot] ([Id], [Code], [Name], [Address1], [Address2], [Address3], [Address4], [PostCode], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) 
	VALUES ('6a9857a6-d0b0-4e1a-84cb-ee9ade159560', 'BLV', 'Blueville', '1 Blue Street', 'Blueville', 'Blueshire', null, 'BL1 1AA', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Depot] ([Id], [Code], [Name], [Address1], [Address2], [Address3], [Address4], [PostCode], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) 
	VALUES ('ba325fad-9a65-4732-872c-da2069bb37e8', 'ORN', 'Orangeborough', '2 Orange Road', 'Orangeborough', 'Orangeshire', null, 'OR1 1AA', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Vehicle')
BEGIN
CREATE TABLE [dbo].[Vehicle](
		[Id] [uniqueidentifier] NOT NULL,
		[RegistrationNumber] [nvarchar](20) NULL,
		[Make] [nvarchar](50) NULL,
		[Model] [nvarchar](50) NULL,
		[PricePerDay] [money] NOT NULL,
		[HomeDepotId] [uniqueidentifier] NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Vehicle] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()

	INSERT INTO [Vehicle] ([Id], [RegistrationNumber], [Make], [Model], [PricePerDay], [HomeDepotId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) 
	VALUES ('911762e0-31ba-4c6c-83f8-3f2288904975', 'SF59 QRT', 'Ford', 'Transit', 90, '6a9857a6-d0b0-4e1a-84cb-ee9ade159560', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Vehicle] ([Id], [RegistrationNumber], [Make], [Model], [PricePerDay], [HomeDepotId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) 
	VALUES ('a50c62cd-b24a-4d0a-aada-9744fce7022c', 'RJ08 FAE', 'Volkswagen', 'Transporter', 100, '6a9857a6-d0b0-4e1a-84cb-ee9ade159560', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
	INSERT INTO [Vehicle] ([Id], [RegistrationNumber], [Make], [Model], [PricePerDay], [HomeDepotId], [CreatedById], [CreatedOn], [LastModifiedById], [LastModifiedOn], [Deleted]) 
	VALUES ('6850BF08-14D2-49A0-BC28-9285A69094BC', 'DG59 USG', 'Volkswagen', 'Transporter', 100, 'ba325fad-9a65-4732-872c-da2069bb37e8', '188403fb-3c5e-45a3-aa39-5908e86ea372', @now, null, null, 0)
END 
GO


IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Customer')
BEGIN
	CREATE TABLE [dbo].[Customer](
		[Id] [uniqueidentifier] NOT NULL,
		[UserId] [uniqueidentifier] NULL,
		[FamilyName] [nvarchar](50) NULL,
		[GivenName] [nvarchar](50) NULL,
		[Address1] [nvarchar](50) NULL,
		[Address2] [nvarchar](50) NULL,
		[Address3] [nvarchar](50) NULL,
		[Address4] [nvarchar](50) NULL,
		[PostCode] [nvarchar](10) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Customer] TO [AllowSelectInsertUpdate]
	
	DECLARE @now AS DATETIME
	SET @now = GETDATE()
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Booking')
BEGIN
CREATE TABLE [dbo].[Booking](
		[Id] [uniqueidentifier] NOT NULL,
		[BookingNumber] [nvarchar](25) NULL,
		[StartDate] [datetime] NOT NULL,
		[EndDate] [datetime] NOT NULL,
		[StartMileage] [decimal](8,2) NULL,
		[EndMileage] [decimal](8,2) NULL,
		[VehicleId] [uniqueidentifier] NULL,
		[CustomerId] [uniqueidentifier] NULL,
		[CollectedOn] [datetime] NULL,
		[ReturnedOn] [datetime] NULL,
		[Total] [decimal](5,2) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Booking] TO [AllowSelectInsertUpdate]
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'MaintenanceCheck')
BEGIN
CREATE TABLE [dbo].[MaintenanceCheck](
		[Id] [uniqueidentifier] NOT NULL,
		[VehicleId] [uniqueidentifier] NULL,
		[CheckedOn] [datetime] NULL,
		[Mileage] [decimal](8,2) NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_MaintenanceCheck] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [MaintenanceCheck] TO [AllowSelectInsertUpdate]
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'Invoice')
BEGIN
CREATE TABLE [dbo].[Invoice](
		[Id] [uniqueidentifier] NOT NULL,
		[InvoiceNumber] [varchar](25) NULL,
		[CustomerId] [uniqueidentifier] NULL,
		[PeriodFrom] [datetime] NOT NULL,
		[PeriodTo] [datetime] NOT NULL,
		[InvoiceDate] [datetime] NOT NULL,
		[Total] [decimal](8,2) NOT NULL,
		[CreatedById] [uniqueidentifier] NULL,
		[CreatedOn] [datetime] NULL,
		[LastModifiedById] [uniqueidentifier] NULL,
		[LastModifiedOn] [datetime] NULL,
		[Deleted] [bit]	NOT NULL,
		CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	GRANT SELECT, INSERT, UPDATE ON [Invoice] TO [AllowSelectInsertUpdate]
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
	WHERE TABLE_NAME = 'LogEvent')
BEGIN
	CREATE TABLE [dbo].[LogEvent](
		[LogEventId] [bigint] IDENTITY(1,1) NOT NULL,
		[Date] [datetime] NOT NULL,
		[Level] [int] NOT NULL,
		[Message] [varchar](100) COLLATE Latin1_General_CI_AS NULL,
		[User] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
		[Exception] [text] COLLATE Latin1_General_CI_AS NULL,
		[Objects] [xml] NULL,
		[ExecutingMachine] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
		[CallingAssembly] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
		[CallingClass] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
		[CallingMethod] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
		[ContextGuid] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	 CONSTRAINT [PK_SyncLogEvent] PRIMARY KEY CLUSTERED 
	(
		[LogEventId] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	
	GRANT SELECT, INSERT, UPDATE ON [LogEvent] TO [AllowSelectInsertUpdate]
END 
GO