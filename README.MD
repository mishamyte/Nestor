# Nestor
Nestor is a library for Telegram notifications of Pokemon Go nests changes. It parses data from the [SilphRoad](thesilphroad.com/atlas) and notifies you about nests changes in selected area.

To use it you need to:
1.	Apply all database scripts (from Nestor/SQL folder) and use EF provider for your database
2.	Implement the ILogger and ISettings interfaces
3.	Create the Nestor instance and go ahead.
```C#
var settings = SomeISettingsImpl();
var logger = SomeILoggerImpl();
var nestor = new Nestor(settings, logger);
```
More detailed example you can see in Nestor.Service project

## Features
* Scheduling data parsing
* Telegram notifications in two formats: image (with google maps link in description) & location (uses Telegram location sharing functionality)
* Tags-based description, which allows you to search, using migration number, location hashtag or pokemon name criterias
* Filters for pokemons & nests, which would be excluded from notifications
* Possibility to mark best nests as recommended
* Saving information about nests changes

## Nestor.Service
Nestor.Service is a client application, which could be runned in two modes: as console and as windows-service. It uses the PostgreSQL db for work and shows Nestor's main functionality.

The example of Telegram channel, which uses Nestor.Service is a [PokemonGoNestsKyiv](https://t.me/PokemonGoNestsKyiv)