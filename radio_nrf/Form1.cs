using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace radio_nrf
{
    public partial class MainForm : Form
    {

        private static Encoding enc8 = Encoding.UTF8;
        private delegate void SetTextDeleg(string text);
        private string data;

        public MainForm()
        {
            InitializeComponent();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            // выводим список портов
            foreach (string p in ports)
                combo_port.Items.Add(p);
            if (combo_port.Items.Count == 0)
                MessageBox.Show("Устройств не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                combo_port.SelectedIndex = 0;
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        //-----Отправка сообщения-----

        private void ButtonSendClick(object sender, EventArgs e)
        {
            Send_Mail();
            //Thread.Sleep(500);
            //serialPort1.Close();
        }

        private void MailKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Send_Mail();
                button_send.Focus();
            }
        }

        private void Send_Mail()
        {
            if (mail.Text != "")
            {
                serialPort1.Write(mail.Text);
                richTextBox1.Clear();
            }
            mail.Clear();
        }
        
        //-----------------------------

        //-----Получение сообщения-----

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
            data = serialPort1.ReadExisting();
            Thread.Sleep(50);
            // Привлечение делегата на потоке UI, и отправка данных, которые
            // были приняты привлеченным методом.
            // ---- Метод "si_DataReceived" будет выполнен в потоке UI,
            // который позволит заполнить текстовое поле TextBox.sss
            BeginInvoke(new SetTextDeleg(SiDataReceived), new object[] { data });
        }

        private void SiDataReceived(string data)
        {
            richTextBox1.Text += data;
        }

        //-----------------------------

        private void PortSelection(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            mail.Clear();
            richTextBox1.Clear();
            serialPort1.PortName = combo_port.SelectedItem.ToString(); //Указываем наш порт
            serialPort1.BaudRate = 9600; //указываем скорость.
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.Handshake = Handshake.None;
            serialPort1.Open();
        }

        private void ButtonClearClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            mail.Clear();
        }
    }
}
