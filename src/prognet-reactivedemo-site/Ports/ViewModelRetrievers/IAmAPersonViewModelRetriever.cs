using reactivedemosite.Adapters.API.Resources;

namespace reactivedemosite.Ports.ViewModelRetrievers
{
    public interface IAmAPersonViewModelRetriever
    {
        PersonViewModel Get(int id);
    }
}