using reactivedemosite.Domain;

namespace reactivedemosite.Ports.Persistance
{
    public interface IAmAPeopleDatabase
    {
        Person Add(Person person);
        void Reset();
        Person Get(int id);
    }
}