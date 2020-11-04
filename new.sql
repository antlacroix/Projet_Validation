ALTER TABLE [dbo].[film] ADD id_type int NOT NULL;
ALTER TABLE [dbo].[film] ADD id_film int NULL;

CREATE TABLE [dbo].[type_film](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,												
	[typage] [nvarchar] (25) NOT NULL);
	
ALTER TABLE 
	film
ADD CONSTRAINT 
	FK_type_film
FOREIGN KEY (
	id_type) 
REFERENCES 
	type_film(id);

ALTER TABLE 
	film
ADD CONSTRAINT 
	fk_id_film_film
FOREIGN KEY 
	(id_film) 
REFERENCES 
	film(id);

CREATE TABLE [dbo].programmation(
	[id] INT IDENTITY(1,1) NOT NULL,												
	id_seance INT NOT NULL,
	[id_film] INT NULL,
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
	
ALTER TABLE dbo.seance DROP CONSTRAINT fk_seances;
ALTER TABLE dbo.seance DROP COLUMN film_id;

UPDATE dbo.film
SET id_type = 2 ;