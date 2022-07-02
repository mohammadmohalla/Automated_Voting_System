using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace voting_system
{

    public partial class Form1 : Form
    {
        #region defined_variables
        byte[] A_name           = { 0xff, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] B_name           = { 0xff, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] C_name           = { 0xff, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] D_name           = { 0xff, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_Numbre     = { 0xff, 0x05, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] start_Proccess   = { 0xff, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_ID         = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_Code       = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_ID_Valid   = { 0xff, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_Code_Valid = { 0xff, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_ID_False   = { 0xff, 0x0A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_Code_False = { 0xff, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voter_choose     = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] voted_Already    = { 0xff, 0x0E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        byte[] end_Voting       = { 0xff, 0x0F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        string[] Ports = SerialPort.GetPortNames();
        string[] BuadRates = { "1200", "1800", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128k" };
        string[] DataBits = { "5", "6", "7", "8" };
        string[] Prty = { "None", "Odd", "Mark", "Even", "Space" };
        string[] StopBit = { "None", "One", "Two", "OnePointFive" };
        string[] candidates = { "A", "B", "C", "D" ,"No Voting" };
        int[] Data_Received = new int[10];
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;
        Range range;
        List <string> voters_Names;
        List<Brush> color = new List<Brush>();
        bool wait_code = false;
        bool wait_confirm = false;
        int[] voters_IDs;
        int[] voters_isVote;
        Int32[] voters_Passwords;
        int current_voters_num = 0;
        string candi_A = "";
        string candi_B = "";
        string candi_C = "";
        string candi_D = "";
        int voters_Numbre = 0;
        int vote_ForA = 0;
        int vote_ForB = 0;
        int vote_ForC = 0;
        int vote_ForD = 0;
        int candi_Numbre = -1;
        int grid = -1;
        int column_Width = -1;
        int ID = 0;
        Int32 CODE = 0;
        int index = -1;

        #endregion

        #region serialport_functions

        public Form1()
        {
            InitializeComponent();
            getavalibaleports();
            color.Add(Brushes.Green);
            color.Add(Brushes.Red);
            color.Add(Brushes.Blue);
            color.Add(Brushes.Yellow);
            color.Add(Brushes.Black);
            A_label.Visible = false;
            B_label.Visible = false;
            C_label.Visible = false;
            D_label.Visible = false;
            A_candi_textBox.Visible = false;
            B_candi_textBox.Visible = false;
            C_candi_textBox.Visible = false;
            D_candi_textBox.Visible = false;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 1000;
            candi_Numbre_trackBar.Minimum = 1;
            candi_Numbre_trackBar.Maximum = 4;
            candi_Numbre_trackBar.Value = 4;
            grid_Numbre_trackBar.Minimum = 1;
            grid_Numbre_trackBar.Maximum = 10;
            grid_Numbre_trackBar.Value = 5;
            columne_Wigth_trackBar.Minimum = 1;
            columne_Wigth_trackBar.Maximum = 10;
            columne_Wigth_trackBar.Value = 5;
            voter_percent_label.Visible = false;
            candidates_label.Visible = false;
        }

        void getavalibaleports()
        {
            PortName_comboBox.Items.AddRange(Ports);
            BaudRate_comboBox.Items.AddRange(BuadRates);
            DataBits_comboBox.Items.AddRange(DataBits);
            Parity_comboBox.Items.AddRange(Prty);
            StopBits_comboBox.Items.AddRange(StopBit);
            if (PortName_comboBox.Items.Count > 0)
            {
                PortName_comboBox.SelectedIndex = 0;
            }
            BaudRate_comboBox.SelectedIndex = 4;
            DataBits_comboBox.SelectedIndex = 3;
            Parity_comboBox.SelectedIndex = 0;
            StopBits_comboBox.SelectedIndex = 1;
            ShowNote_label.Text = "Serial Port is Close";
        }

        private void OpenPort_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (PortName_comboBox.Text == "" || BaudRate_comboBox.Text == "" || DataBits_comboBox.Text == "" || Parity_comboBox.Text == "" || StopBits_comboBox.Text == "")
                {
                    MessageBox.Show("note: choose port settings ");
                }
                else
                {
                    serialPort.PortName = PortName_comboBox.Text;
                    if (BaudRate_comboBox.Text == "1200")
                        serialPort.BaudRate = 1200;
                    if (BaudRate_comboBox.Text == "1800")
                        serialPort.BaudRate = 1800;
                    if (BaudRate_comboBox.Text == "2400")
                        serialPort.BaudRate = 2400;
                    if (BaudRate_comboBox.Text == "4800")
                        serialPort.BaudRate = 4800;
                    if (BaudRate_comboBox.Text == "9600")
                        serialPort.BaudRate = 9600;
                    if (BaudRate_comboBox.Text == "14400")
                        serialPort.BaudRate = 14400;
                    if (BaudRate_comboBox.Text == "19200")
                        serialPort.BaudRate = 19200;
                    if (BaudRate_comboBox.Text == "38400")
                        serialPort.BaudRate = 38400;
                    if (BaudRate_comboBox.Text == "56000")
                        serialPort.BaudRate = 56000;
                    if (BaudRate_comboBox.Text == "57600")
                        serialPort.BaudRate = 57600;
                    if (BaudRate_comboBox.Text == "115200")
                        serialPort.BaudRate = 115200;
                    if (BaudRate_comboBox.Text == "128k")
                        serialPort.BaudRate = 128000;
                    if (DataBits_comboBox.Text == "5")
                        serialPort.DataBits = 5;
                    if (DataBits_comboBox.Text == "6")
                        serialPort.DataBits = 6;
                    if (DataBits_comboBox.Text == "7")
                        serialPort.DataBits = 7;
                    if (DataBits_comboBox.Text == "8")
                        serialPort.DataBits = 8;
                    if (Parity_comboBox.Text == "None")
                        serialPort.Parity = Parity.None;
                    if (Parity_comboBox.Text == "Odd")
                        serialPort.Parity = Parity.Odd;
                    if (Parity_comboBox.Text == "Mark")
                        serialPort.Parity = Parity.Mark;
                    if (Parity_comboBox.Text == "Even")
                        serialPort.Parity = Parity.Even;
                    if (Parity_comboBox.Text == "Space")
                        serialPort.Parity = Parity.Space;
                    if (StopBits_comboBox.Text == "None")
                        serialPort.StopBits = StopBits.None;
                    if (StopBits_comboBox.Text == "One")
                        serialPort.StopBits = StopBits.One;
                    if (StopBits_comboBox.Text == "Two")
                        serialPort.StopBits = StopBits.Two;
                    if (StopBits_comboBox.Text == "OnePointFive")
                        serialPort.StopBits = StopBits.OnePointFive;
                    if (!serialPort.IsOpen)
                    {
                        serialPort.Open();
                        ShowNote_label.Text = "Serial Port is Open";
                    }
                    else
                    {
                        ShowNote_label.Text = "Serial Port is already Open";
                    }
                    ClosePort_btn.Enabled = true;
                    OpenPort_btn.Enabled = false;

                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (TimeoutException)
            {
                ShowNote_label.Text = "timeout";
            }
            catch (Exception)
            {
                ShowNote_label.Text = "exception in open port";
            }
        }

        private void ClosePort_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ShowNote_label.Text = "port closed";
                serialPort.Close();
                OpenPort_btn.Enabled = true;
                ClosePort_btn.Enabled = false;
            }
            catch (Exception)
            {
                ShowNote_label.Text = "exception in close port";
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int i = 0;
            while (i < 10)
            {
                Data_Received[i] = serialPort.ReadByte();
                i++;
            }
            if (i == 10)
            {
                i = 0; ;
                this.Invoke(new EventHandler(DoUpDate));
            }
        }

        private void DoUpDate(object s, EventArgs e)
        {
            int header = 0;
            int number = 0;
            header = Data_Received[0];
            number = Data_Received[1];
            if (header == 0xff && number == 0x06)
            {
                voter_ID[2] = Convert.ToByte(Data_Received[2]);
                voter_ID[3] = Convert.ToByte(Data_Received[3]);
                ID = voter_ID[2] * 256 + voter_ID[3];
                index = ID_index(ID);
                if (index > -1 )
                {
                    if(voters_isVote[index] == 0)
                    {
                        Thread.Sleep(100);
                        Send_frame(voter_ID_Valid);
                        wait_code = true;
                        wait_confirm = true;
                    }
                    else
                    {
                        Thread.Sleep(100);
                        Send_frame(voted_Already);
                    }
                }
                else
                {
                    Thread.Sleep(100);
                    Send_frame(voter_ID_False);
                }
            }
            else if (header == 0xff && number == 0x07)
            {
                voter_Code[2] = Convert.ToByte(Data_Received[2]);
                voter_Code[3] = Convert.ToByte(Data_Received[3]);
                voter_Code[4] = Convert.ToByte(Data_Received[4]);
                CODE = (voter_Code[2] * 65536) + (voter_Code[3] * 256) + voter_Code[4];
                if (CODE == voters_Passwords[index])
                {
                    Thread.Sleep(100);
                    Send_frame(voter_Code_Valid);
                }
                else
                {
                    Thread.Sleep(100);
                    Send_frame(voter_Code_False);
                }
            }
            else if (header == 0xff && number == 0x0C)
            {
                if (Data_Received[2] == 0x01)
                {
                    vote_ForA++;
                    current_voters_num++;
                    result_panel.Refresh();
                    draw_coordinates();
                    draw_grid();
                    draw_rects();
                }
                else if(Data_Received[2] == 0x02)
                {
                    vote_ForB++;
                    current_voters_num++;
                    result_panel.Refresh();
                    draw_coordinates();
                    draw_grid();
                    draw_rects();
                }
                else if (Data_Received[2] == 0x03)
                {
                    vote_ForC++;
                    current_voters_num++;
                    result_panel.Refresh();
                    draw_coordinates();
                    draw_grid();
                    draw_rects();
                }
                else if (Data_Received[2] == 0x04)
                {
                    vote_ForD++;
                    current_voters_num++;
                    result_panel.Refresh();
                    draw_coordinates();
                    draw_grid();
                    draw_rects();
                }
                voters_isVote[index] = 1;
                wait_code = false;
                wait_confirm = false;
            }

        }

        public void Send_frame(byte[] Frame)
        {
            try
            {
                serialPort.Write(Frame, 0, 10);
                return;
            }
            catch
            { }
        }

        void name_To_frame(byte[] Frame, string name)
        {
            for (int i = 0; i < name.Length; i++)
            {
                Frame[i + 2] = Convert.ToByte(name[i]);
            }
        }

        private int ID_index(int ID)
        {
            index = -1;
            for (int i = 0; i < voters_Numbre; i++)
            {
                if (ID == voters_IDs[i])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        #endregion

        #region Set_Candidates

        private void one_candi_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if(one_candi_chBx.Checked)
            {
                two_candi_chBx.Checked = false;
                three_candi_chBx.Checked = false;
                four_candi_chBx.Checked = false;
                A_label.Visible = true;
                B_label.Visible = false;
                C_label.Visible = false;
                D_label.Visible = false;
                A_candi_textBox.Visible = true;
                B_candi_textBox.Visible = false;
                C_candi_textBox.Visible = false;
                D_candi_textBox.Visible = false;
            }
            else
            {
                A_label.Visible = false;
                A_candi_textBox.Visible = false;
            }
        }

        private void two_candi_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (two_candi_chBx.Checked)
            {
                one_candi_chBx.Checked = false;
                three_candi_chBx.Checked = false;
                four_candi_chBx.Checked = false;
                A_label.Visible = true;
                B_label.Visible = true;
                C_label.Visible = false;
                D_label.Visible = false;
                A_candi_textBox.Visible = true;
                B_candi_textBox.Visible = true;
                C_candi_textBox.Visible = false;
                D_candi_textBox.Visible = false;
            }
            else
            {
                A_label.Visible = false;
                B_label.Visible = false;
                A_candi_textBox.Visible = false;
                B_candi_textBox.Visible = false;

            }

        }

        private void three_candi_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (three_candi_chBx.Checked)
            {
                one_candi_chBx.Checked = false;
                two_candi_chBx.Checked = false;
                four_candi_chBx.Checked = false;
                A_label.Visible = true;
                B_label.Visible = true;
                C_label.Visible = true;
                D_label.Visible = false;
                A_candi_textBox.Visible = true;
                B_candi_textBox.Visible = true;
                C_candi_textBox.Visible = true;
                D_candi_textBox.Visible = false;
            }
            else
            {
                A_label.Visible = false;
                B_label.Visible = false;
                C_label.Visible = false;
                A_candi_textBox.Visible = false;
                B_candi_textBox.Visible = false;
                C_candi_textBox.Visible = false;
            }
        }

        private void four_candi_chBx_CheckedChanged(object sender, EventArgs e)
        {
            if (four_candi_chBx.Checked)
            {
                one_candi_chBx.Checked = false;
                two_candi_chBx.Checked = false;
                three_candi_chBx.Checked = false;
                A_label.Visible = true;
                B_label.Visible = true;
                C_label.Visible = true;
                D_label.Visible = true;
                A_candi_textBox.Visible = true;
                B_candi_textBox.Visible = true;
                C_candi_textBox.Visible = true;
                D_candi_textBox.Visible = true;
            }
            else
            {
                A_label.Visible = false;
                B_label.Visible = false;
                C_label.Visible = false;
                D_label.Visible = false;
                A_candi_textBox.Visible = false;
                B_candi_textBox.Visible = false;
                C_candi_textBox.Visible = false;
                D_candi_textBox.Visible = false;
            }
        }

        private void set_candidates_button_Click(object sender, EventArgs e)
        {
            if (one_candi_chBx.Checked == true)
            {
                if(A_candi_textBox.Text!="" && A_candi_textBox.Text.Length <= 8)
                {
                    candi_A = A_candi_textBox.Text;
                    name_To_frame(A_name, candi_A);
                    Send_frame(A_name);
                    defined_Candidates_groupBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Entre A Real Name With Length Less Than 8 Charachters");
                }
            }
            if (two_candi_chBx.Checked == true)
            {
                if (A_candi_textBox.Text != "" && B_candi_textBox.Text != "" && A_candi_textBox.Text.Length <= 8 && B_candi_textBox.Text.Length <= 8)
                {
                    candi_A = A_candi_textBox.Text;
                    candi_B = B_candi_textBox.Text;
                    name_To_frame(A_name, candi_A);
                    Send_frame(A_name);
                    Thread.Sleep(1000);
                    name_To_frame(B_name, candi_B);
                    Send_frame(B_name);
                    defined_Candidates_groupBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Entre A Real Name With Length Less Than 8 Charachters");
                }
            }
            if (three_candi_chBx.Checked == true)
            {
                if (A_candi_textBox.Text != "" && B_candi_textBox.Text != "" && C_candi_textBox.Text != "" && A_candi_textBox.Text.Length <= 8 && B_candi_textBox.Text.Length <= 8 && C_candi_textBox.Text.Length <= 8)
                {
                    candi_A = A_candi_textBox.Text;
                    candi_B = B_candi_textBox.Text;
                    candi_C = C_candi_textBox.Text;
                    name_To_frame(A_name, candi_A);
                    Send_frame(A_name);
                    Thread.Sleep(1000);
                    name_To_frame(B_name, candi_B);
                    Send_frame(B_name);
                    Thread.Sleep(1000);
                    name_To_frame(C_name, candi_C);
                    Send_frame(C_name);
                    defined_Candidates_groupBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Entre A Real Name With Length Less Than 8 Charachters");
                }
            }
            if (four_candi_chBx.Checked == true)
            {
                if (A_candi_textBox.Text != "" && B_candi_textBox.Text != "" && C_candi_textBox.Text != "" && D_candi_textBox.Text != "" && A_candi_textBox.Text.Length <= 8 && B_candi_textBox.Text.Length <= 8 && C_candi_textBox.Text.Length <= 8 && D_candi_textBox.Text.Length <= 8)
                {
                    candi_A = A_candi_textBox.Text;
                    candi_B = B_candi_textBox.Text;
                    candi_C = C_candi_textBox.Text;
                    candi_D = D_candi_textBox.Text;
                    name_To_frame(A_name, candi_A);
                    Send_frame(A_name);
                    Thread.Sleep(1000);
                    name_To_frame(B_name, candi_B);
                    Send_frame(B_name);
                    Thread.Sleep(1000);
                    name_To_frame(C_name, candi_C);
                    Send_frame(C_name);
                    Thread.Sleep(1000);
                    name_To_frame(D_name, candi_D);
                    Send_frame(D_name);
                    defined_Candidates_groupBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please Entre A Real Name With Length Less Than 8 Charachters");
                }
            }
        }

        #endregion

        #region Voting_settings
        private void voters_Names_btn_Click(object sender, EventArgs e)
        {
            if(defined_Candidates_groupBox.Enabled == false && voting_Name_textBox.Text!="")
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "Select a file";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog.Title = "Open file";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        String filename = openFileDialog.FileName;
                        Microsoft.Office.Interop.Excel.Application xl_Voters_Names = new Microsoft.Office.Interop.Excel.Application();
                        Workbook xlWorkBook_voters_Names = xl_Voters_Names.Workbooks.Open(filename, 0, true, 5, "", "",
                            true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                        Worksheet xlWorkSheet_voters_Names = xlWorkBook_voters_Names.Worksheets.get_Item(1);
                        range = xlWorkSheet_voters_Names.UsedRange;
                        voters_Numbre = range.Rows.Count;
                        voters_isVote = new int[voters_Numbre];
                        voters_Names = new List<string>(voters_Numbre);
                        voters_IDs = new int[voters_Numbre];
                        voters_Passwords = new int[voters_Numbre];
                        for (int i = 0; i < voters_Numbre; i++)
                        {
                            voters_Names.Add((range.Cells[i + 1, 1] as Range).Value2);
                            voters_IDs[i] = Convert.ToInt16((range.Cells[i + 1, 2] as Range).Value2);
                            voters_Passwords[i] = Convert.ToInt32((range.Cells[i + 1, 3] as Range).Value2);
                            voters_isVote[i] = 0;
                        }

                        xlWorkBook_voters_Names.Close(0);
                        xl_Voters_Names.Quit();
                    }
                    catch (SecurityException ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                    }
                }
                voter_Numbre[2] = Convert.ToByte(voters_Numbre / 256);
                voter_Numbre[3] = Convert.ToByte(voters_Numbre % 256);
                Send_frame(voter_Numbre);
                voters_Names_button.Enabled = false;
            }
            else if(defined_Candidates_groupBox.Enabled == true)
            {
                MessageBox.Show("Please, Set Your Vote Candidates A,B,C And D First");
            }
            else if (voting_Name_textBox.Text == "")
            {
                MessageBox.Show("Please, Set Your Voting Process Name First");
            }
        }

        private void start_Voting_button_Click(object sender, EventArgs e)
        {
            if (!defined_Candidates_groupBox.Enabled && !voters_Names_button.Enabled && voting_Name_textBox.Text.ToString()!="")
            {
                Send_frame(start_Proccess);
                result_panel.Refresh();
                draw_coordinates();
                draw_grid();
                draw_rects();
            }
            else
            {
                MessageBox.Show("Please, Load voters Names File");
            }
        }

        private void end_Voting_button_Click(object sender, EventArgs e)
        {
            if(wait_code && wait_confirm)
            {
                MessageBox.Show("Please, Wait Voter To End Voting");
            }
            else
            {
                Send_frame(end_Voting);
            }
        }

        private void save_Voting_button_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.FileName = voting_Name_textBox.Text.ToString();
            saveFileDialog.RestoreDirectory = true;
            Microsoft.Office.Interop.Excel.Application xlResult = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkBook_Result = xlResult.Workbooks.Add();
            Worksheet xlWorkSheet_Result = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook_Result.Worksheets.get_Item(1);
            if (one_candi_chBx.Checked == true)
            {
                candi_A = A_candi_textBox.Text;
                xlWorkSheet_Result.Cells[1, 1] = "A";
                xlWorkSheet_Result.Cells[1, 2] = candi_A;
                xlWorkSheet_Result.Cells[1, 3] = vote_ForA.ToString();
                xlWorkSheet_Result.Cells[2, 3] = voters_Numbre.ToString();
            }
            if (two_candi_chBx.Checked == true)
            {
                candi_A = A_candi_textBox.Text;
                candi_B = B_candi_textBox.Text;
                xlWorkSheet_Result.Cells[1, 1] = "A";
                xlWorkSheet_Result.Cells[1, 2] = candi_A;
                xlWorkSheet_Result.Cells[1, 3] = vote_ForA.ToString();
                xlWorkSheet_Result.Cells[2, 1] = "B";
                xlWorkSheet_Result.Cells[2, 2] = candi_B;
                xlWorkSheet_Result.Cells[2, 3] = vote_ForB.ToString();
                xlWorkSheet_Result.Cells[3, 3] = voters_Numbre.ToString();
            }
            if (three_candi_chBx.Checked == true)
            {
                candi_A = A_candi_textBox.Text;
                candi_B = B_candi_textBox.Text;
                candi_C = C_candi_textBox.Text;
                xlWorkSheet_Result.Cells[1, 1] = "A";
                xlWorkSheet_Result.Cells[1, 2] = candi_A;
                xlWorkSheet_Result.Cells[1, 3] = vote_ForA.ToString();
                xlWorkSheet_Result.Cells[2, 1] = "B";
                xlWorkSheet_Result.Cells[2, 2] = candi_B;
                xlWorkSheet_Result.Cells[2, 3] = vote_ForB.ToString();
                xlWorkSheet_Result.Cells[3, 1] = "C";
                xlWorkSheet_Result.Cells[3, 2] = candi_C;
                xlWorkSheet_Result.Cells[3, 3] = vote_ForC.ToString();
                xlWorkSheet_Result.Cells[4, 3] = voters_Numbre.ToString();
            }
            if (four_candi_chBx.Checked == true)
            {
                candi_A = A_candi_textBox.Text;
                candi_B = B_candi_textBox.Text;
                candi_C = C_candi_textBox.Text;
                candi_D = D_candi_textBox.Text;
                xlWorkSheet_Result.Cells[1, 1] = "A";
                xlWorkSheet_Result.Cells[1, 2] = candi_A;
                xlWorkSheet_Result.Cells[1, 3] = vote_ForA.ToString();
                xlWorkSheet_Result.Cells[2, 1] = "B";
                xlWorkSheet_Result.Cells[2, 2] = candi_B;
                xlWorkSheet_Result.Cells[2, 3] = vote_ForB.ToString();
                xlWorkSheet_Result.Cells[3, 1] = "C";
                xlWorkSheet_Result.Cells[3, 2] = candi_C;
                xlWorkSheet_Result.Cells[3, 3] = vote_ForC.ToString();
                xlWorkSheet_Result.Cells[4, 1] = "D";
                xlWorkSheet_Result.Cells[4, 2] = candi_D;
                xlWorkSheet_Result.Cells[4, 3] = vote_ForD.ToString();
                xlWorkSheet_Result.Cells[5, 3] = voters_Numbre.ToString();
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (File.Exists(filePath))
                    File.Delete(filePath);
                xlWorkBook_Result.SaveAs(filePath);
            }
            xlWorkBook_Result.Close(0);
            xlResult.Quit();
        }

        private void open_Voting_button_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "Select a file";
            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            openFileDialog.Title = "Open file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String filename = openFileDialog.FileName;
                    Microsoft.Office.Interop.Excel.Application xlResult = new Microsoft.Office.Interop.Excel.Application();
                    Workbook xlWorkBook_Result = xlResult.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Worksheet xlWorkSheet_Result = xlWorkBook_Result.Worksheets.get_Item(1);
                    range = xlWorkSheet_Result.UsedRange;
                    candi_Numbre = range.Rows.Count;
                    if (candi_Numbre == 2)
                    {
                        candi_A = ((range.Cells[1, 2] as Range).Text);
                        vote_ForA = Convert.ToInt16((range.Cells[1, 3] as Range).Value2);
                        voters_Numbre = Convert.ToInt16((range.Cells[2, 3] as Range).Value2);
                        one_candi_chBx.Checked = true;
                        A_candi_textBox.Text = candi_A;
                    }
                    if (candi_Numbre == 3)
                    {
                        candi_A = ((range.Cells[1, 2] as Range).Text);
                        vote_ForA = Convert.ToInt16((range.Cells[1, 3] as Range).Value2);
                        candi_B = ((range.Cells[2, 2] as Range).Text);
                        vote_ForB = Convert.ToInt16((range.Cells[2, 3] as Range).Value2);
                        voters_Numbre = Convert.ToInt16((range.Cells[3, 3] as Range).Value2);
                        two_candi_chBx.Checked = true;
                        A_candi_textBox.Text = candi_A;
                        B_candi_textBox.Text = candi_B;
                    }
                    if (candi_Numbre == 4)
                    {
                        candi_A = ((range.Cells[1, 2] as Range).Text); ;
                        vote_ForA = Convert.ToInt16((range.Cells[1, 3] as Range).Value2);
                        candi_B = ((range.Cells[2, 2] as Range).Text);
                        vote_ForB = Convert.ToInt16((range.Cells[2, 3] as Range).Value2);
                        candi_C = ((range.Cells[3, 2] as Range).Text);
                        vote_ForC = Convert.ToInt16((range.Cells[3, 3] as Range).Value2);
                        voters_Numbre = Convert.ToInt16((range.Cells[4, 3] as Range).Value2);
                        three_candi_chBx.Checked = true;
                        A_candi_textBox.Text = candi_A;
                        B_candi_textBox.Text = candi_B;
                        C_candi_textBox.Text = candi_C;
                    }
                    if (candi_Numbre == 5)
                    {
                        candi_A = ((range.Cells[1, 2] as Range).Text);
                        vote_ForA = Convert.ToInt16((range.Cells[1, 3] as Range).Value2);
                        candi_B = ((range.Cells[2, 2] as Range).Text);
                        vote_ForB = Convert.ToInt16((range.Cells[2, 3] as Range).Value2);
                        candi_C = ((range.Cells[3, 2] as Range).Text);
                        vote_ForC = Convert.ToInt16((range.Cells[3, 3] as Range).Value2);
                        candi_D = ((range.Cells[4, 2] as Range).Text);
                        vote_ForD = Convert.ToInt16((range.Cells[4, 3] as Range).Value2);
                        voters_Numbre = Convert.ToInt16((range.Cells[5, 3] as Range).Value2);
                        four_candi_chBx.Checked = true;
                        A_candi_textBox.Text = candi_A;
                        B_candi_textBox.Text = candi_B;
                        C_candi_textBox.Text = candi_C;
                        D_candi_textBox.Text = candi_D;
                    }
                    defined_Candidates_groupBox.Enabled = false;
                    xlWorkBook_Result.Close(0);
                    xlResult.Quit();

                    result_panel.Refresh();
                    draw_coordinates();
                    draw_grid();
                    draw_rects();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" + $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void clear_Result_button_Click(object sender, EventArgs e)
        {
            voter_percent_label.Visible = false;
            candidates_label.Visible = false;
            result_panel.Invalidate();
            defined_Candidates_groupBox.Enabled = true;
            one_candi_chBx.Checked = false;
            two_candi_chBx.Checked = false;
            three_candi_chBx.Checked = false;
            four_candi_chBx.Checked = false;
            A_label.Visible = false;
            B_label.Visible = false;
            C_label.Visible = false;
            D_label.Visible = false;
            A_candi_textBox.Visible = false;
            B_candi_textBox.Visible = false;
            C_candi_textBox.Visible = false;
            D_candi_textBox.Visible = false;
            voters_Names = new List<string>();
            voters_IDs = null;
            voters_Passwords = null;
            candi_A = null;
            candi_B = null;
            candi_C = null;
            candi_D = null;
            voters_Numbre = 0;
            vote_ForA = 0;
            vote_ForB = 0;
            vote_ForC = 0;
            vote_ForD = 0;
            candi_Numbre = -1;
            column_Width = -1;
            A_candi_textBox.Text = "";
            B_candi_textBox.Text = "";
            C_candi_textBox.Text = "";
            D_candi_textBox.Text = "";
            wait_code = false;
            wait_confirm = false;
            voters_isVote = null;
            current_voters_num = 0;
            grid = -1;
            ID = 0;
            CODE = 0;
            index = -1;
            for(int i=2;i<10;i++)
            {
                A_name[i] = 0;
                B_name[i] = 0;
                C_name[i] = 0;
                D_name[i] = 0;
                voter_Numbre[i] = 0;
                start_Proccess[i] = 0;
                voter_ID[i] = 0;
                voter_Code[i] = 0;
                voter_ID_Valid[i] = 0;
                voter_Code_Valid[i] = 0;
                voter_ID_False[i] = 0;
                voter_Code_False[i] = 0;
                voter_choose[i] = 0;
                voted_Already[i] = 0;
                end_Voting[i] = 0;
            }
            voters_Names_button.Enabled = true;
        }
        #endregion

        #region draw function
        private void draw_coordinates()
        {
            voter_percent_label.Visible = true;
            candidates_label.Visible = true;
            Pen coord_pen = new Pen(Color.Black, 2.0f);
            Graphics Graph;
            System.Drawing.Font drawFont = new System.Drawing.Font("Times new Roman", 10);
            int width = result_panel.Width;
            int height = result_panel.Height;
            int candi_num = candi_Numbre_trackBar.Value + 2;
            Graph = result_panel.CreateGraphics();
            Graph.DrawLine(coord_pen, 30, height - 30, Width, height - 30);
            Graph.DrawLine(coord_pen, 30, 0, 30, height - 30);
            for (int i = 1; i < candi_num - 1; i++)
            {
                Graph.DrawLine(coord_pen, 30 + i * (width - 30) / candi_num, height - 26, 30 + i * (width - 30) / candi_num, height - 34);
                Graph.DrawString(candidates[i - 1], drawFont, Brushes.Black, 25 + i * (width - 30) / candi_num, height - 25);
            }
            Graph.DrawLine(coord_pen, 30 + (candi_num - 1) * (width - 30) / candi_num, height - 26, 30 + (candi_num - 1) * (width - 30) / candi_num, height - 34);
            Graph.DrawString(candidates[4], drawFont, Brushes.Black, (candi_num - 1) * (width - 30) / candi_num, height - 25);
            coord_pen.Dispose();
            Graph.Dispose();
        }

        private void draw_grid()
        {
            Pen grid_pen = new Pen(Color.Gray, 0.5f);
            Graphics Graph_grid;
            System.Drawing.Font drawFont = new System.Drawing.Font("Times new Roman", 10);
            int width = result_panel.Width;
            int height = result_panel.Height;
            grid = grid_Numbre_trackBar.Value;
            Graph_grid = result_panel.CreateGraphics();
            int candi_num = candi_Numbre_trackBar.Value + 2;
            for (int i = 1; i < candi_num; i++)
            {
                Graph_grid.DrawLine(grid_pen, 30 + i * (width - 30) / candi_num, height - 30, 30 + i * (width - 30) / candi_num, 0);
            }
            for (int i = 1; i < grid; i++)
            {
                Graph_grid.DrawLine(grid_pen, 30, height - 29 - i * ((height - 29) / grid), width, height - 29 - i * ((height - 29) / grid));
                Graph_grid.DrawString((100 / grid * i).ToString() + "%", drawFont, Brushes.Black, 2, height - 36 - i * ((height - 29) / grid));
            }
            grid_pen.Dispose();
            Graph_grid.Dispose();
        }

        private void draw_rects()
        {
            Pen rect_pen = new Pen(Color.Gray, 0.5f);
            Graphics Graph_rect;
            System.Drawing.Font drawFont = new System.Drawing.Font("Times new Roman", 10);
            int width = result_panel.Width;
            int height = result_panel.Height;
            int candi_num = candi_Numbre_trackBar.Value + 2;
            float[] vote = new float[4];
            vote[0] = vote_ForA;
            vote[1] = vote_ForB;
            vote[2] = vote_ForC;
            vote[3] = vote_ForD;
            float real_vote = vote_ForA + vote_ForB + vote_ForC + vote_ForD;
            column_Width = columne_Wigth_trackBar.Value;
            grid = grid_Numbre_trackBar.Value;
            Graph_rect = result_panel.CreateGraphics();
            float scale = (float)(height - 30) / voters_Numbre;
            for (int i = 1; i < candi_num - 1; i++)
            {
                Graph_rect.FillRectangle(color[i - 1], 30 - column_Width + i * (width - 30) /
                    candi_num, height - 30 - (vote[i - 1] * scale), 2 * column_Width, (vote[i - 1] * scale));
            }
            Graph_rect.FillRectangle(color[4], 30 - column_Width + (candi_num - 1) * (width - 30) /
                candi_num, height - 30 - ((voters_Numbre - real_vote) * scale), 2 * column_Width, ((voters_Numbre - real_vote) * scale));
            rect_pen.Dispose();
            Graph_rect.Dispose();
        }

        private void candi_Numbre_trackBar_ValueChanged(object sender, EventArgs e)
        {
            result_panel.Refresh();
            draw_coordinates();
            draw_grid();
            draw_rects();
        }

        private void grid_Numbre_trackBar_ValueChanged(object sender, EventArgs e)
        {
            result_panel.Refresh();
            draw_coordinates();
            draw_grid();
            draw_rects();
        }

        private void columne_Wigth_trackBar_ValueChanged(object sender, EventArgs e)
        {
            result_panel.Refresh();
            draw_coordinates();
            draw_grid();
            draw_rects();
        }

        #endregion

    }
}
