SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cinema](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[contact_info_id] [int] NOT NULL,
	[responsable_user_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[contact_info]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contact_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tel_number] [nchar](9) NOT NULL,
	[code_postal] [nchar](6) NOT NULL,
	[adresse] [nvarchar](50) NOT NULL,
	[ville] [nvarchar](50) NOT NULL,
	[province] [nvarchar](20) NOT NULL,
	[pays] [nvarchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[film]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titre] [nvarchar](100) NOT NULL,
	[ranking] [int] NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[annee_parution] [int] NOT NULL,
	[duree] [int] NOT NULL,
	[rating] [float] NOT NULL,
	[revenu] [float],
	[votes] [int],
	[metascore] [int]
	
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[genre_film]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[genre_film](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[genre_id] [int] NOT NULL,
	[film_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participant]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participation]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[participant_id] [int] NOT NULL,
	[role_id] [int] NOT NULL,
	[film_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role_participant]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role_participant](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salle]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salle](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nbr_place] [int] NOT NULL,
	[numero_salle] [int] NOT NULL,
	[commentaire] [nvarchar](250) NOT NULL,
	[status_id] [int] NOT NULL,
	[cinema_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salle_status]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salle_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seance]    Script Date: 2020-10-14 3:09:19 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2020-10-14 3:09:19 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_status]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_type]    Script Date: 2020-10-14 3:09:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
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
ALTER DATABASE [F:\Projet_Validation\GitWorkspace\Develop\WebCinema\App_Data\CINEMA_DB.MDF] SET  READ_WRITE 
GO
