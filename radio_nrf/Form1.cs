using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Globalization;

namespace radio_nrf
{
    public partial class Form1 : Form
    {

        private static Encoding enc8 = Encoding.UTF8;
        private delegate void SetTextDeleg(string text);
        string data;
        public Form1()
        {
            InitializeComponent();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            // выводим список портов
            foreach (string p in ports)
                comboBox1.Items.Add(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!serialPort1.IsOpen)
                serialPort1.Open();
            //Открываем порт.
            serialPort1.Write("1");
            //Thread.Sleep(500);
            /*while (serialPort1.BytesToRead <= 0)
                if (serialPort1.BytesToRead > 0)
                {
                    string s = serialPort1.ReadExisting();
                    /*byte[] data = new byte[serialPort1.BytesToRead];
                    serialPort1.Read(data, 0, serialPort1.BytesToRead);
                    for (int i = 0; i < data.Length; i++)
                    {
                        string s = enc8.GetString(data);
                        richTextBox1.Text = s;
                    }
                    richTextBox1.Text += s;
                }*/
            //serialPort1.Close();
        }

        //void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    Thread.Sleep(500);
        //    string data = serialPort1.ReadLine();
        //    // Привлечение делегата на потоке UI, и отправка данных, которые
        //    // были приняты привлеченным методом.
        //    // ---- Метод "si_DataReceived" будет выполнен в потоке UI,
        //    // который позволит заполнить текстовое поле TextBox.
        //    this.BeginInvoke(new SetTextDeleg(si_DataReceived),
        //                     new object[] { data });
        //}

        private void si_DataReceived(string data)
        {
            richTextBox1.Text += data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.SelectedItem.ToString(); //Указываем наш порт
            serialPort1.BaudRate = 9600; //указываем скорость.
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.Handshake = Handshake.None;

            try
            {
                //Открываем порт.
                //byte[] data = { (byte)'c', (byte)'o', (byte)'n', (byte)'f', (byte)'i', (byte)'g' };
                //port.Write(data, 0, data.Length);
                /*Byte[] bytes = new Byte[10];
                port.Read(bytes, 0, 5);
                string s = enc8.GetString(bytes);
                textBox1.Text = s;*/
            }
            catch (Exception)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Ошибка получения настроек!");
                return;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /*SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            richTextBox1.Text += indata;*/
            Thread.Sleep(50);
            data = serialPort1.ReadExisting();
            Thread.Sleep(50);
            // Привлечение делегата на потоке UI, и отправка данных, которые
            // были приняты привлеченным методом.
            // ---- Метод "si_DataReceived" будет выполнен в потоке UI,
            // который позволит заполнить текстовое поле TextBox.
            BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }
    }
}
