using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using UsingEventAggregator.Core;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        IEventAggregator _ea;
        private readonly ILogger<MessageListViewModel> _logger;

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator ea, ILogger<MessageListViewModel> logger)
        {
            _ea = ea;
            _logger = logger;
            Messages = new ObservableCollection<string>();

            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.UIThread);
        }

        private void MessageReceived(string message)
        {
            _logger.LogInformation($"MessageReceived {message}");
            Messages.Add(message);
        }
    }
}
