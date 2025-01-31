USE [master]
GO
CREATE LOGIN [bankier] WITH PASSWORD = 'Trudne_haslo';
/****** Object:  Database [Konto_bankowe]    Script Date: 1/19/2025 4:15:32 PM ******/
CREATE DATABASE [Konto_bankowe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Konto_bankowe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Konto_bankowe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Konto_bankowe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Konto_bankowe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Konto_bankowe] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Konto_bankowe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Konto_bankowe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Konto_bankowe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Konto_bankowe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Konto_bankowe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Konto_bankowe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Konto_bankowe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Konto_bankowe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Konto_bankowe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Konto_bankowe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Konto_bankowe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Konto_bankowe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Konto_bankowe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Konto_bankowe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Konto_bankowe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Konto_bankowe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Konto_bankowe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Konto_bankowe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Konto_bankowe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Konto_bankowe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Konto_bankowe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Konto_bankowe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Konto_bankowe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Konto_bankowe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Konto_bankowe] SET  MULTI_USER 
GO
ALTER DATABASE [Konto_bankowe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Konto_bankowe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Konto_bankowe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Konto_bankowe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Konto_bankowe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Konto_bankowe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Konto_bankowe] SET QUERY_STORE = ON
GO
ALTER DATABASE [Konto_bankowe] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Konto_bankowe]
GO
/****** Object:  User [bankier]    Script Date: 1/19/2025 4:15:32 ******/
CREATE USER [bankier] FOR LOGIN [bankier] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [bankier]
GO
/****** Object:  Table [dbo].[Konto]    Script Date: 1/19/2025 4:15:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Konto](
	[numer_konta] [int] IDENTITY(1,1) NOT NULL,
	[wlasciciel] [varchar](100) NULL,
	[stan] [decimal](15, 2) NULL,
	[oprocentowanie] [decimal](5, 2) NULL,
	[debet] [decimal](15, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[numer_konta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Konto] ON 
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (1, N'Jerzy Wiga', CAST(2000.00 AS Decimal(15, 2)), CAST(5.00 AS Decimal(5, 2)), CAST(-400.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (2, N'Adam Nowak', CAST(1000.00 AS Decimal(15, 2)), CAST(3.00 AS Decimal(5, 2)), CAST(-200.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (3, N'Jan Kowalski', CAST(1500.00 AS Decimal(15, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(-300.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (4, N'Anna Kwiatkowska', CAST(2500.00 AS Decimal(15, 2)), CAST(2.50 AS Decimal(5, 2)), CAST(-150.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (5, N'Piotr Zielinski', CAST(3000.00 AS Decimal(15, 2)), CAST(3.50 AS Decimal(5, 2)), CAST(-500.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (6, N'Ewa Malinowska', CAST(2200.00 AS Decimal(15, 2)), CAST(4.00 AS Decimal(5, 2)), CAST(-300.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (7, N'Marek Szymanski', CAST(1800.00 AS Decimal(15, 2)), CAST(1.50 AS Decimal(5, 2)), CAST(-100.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (8, N'Katarzyna Kowalczyk', CAST(2750.00 AS Decimal(15, 2)), CAST(3.20 AS Decimal(5, 2)), CAST(-200.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (9, N'Lukasz Nowicki', CAST(3200.00 AS Decimal(15, 2)), CAST(2.80 AS Decimal(5, 2)), CAST(-250.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (10, N'Monika Wisniewska', CAST(2600.00 AS Decimal(15, 2)), CAST(4.50 AS Decimal(5, 2)), CAST(-350.00 AS Decimal(15, 2)))
GO
INSERT [dbo].[Konto] ([numer_konta], [wlasciciel], [stan], [oprocentowanie], [debet]) VALUES (11, N'Damian Weno', CAST(5800.00 AS Decimal(15, 2)), CAST(3.00 AS Decimal(5, 2)), CAST(-300.00 AS Decimal(15, 2)))
GO
SET IDENTITY_INSERT [dbo].[Konto] OFF
GO
USE [master]
GO
ALTER DATABASE [Konto_bankowe] SET  READ_WRITE 
GO
