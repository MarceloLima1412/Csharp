using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace DataStorageMicroApplication
{
    public partial class Form1 : Form
    {
        string baseURI = @"http://localhost:49956/";
        MqttClient mClient = new MqttClient("127.0.0.1");
        string[] topics = {"sensors", "alarms"};

 

        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
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
            if (pictureBox2.Visible == true)
            {
                pictureBox2.Visible = false;
            }

            if (pictureBox1.Visible == false)
            {
                pictureBox1.Visible = true;
            }

            //Enable/Disable do botão Connect/Disconnect
            if (Desconectar.Enabled == false)
            {
                Desconectar.Enabled = true;
            }

            if (button1.Enabled == true)
            {
                button1.Enabled = false;
            }

            mClient.Subscribe(topics, qosLevels);
            mClient.MqttMsgPublishReceived += interpretaSensor;

        }

       

        private void interpretaSensor(object sender, MqttMsgPublishEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                string message = Encoding.UTF8.GetString(e.Message);

                char[] delimiters = new char[] { ':' };
                string[] valores = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                if (valores.Length == 7)
                {
                    int sensorID = int.Parse(valores[0]);

                    if (sensorID == 1)
                    {
                        float temperature_sensor_1 = float.Parse(valores[1]);
                        float humidity_sensor_1 = float.Parse(valores[2]);
                        int timestamp_sensor_1 = int.Parse(valores[3]);
                        int temperature_alarm_1 = int.Parse(valores[4]);
                        char operador_1 = char.Parse(valores[5]);

                        Console.WriteLine("Upstairs Sensor: " + sensorID);
                        Console.WriteLine(temperature_sensor_1);
                        Console.WriteLine(humidity_sensor_1);
                        Console.WriteLine(timestamp_sensor_1);
                        Console.WriteLine(temperature_alarm_1);
                        DateTime timestamp_1_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_sensor_1);
                        richTextBox1.AppendText($"ALARM !!!! Details: Upstairs Sensor: Temperature -> {temperature_sensor_1} Humidity -> {humidity_sensor_1} Date -> {timestamp_1_date} Alarm configured: {operador_1} {temperature_alarm_1}  '\n");
                    }

                    if (sensorID == 2)
                    {
                        float temperature_sensor_2 = float.Parse(valores[1]);
                        float humidity_sensor_2 = float.Parse(valores[2]);
                        int timestamp_sensor_2 = int.Parse(valores[3]);
                        int temperature_alarm_2 = int.Parse(valores[4]);
                        char operador_2 = char.Parse(valores[5]);

                        Console.WriteLine("Upstairs Sensor: " + sensorID);
                        Console.WriteLine(temperature_sensor_2);
                        Console.WriteLine(humidity_sensor_2);
                        Console.WriteLine(timestamp_sensor_2);
                        Console.WriteLine(temperature_alarm_2);
                        DateTime timestamp_2_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_sensor_2);
                        richTextBox1.AppendText($"ALARM !!!! Details: Downstairs Sensor: Temperature -> {temperature_sensor_2} Humidity -> {humidity_sensor_2} Date -> {timestamp_2_date} Alarm configured: {operador_2} {temperature_alarm_2}  '\n");
                    }

                    if (sensorID != 1 && sensorID != 2)
                    {
                        float temperature_sensor_3 = float.Parse(valores[1]);
                        float humidity_sensor_3 = float.Parse(valores[2]);
                        int timestamp_sensor_3 = int.Parse(valores[3]);
                        int temperature_alarm_3 = int.Parse(valores[4]);
                        char operador_3 = char.Parse(valores[5]);

                        Console.WriteLine("Upstairs Sensor: " + sensorID);
                        Console.WriteLine(temperature_sensor_3);
                        Console.WriteLine(humidity_sensor_3);
                        Console.WriteLine(timestamp_sensor_3);
                        Console.WriteLine(temperature_alarm_3);
                        DateTime timestamp_3_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_sensor_3);
                        richTextBox1.AppendText($"ALARM !!!! Details: New Sensor {sensorID}:  Temperature -> {temperature_sensor_3} Humidity -> {humidity_sensor_3} Date -> {timestamp_3_date} Alarm configured: {operador_3} {temperature_alarm_3} '\n");
                    }

                    Alerta novoAlerta = new Alerta
                    {
                        id = int.Parse(valores[0]),
                        temperature = float.Parse(valores[1]),
                        humidity = float.Parse(valores[2]),
                        timestamp = int.Parse(valores[3]),
                        signal = char.Parse(valores[5]),
                        value = int.Parse(valores[4])
                    };

                    var client = new RestClient(baseURI);
                    string jsonClient = JsonConvert.SerializeObject(novoAlerta);
                    var request = new RestRequest("api/alert/insert", Method.POST);
                    request.AddJsonBody(jsonClient);
                    request.RequestFormat = DataFormat.Json;
                    IRestResponse response = client.Execute(request);




                }
                else
                {
                    int sensorID = int.Parse(valores[0]);

                    if (sensorID == 1)
                    {
                        float temperature_1 = float.Parse(valores[1]);
                        float humidity_1 = float.Parse(valores[2]);
                        int battery_1 = int.Parse(valores[3]);
                        int timestamp_1 = int.Parse(valores[4]);

                        Console.WriteLine("Upstairs Sensor: " + sensorID);
                        Console.WriteLine(temperature_1);
                        Console.WriteLine(humidity_1);
                        Console.WriteLine(battery_1);
                        Console.WriteLine(timestamp_1);
                        DateTime timestamp_1_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_1);
                        richTextBox1.AppendText($"Upstairs Sensor: Temperature -> {temperature_1} Humidity -> {humidity_1} Battery -> {battery_1} Date -> {timestamp_1_date} '\n");
                    }

                    if (sensorID == 2)
                    {
                        float temperature_2 = float.Parse(valores[1]);
                        float humidity_2 = float.Parse(valores[2]);
                        int battery_2 = int.Parse(valores[3]);
                        int timestamp_2 = int.Parse(valores[4]);

                        Console.WriteLine("Downstairs Sensor: " + sensorID);
                        Console.WriteLine(temperature_2);
                        Console.WriteLine(humidity_2);
                        Console.WriteLine(battery_2);
                        Console.WriteLine(timestamp_2);
                        DateTime timestamp_2_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_2);
                        richTextBox1.AppendText($"Downstairs Sensor: Temperature -> {temperature_2} Humidity -> {humidity_2} Battery -> {battery_2} Date -> {timestamp_2_date} '\n");
                    }

                    if (sensorID != 1 && sensorID != 2)
                    {
                        float temperature = float.Parse(valores[1]);
                        float humidity = float.Parse(valores[2]);
                        int battery = int.Parse(valores[3]);
                        int timestamp = int.Parse(valores[4]);

                        Console.WriteLine("New Sensor: " + sensorID);
                        Console.WriteLine(temperature);
                        Console.WriteLine(humidity);
                        Console.WriteLine(battery);
                        Console.WriteLine(timestamp);
                        DateTime timestamp_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp);
                        richTextBox1.AppendText($"New Sensor {sensorID}: Temperature -> {temperature} Humidity -> {humidity} Battery -> {battery} Date -> {timestamp_date} '\n");
                    }



                    Sensor novoSensor = new Sensor
                    {
                        Id = int.Parse(valores[0]),
                        Temperature = float.Parse(valores[1]),
                        Humidity = float.Parse(valores[2]),
                        Battery = int.Parse(valores[3]),
                        Timestamp = int.Parse(valores[4])
                    };

                    var client = new RestClient(baseURI);
                    string jsonClient = JsonConvert.SerializeObject(novoSensor);
                    var request = new RestRequest("api/sensor/insert", Method.POST);
                    request.AddJsonBody(jsonClient);
                    request.RequestFormat = DataFormat.Json;
                    IRestResponse response = client.Execute(request);
                }
            });

        }

        

        


        private void Desconectar_Click(object sender, EventArgs e)
        {
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topics);
                mClient.Disconnect();

                mClient.MqttMsgPublishReceived -= interpretaSensor;

           

                //Limpar dados da Tabela
                richTextBox1.Clear();
             

                //Imagem da ligação ON/OFF
                if (pictureBox1.Visible == true)
                {
                    pictureBox1.Visible = false;
                }

                if (pictureBox2.Visible == false)
                {
                    pictureBox2.Visible = true;
                }

                //Enable/Disable do botão Connect/Disconnect
                if (Desconectar.Enabled == true)
                {
                    Desconectar.Enabled = false;
                }

                if (button1.Enabled == false)
                {
                    button1.Enabled = true;
                }

            }

           
        }
    } 
}
    

