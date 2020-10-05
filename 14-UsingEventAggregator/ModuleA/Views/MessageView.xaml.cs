using Prism.Events;
using System;
using System.Diagnostics;
using System.Windows.Controls;
using UsingEventAggregator.Core;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class MessageView : UserControl
    {
        public MessageView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(MessageReceived);
        }

        private void MessageReceived(string obj)
        {
            Trace.WriteLine("MessageView:" + obj);
        }
    }
}
