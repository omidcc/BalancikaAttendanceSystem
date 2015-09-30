USE [master]
GO
/****** Object:  Database [AttendanceDB]    Script Date: 10/1/2015 2:32:34 AM ******/
CREATE DATABASE [AttendanceDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AttendanceDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AttendanceDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AttendanceDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AttendanceDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AttendanceDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AttendanceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AttendanceDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AttendanceDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AttendanceDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AttendanceDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AttendanceDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AttendanceDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AttendanceDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AttendanceDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AttendanceDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AttendanceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AttendanceDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AttendanceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AttendanceDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AttendanceDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AttendanceDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AttendanceDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AttendanceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AttendanceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AttendanceDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AttendanceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AttendanceDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AttendanceDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AttendanceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AttendanceDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AttendanceDB] SET  MULTI_USER 
GO
ALTER DATABASE [AttendanceDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AttendanceDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AttendanceDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AttendanceDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AttendanceDB]
GO
/****** Object:  Table [dbo].[tbl_attendance]    Script Date: 10/1/2015 2:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_attendance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[date] [date] NOT NULL,
	[holiday] [int] NULL,
 CONSTRAINT [PK_tbl_attendance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_login]    Script Date: 10/1/2015 2:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_login](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[login_time] [varchar](50) NOT NULL,
	[remarks] [varchar](max) NULL,
	[dateId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_login] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_logout]    Script Date: 10/1/2015 2:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_logout](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[logout_time] [varchar](50) NOT NULL,
	[remarks] [varchar](max) NULL,
	[dateId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_logout] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_stuff]    Script Date: 10/1/2015 2:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_stuff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[fullname] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_stuff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_attendance] ON 

INSERT [dbo].[tbl_attendance] ([Id], [userId], [date], [holiday]) VALUES (25, 1, CAST(0x7F3A0B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[tbl_attendance] OFF
SET IDENTITY_INSERT [dbo].[tbl_login] ON 

INSERT [dbo].[tbl_login] ([Id], [login_time], [remarks], [dateId]) VALUES (13, N'10/1/2015 2:06:30 AM', N'Late ', 25)
SET IDENTITY_INSERT [dbo].[tbl_login] OFF
SET IDENTITY_INSERT [dbo].[tbl_logout] ON 

INSERT [dbo].[tbl_logout] ([Id], [logout_time], [remarks], [dateId]) VALUES (5, N'10/1/2015 2:06:55 AM', N'Early leave', 25)
SET IDENTITY_INSERT [dbo].[tbl_logout] OFF
SET IDENTITY_INSERT [dbo].[tbl_stuff] ON 

INSERT [dbo].[tbl_stuff] ([Id], [username], [password], [fullname]) VALUES (1, N'delowar', N'delowar123', N'Delowar Hossain')
INSERT [dbo].[tbl_stuff] ([Id], [username], [password], [fullname]) VALUES (2, N'khairul', N'khairul123', N'Khairul Omi')
INSERT [dbo].[tbl_stuff] ([Id], [username], [password], [fullname]) VALUES (3, N'shibly', N'shibly123', N'Md Musfiqur Shibly')
INSERT [dbo].[tbl_stuff] ([Id], [username], [password], [fullname]) VALUES (4, N'mashfiq', N'mashfiq123', N'Mashfiq Nahid')
SET IDENTITY_INSERT [dbo].[tbl_stuff] OFF
USE [master]
GO
ALTER DATABASE [AttendanceDB] SET  READ_WRITE 
GO
