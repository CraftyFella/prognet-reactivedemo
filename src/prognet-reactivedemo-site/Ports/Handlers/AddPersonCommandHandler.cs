using Common.Logging;
using paramore.brighter.commandprocessor;
using reactivedemosite.Domain;
using reactivedemosite.Ports.Commands;
using reactivedemosite.Ports.Persistance;

namespace reactivedemosite.Ports.Handlers
{
    public class AddPersonCommandHandler : RequestHandler<AddPersonCommand>
    {
        private readonly IAmAPeopleDatabase _database;

        public AddPersonCommandHandler(IAmAPeopleDatabase database, ILog logger)
            : base(logger)
        {
            _database = database;
        }

        public override AddPersonCommand Handle(AddPersonCommand addCommand)
        {
            Person person = _database.Add(new Person(addCommand.Name));

            addCommand.PersonId = person.Id;

            return addCommand;
        }
    }
}