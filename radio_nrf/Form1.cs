using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace radio_nrf
{
    public partial class MainForm : Form
    {
        private delegate void SetTextDeleg(string text);
        private string _data;

        public MainForm()
        {
            InitializeComponent();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length < 2)
            {
                MessageBox.Show("Устройств не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                Close();
                return;
            }
            // выводим список портов
            foreach (string p in ports)
            {
                combo_port_send.Items.Add(p);
                combo_port_received.Items.Add(p);
            }
            serial_port_send.BaudRate = 9600; //указываем скорость
            serial_port_received.BaudRate = 9600; //указываем скорость
            serial_port_send.Parity = Parity.None;
            serial_port_received.Parity = Parity.None;
            serial_port_send.Handshake = Handshake.None;
            serial_port_received.Handshake = Handshake.None;
            serial_port_send.DataBits = 8;
            serial_port_received.DataBits = 8;
            combo_port_send.SelectedIndex = 0;
            combo_port_received.SelectedIndex = 1;
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            serial_port_send.Close();
            serial_port_received.Close();
        }

        //-----Отправка сообщения-----

        private void ButtonSendClick(object sender, EventArgs e)
        {
            Send_Mail();
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
                serial_port_send.Write(mail.Text);
            mail.Clear();
        }

        //----------------------------

        //-----Получение сообщения-----

        private void RichTextBox1TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
            _data = serial_port_received.ReadExisting();
            Thread.Sleep(50);
            // Привлечение делегата на потоке UI, и отправка данных, которые
            // были приняты привлеченным методом.
            // ---- Метод "si_dataReceived" будет выполнен в потоке UI,
            // который позволит заполнить текстовое поле TextBox
            BeginInvoke(new SetTextDeleg(SiDataReceived), new object[] { _data });
        }

        private void SiDataReceived(string _data)
        {
            richTextBox1.Text += _data;
        }

        //-----------------------------

        //-----Настройка-----

        private void ButtonClearClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            mail.Clear();
        }

        private void ButtonChangeClick(object sender, EventArgs e)
        {
            string cs = combo_port_send.SelectedItem.ToString();
            string cr = combo_port_received.SelectedItem.ToString();
            for(int i = 0; i < combo_port_send.Items.Count; i++)
            {
                if (combo_port_received.Items[i].ToString() == cs)
                    combo_port_received.SelectedIndex = i;
                if (combo_port_send.Items[i].ToString() == cr)
                    combo_port_send.SelectedIndex = i;
            }
        }

        private void combo_port_send_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serial_port_send.IsOpen)
                serial_port_send.Close();
            mail.Clear();
            string select_item = combo_port_send.SelectedItem.ToString();
            serial_port_send.PortName = select_item;
            try
            {
                if (combo_port_received.SelectedItem.ToString() == select_item)
                {
                    serial_port_received.Close();
                    for (int i = 0; i < combo_port_received.Items.Count; i++)
                        if (combo_port_received.Items[i].ToString() != select_item)
                        {
                            combo_port_received.SelectedIndex = i;
                            break;
                        }
                }
            }
            catch (NullReferenceException)
            {
                //говнокод блядь
            }
            serial_port_send.Open();
        }

        private void combo_port_received_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serial_port_received.IsOpen)
                serial_port_received.Close();
            richTextBox1.Clear();
            string select_item = combo_port_received.SelectedItem.ToString();
            serial_port_received.PortName = select_item;
            if (combo_port_send.SelectedItem.ToString() == select_item)
            {
                serial_port_send.Close();
                for (int i = 0; i < combo_port_send.Items.Count; i++)
                    if (combo_port_send.Items[i].ToString() != select_item)
                    {
                        combo_port_send.SelectedIndex = i;
                        break;
                    }
            }
            serial_port_received.Open();
        }

        //-------------------
        //Логи в файл
        //Отправка - COM3
        //Прием - COM3

    }
}
