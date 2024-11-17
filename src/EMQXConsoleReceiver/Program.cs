using M2Mqtt.Messages;
using M2Mqtt;
using System.Text;

namespace EMQXConsoleReceiver
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var client = new MqttClient("127.0.0.1", 1883, false, MqttSslProtocols.None, null, null);
                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                var clientId = "2c05f46f-6ff1-42e6-9325-5da81303a6de";
                client.Connect(clientId);

                client.Subscribe(new string[] { "test/topic" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                //client.Disconnect();

                Console.WriteLine("Receiver is listening .....");

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine(System.Text.Encoding.UTF8.GetString(e.Message));
        }
    }
}
