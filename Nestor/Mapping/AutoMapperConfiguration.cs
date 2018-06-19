using AutoMapper;

namespace Nestor
{
	internal class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(cfg => cfg.AddProfile<NestorProfile>());
		}
	}
}