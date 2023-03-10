USE [master]
GO
/****** Object:  Database [DBPrikol]    Script Date: 15.12.2022 20:07:14 ******/
CREATE DATABASE [DBPrikol]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBPrikol', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBPrikol.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBPrikol_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBPrikol_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBPrikol] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBPrikol].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBPrikol] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBPrikol] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBPrikol] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBPrikol] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBPrikol] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBPrikol] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBPrikol] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBPrikol] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBPrikol] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBPrikol] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBPrikol] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBPrikol] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBPrikol] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBPrikol] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBPrikol] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBPrikol] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBPrikol] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBPrikol] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBPrikol] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBPrikol] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBPrikol] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBPrikol] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBPrikol] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBPrikol] SET  MULTI_USER 
GO
ALTER DATABASE [DBPrikol] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBPrikol] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBPrikol] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBPrikol] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBPrikol] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBPrikol] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DBPrikol] SET QUERY_STORE = OFF
GO
USE [DBPrikol]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 15.12.2022 20:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[score] [nchar](10) NULL,
	[playDate] [datetime] NULL,
	[userID] [int] NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 15.12.2022 20:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[creationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Game] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Game]
GO
USE [master]
GO
ALTER DATABASE [DBPrikol] SET  READ_WRITE 
GO
