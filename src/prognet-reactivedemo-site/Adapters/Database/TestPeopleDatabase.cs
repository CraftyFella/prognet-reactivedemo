using System.Collections.Generic;
using reactivedemosite.Domain;
using reactivedemosite.Ports.Persistance;

namespace reactivedemosite.Adapters.Database
{
    public class TestPeopleDatabase : IAmAPeopleDatabase
    {
        private readonly Dictionary<int, Person> db = new Dictionary<int, Person>();

        public Person Add(Person person)
        {
            var id = db.Count + 1;
            db.Add(id, person);
            return new Person(id,person.Name);
        }

        public void Reset()
        {
            db.Clear();
        }

        public Person Get(int id)
        {
            return db.ContainsKey(id) ? db[id] : null;
        }
    }
}