# Nestor [![Build Status](https://travis-ci.org/mishamyte/Nestor.svg?branch=master)](https://travis-ci.org/mishamyte/Nestor)
Nestor is a library for Telegram notifications about Pokemon Go nests changes. It parses data from the [SilphRoad](https://thesilphroad.com/atlas) and notifies you about nests changes in selected area.

To use it you need to:
1.	Apply all database migrations, using default EF migration tool, or execute all SQL scripts from DatabaseScripts folder and use EF provider for your database
2.	Implement the ISettings interface
3.	Configurate Serilog in config files
4.	Create the Nestor instance and go ahead.
```C#
var settings = new SomeISettingsImpl();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Config"))
	.AddJsonFile("logger.json")
	.Build();

var logger = new LoggerConfiguration()
	.ReadFrom.Configuration(configuration)
	.CreateLogger();
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
So if you don't need specific integrations and etc, you just can deploy, configure the Nestor.Service service and use it. 

The example of Telegram channel, which uses Nestor.Service is a [PokemonGoNestsKyiv](https://t.me/PokemonGoNestsKyiv)