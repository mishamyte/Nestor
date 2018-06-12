using AutoMapper;
using Nestor.Contracts.Dtos;
using Nestor.Domain.Contracts;

namespace Nestor
{
	internal class NestorProfile : Profile
	{
		public NestorProfile()
		{
			CreateMap<SilphNestDto, Nest>();
		}
	}
}