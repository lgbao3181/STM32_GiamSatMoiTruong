using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Drawing;




namespace GiaoDien
{

    public partial class Form1 : Form
    {


        double Temp;
        double Hum;
        string ReceiveData = String.Empty;
        string TranmitData = String.Empty;

        private volatile bool choPhepNhanDuLieu = false;





        public Form1()
        {
            InitializeComponent();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;


        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {

                        //TranmitData = "C";
                        //serialPort1.Write(TranmitData);


                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;

            // ReadTo("&") không được phép chờ vô hạn
            serialPort1.ReadTimeout = 500;

            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }

            int[] bauds = { 2400, 4800, 9600, 19200, 115200 };

            foreach (int baud in bauds)
            {
                comboBox2.Items.Add(baud.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show(
                    "Select COM Port and Baud.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                if (serialPort1.IsOpen)
                {
                    MessageBox.Show(
                        "COM Port is connected and ready for use",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                // Thiết lập lại trạng thái trước khi mở
                choPhepNhanDuLieu = true;

                serialPort1.Open();

                textBox1.BackColor = Color.Lime;
                textBox1.Text = "Connected";

                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            catch (Exception ex)
            {
                choPhepNhanDuLieu = false;

                MessageBox.Show(
                    "Không thể mở COM Port.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
            {
                MessageBox.Show("COM Port is Disconnected. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        choPhepNhanDuLieu = false;
                        DungNhapNhay();

                        serialPort1.Close();
                        textBox1.BackColor = Color.Red;
                        textBox1.Text = "Disconnected";
                        comboBox1.Enabled = true;
                        comboBox2.Enabled = true;

                        textBox3.Text = "ĐÃ NGẮT KẾT NỐI";
                        textBox6.Text = "ĐÃ NGẮT KẾT NỐI";
                        textBox2.Text = "ĐÃ NGẮT KẾT NỐI";
                        textBox7.Text = "ĐÃ NGẮT KẾT NỐI";
                        textBox8.Text = "ĐÃ NGẮT KẾT NỐI";
                        textBox4.Text = "";

                        pictureBox1.Image = GiaoDien.Properties.Resources.white;
                        pictureBox2.Image = GiaoDien.Properties.Resources.white;
                        pictureBox3.Image = GiaoDien.Properties.Resources.white;





                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {

                        TranmitData = "F";
                        serialPort1.Write(TranmitData);


                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Không cho nhận dữ liệu
            if (!choPhepNhanDuLieu)
                return;

            try
            {
                // Kiểm tra COM còn mở không
                if (!serialPort1.IsOpen)
                    return;

                // Đọc đến ký tự &
                string received = serialPort1.ReadTo("&");

                // Nếu trong lúc đọc mà đã Disconnect
                if (!choPhepNhanDuLieu)
                    return;

                received = received.Trim();

                // Bỏ @ nếu có
                received = received.TrimStart('@').Trim();

                // Hiển thị dữ liệu gốc
                if (!IsDisposed && IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (choPhepNhanDuLieu && !IsDisposed)
                        {
                            textBox4.Text = received;
                        }
                    }));
                }

                // ==============================
                // TÁCH DỮ LIỆU
                // ==============================

                string[] data = received.Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                double temp = 0;
                double hum = 0;
                int gas = 0;

                bool tempOK = false;
                bool humOK = false;
                bool gasOK = false;

                foreach (string item in data)
                {
                    string value = item.Trim();

                    // T=32.66
                    if (value.StartsWith("T="))
                    {
                        tempOK = double.TryParse(
                            value.Substring(2),
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out temp
                        );
                    }

                    // H=93.03
                    else if (value.StartsWith("H="))
                    {
                        humOK = double.TryParse(
                            value.Substring(2),
                            System.Globalization.NumberStyles.Float,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out hum
                        );
                    }

                    // G=0
                    else if (value.StartsWith("G="))
                    {
                        gasOK = int.TryParse(
                            value.Substring(2),
                            out gas
                        );
                    }
                }

                // Không đủ dữ liệu
                if (!tempOK || !humOK || !gasOK)
                    return;

                // Kiểm tra lần cuối trước khi cập nhật UI
                if (!choPhepNhanDuLieu)
                    return;

                // ==============================
                // CẬP NHẬT GIAO DIỆN
                // ==============================

                if (!IsDisposed && IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (choPhepNhanDuLieu && !IsDisposed)
                        {
                            UpdateDisplay(temp, hum, gas);
                        }
                    }));
                }
            }
            catch (TimeoutException)
            {
                // ReadTo("&") không nhận được & trong 500ms
                // Không làm gì cả
            }
            catch (InvalidOperationException)
            {
                // SerialPort bị đóng trong lúc đang đọc
            }
            catch (IOException)
            {
                // COM bị rút hoặc mất kết nối
            }
            catch (Exception ex)
            {
                if (choPhepNhanDuLieu && !IsDisposed && IsHandleCreated)
                {
                    BeginInvoke(new Action(() =>
                    {
                        if (choPhepNhanDuLieu && !IsDisposed)
                        {
                            textBox7.Text = "Lỗi Serial: " + ex.Message;
                        }
                    }));
                }
            }
        }




        private void UpdateDisplay(double temp, double hum, int gas)
        {
            // =========================
            // HIỂN THỊ NHIỆT ĐỘ
            // =========================

            Temp = temp;

            textBox3.Text = temp.ToString("0.00") + "°C";

            if (temp >= 35)
            {
                pictureBox1.Image = GiaoDien.Properties.Resources.temp;
                textBox7.Text = "NHIỆT ĐỘ QUÁ CAO";
            }
            else
            {
                pictureBox1.Image = GiaoDien.Properties.Resources.save;
                textBox7.Text = "AN TOÀN";
            }


            // =========================
            // HIỂN THỊ ĐỘ ẨM
            // =========================

            Hum = hum;

            textBox6.Text = hum.ToString("0.00") + "%";

            if (hum >= 80)
            {
                pictureBox2.Image = GiaoDien.Properties.Resources.hum;
                textBox8.Text = "ĐỘ ẨM QUÁ CAO";
            }
            else
            {
                pictureBox2.Image = GiaoDien.Properties.Resources.save;
                textBox8.Text = "AN TOÀN";
            }


            // =========================
            // HIỂN THỊ KHÍ GAS
            // =========================

            if (gas == 0)
            {
                pictureBox3.Image = GiaoDien.Properties.Resources.save;
                textBox2.Text = "AN TOÀN: KHÔNG CÓ RÒ RỈ KHÍ GA";
            }
            else
            {
                pictureBox3.Image = GiaoDien.Properties.Resources.gas;
                textBox2.Text = "NGUY HIỂM: RÒ RỈ KHÍ GAS";
            }


            // =========================
            // KIỂM TRA CẢNH BÁO
            // =========================

            bool nguyHiem = temp >= 35 || hum >= 80 || gas != 0;

            if (nguyHiem)
            {
                NhapNhayDo();
            }
            else
            {
                DungNhapNhay();
            }
        }

        private System.Windows.Forms.Timer warningTimer;
        private bool isRed = false;

        private void NhapNhayDo()
        {
            if (warningTimer == null)
            {
                warningTimer = new System.Windows.Forms.Timer();
                warningTimer.Interval = 500;

                warningTimer.Tick += (s, e) =>
                {
                    this.BackColor = isRed ? Color.White : Color.Red;
                    isRed = !isRed;
                };
            }

            warningTimer.Start();
        }

        private void DungNhapNhay()
        {
            if (warningTimer != null)
            {
                warningTimer.Stop();
                this.BackColor = Color.White;
                isRed = false;
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult answer = MessageBox.Show("Do you want to exit the program?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {

                        TranmitData = "R";
                        serialPort1.Write(TranmitData);

                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {

                        TranmitData = "A";
                        serialPort1.Write(TranmitData);

                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select COM Port. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {

                        TranmitData = textBox5.Text;
                        serialPort1.Write(TranmitData);

                    }
                    else
                    {
                        MessageBox.Show("COM Port is Disconnected ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("COM Port is not found. Please check your COM or Cable. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Do you want to exit the program?",
                "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                this.Close();
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button7.Enabled = true;
                textBox5.ReadOnly = false;

            }
            else
            {
                button7.Enabled = false;
                textBox5.ReadOnly = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
