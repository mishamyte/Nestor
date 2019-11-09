# Nestor [![Build Status](https://travis-ci.org/mishamyte/Nestor.svg?branch=master)](https://travis-ci.org/mishamyte/Nestor)
Nestor is a project for Telegram notifications about Pokemon Go nests changes. It parses data from the [SilphRoad](https://thesilphroad.com/atlas) and notifies you about nests changes in selected area.

To setup it from the box you need to:
1.	Create Telegram bot and receive it's key, get google maps key, install PostgreSQL
2.	Setup Nestor's config
3.	Build solution via `dotnet build`
4. 	Run Nestor.Service

Nestor can be runned as
1.	Console project (default `dotnet run`, could be easily containerized)
2.	Windows-service (Windows environments only)

The example of Telegram channel, which uses Nestor.Service is a [PokemonGoNestsKyiv](https://t.me/PokemonGoNestsKyiv)

## Features
* Scheduling data parsing
* Telegram notifications, using gmaps area image (with google maps link in description)
* Tags-based description, which allows you to search, using migration number, location hashtag or pokemon name criterias
* Filters for pokemons & nests, which would be excluded from notifications
* Possibility to mark best nests as recommended
* Saving information about nests changes

## Logging
You could use all Serilog functionality and power of community-developed sinks just adding corresponding packages and enhancing config
We use Console & File sink on development environments and File & Telegram sinks for production
