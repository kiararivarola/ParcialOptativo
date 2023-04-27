-- public.ciudad definition

-- Drop table

-- DROP TABLE public.ciudad;

CREATE TABLE public.ciudad (
	id serial4 NOT NULL,
	ciudad varchar(60) NULL,
	estado varchar(60) NULL,
	CONSTRAINT ciudad_pk PRIMARY KEY (id)
);
