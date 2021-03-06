USE [master]
GO
/****** Object:  Database [EmployeeDatabase]    Script Date: 22/02/2015 10:43:36 p. m. ******/
CREATE DATABASE [EmployeeDatabase] ON  PRIMARY 
( NAME = N'EmployeeDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmployeeDatabase.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmployeeDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EmployeeDatabase_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [EmployeeDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeDatabase] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EmployeeDatabase', N'ON'
GO
USE [EmployeeDatabase]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 22/02/2015 10:43:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SecurityNumber] [int] NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (1, N'Rodrigo', N'Vazquez', 123456789, N'Developer', 0)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (2, N'Isaac', N'Ojeda', 123456789, N'Developer', 1)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (3, N'Fernando', N'Mata', 654789123, N'IT', 1)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (6, N'Jaime', N'Irigoyen', 123654789, N'Developer', 1)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (7, N'Manuel', N'Hinojos', 654897321, N'Developer', 1)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (8, N'Edson', N'Urrutia', 654321987, N'Developer', 0)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (9, N'Samuel', N'Garcia', 123456789, N'ISC', 0)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (10, N'Manuel', N'Santiago', 654987123, N'IT', 1)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (11, N'Ture', N'Matias', 654789123, N'IT', 0)
INSERT [dbo].[Employees] ([EmployeeId], [Name], [LastName], [SecurityNumber], [Department], [Active]) VALUES (12, N'Angel', N'Salmon', 456789321, N'ISC', 0)
SET IDENTITY_INSERT [dbo].[Employees] OFF
USE [master]
GO
ALTER DATABASE [EmployeeDatabase] SET  READ_WRITE 
GO
