USE [master]
GO

-- Create user for SQL Authentication
CREATE LOGIN usrSms WITH PASSWORD = 'usrSms', DEFAULT_DATABASE = [dbSms]
GO

-- Add User to first database
USE dbSms;
CREATE USER usrSms FOR LOGIN usrSms;
EXEC sp_addrolemember 'db_datareader', 'usrSms'
EXEC sp_addrolemember 'db_datawriter', 'usrSms'
GO


/****** Object:  Database [dbSMS]    Script Date: 29/08/2016 01:46:47 ******/
CREATE DATABASE [dbSMS]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'dbSMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbSMS.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'dbSMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\dbSMS_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbSMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbSMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbSMS] SET  MULTI_USER 
GO
ALTER DATABASE [dbSMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [dbSMS]
GO
/****** Object:  User [usrSms]    Script Date: 29/08/2016 01:46:47 ******/
CREATE USER [usrSms] FOR LOGIN [usrSms] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [usrSms]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [usrSms]
GO
/****** Object:  Table [dbo].[CountrySms]    Script Date: 29/08/2016 01:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountrySms](
	[CountrySmsId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](50) NOT NULL,
	[MobileCountryCode] [nvarchar](3) NOT NULL,
	[CountryCode] [nvarchar](2) NOT NULL,
	[SmsPrice] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_dbo.CountrySms] PRIMARY KEY CLUSTERED 
(
	[CountrySmsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SmsTransaction]    Script Date: 29/08/2016 01:46:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmsTransaction](
	[SmsTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[from] [nvarchar](50) NOT NULL,
	[to] [nvarchar](50) NOT NULL,
	[message] [nvarchar](100) NOT NULL,
	[DateTransaction] [datetime] NOT NULL DEFAULT (getutcdate()),
	[MobileCountryCode] [nvarchar](3) NOT NULL,
	[SmsPrice] [decimal](19, 4) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.SmsTransaction] PRIMARY KEY CLUSTERED 
(
	[SmsTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CountrySms] ON 

INSERT [dbo].[CountrySms] ([CountrySmsId], [CountryName], [MobileCountryCode], [CountryCode], [SmsPrice]) VALUES (1, N'Germany', N'262', N'49', CAST(0.0550 AS Decimal(19, 4)))
INSERT [dbo].[CountrySms] ([CountrySmsId], [CountryName], [MobileCountryCode], [CountryCode], [SmsPrice]) VALUES (2, N'Austria', N'232', N'43', CAST(0.0530 AS Decimal(19, 4)))
INSERT [dbo].[CountrySms] ([CountrySmsId], [CountryName], [MobileCountryCode], [CountryCode], [SmsPrice]) VALUES (3, N'Poland', N'260', N'48', CAST(0.0320 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[CountrySms] OFF
SET IDENTITY_INSERT [dbo].[SmsTransaction] ON 

INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (1, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:31.163' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (2, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:31.097' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (3, N'+5561984608436', N'+4323221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:31.163' AS DateTime), N'232', CAST(0.0530 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (4, N'+5561984608436', N'+4926221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:45.307' AS DateTime), N'262', CAST(0.0550 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (5, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:47.530' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (6, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:50.120' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (7, N'+5561984608436', N'+4323221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:53.770' AS DateTime), N'232', CAST(0.0530 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (8, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:56.130' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (9, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:27:58.227' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (10, N'+5561984608436', N'+4926221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:02.193' AS DateTime), N'262', CAST(0.0550 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (11, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:04.263' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (12, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:06.320' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (13, N'+5561984608436', N'+4323221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:08.553' AS DateTime), N'232', CAST(0.0530 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (14, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:10.447' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (15, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:12.147' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (16, N'+5561984608436', N'+4926221293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:14.067' AS DateTime), N'262', CAST(0.0550 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (17, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:16.010' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (18, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:28:18.313' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (19, N'+5561984608436', N'+4826021293388', N'Hello World From Brazil', CAST(N'2016-08-29 01:45:25.550' AS DateTime), N'260', CAST(0.0320 AS Decimal(19, 4)), 1)
SET IDENTITY_INSERT [dbo].[SmsTransaction] OFF
USE [master]
GO
ALTER DATABASE [dbSMS] SET  READ_WRITE 
GO
