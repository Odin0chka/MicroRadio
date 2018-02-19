using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Threading;

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
            //serialPort1.Close();
        }

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
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
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
