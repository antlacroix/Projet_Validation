UPDATE 	
	[dbo].[film]
SET	
	id_type =
		(SELECT	
			id
		FROM
			type_film
		WHERE
			typage = 'standart');
			
ALTER TABLE
	film
ALTER COLUMN
	id_type INT NOT NULL;

ALTER TABLE 
	film
ADD CONSTRAINT 
	FK_type_film
FOREIGN KEY (
	id_type) 
REFERENCES 
	type_film(id);
	
