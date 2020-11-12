----------------------------------------------------------------------------
--Add a column id_film in film for the promotional movies
----------------------------------------------------------------------------
ALTER TABLE [dbo].[film] ADD id_film int NULL;

ALTER TABLE 
	film
ADD CONSTRAINT 
	fk_id_film_film
FOREIGN KEY 
	(id_film) 
REFERENCES 
	film(id);
	
---------------------------------------------------------------------------
--create the table film_type and fills it
---------------------------------------------------------------------------
CREATE TABLE [dbo].[type_film](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,												
	[typage] [nvarchar] (25) NOT NULL);

INSERT INTO
	type_film (typage)
VALUES
	('Standart'),
	('Promotionnel'),
	('Court Metrage');

---------------------------------------------------------------------------
--add the column id_type to film, fills it and make it not nullable
---------------------------------------------------------------------------
ALTER TABLE [dbo].[film] ADD id_type int NULL;

ALTER TABLE 
	film
ADD CONSTRAINT 
	FK_type_film
FOREIGN KEY (
	id_type) 
REFERENCES 
	type_film(id);

UPDATE 
	dbo.film
SET 
	id_type = 
		(SELECT 
			id 
		FROM 
			type_film 
		WHERE 
			typage = 'standart');
			
ALTER TABLE [dbo].[film] ALTER COLUMN id_type int NOT NULL;

--------------------------------------------------------------------------------
--create the table programmation and fills it using films attach to the seances
--------------------------------------------------------------------------------
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
	dbo.programmation (id_seance, id_film)
SELECT 
	id, 
	film_id
FROM 
	seance;	

--------------------------------------------------------------------------
--drop the constraint and the column for the movie in seance
--------------------------------------------------------------------------
ALTER TABLE dbo.seance DROP CONSTRAINT fk_seances;
ALTER TABLE dbo.seance DROP COLUMN film_id;

