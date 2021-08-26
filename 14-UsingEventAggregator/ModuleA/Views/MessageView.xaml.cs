using Prism.Events;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using UsingEventAggregator.Core;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class MessageView : UserControl
    {
        private readonly ILogger<MessageView> _logger;

        public MessageView(IEventAggregator eventAggregator, ILogger<MessageView> logger)
        {
            _logger = logger;
            InitializeComponent();
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread);
        }

        private void MessageReceived(string obj)
        {
            _logger.LogInformation("MessageView:" + obj);
        }
    }
}
