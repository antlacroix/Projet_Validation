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

-- Creating table 'cinema'
CREATE TABLE [dbo].[cinema] (
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

-- Creating table 'film'
CREATE TABLE [dbo].[film] (
    [id] int IDENTITY(1,1) NOT NULL,
    [titre] nvarchar(50)  NOT NULL,
    [description] nvarchar(50)  NOT NULL,
    [annee_parution] int  NOT NULL,
    [duree] int  NOT NULL,
    [rating] float  NOT NULL,
    [revenu] int  NOT NULL
);
GO

-- Creating table 'genre'
CREATE TABLE [dbo].[genre] (
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

-- Creating table 'participant'
CREATE TABLE [dbo].[participant] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'participation'
CREATE TABLE [dbo].[participation] (
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

-- Creating table 'salle'
CREATE TABLE [dbo].[salle] (
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

-- Creating table 'seance'
CREATE TABLE [dbo].[seance] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date_debut] datetime  NOT NULL,
    [date_fin] datetime  NOT NULL,
    [titre_seance] nvarchar(50)  NOT NULL,
    [salle_id] int  NOT NULL,
    [film_id] int  NULL
);
GO

-- Creating table 'user'
CREATE TABLE [dbo].[user] (
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

-- Creating primary key on [id] in table 'cinema'
ALTER TABLE [dbo].[cinema]
ADD CONSTRAINT [PK_cinema]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'contact_info'
ALTER TABLE [dbo].[contact_info]
ADD CONSTRAINT [PK_contact_info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'film'
ALTER TABLE [dbo].[film]
ADD CONSTRAINT [PK_film]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'genre'
ALTER TABLE [dbo].[genre]
ADD CONSTRAINT [PK_genre]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [PK_genre_film]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'participant'
ALTER TABLE [dbo].[participant]
ADD CONSTRAINT [PK_participant]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'participation'
ALTER TABLE [dbo].[participation]
ADD CONSTRAINT [PK_participation]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'role_participant'
ALTER TABLE [dbo].[role_participant]
ADD CONSTRAINT [PK_role_participant]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'salle'
ALTER TABLE [dbo].[salle]
ADD CONSTRAINT [PK_salle]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'salle_status'
ALTER TABLE [dbo].[salle_status]
ADD CONSTRAINT [PK_salle_status]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'seance'
ALTER TABLE [dbo].[seance]
ADD CONSTRAINT [PK_seance]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [PK_user]
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

-- Creating foreign key on [contact_info_id] in table 'cinema'
ALTER TABLE [dbo].[cinema]
ADD CONSTRAINT [fk_cinema_contactinfo]
    FOREIGN KEY ([contact_info_id])
    REFERENCES [dbo].[contact_info]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cinema_contactinfo'
CREATE INDEX [IX_fk_cinema_contactinfo]
ON [dbo].[cinema]
    ([contact_info_id]);
GO

-- Creating foreign key on [responsable_user_id] in table 'cinema'
ALTER TABLE [dbo].[cinema]
ADD CONSTRAINT [fk_cinema_responsable]
    FOREIGN KEY ([responsable_user_id])
    REFERENCES [dbo].[user]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cinema_responsable'
CREATE INDEX [IX_fk_cinema_responsable]
ON [dbo].[cinema]
    ([responsable_user_id]);
GO

-- Creating foreign key on [cinema_id] in table 'salle'
ALTER TABLE [dbo].[salle]
ADD CONSTRAINT [fk_salle_cinema]
    FOREIGN KEY ([cinema_id])
    REFERENCES [dbo].[cinema]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_salle_cinema'
CREATE INDEX [IX_fk_salle_cinema]
ON [dbo].[salle]
    ([cinema_id]);
GO

-- Creating foreign key on [contact_info_id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [fk_user_contactinfo]
    FOREIGN KEY ([contact_info_id])
    REFERENCES [dbo].[contact_info]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_contactinfo'
CREATE INDEX [IX_fk_user_contactinfo]
ON [dbo].[user]
    ([contact_info_id]);
GO

-- Creating foreign key on [film_id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [fk_genrefilm_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[film]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_genrefilm_film'
CREATE INDEX [IX_fk_genrefilm_film]
ON [dbo].[genre_film]
    ([film_id]);
GO

-- Creating foreign key on [film_id] in table 'participation'
ALTER TABLE [dbo].[participation]
ADD CONSTRAINT [fk_participation_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[film]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_film'
CREATE INDEX [IX_fk_participation_film]
ON [dbo].[participation]
    ([film_id]);
GO

-- Creating foreign key on [film_id] in table 'seance'
ALTER TABLE [dbo].[seance]
ADD CONSTRAINT [fk_seance_film]
    FOREIGN KEY ([film_id])
    REFERENCES [dbo].[film]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_seance_film'
CREATE INDEX [IX_fk_seance_film]
ON [dbo].[seance]
    ([film_id]);
GO

-- Creating foreign key on [genre_id] in table 'genre_film'
ALTER TABLE [dbo].[genre_film]
ADD CONSTRAINT [fk_genrefilm_genre]
    FOREIGN KEY ([genre_id])
    REFERENCES [dbo].[genre]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_genrefilm_genre'
CREATE INDEX [IX_fk_genrefilm_genre]
ON [dbo].[genre_film]
    ([genre_id]);
GO

-- Creating foreign key on [participant_id] in table 'participation'
ALTER TABLE [dbo].[participation]
ADD CONSTRAINT [fk_participation_participant]
    FOREIGN KEY ([participant_id])
    REFERENCES [dbo].[participant]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_participant'
CREATE INDEX [IX_fk_participation_participant]
ON [dbo].[participation]
    ([participant_id]);
GO

-- Creating foreign key on [role_id] in table 'participation'
ALTER TABLE [dbo].[participation]
ADD CONSTRAINT [fk_participation_role]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[role_participant]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_participation_role'
CREATE INDEX [IX_fk_participation_role]
ON [dbo].[participation]
    ([role_id]);
GO

-- Creating foreign key on [status_id] in table 'salle'
ALTER TABLE [dbo].[salle]
ADD CONSTRAINT [fk_salle_status]
    FOREIGN KEY ([status_id])
    REFERENCES [dbo].[salle_status]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_salle_status'
CREATE INDEX [IX_fk_salle_status]
ON [dbo].[salle]
    ([status_id]);
GO

-- Creating foreign key on [salle_id] in table 'seance'
ALTER TABLE [dbo].[seance]
ADD CONSTRAINT [fk_seance_salle]
    FOREIGN KEY ([salle_id])
    REFERENCES [dbo].[salle]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_seance_salle'
CREATE INDEX [IX_fk_seance_salle]
ON [dbo].[seance]
    ([salle_id]);
GO

-- Creating foreign key on [user_status_id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [fk_user_userstatus]
    FOREIGN KEY ([user_status_id])
    REFERENCES [dbo].[user_status]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_userstatus'
CREATE INDEX [IX_fk_user_userstatus]
ON [dbo].[user]
    ([user_status_id]);
GO

-- Creating foreign key on [user_type_id] in table 'user'
ALTER TABLE [dbo].[user]
ADD CONSTRAINT [fk_user_usertype]
    FOREIGN KEY ([user_type_id])
    REFERENCES [dbo].[user_type]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_user_usertype'
CREATE INDEX [IX_fk_user_usertype]
ON [dbo].[user]
    ([user_type_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------