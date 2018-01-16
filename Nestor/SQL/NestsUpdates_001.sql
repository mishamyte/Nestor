-- ----------------------------
-- Table structure for NestsUpdates
-- ----------------------------
DROP TABLE IF EXISTS "public"."NestsUpdates";
CREATE TABLE "public"."NestsUpdates" (
"Id" int4 DEFAULT nextval('"NestsUpdates_Id_seq"'::regclass) NOT NULL,
"NestId" int4 NOT NULL,
"PokemonId" int4 NOT NULL,
"MigrationNumber" int4 NOT NULL,
"Timestamp" timestamp(6) NOT NULL
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table NestsUpdates
-- ----------------------------
ALTER TABLE "public"."NestsUpdates" ADD PRIMARY KEY ("Id");

-- ----------------------------
-- Foreign Key structure for table "public"."NestsUpdates"
-- ----------------------------
ALTER TABLE "public"."NestsUpdates" ADD FOREIGN KEY ("PokemonId") REFERENCES "public"."Pokemons" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."NestsUpdates" ADD FOREIGN KEY ("NestId") REFERENCES "public"."Nests" ("Id") ON DELETE NO ACTION ON UPDATE NO ACTION;
