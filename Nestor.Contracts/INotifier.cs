using Nestor.Domain.Contracts;

namespace Nestor.Contracts
{
	public interface INotifier
	{
		void Notify(Nest nest, bool isUpdate = false);
	}
}