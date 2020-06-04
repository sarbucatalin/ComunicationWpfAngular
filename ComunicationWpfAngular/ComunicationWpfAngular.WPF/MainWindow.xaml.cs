using ComunicationWpfAngular.Contracts;
using EasyNetQ;
using System.Windows;

namespace ComunicationWpfAngular.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBus bus;
        public MainWindow()
        {
            bus = RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=guest;password=guest",
                serviceRegister => serviceRegister.Register<ISerializer>(serviceProvider => new MyJsonSerializer())
                );
            
            InitializeComponent();

        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var response = bus.Receive<MessageContract>("ApiToWpf", message => Listen(message));
        }

        private void Listen(MessageContract message)
        {
            Dispatcher.Invoke(() =>
            {
                // Set property or change UI compomponents. 
                ChatBox.Text += "\r\n" + message.Value;
            });
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            bus.Send<MessageContract>("WpfToApi",new MessageContract { Value = MessageBox.Text });
        }
    }
}
