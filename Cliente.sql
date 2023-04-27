-- public.cliente definition

-- Drop table

-- DROP TABLE public.cliente;

CREATE TABLE public.cliente (
	id int4 NOT NULL DEFAULT nextval('persona_id_seq'::regclass),
	nombre varchar(60) NULL,
	apellido varchar(60) NULL,
	email varchar(60) NULL,
	telefono varchar(60) NULL,
	documentonum varchar(60) NULL,
	nacionalidad varchar(60) NULL,
	fechanacimiento varchar(60) NULL,
	ciudad varchar(60) NULL,
	idciudad int8 NULL,
	CONSTRAINT persona_pk PRIMARY KEY (id)
);


-- public.cliente foreign keys

ALTER TABLE public.cliente ADD CONSTRAINT cliente_fk FOREIGN KEY (id) REFERENCES public.ciudad(id);
