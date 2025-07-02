CREATE TABLE IF NOT EXISTS public.usuario
(
    id integer NOT NULL DEFAULT nextval('usuario_id_seq'::regclass),
    login integer NOT NULL,
    senha text COLLATE pg_catalog."default" NOT NULL,
    tipo integer NOT NULL,
    nome text COLLATE pg_catalog."default" NOT NULL DEFAULT ''::text,
    CONSTRAINT usuario_pkey PRIMARY KEY (id),
    CONSTRAINT usuario_login_key UNIQUE (login)
)

CREATE TABLE IF NOT EXISTS public.manifestacao
(
    id integer NOT NULL DEFAULT nextval('manifestacao_id_seq'::regclass),
    usuario_id integer NOT NULL,
    descricao text COLLATE pg_catalog."default" NOT NULL,
    tipo integer NOT NULL,
    situacao integer NOT NULL,
    data date NOT NULL,
    data_solucao date,
    titulo text COLLATE pg_catalog."default" NOT NULL DEFAULT ''::text,
    CONSTRAINT manifestacao_pkey PRIMARY KEY (id),
    CONSTRAINT fk_usuario FOREIGN KEY (usuario_id)
        REFERENCES public.usuario (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)