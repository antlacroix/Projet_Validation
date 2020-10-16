
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2020 15:03:45
-- Generated from EDMX file: E:\Cours\Session 5\Projet validation\ProjetValidation\ProjetValidation\Models\ModelCinema.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [cinema_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_cinema_contactinfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[cinema] DROP CONSTRAINT [fk_cinema_contactinfo];
GO
IF OBJECT_ID(N'[dbo].[fk_cinema_responsable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[cinema] DROP CONSTRAINT [fk_cinema_responsable];
GO
IF OBJECT_ID(N'[dbo].[fk_genrefilm_film]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[genre_film] DROP CONSTRAINT [fk_genrefilm_film];
GO
IF OBJECT_ID(N'[dbo].[fk_genrefilm_genre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[genre_film] DROP CONSTRAINT [fk_genrefilm_genre];
GO
IF OBJECT_ID(N'[dbo].[fk_participation_film]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[participation] DROP CONSTRAINT [fk_participation_film];
GO
IF OBJECT_ID(N'[dbo].[fk_participation_participant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[participation] DROP CONSTRAINT [fk_participation_participant];
GO
IF OBJECT_ID(N'[dbo].[fk_participation_role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[participation] DROP CONSTRAINT [fk_participation_role];
GO
IF OBJECT_ID(N'[dbo].[fk_salle_cinema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[salle] DROP CONSTRAINT [fk_salle_cinema];
GO
IF OBJECT_ID(N'[dbo].[fk_salle_status]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[salle] DROP CONSTRAINT [fk_salle_status];
GO
IF OBJECT_ID(N'[dbo].[fk_seance_film]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[seance] DROP CONSTRAINT [fk_seance_film];
GO
IF OBJECT_ID(N'[dbo].[fk_seance_salle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[seance] DROP CONSTRAINT [fk_seance_salle];
GO
IF OBJECT_ID(N'[dbo].[fk_user_contactinfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user] DROP CONSTRAINT [fk_user_contactinfo];
GO
IF OBJECT_ID(N'[dbo].[fk_user_userstatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user] DROP CONSTRAINT [fk_user_userstatus];
GO
IF OBJECT_ID(N'[dbo].[fk_user_usertype]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[user] DROP CONSTRAINT [fk_user_usertype];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[cinema]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cinema];
GO
IF OBJECT_ID(N'[dbo].[contact_info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[contact_info];
GO
IF OBJECT_ID(N'[dbo].[film]', 'U') IS NOT NULL
    DROP TABLE [dbo].[film];
GO
IF OBJECT_ID(N'[dbo].[genre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[genre];
GO
IF OBJECT_ID(N'[dbo].[genre_film]', 'U') IS NOT NULL
    DROP TABLE [dbo].[genre_film];
GO
IF OBJECT_ID(N'[dbo].[participant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[participant];
GO
IF OBJECT_ID(N'[dbo].[participation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[participation];
GO
IF OBJECT_ID(N'[dbo].[role_participant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[role_participant];
GO
IF OBJECT_ID(N'[dbo].[salle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[salle];
GO
IF OBJECT_ID(N'[dbo].[salle_status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[salle_status];
GO
IF OBJECT_ID(N'[dbo].[seance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[seance];
GO
IF OBJECT_ID(N'[dbo].[user]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user];
GO
IF OBJECT_ID(N'[dbo].[user_status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_status];
GO
IF OBJECT_ID(N'[dbo].[user_type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[user_type];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'cinemas'
CREATE TABLE [dbo].[cinemas] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contact_info_id] int  NOT NULL,
    [responsable_user_id] int  NOT NULL
);
GO

-- Creating table 'contact_info'
CREATE TABLE [dbo].[contact_info] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tel_number] nchar(9)  NOT NULL,
    [code_postal] nchar(6)  NOT NULL,
    [adresse] nvarchar(50)  NOT NULL,
    [ville] nvarchar(50)  NOT NULL,
    [province] nvarchar(20)  NOT NULL,
    [pays] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'films'
CREATE TABLE [dbo].[films] (
    [id] int IDENTITY(1,1) NOT NULL,
    [titre] nvarchar(50)  NOT NULL,
    [description] nvarchar(50)  NOT NULL,
    [annee_parution] int  NOT NULL,
    [duree] int  NOT NULL,
    [rating] float  NOT NULL,
    [revenu] int  NOT NULL
);
GO

-- Creating table 'genres'
CREATE TABLE [dbo].[genres] (
    [id] int IDENTITY(1,1) NOT NULL,
    [genre1] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'genre_film'
CREATE TABLE [dbo].[genre_film] (
    [id] int IDENTITY(1,1) NOT NULL,
    [genre_id] int  NOT NULL,
    [film_id] int  NOT NULL
);
GO

-- Creating table 'participants'
CREATE TABLE [dbo].[participants] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'participations'
CREATE TABLE [dbo].[participations] (
    [id] int IDENTITY(1,1) NOT NULL,
    [participant_id] int  NOT NULL,
    [role_id] int  NOT NULL,
    [film_id] int  NOT NULL
);
GO

-- Creating table 'role_participant'
CREATE TABLE [dbo].[role_participant] (
    [id] int IDENTITY(1,1) NOT NULL,
    [role] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'salles'
CREATE TABLE [dbo].[salles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [nbr_place] int  NOT NULL,
    [numero_salle] int  NOT NULL,
    [commentaire] nvarchar(250)  NOT NULL,
    [status_id] int  NOT NULL,
    [cinema_id] int  NOT NULL
);
GO

-- Creating table 'salle_status'
CREATE TABLE [dbo].[salle_status] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'seances'
CREATE TABLE [dbo].[seances] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date_debut] datetime  NOT NULL,
    [date_fin] datetime  NOT NULL,
    [titre_seance] nvarchar(50)  NOT NULL,
    [salle_id] int  NOT NULL,
    [film_id] int  NULL
);
GO

-- Creating table 'users'
CREATE TABLE [dbo].[users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [login] nvarchar(15)  NOT NULL,
    [password] nvarchar(25)  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [contact_info_id] int  NOT NULL,
    [user_status_id] int  NOT NULL,
    [user_type_id] int  NOT NULL
);
GO

-- Creating table 'user_status'
CREATE TABLE [dbo].[user_status] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'user_type'
CREATE TABLE [dbo].[user_type] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'cinemas'
ALTER TABLE [dbo].[cinemas]
ADD CONSTRAINT [PK_cinemas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'contact_info'
ALTER TABLE [dbo].[contact_info]
ADD CONSTRAINT [PK_contact_info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'films'
ALTER TABLE [dbo].[films]
ADD CONSTRAINT [PK_films]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'genres'
ALTER TABLE [dbo].[genres]
ADD CONSTRAINT [PK_genres]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [PK_genre_film]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'participants'
ALTER TABLE [dbo].[participants]
ADD CONSTRAINT [PK_participants]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'participations'
ALTER TABLE [dbo].[participations]
ADD CONSTRAINT [PK_participations]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'role_participant'
ALTER TABLE [dbo].[role_participant]
ADD CONSTRAINT [PK_role_participant]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'salles'
ALTER TABLE [dbo].[salles]
ADD CONSTRAINT [PK_salles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'salle_status'
ALTER TABLE [dbo].[salle_status]
ADD CONSTRAINT [PK_salle_status]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'seances'
ALTER TABLE [dbo].[seances]
ADD CONSTRAINT [PK_seances]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [PK_users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'user_status'
ALTER TABLE [dbo].[user_status]
ADD CONSTRAINT [PK_user_status]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'user_type'
ALTER TABLE [dbo].[user_type]
ADD CONSTRAINT [PK_user_type]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [contact_info_id] in table 'cinemas'
ALTER TABLE [dbo].[cinemas]
ADD CONSTRAINT [fk_cinema_contactinfo]
    FOREIGN KEY ([contact_info_id])
    REFERENCES [dbo].[contact_info]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cinema_contactinfo'
CREATE INDEX [IX_fk_cinema_contactinfo]
ON [dbo].[cinemas]
    ([contact_info_id]);
GO

-- Creating foreign key on [responsable_user_id] in table 'cinemas'
ALTER TABLE [dbo].[cinemas]
ADD CONSTRAINT [fk_cinema_responsable]
    FOREIGN KEY ([responsable_user_id])
    REFERENCES [dbo].[users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cinema_responsable'
CREATE INDEX [IX_fk_cinema_responsable]
ON [dbo].[cinemas]
    ([responsable_user_id]);
GO

-- Creating foreign key on [cinema_id] in table 'salles'
ALTER TABLE [dbo].[salles]
ADD CONSTRAINT [fk_salle_cinema]
    FOREIGN KEY ([cinema_id])
    REFERENCES [dbo].[cinemas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_salle_cinema'
CREATE INDEX [IX_fk_salle_cinema]
ON [dbo].[salles]
    ([cinema_id]);
GO

-- Creating foreign key on [contact_info_id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [fk_user_contactinfo]
    FOREIGN KEY ([contact_info_id])
    REFERENCES [dbo].[contact_info]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_contactinfo'
CREATE INDEX [IX_fk_user_contactinfo]
ON [dbo].[users]
    ([contact_info_id]);
GO

-- Creating foreign key on [film_id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [fk_genrefilm_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[films]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_genrefilm_film'
CREATE INDEX [IX_fk_genrefilm_film]
ON [dbo].[genre_film]
    ([film_id]);
GO

-- Creating foreign key on [film_id] in table 'participations'
ALTER TABLE [dbo].[participations]
ADD CONSTRAINT [fk_participation_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[films]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_film'
CREATE INDEX [IX_fk_participation_film]
ON [dbo].[participations]
    ([film_id]);
GO

-- Creating foreign key on [film_id] in table 'seances'
ALTER TABLE [dbo].[seances]
ADD CONSTRAINT [fk_seance_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[films]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_seance_film'
CREATE INDEX [IX_fk_seance_film]
ON [dbo].[seances]
    ([film_id]);
GO

-- Creating foreign key on [genre_id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [fk_genrefilm_genre]
    FOREIGN KEY ([genre_id])
    REFERENCES [dbo].[genres]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_genrefilm_genre'
CREATE INDEX [IX_fk_genrefilm_genre]
ON [dbo].[genre_film]
    ([genre_id]);
GO

-- Creating foreign key on [participant_id] in table 'participations'
ALTER TABLE [dbo].[participations]
ADD CONSTRAINT [fk_participation_participant]
    FOREIGN KEY ([participant_id])
    REFERENCES [dbo].[participants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_participant'
CREATE INDEX [IX_fk_participation_participant]
ON [dbo].[participations]
    ([participant_id]);
GO

-- Creating foreign key on [role_id] in table 'participations'
ALTER TABLE [dbo].[participations]
ADD CONSTRAINT [fk_participation_role]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[role_participant]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_role'
CREATE INDEX [IX_fk_participation_role]
ON [dbo].[participations]
    ([role_id]);
GO

-- Creating foreign key on [status_id] in table 'salles'
ALTER TABLE [dbo].[salles]
ADD CONSTRAINT [fk_salle_status]
    FOREIGN KEY ([status_id])
    REFERENCES [dbo].[salle_status]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_salle_status'
CREATE INDEX [IX_fk_salle_status]
ON [dbo].[salles]
    ([status_id]);
GO

-- Creating foreign key on [salle_id] in table 'seances'
ALTER TABLE [dbo].[seances]
ADD CONSTRAINT [fk_seance_salle]
    FOREIGN KEY ([salle_id])
    REFERENCES [dbo].[salles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_seance_salle'
CREATE INDEX [IX_fk_seance_salle]
ON [dbo].[seances]
    ([salle_id]);
GO

-- Creating foreign key on [user_status_id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [fk_user_userstatus]
    FOREIGN KEY ([user_status_id])
    REFERENCES [dbo].[user_status]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_userstatus'
CREATE INDEX [IX_fk_user_userstatus]
ON [dbo].[users]
    ([user_status_id]);
GO

-- Creating foreign key on [user_type_id] in table 'users'
ALTER TABLE [dbo].[users]
ADD CONSTRAINT [fk_user_usertype]
    FOREIGN KEY ([user_type_id])
    REFERENCES [dbo].[user_type]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_usertype'
CREATE INDEX [IX_fk_user_usertype]
ON [dbo].[users]
    ([user_type_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------