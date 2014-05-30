using System;
using paramore.brighter.commandprocessor;

namespace reactivedemosite.Ports.Commands
{
    public class AddPersonCommand : ICommand
    {
        public AddPersonCommand(string name)
        {
            Name = name;
        }

        public int PersonId { get; set; }

        public string Name { get; private set; }

        public Guid Id { get; set; }
    }
}