CREATE TABLE "public"."Nests"("Id" int4 NOT NULL DEFAULT 0,"PokemonId" int4 NOT NULL DEFAULT 0,"NestType" int4 NOT NULL DEFAULT 0,"Lat" float8 NOT NULL DEFAULT 0,"Lng" float8 NOT NULL DEFAULT 0,"IsRecommended" boolean NOT NULL DEFAULT FALSE,"LastMigration" int4 NOT NULL DEFAULT 0,CONSTRAINT "PK_public.Nests" PRIMARY KEY ("Id"))
;

CREATE INDEX "Nests_IX_PokemonId" ON "public"."Nests" ("PokemonId")
;

CREATE TABLE "public"."NestsUpdates"("Id" serial4 NOT NULL,"NestId" int4 NOT NULL DEFAULT 0,"PokemonId" int4 NOT NULL DEFAULT 0,"MigrationNumber" int4 NOT NULL DEFAULT 0,"Timestamp" timestamp NOT NULL DEFAULT '0001-01-01 00:00:00',CONSTRAINT "PK_public.NestsUpdates" PRIMARY KEY ("Id"))
;

CREATE INDEX "NestsUpdates_IX_NestId" ON "public"."NestsUpdates" ("NestId")
;

CREATE INDEX "NestsUpdates_IX_PokemonId" ON "public"."NestsUpdates" ("PokemonId")
;

CREATE TABLE "public"."Pokemons"("Id" int4 NOT NULL DEFAULT 0,"Name" text,CONSTRAINT "PK_public.Pokemons" PRIMARY KEY ("Id"))
;

CREATE TABLE "public"."NestsInfo"("Id" int4 NOT NULL DEFAULT 0,"Name" text,"HashtagName" text,CONSTRAINT "PK_public.NestsInfo" PRIMARY KEY ("Id"))
;

ALTER TABLE "public"."Nests" ADD CONSTRAINT "FK_public.Nests_public.Pokemons_PokemonId" FOREIGN KEY ("PokemonId") REFERENCES "public"."Pokemons" ("Id") ON DELETE CASCADE
;

ALTER TABLE "public"."NestsUpdates" ADD CONSTRAINT "FK_public.NestsUpdates_public.Nests_NestId" FOREIGN KEY ("NestId") REFERENCES "public"."Nests" ("Id") ON DELETE CASCADE
;

ALTER TABLE "public"."NestsUpdates" ADD CONSTRAINT "FK_public.NestsUpdates_public.Pokemons_PokemonId" FOREIGN KEY ("PokemonId") REFERENCES "public"."Pokemons" ("Id") ON DELETE CASCADE
;

CREATE TABLE "public"."__MigrationHistory"("MigrationId" varchar(150) NOT NULL DEFAULT '',"ContextKey" varchar(300) NOT NULL DEFAULT '',"Model" bytea NOT NULL DEFAULT '',"ProductVersion" varchar(32) NOT NULL DEFAULT '',CONSTRAINT "PK_public.__MigrationHistory" PRIMARY KEY ("MigrationId","ContextKey"))
;

INSERT INTO "public"."__MigrationHistory"("MigrationId","ContextKey","Model","ProductVersion") VALUES (E'201806142132305_InitialCreate',E'Nestor.Domain.Migrations.Configuration',decode('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', 'base64'),E'6.2.0-61023')
