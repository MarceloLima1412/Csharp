using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartGraphsApp
{
    public partial class Notification : Form
    {
        public Notification(string _message, AlertType type)
        {
            InitializeComponent();
            message.Text = _message;
            switch(type)
            {
                case AlertType.connect:
                    this.BackColor = Color.SeaGreen;
                    break;
                case AlertType.disconnect:
                    this.BackColor = Color.FromArgb(255, 128, 0);
                    break;
            }
        }

        public enum AlertType
        {
            connect, disconnect
        }

        public static void Show(string message, AlertType type)
        {
            new ChartGraphsApp.Notification(message, type).Show();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            this.Top = 60;
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 60;

            show_notif.Start();
        }

        private void timeout_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            close_notif.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        int interval = 0;
        //Mostrar a Notificação
        private void show_notif_Tick(object sender, EventArgs e)
        {
            if (this.Top<60)
            {
                this.Top += interval;
                interval += 2;
            }else
            {
                show_notif.Stop();
            }
        }

        private void close_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity-= 0.1;
            }
            else
            {
                this.Close();
            }
        }
    }
}
