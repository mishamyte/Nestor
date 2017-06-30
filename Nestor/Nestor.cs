using Nestor.Interfaces;

namespace Nestor
{
    public class Nestor
    {
	    private readonly ISettings _settings;

	    public Nestor(ISettings settings)
	    {
		    _settings = settings;
	    }
    }
}
