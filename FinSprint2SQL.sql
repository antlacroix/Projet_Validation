USE [master]
GO
/****** Object:  Database [ProjetValidationTest]    Script Date: 2020-10-28 16:57:55 ******/
CREATE DATABASE [ProjetValidationTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjetValidationTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2\MSSQL\DATA\ProjetValidationTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjetValidationTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS2\MSSQL\DATA\ProjetValidationTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjetValidationTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjetValidationTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjetValidationTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjetValidationTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjetValidationTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjetValidationTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjetValidationTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjetValidationTest] SET  MULTI_USER 
GO
ALTER DATABASE [ProjetValidationTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjetValidationTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjetValidationTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjetValidationTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjetValidationTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjetValidationTest] SET QUERY_STORE = OFF
GO
USE [ProjetValidationTest]
GO
/****** Object:  User [SQLExpress2]    Script Date: 2020-10-28 16:57:55 ******/
CREATE USER [SQLExpress2] FOR LOGIN [SQLExpress2] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[cinema]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cinema](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contact_info_id] [int] NOT NULL,
	[responsable_user_id] [int] NOT NULL,
	[cinema_name] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_cinema] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact_info]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tel_number] [nchar](10) NOT NULL,
	[code_postal] [nchar](6) NOT NULL,
	[adresse] [nvarchar](50) NOT NULL,
	[ville] [nvarchar](50) NOT NULL,
	[province] [nvarchar](20) NOT NULL,
	[pays] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_contact_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[film]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titre] [nvarchar](100) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[annee_parution] [int] NOT NULL,
	[duree] [int] NOT NULL,
	[rating] [float] NULL,
	[revenu] [float] NULL,
	[ranking] [int] NULL,
	[votes] [int] NULL,
	[metascore] [int] NULL,
 CONSTRAINT [PK_film] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre1] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_genre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre_film]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre_film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre_id] [int] NOT NULL,
	[film_id] [int] NOT NULL,
 CONSTRAINT [PK_genre_film] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participant]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_participant] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participation]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[participant_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[film_id] [int] NOT NULL,
 CONSTRAINT [PK_participation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role_participant]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_participant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_role_participant] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salle]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nbr_place] [int] NOT NULL,
	[numero_salle] [int] NOT NULL,
	[commentaire] [nvarchar](250) NULL,
	[status_id] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
 CONSTRAINT [PK_salle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salle_status]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salle_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_salle_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seance]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_debut] [datetime] NOT NULL,
	[date_fin] [datetime] NOT NULL,
	[titre_seance] [nvarchar](50) NOT NULL,
	[salle_id] [int] NOT NULL,
	[film_id] [int] NULL,
 CONSTRAINT [PK_seance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [nvarchar](15) NOT NULL,
	[password] [nvarchar](25) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[contact_info_id] [int] NOT NULL,
	[user_status_id] [int] NOT NULL,
	[user_type_id] [int] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_status]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_user_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_type]    Script Date: 2020-10-28 16:57:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_user_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_cinema_contactinfo]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_cinema_contactinfo] ON [dbo].[cinema]
(
	[contact_info_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_cinema_responsable]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_cinema_responsable] ON [dbo].[cinema]
(
	[responsable_user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_genrefilm_film]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_genrefilm_film] ON [dbo].[genre_film]
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_genrefilm_genre]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_genrefilm_genre] ON [dbo].[genre_film]
(
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_participation_film]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_participation_film] ON [dbo].[participation]
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_participation_participant]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_participation_participant] ON [dbo].[participation]
(
	[participant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_participation_role]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_participation_role] ON [dbo].[participation]
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_salle_cinema]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_salle_cinema] ON [dbo].[salle]
(
	[cinema_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_salle_status]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_salle_status] ON [dbo].[salle]
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_seance_film]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_seance_film] ON [dbo].[seance]
(
	[film_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_seance_salle]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_seance_salle] ON [dbo].[seance]
