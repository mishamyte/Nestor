using Nestor.Contracts.Dtos;

namespace Nestor.Contracts
{
	public interface INotifier
	{
		void Notify(SilphNestDto nest, bool isUpdate = false);
	}
}