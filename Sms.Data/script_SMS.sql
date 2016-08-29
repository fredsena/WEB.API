USE [master]
GO
/****** Object:  Database [dbSms]    Script Date: 26/08/2016 15:47:57 ******/
CREATE DATABASE [dbSms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbSms', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\dbSms.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbSms_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLSERVER\MSSQL\DATA\dbSms_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbSms] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbSms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbSms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbSms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbSms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbSms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbSms] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbSms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbSms] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbSms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbSms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbSms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbSms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbSms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbSms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbSms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbSms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbSms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbSms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbSms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbSms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbSms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbSms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbSms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbSms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbSms] SET RECOVERY FULL 
GO
ALTER DATABASE [dbSms] SET  MULTI_USER 
GO
ALTER DATABASE [dbSms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbSms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbSms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbSms] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbSms', N'ON'
GO
USE [dbSms]
GO
/****** Object:  Table [dbo].[CountrySms]    Script Date: 26/08/2016 15:47:57 ******/
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
/****** Object:  Table [dbo].[SmsTransaction]    Script Date: 26/08/2016 15:47:57 ******/
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

INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (1, N'49262123456789', N'43232987654321', N'Hello from Germany', CAST(N'2016-08-26 01:51:45.910' AS DateTime), N'232', CAST(0.0530 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (2, N'43232987654321', N'49262123456789', N'Hello from Austria', CAST(N'2016-08-26 01:54:02.110' AS DateTime), N'262', CAST(0.0550 AS Decimal(19, 4)), 1)
INSERT [dbo].[SmsTransaction] ([SmsTransactionId], [from], [to], [message], [DateTransaction], [MobileCountryCode], [SmsPrice], [Status]) VALUES (3, N'48260456789123', N'43232987654321', N'Hello from Poland', CAST(N'2016-08-26 01:54:33.887' AS DateTime), N'232', CAST(0.0530 AS Decimal(19, 4)), 1)
SET IDENTITY_INSERT [dbo].[SmsTransaction] OFF
USE [master]
GO
ALTER DATABASE [dbSms] SET  READ_WRITE 
GO