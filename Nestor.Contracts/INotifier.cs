using Nestor.Contracts.Dtos;

namespace Nestor.Contracts
{
	public interface INotifier
	{
		void Notify(NestDto nest);
	}
}