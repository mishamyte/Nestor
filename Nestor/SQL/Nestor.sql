-- ----------------------------
-- Table structure for Nests
-- ----------------------------
DROP TABLE IF EXISTS "public"."Nests";
CREATE TABLE "public"."Nests" (
"Id" int4 NOT NULL,
"PokemonId" int4 NOT NULL,
"Lat" float8 NOT NULL,
"Lng" float8 NOT NULL,
"LastMigration" int4 NOT NULL,
"NestType" int4 DEFAULT 1 NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for NestsInfo
-- ----------------------------
DROP TABLE IF EXISTS "public"."NestsInfo";
CREATE TABLE "public"."NestsInfo" (
"Id" int4 NOT NULL,
"Name" varchar(255) COLLATE "default" NOT NULL,
"HashtagName" varchar(255) COLLATE "default"
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Table structure for Pokemons
-- ----------------------------
DROP TABLE IF EXISTS "public"."Pokemons";
CREATE TABLE "public"."Pokemons" (
"Id" int4 NOT NULL,
"Name" varchar(255) COLLATE "default" NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- View structure for NestsWithoutInfo
-- ----------------------------
CREATE OR REPLACE VIEW "public"."NestsWithoutInfo" AS 
 SELECT "Nests"."Id",
    concat_ws(','::text, "Nests"."Lat", "Nests"."Lng") AS "Coords"
   FROM "Nests"
  WHERE (NOT ("Nests"."Id" IN ( SELECT "NestsInfo"."Id"
           FROM "NestsInfo")));

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table NestsInfo
-- ----------------------------
ALTER TABLE "public"."NestsInfo" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Pokemons
-- ----------------------------
ALTER TABLE "public"."Pokemons" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Foreign Key structure for table "public"."Nests"
-- ----------------------------
ALTER TABLE "public"."Nests" ADD FOREIGN KEY ("PokemonId") REFERENCES "public"."Pokemons" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
