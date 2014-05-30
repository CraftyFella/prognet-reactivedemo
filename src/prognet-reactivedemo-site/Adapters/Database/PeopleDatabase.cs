using System.Web;
using reactivedemosite.Domain;
using reactivedemosite.Ports.Persistance;

namespace reactivedemosite.Adapters.Database
{
    public class PeopleDatabase : IAmAPeopleDatabase
    {
        private readonly dynamic _database;

        public PeopleDatabase()
        {
            string path = HttpContext.Current.Server.MapPath("~\\App_Data\\howmuchyouspend.sdf");
            _database = Simple.Data.Database.Opener.OpenFile(path);
        }

        public Person Add(Person person)
        {
            return _database.People.Insert(person);
        }

        public void Reset()
        {
            _database.People.DeleteAll();
        }


        public Person Get(int id)
        {
            return _database.People.FindById(id);
        }
    }
}