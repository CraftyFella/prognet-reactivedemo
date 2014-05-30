using OpenRasta.Web;
using paramore.brighter.commandprocessor;
using reactivedemosite.Adapters.API.Resources;
using reactivedemosite.Ports.Commands;
using reactivedemosite.Ports.ViewModelRetrievers;

namespace reactivedemosite.Adapters.API.Handlers
{
    public class PeopleEndPointHandler
    {
        private readonly IAmAPersonViewModelRetriever _viewModelRetriever;
        private readonly IAmACommandProcessor _commandProcessor;

        public PeopleEndPointHandler(IAmACommandProcessor commandProcessor,
            IAmAPersonViewModelRetriever viewModelRetriever)
        {
            _commandProcessor = commandProcessor;
            _viewModelRetriever = viewModelRetriever;
        }

        public OperationResult Get(int id)
        {
            PersonViewModel viewModel = _viewModelRetriever.Get(id);

            if (viewModel == null)
                return new OperationResult.NotFound();

            return new OperationResult.OK
            {
                ResponseResource = viewModel
            };
        }

        public OperationResult Post(PersonViewModel inputModel)
        {
            var command = new AddPersonCommand(inputModel.Name);
            _commandProcessor.Send(command);

            var outputModel =
                _viewModelRetriever.Get(command.PersonId);

            return new OperationResult.Created
            {
                ResponseResource = outputModel,
                CreatedResourceUrl = outputModel.CreateUri()
            };
        }
    }
}