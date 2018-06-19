CREATE 
	OR REPLACE VIEW "vNestsWithoutInfo" AS SELECT
	"Nests"."Id",
	concat_ws( ',' :: text, "Nests"."Lat", "Nests"."Lng" ) AS "Coords" 
FROM
	"Nests" 
WHERE
	( NOT ( "Nests"."Id" IN ( SELECT "NestsInfo"."Id" FROM "NestsInfo" ) ) );