----------------------------------------------------------------------------
--Add a column id_film in film for the promotional movies
----------------------------------------------------------------------------
IF NOT EXISTS(SELECT * FROM sys.all_columns WHERE object_id = OBJECT_ID(N'[dbo].[film]') AND name='id_film')
	BEGIN
		ALTER TABLE [dbo].[film] ADD id_film int NULL;

		ALTER TABLE 
			film
		ADD CONSTRAINT 
			fk_id_film_film
		FOREIGN KEY 
			(id_film) 
		REFERENCES 
			film(id);
	END
---------------------------------------------------------------------------
--create the table film_type and fills it
---------------------------------------------------------------------------
if not exists(select * from sys.tables where name='type_film')
	BEGIN
		CREATE TABLE [dbo].[type_film](
			[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,												
			[typage] [nvarchar] (25) NOT NULL);

		INSERT INTO
			type_film (typage)
		VALUES
			('Standart'),
			('Promotionnel'),
			('Court Metrage');
	END
---------------------------------------------------------------------------
--add the column id_type to film, fills it and make it not nullable
---------------------------------------------------------------------------


ALTER TABLE 
	[dbo].[film] 
ADD 
	[id_type] int NULL;


--------------------------------------------------------------------------------
--create the table programmation and fills it using films attach to the seances
--------------------------------------------------------------------------------
if not exists(select * from sys.tables where name='programmation')
	BEGIN
		CREATE TABLE [dbo].programmation(
			[id] INT IDENTITY(1,1) NOT NULL,												
			id_seance INT NOT NULL,
			[id_film] INT NOT NULL,
			[is_primary] BIT NOT NULL,
			PRIMARY KEY (id),
			CONSTRAINT fk_id_seance FOREIGN KEY (id_seance)
			REFERENCES seance (id),
			CONSTRAINT fk_id_film FOREIGN KEY (id_film)
			REFERENCES film (id)
			);
	
		INSERT INTO 
			dbo.programmation (id_seance, id_film, is_primary)
		SELECT 
			id, 
			film_id,
			1
		FROM 
			seance;	
	END
--------------------------------------------------------------------------
--drop the constraint and the column for the movie in seance
--------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sys.all_columns WHERE object_id = OBJECT_ID(N'[dbo].[seance]') AND name='film_id')
	BEGIN
		ALTER TABLE dbo.seance DROP CONSTRAINT fk_seance_film;
		DROP INDEX dbo.seance.IX_fk_seance_film;
		ALTER TABLE dbo.seance DROP COLUMN film_id;
	END
