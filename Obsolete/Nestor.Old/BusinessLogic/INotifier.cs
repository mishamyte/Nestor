using Nestor.Model;

namespace Nestor.BusinessLogic
{
	internal interface INotifier
	{
		void Notify(Nest nest, bool isUpdate = false);
	}
}
