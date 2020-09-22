using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ChartGraphsApp
{
    public partial class ShowData : Form
    {
        //Endereço para conexão ao BROKER (Mosquitto)
        //MqttClient mClient = new MqttClient("192.168.1.103");
        MqttClient mClient = new MqttClient("127.0.0.1");

        //String dos tópicos a subscrever
        string[] topics = { "sensors" };

        public ShowData()
        {
            InitializeComponent();
        }

        private void btn_connectBroker_Click(object sender, EventArgs e)
        {
            //Subscrever Valores
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };

            //Conecta com o Broker
            mClient.Connect(Guid.NewGuid().ToString());

            //Se não conseguir conectar
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Erro de conexão");
            }

            Notification.Show("Subscribed with success", Notification.AlertType.connect);


            if (pictureBoxOff.Visible == true)
            {
                pictureBoxOff.Visible = false;
            }

            if (pictureBoxOn.Visible == false)
            {
                pictureBoxOn.Visible = true;
            }

            //Enable/Disable do botão Connect/Disconnect
            if (btn_disconnectBroker.Enabled == false)
            {
                btn_disconnectBroker.Enabled = true;
            }

            if (btn_connectBroker.Enabled == true)
            {
                btn_connectBroker.Enabled = false;
            }


            mClient.Subscribe(topics, qosLevels);

            //Quando recebe mensagem no tópico subscrito, executa a função "interpretaDados"
            mClient.MqttMsgPublishReceived += interpretaDados;
            

        }


        private void btn_disconnectBroker_Click(object sender, EventArgs e)
        {
            //se estiver conectado
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topics);
                mClient.Disconnect();

                mClient.MqttMsgPublishReceived -= interpretaDados;

                Notification.Show("Unsubscribed with success", Notification.AlertType.disconnect);

                //Limpar dados da Tabela
                tabelaSensor1.Items.Clear();
                tabelaSensor2.Items.Clear();

                //Imagem da ligação ON/OFF
                if (pictureBoxOn.Visible == true)
                {
                    pictureBoxOn.Visible = false;
                }

                if (pictureBoxOff.Visible == false)
                {
                    pictureBoxOff.Visible = true;
                }

                //Enable/Disable do botão Connect/Disconnect
                if (btn_disconnectBroker.Enabled == true)
                {
                    btn_disconnectBroker.Enabled = false;
                }

                if (btn_connectBroker.Enabled == false)
                {
                    btn_connectBroker.Enabled = true;
                }

            }
        }


        //Tuple<float, float, int>
        private void interpretaDados(object sender, MqttMsgPublishEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                string message = Encoding.UTF8.GetString(e.Message);

                char[] delimiters = new char[] { ':' };
                string[] valores = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int sensorID = int.Parse(valores[0]);

                if (sensorID == 1)
                {
                    float temperature_1 = float.Parse(valores[1].Replace(".", ","));
                    float humidity_1 = float.Parse(valores[2].Replace(".", ","));
                    //int battery_1 = int.Parse(valores[3]);
                    int timestamp_1 = int.Parse(valores[4]);

                    DateTime timestamp_1_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_1);
                    Console.WriteLine(timestamp_1_date);

                    Console.WriteLine("Upstairs Sensor: " + sensorID);
                    Console.WriteLine(temperature_1);
                    Console.WriteLine(humidity_1);
                    //Console.WriteLine(battery_1);
                    Console.WriteLine(timestamp_1_date);

                    //Adicionar dados à tabela do Sensor 1
                    ListViewItem dadosSensor1 = new ListViewItem(timestamp_1_date.ToString());
                    dadosSensor1.SubItems.Add(temperature_1 + " °C");
                    dadosSensor1.SubItems.Add(humidity_1 + "");

                    tabelaSensor1.Items.Add(dadosSensor1);

                    //Adicionar dados ao gráfico do Sensor 1
                    graficoSensor1.Series["Temperature_1"].Points.AddXY(timestamp_1_date, temperature_1);
                    graficoSensor1.Series["Humidity_1"].Points.AddXY(timestamp_1_date, humidity_1);


                    //Colocar o Array a 0
                    //Array.Clear(valores, 0, valores.Length);
                    //Mostrar todos os valores do Array
                    //Array.ForEach(valores, Console.WriteLine);

                }

                if (sensorID == 2)
                {
                    float temperature_2 = float.Parse(valores[1].Replace(".", ","));
                    float humidity_2 = float.Parse(valores[2].Replace(".", ","));
                    //int battery_2 = int.Parse(valores[3]);
                    int timestamp_2 = int.Parse(valores[4]);

                    Console.WriteLine("Downstairs Sensor: " + sensorID);
                    Console.WriteLine(temperature_2);
                    Console.WriteLine(humidity_2);
                    //Console.WriteLine(battery_2);
                    Console.WriteLine(timestamp_2);

                    DateTime timestamp_2_date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp_2);
                    Console.WriteLine(timestamp_2_date);

                    //Adicionar dados à tabela do Sensor 2
                    ListViewItem dadosSensor2 = new ListViewItem(timestamp_2_date.ToString());
                    dadosSensor2.SubItems.Add(temperature_2 + " °C");
                    dadosSensor2.SubItems.Add(humidity_2 + "");

                    tabelaSensor2.Items.Add(dadosSensor2);

                    //Adicionar dados ao gráfico do Sensor 2
                    graficoSensor2.Series["Temperature_2"].Points.AddXY(timestamp_2_date, temperature_2);
                    graficoSensor2.Series["Humidity_2"].Points.AddXY(timestamp_2_date, humidity_2);

                }
                //return (temperature_1, humidity_1, timestamp_1);
            });

            //return Tuple.Create();
        }









        private void desenhaDadosSensor1()
        {


            //Adicionar dados à tabela do Sensor 1
            ListViewItem dadosSensor1 = new ListViewItem("12/12/19-12:06");
            dadosSensor1.SubItems.Add("22.47 °C");
            dadosSensor1.SubItems.Add("85.01");

            tabelaSensor1.Items.Add(dadosSensor1);

            //Adicionar dados ao gráfico do Sensor 1
            graficoSensor1.Series["Temperature_1"].Points.AddXY("12:40", 22.67);
            graficoSensor1.Series["Humidity_1"].Points.AddXY("12:41", 87);

            //Adicionar dados à tabela do Sensor 2
            ListViewItem dadosSensor2 = new ListViewItem("12/12/19-12:06");
            dadosSensor2.SubItems.Add("22.47 °C");
            dadosSensor2.SubItems.Add("85.01");

            tabelaSensor2.Items.Add(dadosSensor2);

            //Adicionar dados ao gráfico do Sensor 2
            graficoSensor2.Series["Temperature_2"].Points.AddXY("12:55", 21);
            graficoSensor2.Series["Humidity_2"].Points.AddXY("12:59", 50);




        }

        private void desenhaDadosSensor2()
        {


            //Adicionar dados à tabela do Sensor 1
            ListViewItem dadosSensor1 = new ListViewItem("12/12/19-12:06");
            dadosSensor1.SubItems.Add("22.47 °C");
            dadosSensor1.SubItems.Add("85.01");

            tabelaSensor1.Items.Add(dadosSensor1);

            //Adicionar dados à tabela do Sensor 2
            ListViewItem dadosSensor2 = new ListViewItem("12/12/19-12:06");
            dadosSensor2.SubItems.Add("22.47 °C");
            dadosSensor2.SubItems.Add("85.01");

            tabelaSensor2.Items.Add(dadosSensor2);

            //Adicionar dados ao gráfico do Sensor 1
            graficoSensor1.Series["Temperature_1"].Points.AddXY("12:40", 22.67);
            graficoSensor1.Series["Humidity_1"].Points.AddXY("12:41", 87);

            //Adicionar dados ao gráfico do Sensor 2
            graficoSensor2.Series["Temperature_2"].Points.AddXY("12:55", 21);
            graficoSensor2.Series["Humidity_2"].Points.AddXY("12:59", 50);


        }


        private void tabelaSensor1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topics);
                mClient.Disconnect();
            }
        }
    }
}
