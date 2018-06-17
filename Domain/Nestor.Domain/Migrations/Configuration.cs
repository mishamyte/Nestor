using System.Data.Entity.Migrations;
using Nestor.Domain.Contracts;

namespace Nestor.Domain.Migrations
{

	internal sealed class Configuration : DbMigrationsConfiguration<NestorContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(NestorContext context)
		{
			context.Pokemons.AddOrUpdate(p => p.Id,
				new Pokemon
				{
					Id = 1,
					Name = "Bulbasaur"
				},
				new Pokemon
				{
					Id = 2,
					Name = "Ivysaur"
				},
				new Pokemon
				{
					Id = 3,
					Name = "Venusaur"
				},
				new Pokemon
				{
					Id = 4,
					Name = "Charmander"
				},
				new Pokemon
				{
					Id = 5,
					Name = "Charmeleon"
				},
				new Pokemon
				{
					Id = 6,
					Name = "Charizard"
				},
				new Pokemon
				{
					Id = 7,
					Name = "Squirtle"
				},
				new Pokemon
				{
					Id = 8,
					Name = "Wartortle"
				},
				new Pokemon
				{
					Id = 9,
					Name = "Blastoise"
				},
				new Pokemon
				{
					Id = 10,
					Name = "Caterpie"
				},
				new Pokemon
				{
					Id = 11,
					Name = "Metapod"
				},
				new Pokemon
				{
					Id = 12,
					Name = "Butterfree"
				},
				new Pokemon
				{
					Id = 13,
					Name = "Weedle"
				},
				new Pokemon
				{
					Id = 14,
					Name = "Kakuna"
				},
				new Pokemon
				{
					Id = 15,
					Name = "Beedrill"
				},
				new Pokemon
				{
					Id = 16,
					Name = "Pidgey"
				},
				new Pokemon
				{
					Id = 17,
					Name = "Pidgeotto"
				},
				new Pokemon
				{
					Id = 18,
					Name = "Pidgeot"
				},
				new Pokemon
				{
					Id = 19,
					Name = "Rattata"
				},
				new Pokemon
				{
					Id = 20,
					Name = "Raticate"
				},
				new Pokemon
				{
					Id = 21,
					Name = "Spearow"
				},
				new Pokemon
				{
					Id = 22,
					Name = "Fearow"
				},
				new Pokemon
				{
					Id = 23,
					Name = "Ekans"
				},
				new Pokemon
				{
					Id = 24,
					Name = "Arbok"
				},
				new Pokemon
				{
					Id = 25,
					Name = "Pikachu"
				},
				new Pokemon
				{
					Id = 26,
					Name = "Raichu"
				},
				new Pokemon
				{
					Id = 27,
					Name = "Sandshrew"
				},
				new Pokemon
				{
					Id = 28,
					Name = "Sandslash"
				},
				new Pokemon
				{
					Id = 29,
					Name = "Nidoran♀"
				},
				new Pokemon
				{
					Id = 30,
					Name = "Nidorina"
				},
				new Pokemon
				{
					Id = 31,
					Name = "Nidoqueen"
				},
				new Pokemon
				{
					Id = 32,
					Name = "Nidoran♂"
				},
				new Pokemon
				{
					Id = 33,
					Name = "Nidorino"
				},
				new Pokemon
				{
					Id = 34,
					Name = "Nidoking"
				},
				new Pokemon
				{
					Id = 35,
					Name = "Clefairy"
				},
				new Pokemon
				{
					Id = 36,
					Name = "Clefable"
				},
				new Pokemon
				{
					Id = 37,
					Name = "Vulpix"
				},
				new Pokemon
				{
					Id = 38,
					Name = "Ninetales"
				},
				new Pokemon
				{
					Id = 39,
					Name = "Jigglypuff"
				},
				new Pokemon
				{
					Id = 40,
					Name = "Wigglytuff"
				},
				new Pokemon
				{
					Id = 41,
					Name = "Zubat"
				},
				new Pokemon
				{
					Id = 42,
					Name = "Golbat"
				},
				new Pokemon
				{
					Id = 43,
					Name = "Oddish"
				},
				new Pokemon
				{
					Id = 44,
					Name = "Gloom"
				},
				new Pokemon
				{
					Id = 45,
					Name = "Vileplume"
				},
				new Pokemon
				{
					Id = 46,
					Name = "Paras"
				},
				new Pokemon
				{
					Id = 47,
					Name = "Parasect"
				},
				new Pokemon
				{
					Id = 48,
					Name = "Venonat"
				},
				new Pokemon
				{
					Id = 49,
					Name = "Venomoth"
				},
				new Pokemon
				{
					Id = 50,
					Name = "Diglett"
				},
				new Pokemon
				{
					Id = 51,
					Name = "Dugtrio"
				},
				new Pokemon
				{
					Id = 52,
					Name = "Meowth"
				},
				new Pokemon
				{
					Id = 53,
					Name = "Persian"
				},
				new Pokemon
				{
					Id = 54,
					Name = "Psyduck"
				},
				new Pokemon
				{
					Id = 55,
					Name = "Golduck"
				},
				new Pokemon
				{
					Id = 56,
					Name = "Mankey"
				},
				new Pokemon
				{
					Id = 57,
					Name = "Primeape"
				},
				new Pokemon
				{
					Id = 58,
					Name = "Growlithe"
				},
				new Pokemon
				{
					Id = 59,
					Name = "Arcanine"
				},
				new Pokemon
				{
					Id = 60,
					Name = "Poliwag"
				},
				new Pokemon
				{
					Id = 61,
					Name = "Poliwhirl"
				},
				new Pokemon
				{
					Id = 62,
					Name = "Poliwrath"
				},
				new Pokemon
				{
					Id = 63,
					Name = "Abra"
				},
				new Pokemon
				{
					Id = 64,
					Name = "Kadabra"
				},
				new Pokemon
				{
					Id = 65,
					Name = "Alakazam"
				},
				new Pokemon
				{
					Id = 66,
					Name = "Machop"
				},
				new Pokemon
				{
					Id = 67,
					Name = "Machoke"
				},
				new Pokemon
				{
					Id = 68,
					Name = "Machamp"
				},
				new Pokemon
				{
					Id = 69,
					Name = "Bellsprout"
				},
				new Pokemon
				{
					Id = 70,
					Name = "Weepinbell"
				},
				new Pokemon
				{
					Id = 71,
					Name = "Victreebel"
				},
				new Pokemon
				{
					Id = 72,
					Name = "Tentacool"
				},
				new Pokemon
				{
					Id = 73,
					Name = "Tentacruel"
				},
				new Pokemon
				{
					Id = 74,
					Name = "Geodude"
				},
				new Pokemon
				{
					Id = 75,
					Name = "Graveler"
				},
				new Pokemon
				{
					Id = 76,
					Name = "Golem"
				},
				new Pokemon
				{
					Id = 77,
					Name = "Ponyta"
				},
				new Pokemon
				{
					Id = 78,
					Name = "Rapidash"
				},
				new Pokemon
				{
					Id = 79,
					Name = "Slowpoke"
				},
				new Pokemon
				{
					Id = 80,
					Name = "Slowbro"
				},
				new Pokemon
				{
					Id = 81,
					Name = "Magnemite"
				},
				new Pokemon
				{
					Id = 82,
					Name = "Magneton"
				},
				new Pokemon
				{
					Id = 83,
					Name = "Farfetch’d"
				},
				new Pokemon
				{
					Id = 84,
					Name = "Doduo"
				},
				new Pokemon
				{
					Id = 85,
					Name = "Dodrio"
				},
				new Pokemon
				{
					Id = 86,
					Name = "Seel"
				},
				new Pokemon
				{
					Id = 87,
					Name = "Dewgong"
				},
				new Pokemon
				{
					Id = 88,
					Name = "Grimer"
				},
				new Pokemon
				{
					Id = 89,
					Name = "Muk"
				},
				new Pokemon
				{
					Id = 90,
					Name = "Shellder"
				},
				new Pokemon
				{
					Id = 91,
					Name = "Cloyster"
				},
				new Pokemon
				{
					Id = 92,
					Name = "Gastly"
				},
				new Pokemon
				{
					Id = 93,
					Name = "Haunter"
				},
				new Pokemon
				{
					Id = 94,
					Name = "Gengar"
				},
				new Pokemon
				{
					Id = 95,
					Name = "Onix"
				},
				new Pokemon
				{
					Id = 96,
					Name = "Drowzee"
				},
				new Pokemon
				{
					Id = 97,
					Name = "Hypno"
				},
				new Pokemon
				{
					Id = 98,
					Name = "Krabby"
				},
				new Pokemon
				{
					Id = 99,
					Name = "Kingler"
				},
				new Pokemon
				{
					Id = 100,
					Name = "Voltorb"
				},
				new Pokemon
				{
					Id = 101,
					Name = "Electrode"
				},
				new Pokemon
				{
					Id = 102,
					Name = "Exeggcute"
				},
				new Pokemon
				{
					Id = 103,
					Name = "Exeggutor"
				},
				new Pokemon
				{
					Id = 104,
					Name = "Cubone"
				},
				new Pokemon
				{
					Id = 105,
					Name = "Marowak"
				},
				new Pokemon
				{
					Id = 106,
					Name = "Hitmonlee"
				},
				new Pokemon
				{
					Id = 107,
					Name = "Hitmonchan"
				},
				new Pokemon
				{
					Id = 108,
					Name = "Lickitung"
				},
				new Pokemon
				{
					Id = 109,
					Name = "Koffing"
				},
				new Pokemon
				{
					Id = 110,
					Name = "Weezing"
				},
				new Pokemon
				{
					Id = 111,
					Name = "Rhyhorn"
				},
				new Pokemon
				{
					Id = 112,
					Name = "Rhydon"
				},
				new Pokemon
				{
					Id = 113,
					Name = "Chansey"
				},
				new Pokemon
				{
					Id = 114,
					Name = "Tangela"
				},
				new Pokemon
				{
					Id = 115,
					Name = "Kangaskhan"
				},
				new Pokemon
				{
					Id = 116,
					Name = "Horsea"
				},
				new Pokemon
				{
					Id = 117,
					Name = "Seadra"
				},
				new Pokemon
				{
					Id = 118,
					Name = "Goldeen"
				},
				new Pokemon
				{
					Id = 119,
					Name = "Seaking"
				},
				new Pokemon
				{
					Id = 120,
					Name = "Staryu"
				},
				new Pokemon
				{
					Id = 121,
					Name = "Starmie"
				},
				new Pokemon
				{
					Id = 122,
					Name = "Mr. Mime"
				},
				new Pokemon
				{
					Id = 123,
					Name = "Scyther"
				},
				new Pokemon
				{
					Id = 124,
					Name = "Jynx"
				},
				new Pokemon
				{
					Id = 125,
					Name = "Electabuzz"
				},
				new Pokemon
				{
					Id = 126,
					Name = "Magmar"
				},
				new Pokemon
				{
					Id = 127,
					Name = "Pinsir"
				},
				new Pokemon
				{
					Id = 128,
					Name = "Tauros"
				},
				new Pokemon
				{
					Id = 129,
					Name = "Magikarp"
				},
				new Pokemon
				{
					Id = 130,
					Name = "Gyarados"
				},
				new Pokemon
				{
					Id = 131,
					Name = "Lapras"
				},
				new Pokemon
				{
					Id = 132,
					Name = "Ditto"
				},
				new Pokemon
				{
					Id = 133,
					Name = "Eevee"
				},
				new Pokemon
				{
					Id = 134,
					Name = "Vaporeon"
				},
				new Pokemon
				{
					Id = 135,
					Name = "Jolteon"
				},
				new Pokemon
				{
					Id = 136,
					Name = "Flareon"
				},
				new Pokemon
				{
					Id = 137,
					Name = "Porygon"
				},
				new Pokemon
				{
					Id = 138,
					Name = "Omanyte"
				},
				new Pokemon
				{
					Id = 139,
					Name = "Omastar"
				},
				new Pokemon
				{
					Id = 140,
					Name = "Kabuto"
				},
				new Pokemon
				{
					Id = 141,
					Name = "Kabutops"
				},
				new Pokemon
				{
					Id = 142,
					Name = "Aerodactyl"
				},
				new Pokemon
				{
					Id = 143,
					Name = "Snorlax"
				},
				new Pokemon
				{
					Id = 144,
					Name = "Articuno"
				},
				new Pokemon
				{
					Id = 145,
					Name = "Zapdos"
				},
				new Pokemon
				{
					Id = 146,
					Name = "Moltres"
				},
				new Pokemon
				{
					Id = 147,
					Name = "Dratini"
				},
				new Pokemon
				{
					Id = 148,
					Name = "Dragonair"
				},
				new Pokemon
				{
					Id = 149,
					Name = "Dragonite"
				},
				new Pokemon
				{
					Id = 150,
					Name = "Mewtwo"
				},
				new Pokemon
				{
					Id = 151,
					Name = "Mew"
				},
				new Pokemon
				{
					Id = 152,
					Name = "Chikorita"
				},
				new Pokemon
				{
					Id = 153,
					Name = "Bayleef"
				},
				new Pokemon
				{
					Id = 154,
					Name = "Meganium"
				},
				new Pokemon
				{
					Id = 155,
					Name = "Cyndaquil"
				},
				new Pokemon
				{
					Id = 156,
					Name = "Quilava"
				},
				new Pokemon
				{
					Id = 157,
					Name = "Typhlosion"
				},
				new Pokemon
				{
					Id = 158,
					Name = "Totodile"
				},
				new Pokemon
				{
					Id = 159,
					Name = "Croconaw"
				},
				new Pokemon
				{
					Id = 160,
					Name = "Feraligatr"
				},
				new Pokemon
				{
					Id = 161,
					Name = "Sentret"
				},
				new Pokemon
				{
					Id = 162,
					Name = "Furret"
				},
				new Pokemon
				{
					Id = 163,
					Name = "Hoothoot"
				},
				new Pokemon
				{
					Id = 164,
					Name = "Noctowl"
				},
				new Pokemon
				{
					Id = 165,
					Name = "Ledyba"
				},
				new Pokemon
				{
					Id = 166,
					Name = "Ledian"
				},
				new Pokemon
				{
					Id = 167,
					Name = "Spinarak"
				},
				new Pokemon
				{
					Id = 168,
					Name = "Ariados"
				},
				new Pokemon
				{
					Id = 169,
					Name = "Crobat"
				},
				new Pokemon
				{
					Id = 170,
					Name = "Chinchou"
				},
				new Pokemon
				{
					Id = 171,
					Name = "Lanturn"
				},
				new Pokemon
				{
					Id = 172,
					Name = "Pichu"
				},
				new Pokemon
				{
					Id = 173,
					Name = "Cleffa"
				},
				new Pokemon
				{
					Id = 174,
					Name = "Igglybuff"
				},
				new Pokemon
				{
					Id = 175,
					Name = "Togepi"
				},
				new Pokemon
				{
					Id = 176,
					Name = "Togetic"
				},
				new Pokemon
				{
					Id = 177,
					Name = "Natu"
				},
				new Pokemon
				{
					Id = 178,
					Name = "Xatu"
				},
				new Pokemon
				{
					Id = 179,
					Name = "Mareep"
				},
				new Pokemon
				{
					Id = 180,
					Name = "Flaaffy"
				},
				new Pokemon
				{
					Id = 181,
					Name = "Ampharos"
				},
				new Pokemon
				{
					Id = 182,
					Name = "Bellossom"
				},
				new Pokemon
				{
					Id = 183,
					Name = "Marill"
				},
				new Pokemon
				{
					Id = 184,
					Name = "Azumarill"
				},
				new Pokemon
				{
					Id = 185,
					Name = "Sudowoodo"
				},
				new Pokemon
				{
					Id = 186,
					Name = "Politoed"
				},
				new Pokemon
				{
					Id = 187,
					Name = "Hoppip"
				},
				new Pokemon
				{
					Id = 188,
					Name = "Skiploom"
				},
				new Pokemon
				{
					Id = 189,
					Name = "Jumpluff"
				},
				new Pokemon
				{
					Id = 190,
					Name = "Aipom"
				},
				new Pokemon
				{
					Id = 191,
					Name = "Sunkern"
				},
				new Pokemon
				{
					Id = 192,
					Name = "Sunflora"
				},
				new Pokemon
				{
					Id = 193,
					Name = "Yanma"
				},
				new Pokemon
				{
					Id = 194,
					Name = "Wooper"
				},
				new Pokemon
				{
					Id = 195,
					Name = "Quagsire"
				},
				new Pokemon
				{
					Id = 196,
					Name = "Espeon"
				},
				new Pokemon
				{
					Id = 197,
					Name = "Umbreon"
				},
				new Pokemon
				{
					Id = 198,
					Name = "Murkrow"
				},
				new Pokemon
				{
					Id = 199,
					Name = "Slowking"
				},
				new Pokemon
				{
					Id = 200,
					Name = "Misdreavus"
				},
				new Pokemon
				{
					Id = 201,
					Name = "Unown"
				},
				new Pokemon
				{
					Id = 202,
					Name = "Wobbuffet"
				},
				new Pokemon
				{
					Id = 203,
					Name = "Girafarig"
				},
				new Pokemon
				{
					Id = 204,
					Name = "Pineco"
				},
				new Pokemon
				{
					Id = 205,
					Name = "Forretress"
				},
				new Pokemon
				{
					Id = 206,
					Name = "Dunsparce"
				},
				new Pokemon
				{
					Id = 207,
					Name = "Gligar"
				},
				new Pokemon
				{
					Id = 208,
					Name = "Steelix"
				},
				new Pokemon
				{
					Id = 209,
					Name = "Snubbull"
				},
				new Pokemon
				{
					Id = 210,
					Name = "Granbull"
				},
				new Pokemon
				{
					Id = 211,
					Name = "Qwilfish"
				},
				new Pokemon
				{
					Id = 212,
					Name = "Scizor"
				},
				new Pokemon
				{
					Id = 213,
					Name = "Shuckle"
				},
				new Pokemon
				{
					Id = 214,
					Name = "Heracross"
				},
				new Pokemon
				{
					Id = 215,
					Name = "Sneasel"
				},
				new Pokemon
				{
					Id = 216,
					Name = "Teddiursa"
				},
				new Pokemon
				{
					Id = 217,
					Name = "Ursaring"
				},
				new Pokemon
				{
					Id = 218,
					Name = "Slugma"
				},
				new Pokemon
				{
					Id = 219,
					Name = "Magcargo"
				},
				new Pokemon
				{
					Id = 220,
					Name = "Swinub"
				},
				new Pokemon
				{
					Id = 221,
					Name = "Piloswine"
				},
				new Pokemon
				{
					Id = 222,
					Name = "Corsola"
				},
				new Pokemon
				{
					Id = 223,
					Name = "Remoraid"
				},
				new Pokemon
				{
					Id = 224,
					Name = "Octillery"
				},
				new Pokemon
				{
					Id = 225,
					Name = "Delibird"
				},
				new Pokemon
				{
					Id = 226,
					Name = "Mantine"
				},
				new Pokemon
				{
					Id = 227,
					Name = "Skarmory"
				},
				new Pokemon
				{
					Id = 228,
					Name = "Houndour"
				},
				new Pokemon
				{
					Id = 229,
					Name = "Houndoom"
				},
				new Pokemon
				{
					Id = 230,
					Name = "Kingdra"
				},
				new Pokemon
				{
					Id = 231,
					Name = "Phanpy"
				},
				new Pokemon
				{
					Id = 232,
					Name = "Donphan"
				},
				new Pokemon
				{
					Id = 233,
					Name = "Porygon2"
				},
				new Pokemon
				{
					Id = 234,
					Name = "Stantler"
				},
				new Pokemon
				{
					Id = 235,
					Name = "Smeargle"
				},
				new Pokemon
				{
					Id = 236,
					Name = "Tyrogue"
				},
				new Pokemon
				{
					Id = 237,
					Name = "Hitmontop"
				},
				new Pokemon
				{
					Id = 238,
					Name = "Smoochum"
				},
				new Pokemon
				{
					Id = 239,
					Name = "Elekid"
				},
				new Pokemon
				{
					Id = 240,
					Name = "Magby"
				},
				new Pokemon
				{
					Id = 241,
					Name = "Miltank"
				},
				new Pokemon
				{
					Id = 242,
					Name = "Blissey"
				},
				new Pokemon
				{
					Id = 243,
					Name = "Raikou"
				},
				new Pokemon
				{
					Id = 244,
					Name = "Entei"
				},
				new Pokemon
				{
					Id = 245,
					Name = "Suicune"
				},
				new Pokemon
				{
					Id = 246,
					Name = "Larvitar"
				},
				new Pokemon
				{
					Id = 247,
					Name = "Pupitar"
				},
				new Pokemon
				{
					Id = 248,
					Name = "Tyranitar"
				},
				new Pokemon
				{
					Id = 249,
					Name = "Lugia"
				},
				new Pokemon
				{
					Id = 250,
					Name = "Ho-Oh"
				},
				new Pokemon
				{
					Id = 251,
					Name = "Celebi"
				},
				new Pokemon
				{
					Id = 252,
					Name = "Treecko"
				},
				new Pokemon
				{
					Id = 253,
					Name = "Grovyle"
				},
				new Pokemon
				{
					Id = 254,
					Name = "Sceptile"
				},
				new Pokemon
				{
					Id = 255,
					Name = "Torchic"
				},
				new Pokemon
				{
					Id = 256,
					Name = "Combusken"
				},
				new Pokemon
				{
					Id = 257,
					Name = "Blaziken"
				},
				new Pokemon
				{
					Id = 258,
					Name = "Mudkip"
				},
				new Pokemon
				{
					Id = 259,
					Name = "Marshtomp"
				},
				new Pokemon
				{
					Id = 260,
					Name = "Swampert"
				},
				new Pokemon
				{
					Id = 261,
					Name = "Poochyena"
				},
				new Pokemon
				{
					Id = 262,
					Name = "Mightyena"
				},
				new Pokemon
				{
					Id = 263,
					Name = "Zigzagoon"
				},
				new Pokemon
				{
					Id = 264,
					Name = "Linoone"
				},
				new Pokemon
				{
					Id = 265,
					Name = "Wurmple"
				},
				new Pokemon
				{
					Id = 266,
					Name = "Silcoon"
				},
				new Pokemon
				{
					Id = 267,
					Name = "Beautifly"
				},
				new Pokemon
				{
					Id = 268,
					Name = "Cascoon"
				},
				new Pokemon
				{
					Id = 269,
					Name = "Dustox"
				},
				new Pokemon
				{
					Id = 270,
					Name = "Lotad"
				},
				new Pokemon
				{
					Id = 271,
					Name = "Lombre"
				},
				new Pokemon
				{
					Id = 272,
					Name = "Ludicolo"
				},
				new Pokemon
				{
					Id = 273,
					Name = "Seedot"
				},
				new Pokemon
				{
					Id = 274,
					Name = "Nuzleaf"
				},
				new Pokemon
				{
					Id = 275,
					Name = "Shiftry"
				},
				new Pokemon
				{
					Id = 276,
					Name = "Taillow"
				},
				new Pokemon
				{
					Id = 277,
					Name = "Swellow"
				},
				new Pokemon
				{
					Id = 278,
					Name = "Wingull"
				},
				new Pokemon
				{
					Id = 279,
					Name = "Pelipper"
				},
				new Pokemon
				{
					Id = 280,
					Name = "Ralts"
				},
				new Pokemon
				{
					Id = 281,
					Name = "Kirlia"
				},
				new Pokemon
				{
					Id = 282,
					Name = "Gardevoir"
				},
				new Pokemon
				{
					Id = 283,
					Name = "Surskit"
				},
				new Pokemon
				{
					Id = 284,
					Name = "Masquerain"
				},
				new Pokemon
				{
					Id = 285,
					Name = "Shroomish"
				},
				new Pokemon
				{
					Id = 286,
					Name = "Breloom"
				},
				new Pokemon
				{
					Id = 287,
					Name = "Slakoth"
				},
				new Pokemon
				{
					Id = 288,
					Name = "Vigoroth"
				},
				new Pokemon
				{
					Id = 289,
					Name = "Slaking"
				},
				new Pokemon
				{
					Id = 290,
					Name = "Nincada"
				},
				new Pokemon
				{
					Id = 291,
					Name = "Ninjask"
				},
				new Pokemon
				{
					Id = 292,
					Name = "Shedinja"
				},
				new Pokemon
				{
					Id = 293,
					Name = "Whismur"
				},
				new Pokemon
				{
					Id = 294,
					Name = "Loudred"
				},
				new Pokemon
				{
					Id = 295,
					Name = "Exploud"
				},
				new Pokemon
				{
					Id = 296,
					Name = "Makuhita"
				},
				new Pokemon
				{
					Id = 297,
					Name = "Hariyama"
				},
				new Pokemon
				{
					Id = 298,
					Name = "Azurill"
				},
				new Pokemon
				{
					Id = 299,
					Name = "Nosepass"
				},
				new Pokemon
				{
					Id = 300,
					Name = "Skitty"
				},
				new Pokemon
				{
					Id = 301,
					Name = "Delcatty"
				},
				new Pokemon
				{
					Id = 302,
					Name = "Sableye"
				},
				new Pokemon
				{
					Id = 303,
					Name = "Mawile"
				},
				new Pokemon
				{
					Id = 304,
					Name = "Aron"
				},
				new Pokemon
				{
					Id = 305,
					Name = "Lairon"
				},
				new Pokemon
				{
					Id = 306,
					Name = "Aggron"
				},
				new Pokemon
				{
					Id = 307,
					Name = "Meditite"
				},
				new Pokemon
				{
					Id = 308,
					Name = "Medicham"
				},
				new Pokemon
				{
					Id = 309,
					Name = "Electrike"
				},
				new Pokemon
				{
					Id = 310,
					Name = "Manectric"
				},
				new Pokemon
				{
					Id = 311,
					Name = "Plusle"
				},
				new Pokemon
				{
					Id = 312,
					Name = "Minun"
				},
				new Pokemon
				{
					Id = 313,
					Name = "Volbeat"
				},
				new Pokemon
				{
					Id = 314,
					Name = "Illumise"
				},
				new Pokemon
				{
					Id = 315,
					Name = "Roselia"
				},
				new Pokemon
				{
					Id = 316,
					Name = "Gulpin"
				},
				new Pokemon
				{
					Id = 317,
					Name = "Swalot"
				},
				new Pokemon
				{
					Id = 318,
					Name = "Carvanha"
				},
				new Pokemon
				{
					Id = 319,
					Name = "Sharpedo"
				},
				new Pokemon
				{
					Id = 320,
					Name = "Wailmer"
				},
				new Pokemon
				{
					Id = 321,
					Name = "Wailord"
				},
				new Pokemon
				{
					Id = 322,
					Name = "Numel"
				},
				new Pokemon
				{
					Id = 323,
					Name = "Camerupt"
				},
				new Pokemon
				{
					Id = 324,
					Name = "Torkoal"
				},
				new Pokemon
				{
					Id = 325,
					Name = "Spoink"
				},
				new Pokemon
				{
					Id = 326,
					Name = "Grumpig"
				},
				new Pokemon
				{
					Id = 327,
					Name = "Spinda"
				},
				new Pokemon
				{
					Id = 328,
					Name = "Trapinch"
				},
				new Pokemon
				{
					Id = 329,
					Name = "Vibrava"
				},
				new Pokemon
				{
					Id = 330,
					Name = "Flygon"
				},
				new Pokemon
				{
					Id = 331,
					Name = "Cacnea"
				},
				new Pokemon
				{
					Id = 332,
					Name = "Cacturne"
				},
				new Pokemon
				{
					Id = 333,
					Name = "Swablu"
				},
				new Pokemon
				{
					Id = 334,
					Name = "Altaria"
				},
				new Pokemon
				{
					Id = 335,
					Name = "Zangoose"
				},
				new Pokemon
				{
					Id = 336,
					Name = "Seviper"
				},
				new Pokemon
				{
					Id = 337,
					Name = "Lunatone"
				},
				new Pokemon
				{
					Id = 338,
					Name = "Solrock"
				},
				new Pokemon
				{
					Id = 339,
					Name = "Barboach"
				},
				new Pokemon
				{
					Id = 340,
					Name = "Whiscash"
				},
				new Pokemon
				{
					Id = 341,
					Name = "Corphish"
				},
				new Pokemon
				{
					Id = 342,
					Name = "Crawdaunt"
				},
				new Pokemon
				{
					Id = 343,
					Name = "Baltoy"
				},
				new Pokemon
				{
					Id = 344,
					Name = "Claydol"
				},
				new Pokemon
				{
					Id = 345,
					Name = "Lileep"
				},
				new Pokemon
				{
					Id = 346,
					Name = "Cradily"
				},
				new Pokemon
				{
					Id = 347,
					Name = "Anorith"
				},
				new Pokemon
				{
					Id = 348,
					Name = "Armaldo"
				},
				new Pokemon
				{
					Id = 349,
					Name = "Feebas"
				},
				new Pokemon
				{
					Id = 350,
					Name = "Milotic"
				},
				new Pokemon
				{
					Id = 351,
					Name = "Castform"
				},
				new Pokemon
				{
					Id = 352,
					Name = "Kecleon"
				},
				new Pokemon
				{
					Id = 353,
					Name = "Shuppet"
				},
				new Pokemon
				{
					Id = 354,
					Name = "Banette"
				},
				new Pokemon
				{
					Id = 355,
					Name = "Duskull"
				},
				new Pokemon
				{
					Id = 356,
					Name = "Dusclops"
				},
				new Pokemon
				{
					Id = 357,
					Name = "Tropius"
				},
				new Pokemon
				{
					Id = 358,
					Name = "Chimecho"
				},
				new Pokemon
				{
					Id = 359,
					Name = "Absol"
				},
				new Pokemon
				{
					Id = 360,
					Name = "Wynaut"
				},
				new Pokemon
				{
					Id = 361,
					Name = "Snorunt"
				},
				new Pokemon
				{
					Id = 362,
					Name = "Glalie"
				},
				new Pokemon
				{
					Id = 363,
					Name = "Spheal"
				},
				new Pokemon
				{
					Id = 364,
					Name = "Sealeo"
				},
				new Pokemon
				{
					Id = 365,
					Name = "Walrein"
				},
				new Pokemon
				{
					Id = 366,
					Name = "Clamperl"
				},
				new Pokemon
				{
					Id = 367,
					Name = "Huntail"
				},
				new Pokemon
				{
					Id = 368,
					Name = "Gorebyss"
				},
				new Pokemon
				{
					Id = 369,
					Name = "Relicanth"
				},
				new Pokemon
				{
					Id = 370,
					Name = "Luvdisc"
				},
				new Pokemon
				{
					Id = 371,
					Name = "Bagon"
				},
				new Pokemon
				{
					Id = 372,
					Name = "Shelgon"
				},
				new Pokemon
				{
					Id = 373,
					Name = "Salamence"
				},
				new Pokemon
				{
					Id = 374,
					Name = "Beldum"
				},
				new Pokemon
				{
					Id = 375,
					Name = "Metang"
				},
				new Pokemon
				{
					Id = 376,
					Name = "Metagross"
				},
				new Pokemon
				{
					Id = 377,
					Name = "Regirock"
				},
				new Pokemon
				{
					Id = 378,
					Name = "Regice"
				},
				new Pokemon
				{
					Id = 379,
					Name = "Registeel"
				},
				new Pokemon
				{
					Id = 380,
					Name = "Latias"
				},
				new Pokemon
				{
					Id = 381,
					Name = "Latios"
				},
				new Pokemon
				{
					Id = 382,
					Name = "Kyogre"
				},
				new Pokemon
				{
					Id = 383,
					Name = "Groudon"
				},
				new Pokemon
				{
					Id = 384,
					Name = "Rayquaza"
				},
				new Pokemon
				{
					Id = 385,
					Name = "Jirachi"
				},
				new Pokemon
				{
					Id = 386,
					Name = "Deoxys"
				},
				new Pokemon
				{
					Id = 387,
					Name = "Turtwig"
				},
				new Pokemon
				{
					Id = 388,
					Name = "Grotle"
				},
				new Pokemon
				{
					Id = 389,
					Name = "Torterra"
				},
				new Pokemon
				{
					Id = 390,
					Name = "Chimchar"
				},
				new Pokemon
				{
					Id = 391,
					Name = "Monferno"
				},
				new Pokemon
				{
					Id = 392,
					Name = "Infernape"
				},
				new Pokemon
				{
					Id = 393,
					Name = "Piplup"
				},
				new Pokemon
				{
					Id = 394,
					Name = "Prinplup"
				},
				new Pokemon
				{
					Id = 395,
					Name = "Empoleon"
				},
				new Pokemon
				{
					Id = 396,
					Name = "Starly"
				},
				new Pokemon
				{
					Id = 397,
					Name = "Staravia"
				},
				new Pokemon
				{
					Id = 398,
					Name = "Staraptor"
				},
				new Pokemon
				{
					Id = 399,
					Name = "Bidoof"
				},
				new Pokemon
				{
					Id = 400,
					Name = "Bibarel"
				},
				new Pokemon
				{
					Id = 401,
					Name = "Kricketot"
				},
				new Pokemon
				{
					Id = 402,
					Name = "Kricketune"
				},
				new Pokemon
				{
					Id = 403,
					Name = "Shinx"
				},
				new Pokemon
				{
					Id = 404,
					Name = "Luxio"
				},
				new Pokemon
				{
					Id = 405,
					Name = "Luxray"
				},
				new Pokemon
				{
					Id = 406,
					Name = "Budew"
				},
				new Pokemon
				{
					Id = 407,
					Name = "Roserade"
				},
				new Pokemon
				{
					Id = 408,
					Name = "Cranidos"
				},
				new Pokemon
				{
					Id = 409,
					Name = "Rampardos"
				},
				new Pokemon
				{
					Id = 410,
					Name = "Shieldon"
				},
				new Pokemon
				{
					Id = 411,
					Name = "Bastiodon"
				},
				new Pokemon
				{
					Id = 412,
					Name = "Burmy"
				},
				new Pokemon
				{
					Id = 413,
					Name = "Wormadam"
				},
				new Pokemon
				{
					Id = 414,
					Name = "Mothim"
				},
				new Pokemon
				{
					Id = 415,
					Name = "Combee"
				},
				new Pokemon
				{
					Id = 416,
					Name = "Vespiquen"
				},
				new Pokemon
				{
					Id = 417,
					Name = "Pachirisu"
				},
				new Pokemon
				{
					Id = 418,
					Name = "Buizel"
				},
				new Pokemon
				{
					Id = 419,
					Name = "Floatzel"
				},
				new Pokemon
				{
					Id = 420,
					Name = "Cherubi"
				},
				new Pokemon
				{
					Id = 421,
					Name = "Cherrim"
				},
				new Pokemon
				{
					Id = 422,
					Name = "Shellos"
				},
				new Pokemon
				{
					Id = 423,
					Name = "Gastrodon"
				},
				new Pokemon
				{
					Id = 424,
					Name = "Ambipom"
				},
				new Pokemon
				{
					Id = 425,
					Name = "Drifloon"
				},
				new Pokemon
				{
					Id = 426,
					Name = "Drifblim"
				},
				new Pokemon
				{
					Id = 427,
					Name = "Buneary"
				},
				new Pokemon
				{
					Id = 428,
					Name = "Lopunny"
				},
				new Pokemon
				{
					Id = 429,
					Name = "Mismagius"
				},
				new Pokemon
				{
					Id = 430,
					Name = "Honchkrow"
				},
				new Pokemon
				{
					Id = 431,
					Name = "Glameow"
				},
				new Pokemon
				{
					Id = 432,
					Name = "Purugly"
				},
				new Pokemon
				{
					Id = 433,
					Name = "Chingling"
				},
				new Pokemon
				{
					Id = 434,
					Name = "Stunky"
				},
				new Pokemon
				{
					Id = 435,
					Name = "Skuntank"
				},
				new Pokemon
				{
					Id = 436,
					Name = "Bronzor"
				},
				new Pokemon
				{
					Id = 437,
					Name = "Bronzong"
				},
				new Pokemon
				{
					Id = 438,
					Name = "Bonsly"
				},
				new Pokemon
				{
					Id = 439,
					Name = "Mime Jr."
				},
				new Pokemon
				{
					Id = 440,
					Name = "Happiny"
				},
				new Pokemon
				{
					Id = 441,
					Name = "Chatot"
				},
				new Pokemon
				{
					Id = 442,
					Name = "Spiritomb"
				},
				new Pokemon
				{
					Id = 443,
					Name = "Gible"
				},
				new Pokemon
				{
					Id = 444,
					Name = "Gabite"
				},
				new Pokemon
				{
					Id = 445,
					Name = "Garchomp"
				},
				new Pokemon
				{
					Id = 446,
					Name = "Munchlax"
				},
				new Pokemon
				{
					Id = 447,
					Name = "Riolu"
				},
				new Pokemon
				{
					Id = 448,
					Name = "Lucario"
				},
				new Pokemon
				{
					Id = 449,
					Name = "Hippopotas"
				},
				new Pokemon
				{
					Id = 450,
					Name = "Hippowdon"
				},
				new Pokemon
				{
					Id = 451,
					Name = "Skorupi"
				},
				new Pokemon
				{
					Id = 452,
					Name = "Drapion"
				},
				new Pokemon
				{
					Id = 453,
					Name = "Croagunk"
				},
				new Pokemon
				{
					Id = 454,
					Name = "Toxicroak"
				},
				new Pokemon
				{
					Id = 455,
					Name = "Carnivine"
				},
				new Pokemon
				{
					Id = 456,
					Name = "Finneon"
				},
				new Pokemon
				{
					Id = 457,
					Name = "Lumineon"
				},
				new Pokemon
				{
					Id = 458,
					Name = "Mantyke"
				},
				new Pokemon
				{
					Id = 459,
					Name = "Snover"
				},
				new Pokemon
				{
					Id = 460,
					Name = "Abomasnow"
				},
				new Pokemon
				{
					Id = 461,
					Name = "Weavile"
				},
				new Pokemon
				{
					Id = 462,
					Name = "Magnezone"
				},
				new Pokemon
				{
					Id = 463,
					Name = "Lickilicky"
				},
				new Pokemon
				{
					Id = 464,
					Name = "Rhyperior"
				},
				new Pokemon
				{
					Id = 465,
					Name = "Tangrowth"
				},
				new Pokemon
				{
					Id = 466,
					Name = "Electivire"
				},
				new Pokemon
				{
					Id = 467,
					Name = "Magmortar"
				},
				new Pokemon
				{
					Id = 468,
					Name = "Togekiss"
				},
				new Pokemon
				{
					Id = 469,
					Name = "Yanmega"
				},
				new Pokemon
				{
					Id = 470,
					Name = "Leafeon"
				},
				new Pokemon
				{
					Id = 471,
					Name = "Glaceon"
				},
				new Pokemon
				{
					Id = 472,
					Name = "Gliscor"
				},
				new Pokemon
				{
					Id = 473,
					Name = "Mamoswine"
				},
				new Pokemon
				{
					Id = 474,
					Name = "Porygon-Z"
				},
				new Pokemon
				{
					Id = 475,
					Name = "Gallade"
				},
				new Pokemon
				{
					Id = 476,
					Name = "Probopass"
				},
				new Pokemon
				{
					Id = 477,
					Name = "Dusknoir"
				},
				new Pokemon
				{
					Id = 478,
					Name = "Froslass"
				},
				new Pokemon
				{
					Id = 479,
					Name = "Rotom"
				},
				new Pokemon
				{
					Id = 480,
					Name = "Uxie"
				},
				new Pokemon
				{
					Id = 481,
					Name = "Mesprit"
				},
				new Pokemon
				{
					Id = 482,
					Name = "Azelf"
				},
				new Pokemon
				{
					Id = 483,
					Name = "Dialga"
				},
				new Pokemon
				{
					Id = 484,
					Name = "Palkia"
				},
				new Pokemon
				{
					Id = 485,
					Name = "Heatran"
				},
				new Pokemon
				{
					Id = 486,
					Name = "Regigigas"
				},
				new Pokemon
				{
					Id = 487,
					Name = "Giratina"
				},
				new Pokemon
				{
					Id = 488,
					Name = "Cresselia"
				},
				new Pokemon
				{
					Id = 489,
					Name = "Phione"
				},
				new Pokemon
				{
					Id = 490,
					Name = "Manaphy"
				},
				new Pokemon
				{
					Id = 491,
					Name = "Darkrai"
				},
				new Pokemon
				{
					Id = 492,
					Name = "Shaymin"
				},
				new Pokemon
				{
					Id = 493,
					Name = "Arceus"
				},
				new Pokemon
				{
					Id = 494,
					Name = "Victini"
				},
				new Pokemon
				{
					Id = 495,
					Name = "Snivy"
				},
				new Pokemon
				{
					Id = 496,
					Name = "Servine"
				},
				new Pokemon
				{
					Id = 497,
					Name = "Serperior"
				},
				new Pokemon
				{
					Id = 498,
					Name = "Tepig"
				},
				new Pokemon
				{
					Id = 499,
					Name = "Pignite"
				},
				new Pokemon
				{
					Id = 500,
					Name = "Emboar"
				},
				new Pokemon
				{
					Id = 501,
					Name = "Oshawott"
				},
				new Pokemon
				{
					Id = 502,
					Name = "Dewott"
				},
				new Pokemon
				{
					Id = 503,
					Name = "Samurott"
				},
				new Pokemon
				{
					Id = 504,
					Name = "Patrat"
				},
				new Pokemon
				{
					Id = 505,
					Name = "Watchog"
				},
				new Pokemon
				{
					Id = 506,
					Name = "Lillipup"
				},
				new Pokemon
				{
					Id = 507,
					Name = "Herdier"
				},
				new Pokemon
				{
					Id = 508,
					Name = "Stoutland"
				},
				new Pokemon
				{
					Id = 509,
					Name = "Purrloin"
				},
				new Pokemon
				{
					Id = 510,
					Name = "Liepard"
				},
				new Pokemon
				{
					Id = 511,
					Name = "Pansage"
				},
				new Pokemon
				{
					Id = 512,
					Name = "Simisage"
				},
				new Pokemon
				{
					Id = 513,
					Name = "Pansear"
				},
				new Pokemon
				{
					Id = 514,
					Name = "Simisear"
				},
				new Pokemon
				{
					Id = 515,
					Name = "Panpour"
				},
				new Pokemon
				{
					Id = 516,
					Name = "Simipour"
				},
				new Pokemon
				{
					Id = 517,
					Name = "Munna"
				},
				new Pokemon
				{
					Id = 518,
					Name = "Musharna"
				},
				new Pokemon
				{
					Id = 519,
					Name = "Pidove"
				},
				new Pokemon
				{
					Id = 520,
					Name = "Tranquill"
				},
				new Pokemon
				{
					Id = 521,
					Name = "Unfezant"
				},
				new Pokemon
				{
					Id = 522,
					Name = "Blitzle"
				},
				new Pokemon
				{
					Id = 523,
					Name = "Zebstrika"
				},
				new Pokemon
				{
					Id = 524,
					Name = "Roggenrola"
				},
				new Pokemon
				{
					Id = 525,
					Name = "Boldore"
				},
				new Pokemon
				{
					Id = 526,
					Name = "Gigalith"
				},
				new Pokemon
				{
					Id = 527,
					Name = "Woobat"
				},
				new Pokemon
				{
					Id = 528,
					Name = "Swoobat"
				},
				new Pokemon
				{
					Id = 529,
					Name = "Drilbur"
				},
				new Pokemon
				{
					Id = 530,
					Name = "Excadrill"
				},
				new Pokemon
				{
					Id = 531,
					Name = "Audino"
				},
				new Pokemon
				{
					Id = 532,
					Name = "Timburr"
				},
				new Pokemon
				{
					Id = 533,
					Name = "Gurdurr"
				},
				new Pokemon
				{
					Id = 534,
					Name = "Conkeldurr"
				},
				new Pokemon
				{
					Id = 535,
					Name = "Tympole"
				},
				new Pokemon
				{
					Id = 536,
					Name = "Palpitoad"
				},
				new Pokemon
				{
					Id = 537,
					Name = "Seismitoad"
				},
				new Pokemon
				{
					Id = 538,
					Name = "Throh"
				},
				new Pokemon
				{
					Id = 539,
					Name = "Sawk"
				},
				new Pokemon
				{
					Id = 540,
					Name = "Sewaddle"
				},
				new Pokemon
				{
					Id = 541,
					Name = "Swadloon"
				},
				new Pokemon
				{
					Id = 542,
					Name = "Leavanny"
				},
				new Pokemon
				{
					Id = 543,
					Name = "Venipede"
				},
				new Pokemon
				{
					Id = 544,
					Name = "Whirlipede"
				},
				new Pokemon
				{
					Id = 545,
					Name = "Scolipede"
				},
				new Pokemon
				{
					Id = 546,
					Name = "Cottonee"
				},
				new Pokemon
				{
					Id = 547,
					Name = "Whimsicott"
				},
				new Pokemon
				{
					Id = 548,
					Name = "Petilil"
				},
				new Pokemon
				{
					Id = 549,
					Name = "Lilligant"
				},
				new Pokemon
				{
					Id = 550,
					Name = "Basculin"
				},
				new Pokemon
				{
					Id = 551,
					Name = "Sandile"
				},
				new Pokemon
				{
					Id = 552,
					Name = "Krokorok"
				},
				new Pokemon
				{
					Id = 553,
					Name = "Krookodile"
				},
				new Pokemon
				{
					Id = 554,
					Name = "Darumaka"
				},
				new Pokemon
				{
					Id = 555,
					Name = "Darmanitan"
				},
				new Pokemon
				{
					Id = 556,
					Name = "Maractus"
				},
				new Pokemon
				{
					Id = 557,
					Name = "Dwebble"
				},
				new Pokemon
				{
					Id = 558,
					Name = "Crustle"
				},
				new Pokemon
				{
					Id = 559,
					Name = "Scraggy"
				},
				new Pokemon
				{
					Id = 560,
					Name = "Scrafty"
				},
				new Pokemon
				{
					Id = 561,
					Name = "Sigilyph"
				},
				new Pokemon
				{
					Id = 562,
					Name = "Yamask"
				},
				new Pokemon
				{
					Id = 563,
					Name = "Cofagrigus"
				},
				new Pokemon
				{
					Id = 564,
					Name = "Tirtouga"
				},
				new Pokemon
				{
					Id = 565,
					Name = "Carracosta"
				},
				new Pokemon
				{
					Id = 566,
					Name = "Archen"
				},
				new Pokemon
				{
					Id = 567,
					Name = "Archeops"
				},
				new Pokemon
				{
					Id = 568,
					Name = "Trubbish"
				},
				new Pokemon
				{
					Id = 569,
					Name = "Garbodor"
				},
				new Pokemon
				{
					Id = 570,
					Name = "Zorua"
				},
				new Pokemon
				{
					Id = 571,
					Name = "Zoroark"
				},
				new Pokemon
				{
					Id = 572,
					Name = "Minccino"
				},
				new Pokemon
				{
					Id = 573,
					Name = "Cinccino"
				},
				new Pokemon
				{
					Id = 574,
					Name = "Gothita"
				},
				new Pokemon
				{
					Id = 575,
					Name = "Gothorita"
				},
				new Pokemon
				{
					Id = 576,
					Name = "Gothitelle"
				},
				new Pokemon
				{
					Id = 577,
					Name = "Solosis"
				},
				new Pokemon
				{
					Id = 578,
					Name = "Duosion"
				},
				new Pokemon
				{
					Id = 579,
					Name = "Reuniclus"
				},
				new Pokemon
				{
					Id = 580,
					Name = "Ducklett"
				},
				new Pokemon
				{
					Id = 581,
					Name = "Swanna"
				},
				new Pokemon
				{
					Id = 582,
					Name = "Vanillite"
				},
				new Pokemon
				{
					Id = 583,
					Name = "Vanillish"
				},
				new Pokemon
				{
					Id = 584,
					Name = "Vanilluxe"
				},
				new Pokemon
				{
					Id = 585,
					Name = "Deerling"
				},
				new Pokemon
				{
					Id = 586,
					Name = "Sawsbuck"
				},
				new Pokemon
				{
					Id = 587,
					Name = "Emolga"
				},
				new Pokemon
				{
					Id = 588,
					Name = "Karrablast"
				},
				new Pokemon
				{
					Id = 589,
					Name = "Escavalier"
				},
				new Pokemon
				{
					Id = 590,
					Name = "Foongus"
				},
				new Pokemon
				{
					Id = 591,
					Name = "Amoonguss"
				},
				new Pokemon
				{
					Id = 592,
					Name = "Frillish"
				},
				new Pokemon
				{
					Id = 593,
					Name = "Jellicent"
				},
				new Pokemon
				{
					Id = 594,
					Name = "Alomomola"
				},
				new Pokemon
				{
					Id = 595,
					Name = "Joltik"
				},
				new Pokemon
				{
					Id = 596,
					Name = "Galvantula"
				},
				new Pokemon
				{
					Id = 597,
					Name = "Ferroseed"
				},
				new Pokemon
				{
					Id = 598,
					Name = "Ferrothorn"
				},
				new Pokemon
				{
					Id = 599,
					Name = "Klink"
				},
				new Pokemon
				{
					Id = 600,
					Name = "Klang"
				},
				new Pokemon
				{
					Id = 601,
					Name = "Klinklang"
				},
				new Pokemon
				{
					Id = 602,
					Name = "Tynamo"
				},
				new Pokemon
				{
					Id = 603,
					Name = "Eelektrik"
				},
				new Pokemon
				{
					Id = 604,
					Name = "Eelektross"
				},
				new Pokemon
				{
					Id = 605,
					Name = "Elgyem"
				},
				new Pokemon
				{
					Id = 606,
					Name = "Beheeyem"
				},
				new Pokemon
				{
					Id = 607,
					Name = "Litwick"
				},
				new Pokemon
				{
					Id = 608,
					Name = "Lampent"
				},
				new Pokemon
				{
					Id = 609,
					Name = "Chandelure"
				},
				new Pokemon
				{
					Id = 610,
					Name = "Axew"
				},
				new Pokemon
				{
					Id = 611,
					Name = "Fraxure"
				},
				new Pokemon
				{
					Id = 612,
					Name = "Haxorus"
				},
				new Pokemon
				{
					Id = 613,
					Name = "Cubchoo"
				},
				new Pokemon
				{
					Id = 614,
					Name = "Beartic"
				},
				new Pokemon
				{
					Id = 615,
					Name = "Cryogonal"
				},
				new Pokemon
				{
					Id = 616,
					Name = "Shelmet"
				},
				new Pokemon
				{
					Id = 617,
					Name = "Accelgor"
				},
				new Pokemon
				{
					Id = 618,
					Name = "Stunfisk"
				},
				new Pokemon
				{
					Id = 619,
					Name = "Mienfoo"
				},
				new Pokemon
				{
					Id = 620,
					Name = "Mienshao"
				},
				new Pokemon
				{
					Id = 621,
					Name = "Druddigon"
				},
				new Pokemon
				{
					Id = 622,
					Name = "Golett"
				},
				new Pokemon
				{
					Id = 623,
					Name = "Golurk"
				},
				new Pokemon
				{
					Id = 624,
					Name = "Pawniard"
				},
				new Pokemon
				{
					Id = 625,
					Name = "Bisharp"
				},
				new Pokemon
				{
					Id = 626,
					Name = "Bouffalant"
				},
				new Pokemon
				{
					Id = 627,
					Name = "Rufflet"
				},
				new Pokemon
				{
					Id = 628,
					Name = "Braviary"
				},
				new Pokemon
				{
					Id = 629,
					Name = "Vullaby"
				},
				new Pokemon
				{
					Id = 630,
					Name = "Mandibuzz"
				},
				new Pokemon
				{
					Id = 631,
					Name = "Heatmor"
				},
				new Pokemon
				{
					Id = 632,
					Name = "Durant"
				},
				new Pokemon
				{
					Id = 633,
					Name = "Deino"
				},
				new Pokemon
				{
					Id = 634,
					Name = "Zweilous"
				},
				new Pokemon
				{
					Id = 635,
					Name = "Hydreigon"
				},
				new Pokemon
				{
					Id = 636,
					Name = "Larvesta"
				},
				new Pokemon
				{
					Id = 637,
					Name = "Volcarona"
				},
				new Pokemon
				{
					Id = 638,
					Name = "Cobalion"
				},
				new Pokemon
				{
					Id = 639,
					Name = "Terrakion"
				},
				new Pokemon
				{
					Id = 640,
					Name = "Virizion"
				},
				new Pokemon
				{
					Id = 641,
					Name = "Tornadus"
				},
				new Pokemon
				{
					Id = 642,
					Name = "Thundurus"
				},
				new Pokemon
				{
					Id = 643,
					Name = "Reshiram"
				},
				new Pokemon
				{
					Id = 644,
					Name = "Zekrom "
				},
				new Pokemon
				{
					Id = 645,
					Name = "Landorus"
				},
				new Pokemon
				{
					Id = 646,
					Name = "Kyurem"
				},
				new Pokemon
				{
					Id = 647,
					Name = "Keldeo"
				},
				new Pokemon
				{
					Id = 648,
					Name = "Meloetta"
				},
				new Pokemon
				{
					Id = 649,
					Name = "Genesect"
				},
				new Pokemon
				{
					Id = 650,
					Name = "Chespin"
				},
				new Pokemon
				{
					Id = 651,
					Name = "Quilladin"
				},
				new Pokemon
				{
					Id = 652,
					Name = "Chesnaught"
				},
				new Pokemon
				{
					Id = 653,
					Name = "Fennekin"
				},
				new Pokemon
				{
					Id = 654,
					Name = "Braixen"
				},
				new Pokemon
				{
					Id = 655,
					Name = "Delphox"
				},
				new Pokemon
				{
					Id = 656,
					Name = "Froakie"
				},
				new Pokemon
				{
					Id = 657,
					Name = "Frogadier"
				},
				new Pokemon
				{
					Id = 658,
					Name = "Greninja"
				},
				new Pokemon
				{
					Id = 659,
					Name = "Bunnelby"
				},
				new Pokemon
				{
					Id = 660,
					Name = "Diggersby"
				},
				new Pokemon
				{
					Id = 661,
					Name = "Fletchling"
				},
				new Pokemon
				{
					Id = 662,
					Name = "Fletchinder"
				},
				new Pokemon
				{
					Id = 663,
					Name = "Talonflame"
				},
				new Pokemon
				{
					Id = 664,
					Name = "Scatterbug"
				},
				new Pokemon
				{
					Id = 665,
					Name = "Spewpa"
				},
				new Pokemon
				{
					Id = 666,
					Name = "Vivillon"
				},
				new Pokemon
				{
					Id = 667,
					Name = "Litleo"
				},
				new Pokemon
				{
					Id = 668,
					Name = "Pyroar"
				},
				new Pokemon
				{
					Id = 669,
					Name = "Flabebe"
				},
				new Pokemon
				{
					Id = 670,
					Name = "Floette"
				},
				new Pokemon
				{
					Id = 671,
					Name = "Florges"
				},
				new Pokemon
				{
					Id = 672,
					Name = "Skiddo"
				},
				new Pokemon
				{
					Id = 673,
					Name = "Gogoat"
				},
				new Pokemon
				{
					Id = 674,
					Name = "Pancham"
				},
				new Pokemon
				{
					Id = 675,
					Name = "Pangoro"
				},
				new Pokemon
				{
					Id = 676,
					Name = "Furfrou"
				},
				new Pokemon
				{
					Id = 677,
					Name = "Espurr"
				},
				new Pokemon
				{
					Id = 678,
					Name = "Meowstic"
				},
				new Pokemon
				{
					Id = 679,
					Name = "Honedge"
				},
				new Pokemon
				{
					Id = 680,
					Name = "Doublade"
				},
				new Pokemon
				{
					Id = 681,
					Name = "Aegislash"
				},
				new Pokemon
				{
					Id = 682,
					Name = "Spritzee"
				},
				new Pokemon
				{
					Id = 683,
					Name = "Aromatisse"
				},
				new Pokemon
				{
					Id = 684,
					Name = "Swirlix"
				},
				new Pokemon
				{
					Id = 685,
					Name = "Slurpuff"
				},
				new Pokemon
				{
					Id = 686,
					Name = "Inkay"
				},
				new Pokemon
				{
					Id = 687,
					Name = "Malamar"
				},
				new Pokemon
				{
					Id = 688,
					Name = "Binacle"
				},
				new Pokemon
				{
					Id = 689,
					Name = "Barbaracle"
				},
				new Pokemon
				{
					Id = 690,
					Name = "Skrelp"
				},
				new Pokemon
				{
					Id = 691,
					Name = "Dragalge"
				},
				new Pokemon
				{
					Id = 692,
					Name = "Clauncher"
				},
				new Pokemon
				{
					Id = 693,
					Name = "Clawitzer"
				},
				new Pokemon
				{
					Id = 694,
					Name = "Helioptile"
				},
				new Pokemon
				{
					Id = 695,
					Name = "Heliolisk"
				},
				new Pokemon
				{
					Id = 696,
					Name = "Tyrunt"
				},
				new Pokemon
				{
					Id = 697,
					Name = "Tyrantrum"
				},
				new Pokemon
				{
					Id = 698,
					Name = "Amaura"
				},
				new Pokemon
				{
					Id = 699,
					Name = "Aurorus"
				},
				new Pokemon
				{
					Id = 700,
					Name = "Sylveon"
				},
				new Pokemon
				{
					Id = 701,
					Name = "Hawlucha"
				},
				new Pokemon
				{
					Id = 702,
					Name = "Dedenne"
				},
				new Pokemon
				{
					Id = 703,
					Name = "Carbink"
				},
				new Pokemon
				{
					Id = 704,
					Name = "Goomy"
				},
				new Pokemon
				{
					Id = 705,
					Name = "Sliggoo"
				},
				new Pokemon
				{
					Id = 706,
					Name = "Goodra"
				},
				new Pokemon
				{
					Id = 707,
					Name = "Klefki"
				},
				new Pokemon
				{
					Id = 708,
					Name = "Phantump"
				},
				new Pokemon
				{
					Id = 709,
					Name = "Trevenant"
				},
				new Pokemon
				{
					Id = 710,
					Name = "Pumpkaboo"
				},
				new Pokemon
				{
					Id = 711,
					Name = "Gourgeist"
				},
				new Pokemon
				{
					Id = 712,
					Name = "Bergmite"
				},
				new Pokemon
				{
					Id = 713,
					Name = "Avalugg"
				},
				new Pokemon
				{
					Id = 714,
					Name = "Noibat"
				},
				new Pokemon
				{
					Id = 715,
					Name = "Noivern"
				},
				new Pokemon
				{
					Id = 716,
					Name = "Xerneas"
				},
				new Pokemon
				{
					Id = 717,
					Name = "Yveltal"
				},
				new Pokemon
				{
					Id = 718,
					Name = "Zygarde"
				},
				new Pokemon
				{
					Id = 719,
					Name = "Diancie"
				},
				new Pokemon
				{
					Id = 720,
					Name = "Hoopa"
				},
				new Pokemon
				{
					Id = 721,
					Name = "Volcanion"
				},
				new Pokemon
				{
					Id = 722,
					Name = "Rowlet"
				},
				new Pokemon
				{
					Id = 723,
					Name = "Dartrix"
				},
				new Pokemon
				{
					Id = 724,
					Name = "Decidueye"
				},
				new Pokemon
				{
					Id = 725,
					Name = "Litten"
				},
				new Pokemon
				{
					Id = 726,
					Name = "Torracat"
				},
				new Pokemon
				{
					Id = 727,
					Name = "Incineroar"
				},
				new Pokemon
				{
					Id = 728,
					Name = "Popplio"
				},
				new Pokemon
				{
					Id = 729,
					Name = "Brionne"
				},
				new Pokemon
				{
					Id = 730,
					Name = "Primarina"
				},
				new Pokemon
				{
					Id = 731,
					Name = "Pikipek"
				},
				new Pokemon
				{
					Id = 732,
					Name = "Trumbeak"
				},
				new Pokemon
				{
					Id = 733,
					Name = "Toucannon"
				},
				new Pokemon
				{
					Id = 734,
					Name = "Yungoos"
				},
				new Pokemon
				{
					Id = 735,
					Name = "Gumshoos"
				},
				new Pokemon
				{
					Id = 736,
					Name = "Grubbin"
				},
				new Pokemon
				{
					Id = 737,
					Name = "Charjabug"
				},
				new Pokemon
				{
					Id = 738,
					Name = "Vikavolt"
				},
				new Pokemon
				{
					Id = 739,
					Name = "Crabrawler"
				},
				new Pokemon
				{
					Id = 740,
					Name = "Crabominable"
				},
				new Pokemon
				{
					Id = 741,
					Name = "Oricorio"
				},
				new Pokemon
				{
					Id = 742,
					Name = "Cutiefly"
				},
				new Pokemon
				{
					Id = 743,
					Name = "Ribombee"
				},
				new Pokemon
				{
					Id = 744,
					Name = "Rockruff"
				},
				new Pokemon
				{
					Id = 745,
					Name = "Lycanroc"
				},
				new Pokemon
				{
					Id = 746,
					Name = "Wishiwashi"
				},
				new Pokemon
				{
					Id = 747,
					Name = "Mareanie"
				},
				new Pokemon
				{
					Id = 748,
					Name = "Toxapex"
				},
				new Pokemon
				{
					Id = 749,
					Name = "Mudbray"
				},
				new Pokemon
				{
					Id = 750,
					Name = "Mudsdale"
				},
				new Pokemon
				{
					Id = 751,
					Name = "Dewpider"
				},
				new Pokemon
				{
					Id = 752,
					Name = "Araquanid"
				},
				new Pokemon
				{
					Id = 753,
					Name = "Fomantis"
				},
				new Pokemon
				{
					Id = 754,
					Name = "Lurantis"
				},
				new Pokemon
				{
					Id = 755,
					Name = "Morelull"
				},
				new Pokemon
				{
					Id = 756,
					Name = "Shiinotic"
				},
				new Pokemon
				{
					Id = 757,
					Name = "Salandit"
				},
				new Pokemon
				{
					Id = 758,
					Name = "Salazzle"
				},
				new Pokemon
				{
					Id = 759,
					Name = "Stufful"
				},
				new Pokemon
				{
					Id = 760,
					Name = "Bewear"
				},
				new Pokemon
				{
					Id = 761,
					Name = "Bounsweet"
				},
				new Pokemon
				{
					Id = 762,
					Name = "Steenee"
				},
				new Pokemon
				{
					Id = 763,
					Name = "Tsareena"
				},
				new Pokemon
				{
					Id = 764,
					Name = "Comfey"
				},
				new Pokemon
				{
					Id = 765,
					Name = "Oranguru"
				},
				new Pokemon
				{
					Id = 766,
					Name = "Passimian"
				},
				new Pokemon
				{
					Id = 767,
					Name = "Wimpod"
				},
				new Pokemon
				{
					Id = 768,
					Name = "Golisopod"
				},
				new Pokemon
				{
					Id = 769,
					Name = "Sandygast"
				},
				new Pokemon
				{
					Id = 770,
					Name = "Palossand"
				},
				new Pokemon
				{
					Id = 771,
					Name = "Pyukumuku"
				},
				new Pokemon
				{
					Id = 772,
					Name = "Type: Null"
				},
				new Pokemon
				{
					Id = 773,
					Name = "Silvally"
				},
				new Pokemon
				{
					Id = 774,
					Name = "Minior"
				},
				new Pokemon
				{
					Id = 775,
					Name = "Komala"
				},
				new Pokemon
				{
					Id = 776,
					Name = "Turtonator"
				},
				new Pokemon
				{
					Id = 777,
					Name = "Togedemaru"
				},
				new Pokemon
				{
					Id = 778,
					Name = "Mimikyu"
				},
				new Pokemon
				{
					Id = 779,
					Name = "Bruxish"
				},
				new Pokemon
				{
					Id = 780,
					Name = "Drampa"
				},
				new Pokemon
				{
					Id = 781,
					Name = "Dhelmise"
				},
				new Pokemon
				{
					Id = 782,
					Name = "Jangmo-o"
				},
				new Pokemon
				{
					Id = 783,
					Name = "Hakamo-o"
				},
				new Pokemon
				{
					Id = 784,
					Name = "Kommo-o"
				},
				new Pokemon
				{
					Id = 785,
					Name = "Tapu Koko"
				},
				new Pokemon
				{
					Id = 786,
					Name = "Tapu Lele"
				},
				new Pokemon
				{
					Id = 787,
					Name = "Tapu Bulu"
				},
				new Pokemon
				{
					Id = 788,
					Name = "Tapu Fini"
				},
				new Pokemon
				{
					Id = 789,
					Name = "Cosmog"
				},
				new Pokemon
				{
					Id = 790,
					Name = "Cosmoem"
				},
				new Pokemon
				{
					Id = 791,
					Name = "Solgaleo"
				},
				new Pokemon
				{
					Id = 792,
					Name = "Lunala"
				},
				new Pokemon
				{
					Id = 793,
					Name = "Nihilego"
				},
				new Pokemon
				{
					Id = 794,
					Name = "Buzzwole"
				},
				new Pokemon
				{
					Id = 795,
					Name = "Pheromosa"
				},
				new Pokemon
				{
					Id = 796,
					Name = "Xurkitree"
				},
				new Pokemon
				{
					Id = 797,
					Name = "Celesteela"
				},
				new Pokemon
				{
					Id = 798,
					Name = "Kartana"
				},
				new Pokemon
				{
					Id = 799,
					Name = "Guzzlord"
				},
				new Pokemon
				{
					Id = 800,
					Name = "Necrozma"
				},
				new Pokemon
				{
					Id = 801,
					Name = "Magearna"
				},
				new Pokemon
				{
					Id = 802,
					Name = "Marshadow"
				});
		}
	}
}