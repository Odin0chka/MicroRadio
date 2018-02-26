namespace radio_nrf
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_send = new System.Windows.Forms.Button();
            this.mail = new System.Windows.Forms.TextBox();
            this.serial_port_send = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_port_send = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.combo_port_received = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.change = new System.Windows.Forms.Button();
            this.serial_port_received = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(453, 26);
            this.button_send.Margin = new System.Windows.Forms.Padding(4);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(100, 28);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.ButtonSendClick);
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(7, 29);
            this.mail.Margin = new System.Windows.Forms.Padding(4);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(438, 22);
            this.mail.TabIndex = 1;
            this.mail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MailKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combo_port_send);
            this.groupBox1.Controls.Add(this.mail);
            this.groupBox1.Controls.Add(this.button_send);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 122);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Отправка";
            // 
            // combo_port_send
            // 
            this.combo_port_send.FormattingEnabled = true;
            this.combo_port_send.Location = new System.Drawing.Point(453, 61);
            this.combo_port_send.Name = "combo_port_send";
            this.combo_port_send.Size = new System.Drawing.Size(100, 24);
            this.combo_port_send.TabIndex = 6;
            this.combo_port_send.SelectedIndexChanged += new System.EventHandler(this.combo_port_send_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_clear);
            this.groupBox2.Location = new System.Drawing.Point(578, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 67);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Option";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(7, 22);
            this.button_clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(101, 28);
            this.button_clear.TabIndex = 6;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.combo_port_received);
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 245);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прием";
            // 
            // combo_port_received
            // 
            this.combo_port_received.FormattingEnabled = true;
            this.combo_port_received.Location = new System.Drawing.Point(453, 21);
            this.combo_port_received.Name = "combo_port_received";
            this.combo_port_received.Size = new System.Drawing.Size(100, 24);
            this.combo_port_received.TabIndex = 7;
            this.combo_port_received.SelectedIndexChanged += new System.EventHandler(this.combo_port_received_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(439, 213);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1TextChanged);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(579, 197);
            this.change.Margin = new System.Windows.Forms.Padding(4);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(114, 244);
            this.change.TabIndex = 7;
            this.change.Text = "Сменить";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.button1_Click);
            // 
            // serial_port_received
            // 
            this.serial_port_received.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPortDataReceived);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 554);
            this.Controls.Add(this.change);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Is my PROJECT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox mail;
        private System.IO.Ports.SerialPort serial_port_send;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button change;
        private System.IO.Ports.SerialPort serial_port_received;
        private System.Windows.Forms.ComboBox combo_port_send;
        private System.Windows.Forms.ComboBox combo_port_received;
    }
}

