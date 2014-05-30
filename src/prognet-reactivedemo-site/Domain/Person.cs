namespace reactivedemosite.Domain
{
    public class Person
    {
        public Person()
        {
        }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Person(string name)
        {
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}