using reactivedemosite.Adapters.API.Resources;
using reactivedemosite.Ports.Persistance;

namespace reactivedemosite.Ports.ViewModelRetrievers
{
    public class PersonViewModelRetriever : IAmAPersonViewModelRetriever
    {
        private readonly IAmAPeopleDatabase database;

        public PersonViewModelRetriever(IAmAPeopleDatabase database)
        {
            this.database = database;
        }

        public PersonViewModel Get(int id)
        {
            var person = database.Get(id);

            if (person == null) return null;

            return new PersonViewModel(person.Id, person.Name);
        }
    }
}