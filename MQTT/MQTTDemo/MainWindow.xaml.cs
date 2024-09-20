using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MQTTDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMqttClient mqttClient;

        public MainWindow()
        {
            InitializeComponent();
            InitMqtt();
        }

        /// <summary>
        /// Mqtt 客户端的初始化
        /// </summary>
        private async void InitMqtt()
        {
            try
            {
                var mqttFactory = new MqttFactory();
                mqttClient = mqttFactory.CreateMqttClient();
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("127.0.0.1", 1883)
                    .WithClientId("Client567")
                    .WithCleanSession(false)
                    .Build();
                var connectResult = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                MessageBox.Show($"Client567{connectResult}");
            }
            catch (Exception e)
            {
                MessageBox.Show($"Client567{e.Message}");
            }
        }

        /// <summary>
        /// 消息发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string topic = TbTopic.Text;
            string payload = $"{TbMessage.Text}-{DateTime.Now}";
            var messageApplication = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.ExactlyOnce)
                .WithRetainFlag(false)
                .Build();
            await mqttClient.PublishAsync(messageApplication, CancellationToken.None);
        }

        /// <summary>
        /// 订阅消息并展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                mqttClient.ApplicationMessageReceivedAsync += (e) =>
                {
                    var task = Task.Factory.StartNew(() =>
                    {
                        var msgArray = e.ApplicationMessage.Payload;
                        var msg = Encoding.UTF8.GetString(msgArray);

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            TbShowMessage.Text += msg + "\r\n";
                        });
                    });

                    return task;
                };

                await mqttClient.SubscribeAsync(new MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter(TbTopic.Text)
                    .Build());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}