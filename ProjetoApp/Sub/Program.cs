using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Sub
{
            class Subscribe
            {
            static void subscribe()
            {
                MqttClient mClient = new MqttClient("test.mosquitto.org");
                string[] topics = { "sensors", "alerts" };
                byte[] qosLevels =
                {
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
            MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE
        };

                mClient.Connect(Guid.NewGuid().ToString());
                if (!mClient.IsConnected)
                {
                    Console.WriteLine("Erro de conexão");
                }
                mClient.Subscribe(topics, qosLevels);


           
        }
    }
}
