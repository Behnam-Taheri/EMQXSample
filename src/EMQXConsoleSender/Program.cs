using M2Mqtt.Messages;
using M2Mqtt;
using System.Net;

namespace EMQXConsoleSender
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello, MQTT!";

            MqttClient client = new MqttClient("127.0.0.1", 1883, false, MqttSslProtocols.None, null, null);

            var clientId = Guid.NewGuid().ToString();

            client.Connect(clientId);

            Console.WriteLine("Publisher Connected");

            while (true)
            {

                message = Console.ReadLine()!;

                client.Publish("test/topic", System.Text.Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

                client.Disconnect();
            }
        }

    }
}
