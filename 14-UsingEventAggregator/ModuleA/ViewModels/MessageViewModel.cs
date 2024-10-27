using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using UsingEventAggregator.Core;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        IEventAggregator _ea;
        private readonly ILogger<MessageViewModel> _logger;

        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea, ILogger<MessageViewModel> logger)
        {
            _ea = ea;
            _logger = logger;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            Task.Run(()=>
            {
                _logger.LogInformation($"SendMessage");
                _ea.GetEvent<MessageSentEvent>().Publish(Message);
            });
        }
    }
}