(
	[salle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_user_contactinfo]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_user_contactinfo] ON [dbo].[user]
(
	[contact_info_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_user_userstatus]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_user_userstatus] ON [dbo].[user]
(
	[user_status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_fk_user_usertype]    Script Date: 2020-10-28 16:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_fk_user_usertype] ON [dbo].[user]
(
	[user_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cinema]  WITH CHECK ADD  CONSTRAINT [fk_cinema_contactinfo] FOREIGN KEY([contact_info_id])
REFERENCES [dbo].[contact_info] ([id])
GO
ALTER TABLE [dbo].[cinema] CHECK CONSTRAINT [fk_cinema_contactinfo]
GO
ALTER TABLE [dbo].[cinema]  WITH CHECK ADD  CONSTRAINT [fk_cinema_responsable] FOREIGN KEY([responsable_user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[cinema] CHECK CONSTRAINT [fk_cinema_responsable]
GO
ALTER TABLE [dbo].[genre_film]  WITH CHECK ADD  CONSTRAINT [fk_genrefilm_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[genre_film] CHECK CONSTRAINT [fk_genrefilm_film]
GO
ALTER TABLE [dbo].[genre_film]  WITH CHECK ADD  CONSTRAINT [fk_genrefilm_genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genre] ([id])
GO
ALTER TABLE [dbo].[genre_film] CHECK CONSTRAINT [fk_genrefilm_genre]
GO
ALTER TABLE [dbo].[participation]  WITH CHECK ADD  CONSTRAINT [fk_participation_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[participation] CHECK CONSTRAINT [fk_participation_film]
GO
ALTER TABLE [dbo].[participation]  WITH CHECK ADD  CONSTRAINT [fk_participation_participant] FOREIGN KEY([participant_id])
REFERENCES [dbo].[participant] ([id])
GO
ALTER TABLE [dbo].[participation] CHECK CONSTRAINT [fk_participation_participant]
GO
ALTER TABLE [dbo].[participation]  WITH CHECK ADD  CONSTRAINT [fk_participation_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[role_participant] ([id])
GO
ALTER TABLE [dbo].[participation] CHECK CONSTRAINT [fk_participation_role]
GO
ALTER TABLE [dbo].[salle]  WITH CHECK ADD  CONSTRAINT [fk_salle_cinema] FOREIGN KEY([cinema_id])
REFERENCES [dbo].[cinema] ([id])
GO
ALTER TABLE [dbo].[salle] CHECK CONSTRAINT [fk_salle_cinema]
GO
ALTER TABLE [dbo].[salle]  WITH CHECK ADD  CONSTRAINT [fk_salle_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[salle_status] ([id])
GO
ALTER TABLE [dbo].[salle] CHECK CONSTRAINT [fk_salle_status]
GO
ALTER TABLE [dbo].[seance]  WITH CHECK ADD  CONSTRAINT [fk_seance_film] FOREIGN KEY([film_id])
REFERENCES [dbo].[film] ([id])
GO
ALTER TABLE [dbo].[seance] CHECK CONSTRAINT [fk_seance_film]
GO
ALTER TABLE [dbo].[seance]  WITH CHECK ADD  CONSTRAINT [fk_seance_salle] FOREIGN KEY([salle_id])
REFERENCES [dbo].[salle] ([id])
GO
ALTER TABLE [dbo].[seance] CHECK CONSTRAINT [fk_seance_salle]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [fk_user_contactinfo] FOREIGN KEY([contact_info_id])
REFERENCES [dbo].[contact_info] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [fk_user_contactinfo]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [fk_user_userstatus] FOREIGN KEY([user_status_id])
REFERENCES [dbo].[user_status] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [fk_user_userstatus]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [fk_user_usertype] FOREIGN KEY([user_type_id])
REFERENCES [dbo].[user_type] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [fk_user_usertype]
GO
USE [master]
GO
ALTER DATABASE [ProjetValidationTest] SET  READ_WRITE 
GO
