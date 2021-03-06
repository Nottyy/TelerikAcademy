USE [master]
GO
/****** Object:  Database [PersonInfo]    Script Date: 8/24/2014 3:02:27 PM ******/
CREATE DATABASE [PersonInfo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PersonInfo', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonInfo.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonInfo_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\PersonInfo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PersonInfo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonInfo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PersonInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonInfo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonInfo] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonInfo] SET  MULTI_USER 
GO
ALTER DATABASE [PersonInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PersonInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PersonInfo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonInfo', N'ON'
GO
USE [PersonInfo]
GO
/****** Object:  User [nakov]    Script Date: 8/24/2014 3:02:27 PM ******/
CREATE USER [nakov] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/24/2014 3:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [text] NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 8/24/2014 3:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[ContinentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[ContinentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 8/24/2014 3:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentID] [int] NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 8/24/2014 3:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressID] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 8/24/2014 3:02:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[TownID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (1, N'Pozitano', 1)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (2, N'Batenberg', 1)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (3, N'Morskata Gradina', 2)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (4, N'Hristo Botev', 3)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (5, N'Lauta', 3)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (6, N'Bernabeu', 5)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (7, N'Brandenburg''s Gate', 4)
INSERT [dbo].[Address] ([AddressID], [AddressText], [TownID]) VALUES (8, N'5th Avenue', 8)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (2, N'Asia')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (3, N'South America')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (4, N'North America')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (5, N'Australia')
INSERT [dbo].[Continent] ([ContinentID], [Name]) VALUES (6, N'Africa')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (1, N'Bulgaria', 1)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (2, N'Spain', 1)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (3, N'Germany', 1)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (4, N'China', 2)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (5, N'USA', 4)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (6, N'Brazil', 3)
INSERT [dbo].[Country] ([CountryID], [Name], [ContinentID]) VALUES (7, N'Egypt', 6)
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (1, N'Gosho', N'Goshov', 1)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (2, N'Ivan', N'Ivanov', 2)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (3, N'Evlogi', N'Asparuhov', 3)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (4, N'Valeri', N'Boijinov', 5)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (5, N'Mici', N'Makriev', 4)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (6, N'Gosho', N'Petkov', 1)
INSERT [dbo].[Person] ([PersonID], [FirstName], [LastName], [AddressID]) VALUES (7, N'Marcho', N'Dafchev', 6)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (1, N'Sofia', 1)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (2, N'Varna', 1)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (3, N'Plovdiv', 1)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (4, N'Berlin', 3)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (5, N'Madrid', 2)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (6, N'Malaga', 2)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (7, N'Beijing', 4)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (8, N'New York', 5)
INSERT [dbo].[Town] ([TownID], [Name], [CountryID]) VALUES (9, N'Sao Paulo', 6)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Town] ([TownID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentID])
REFERENCES [dbo].[Continent] ([ContinentID])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressID])
REFERENCES [dbo].[Address] ([AddressID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([CountryID])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PersonInfo] SET  READ_WRITE 
GO
