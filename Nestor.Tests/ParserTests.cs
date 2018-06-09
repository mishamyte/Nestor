﻿using Moq;
using Nestor.Contracts;
using NUnit.Framework;
using Serilog;

namespace Nestor.Tests
{
	[TestFixture]
	public class ParserTests
	{
		[Test]
		public void ParserShouldParseValidJsonCorrectly()
		{
			var mock = new Mock<INestProvider>();
			mock.Setup(m => m.GetNestsJsonData())
				.ReturnsAsync(@"{""_jsonp"":true,""localFacilities"":[],""localCamps"":[],""isNest"":true,""localMarkers"":{""25799"":{""id"":""25799"",""pokemon_id"":""170"",""s"":""1"",""t"":""1"",""lt"":""50.43909903"",""ln"":""30.55218458"",""is_nest"":1},""36701"":{""id"":""36701"",""pokemon_id"":""118"",""s"":""1"",""t"":""1"",""lt"":""50.47142427"",""ln"":""30.44921458"",""is_nest"":1},""61521"":{""id"":""61521"",""pokemon_id"":""39"",""s"":""1"",""t"":""1"",""lt"":""50.45893158"",""ln"":""30.60632229"",""is_nest"":1},""74100"":{""id"":""74100"",""pokemon_id"":""54"",""s"":""1"",""t"":""2"",""lt"":""50.44273414"",""ln"":""30.50491333"",""is_nest"":1},""74767"":{""id"":""74767"",""pokemon_id"":""77"",""s"":""1"",""t"":""1"",""lt"":""50.44175022"",""ln"":""30.51315308"",""is_nest"":1},""76075"":{""id"":""76075"",""pokemon_id"":""96"",""s"":""1"",""t"":""1"",""lt"":""50.42860211"",""ln"":""30.48731804"",""is_nest"":1},""83807"":{""id"":""83807"",""pokemon_id"":""19"",""s"":""1"",""t"":""1"",""lt"":""50.45213493"",""ln"":""30.52834511"",""is_nest"":1},""87318"":{""id"":""87318"",""pokemon_id"":""152"",""s"":""1"",""t"":""3"",""lt"":""50.44897877"",""ln"":""30.53568363"",""is_nest"":1},""91979"":{""id"":""91979"",""pokemon_id"":""66"",""s"":""1"",""t"":""1"",""lt"":""50.44519383"",""ln"":""30.54104805"",""is_nest"":1},""92825"":{""id"":""92825"",""pokemon_id"":""74"",""s"":""1"",""t"":""2"",""lt"":""50.44712049"",""ln"":""30.45410156"",""is_nest"":1},""98637"":{""id"":""98637"",""pokemon_id"":""163"",""s"":""1"",""t"":""2"",""lt"":""50.45341919"",""ln"":""30.49555779"",""is_nest"":1},""102101"":{""id"":""102101"",""pokemon_id"":""152"",""s"":""1"",""t"":""1"",""lt"":""50.43559006"",""ln"":""30.42891026"",""is_nest"":1},""104744"":{""id"":""104744"",""pokemon_id"":""215"",""s"":""1"",""t"":""2"",""lt"":""50.45658872"",""ln"":""30.45470238"",""is_nest"":1},""108311"":{""id"":""108311"",""pokemon_id"":""158"",""s"":""1"",""t"":""1"",""lt"":""50.45967608"",""ln"":""30.41084290"",""is_nest"":1},""111179"":{""id"":""111179"",""pokemon_id"":""223"",""s"":""1"",""t"":""1"",""lt"":""50.47432289"",""ln"":""30.47652483"",""is_nest"":1},""116452"":{""id"":""116452"",""pokemon_id"":""63"",""s"":""1"",""t"":""1"",""lt"":""50.45396568"",""ln"":""30.38354874"",""is_nest"":1},""126811"":{""id"":""126811"",""pokemon_id"":""124"",""s"":""1"",""t"":""1"",""lt"":""50.46758479"",""ln"":""30.47298431"",""is_nest"":1},""134660"":{""id"":""134660"",""pokemon_id"":""116"",""s"":""1"",""t"":""1"",""lt"":""50.45101458"",""ln"":""30.46045303"",""is_nest"":1},""142551"":{""id"":""142551"",""pokemon_id"":""21"",""s"":""1"",""t"":""1"",""lt"":""50.44013766"",""ln"":""30.37505150"",""is_nest"":1},""142753"":{""id"":""142753"",""pokemon_id"":""120"",""s"":""1"",""t"":""1"",""lt"":""50.43058601"",""ln"":""30.38103841"",""is_nest"":1},""150289"":{""id"":""150289"",""pokemon_id"":""56"",""s"":""1"",""t"":""3"",""lt"":""50.42774093"",""ln"":""30.46603203"",""is_nest"":1},""157753"":{""id"":""157753"",""pokemon_id"":""96"",""s"":""1"",""t"":""2"",""lt"":""50.43070715"",""ln"":""30.64980090"",""is_nest"":1},""162189"":{""id"":""162189"",""pokemon_id"":""81"",""s"":""1"",""t"":""2"",""lt"":""50.46949689"",""ln"":""30.44217110"",""is_nest"":1},""171342"":{""id"":""171342"",""pokemon_id"":""90"",""s"":""1"",""t"":""1"",""lt"":""50.43376543"",""ln"":""30.42701125"",""is_nest"":1},""178024"":{""id"":""178024"",""pokemon_id"":""183"",""s"":""1"",""t"":""1"",""lt"":""50.44714782"",""ln"":""30.57613134"",""is_nest"":1},""190851"":{""id"":""190851"",""pokemon_id"":""23"",""s"":""1"",""t"":""1"",""lt"":""50.44442860"",""ln"":""30.42667866"",""is_nest"":1},""196129"":{""id"":""196129"",""pokemon_id"":""203"",""s"":""1"",""t"":""1"",""lt"":""50.47770541"",""ln"":""30.45506587"",""is_nest"":1},""196662"":{""id"":""196662"",""pokemon_id"":""100"",""s"":""1"",""t"":""1"",""lt"":""50.45484004"",""ln"":""30.50641537"",""is_nest"":1},""211117"":{""id"":""211117"",""pokemon_id"":""133"",""s"":""1"",""t"":""1"",""lt"":""50.49748662"",""ln"":""30.57276249"",""is_nest"":1},""213196"":{""id"":""213196"",""pokemon_id"":""133"",""s"":""1"",""t"":""2"",""lt"":""50.44837757"",""ln"":""30.45869350"",""is_nest"":1},""220318"":{""id"":""220318"",""pokemon_id"":""1"",""s"":""1"",""t"":""2"",""lt"":""50.42749487"",""ln"":""30.63851416"",""is_nest"":1},""220633"":{""id"":""220633"",""pokemon_id"":""104"",""s"":""1"",""t"":""1"",""lt"":""50.42724882"",""ln"":""30.51440835"",""is_nest"":1},""227590"":{""id"":""227590"",""pokemon_id"":""21"",""s"":""1"",""t"":""1"",""lt"":""50.47500057"",""ln"":""30.42333126"",""is_nest"":1},""235240"":{""id"":""235240"",""pokemon_id"":""13"",""s"":""1"",""t"":""1"",""lt"":""50.47277459"",""ln"":""30.39749622"",""is_nest"":1},""266071"":{""id"":""266071"",""pokemon_id"":""27"",""s"":""1"",""t"":""1"",""lt"":""50.42925482"",""ln"":""30.64564884"",""is_nest"":1},""268941"":{""id"":""268941"",""pokemon_id"":""23"",""s"":""1"",""t"":""1"",""lt"":""50.46889824"",""ln"":""30.48603187"",""is_nest"":1}},""t_level"":0}");

			var parser = new Parser(mock.Object);

			var task = parser.GetNests();
			task.Wait();

			var result = task.Result;
			foreach (var nest in result)
			{
				Log.Information($"Id: {nest.Id}\t Pokemon: {nest.PokemonId}");
			}

			Assert.AreEqual(36, result.Count);
		}
	}
}