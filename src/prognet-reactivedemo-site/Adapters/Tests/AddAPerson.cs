using Machine.Specifications;
using reactivedemosite.Adapters.Database;
using reactivedemosite.Ports.Commands;
using reactivedemosite.Ports.Handlers;

namespace reactivedemosite.Adapters.Tests
{
    [Subject("Person")]
    public class AddAPerson
    {
        public class When_I_add_person
        {
            private static AddPersonCommandHandler _handler;
            private static AddPersonCommand _returnedCommand;
            private static AddPersonCommand _incomingCommand;
            private static TestPeopleDatabase _database;

            private Establish context = () =>
            {
                _database = new TestPeopleDatabase();

                _incomingCommand = new AddPersonCommand("eating out");

                _handler = new AddPersonCommandHandler(_database, null);
            };

            private Because of =
                () => { _returnedCommand = _handler.Handle(_incomingCommand); };

            private It should_have_the_person_in_the_database =
                () =>
                {
                    _database.Get(_incomingCommand.PersonId)
                        .Name.ShouldEqual(_returnedCommand.Name);
                };
        }
    }
}