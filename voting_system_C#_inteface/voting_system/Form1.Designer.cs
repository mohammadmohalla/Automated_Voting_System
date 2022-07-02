namespace voting_system
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.voters_Names_button = new System.Windows.Forms.Button();
            this.start_Voting_button = new System.Windows.Forms.Button();
            this.end_Voting_button = new System.Windows.Forms.Button();
            this.one_candi_chBx = new System.Windows.Forms.CheckBox();
            this.defined_Candidates_groupBox = new System.Windows.Forms.GroupBox();
            this.set_candidates_button = new System.Windows.Forms.Button();
            this.D_candi_textBox = new System.Windows.Forms.TextBox();
            this.C_candi_textBox = new System.Windows.Forms.TextBox();
            this.B_candi_textBox = new System.Windows.Forms.TextBox();
            this.A_candi_textBox = new System.Windows.Forms.TextBox();
            this.D_label = new System.Windows.Forms.Label();
            this.C_label = new System.Windows.Forms.Label();
            this.B_label = new System.Windows.Forms.Label();
            this.A_label = new System.Windows.Forms.Label();
            this.four_candi_chBx = new System.Windows.Forms.CheckBox();
            this.three_candi_chBx = new System.Windows.Forms.CheckBox();
            this.two_candi_chBx = new System.Windows.Forms.CheckBox();
            this.serial_Settings_groupBox = new System.Windows.Forms.GroupBox();
            this.PortName_label = new System.Windows.Forms.Label();
            this.ShowNote_label = new System.Windows.Forms.Label();
            this.ClosePort_btn = new System.Windows.Forms.Button();
            this.Note_label = new System.Windows.Forms.Label();
            this.PortName_comboBox = new System.Windows.Forms.ComboBox();
            this.OpenPort_btn = new System.Windows.Forms.Button();
            this.BaudRate_comboBox = new System.Windows.Forms.ComboBox();
            this.StopBits_label = new System.Windows.Forms.Label();
            this.DataBits_comboBox = new System.Windows.Forms.ComboBox();
            this.Parity_label = new System.Windows.Forms.Label();
            this.Parity_comboBox = new System.Windows.Forms.ComboBox();
            this.DataBits_label = new System.Windows.Forms.Label();
            this.StopBits_comboBox = new System.Windows.Forms.ComboBox();
            this.BaudRate_label = new System.Windows.Forms.Label();
            this.voting_Result_groupBox = new System.Windows.Forms.GroupBox();
            this.result_panel = new System.Windows.Forms.Panel();
            this.vote_Settings_groupBox = new System.Windows.Forms.GroupBox();
            this.clear_Result_button = new System.Windows.Forms.Button();
            this.open_Voting_button = new System.Windows.Forms.Button();
            this.save_Voting_button = new System.Windows.Forms.Button();
            this.grid_Numbre_trackBar = new System.Windows.Forms.TrackBar();
            this.columne_Wigth_trackBar = new System.Windows.Forms.TrackBar();
            this.candi_Numbre_trackBar = new System.Windows.Forms.TrackBar();
            this.result_Drawing_groupBox = new System.Windows.Forms.GroupBox();
            this.image_Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.voting_Name_textBox = new System.Windows.Forms.TextBox();
            this.voter_percent_label = new System.Windows.Forms.Label();
            this.candidates_label = new System.Windows.Forms.Label();
            this.defined_Candidates_groupBox.SuspendLayout();
            this.serial_Settings_groupBox.SuspendLayout();
            this.voting_Result_groupBox.SuspendLayout();
            this.result_panel.SuspendLayout();
            this.vote_Settings_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Numbre_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columne_Wigth_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candi_Numbre_trackBar)).BeginInit();
            this.result_Drawing_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // voters_Names_button
            // 
            this.voters_Names_button.Location = new System.Drawing.Point(17, 25);
            this.voters_Names_button.Name = "voters_Names_button";
            this.voters_Names_button.Size = new System.Drawing.Size(195, 30);
            this.voters_Names_button.TabIndex = 30;
            this.voters_Names_button.Text = "Load Voters Name File";
            this.voters_Names_button.UseVisualStyleBackColor = true;
            this.voters_Names_button.Click += new System.EventHandler(this.voters_Names_btn_Click);
            // 
            // start_Voting_button
            // 
            this.start_Voting_button.Location = new System.Drawing.Point(17, 71);
            this.start_Voting_button.Name = "start_Voting_button";
            this.start_Voting_button.Size = new System.Drawing.Size(195, 30);
            this.start_Voting_button.TabIndex = 32;
            this.start_Voting_button.Text = "Start Voting Process";
            this.start_Voting_button.UseVisualStyleBackColor = true;
            this.start_Voting_button.Click += new System.EventHandler(this.start_Voting_button_Click);
            // 
            // end_Voting_button
            // 
            this.end_Voting_button.Location = new System.Drawing.Point(17, 117);
            this.end_Voting_button.Name = "end_Voting_button";
            this.end_Voting_button.Size = new System.Drawing.Size(195, 30);
            this.end_Voting_button.TabIndex = 33;
            this.end_Voting_button.Text = "End Voting Process";
            this.end_Voting_button.UseVisualStyleBackColor = true;
            this.end_Voting_button.Click += new System.EventHandler(this.end_Voting_button_Click);
            // 
            // one_candi_chBx
            // 
            this.one_candi_chBx.AutoSize = true;
            this.one_candi_chBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.one_candi_chBx.ForeColor = System.Drawing.Color.Black;
            this.one_candi_chBx.Location = new System.Drawing.Point(14, 28);
            this.one_candi_chBx.Name = "one_candi_chBx";
            this.one_candi_chBx.Size = new System.Drawing.Size(128, 23);
            this.one_candi_chBx.TabIndex = 0;
            this.one_candi_chBx.Text = "One Candidate";
            this.one_candi_chBx.UseVisualStyleBackColor = true;
            this.one_candi_chBx.CheckedChanged += new System.EventHandler(this.one_candi_chBx_CheckedChanged);
            // 
            // defined_Candidates_groupBox
            // 
            this.defined_Candidates_groupBox.Controls.Add(this.set_candidates_button);
            this.defined_Candidates_groupBox.Controls.Add(this.D_candi_textBox);
            this.defined_Candidates_groupBox.Controls.Add(this.C_candi_textBox);
            this.defined_Candidates_groupBox.Controls.Add(this.B_candi_textBox);
            this.defined_Candidates_groupBox.Controls.Add(this.A_candi_textBox);
            this.defined_Candidates_groupBox.Controls.Add(this.D_label);
            this.defined_Candidates_groupBox.Controls.Add(this.C_label);
            this.defined_Candidates_groupBox.Controls.Add(this.B_label);
            this.defined_Candidates_groupBox.Controls.Add(this.A_label);
            this.defined_Candidates_groupBox.Controls.Add(this.four_candi_chBx);
            this.defined_Candidates_groupBox.Controls.Add(this.three_candi_chBx);
            this.defined_Candidates_groupBox.Controls.Add(this.two_candi_chBx);
            this.defined_Candidates_groupBox.Controls.Add(this.one_candi_chBx);
            this.defined_Candidates_groupBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defined_Candidates_groupBox.ForeColor = System.Drawing.Color.Red;
            this.defined_Candidates_groupBox.Location = new System.Drawing.Point(245, 6);
            this.defined_Candidates_groupBox.Name = "defined_Candidates_groupBox";
            this.defined_Candidates_groupBox.Size = new System.Drawing.Size(548, 187);
            this.defined_Candidates_groupBox.TabIndex = 34;
            this.defined_Candidates_groupBox.TabStop = false;
            this.defined_Candidates_groupBox.Text = "Defined Candidates";
            // 
            // set_candidates_button
            // 
            this.set_candidates_button.ForeColor = System.Drawing.Color.Black;
            this.set_candidates_button.Location = new System.Drawing.Point(14, 138);
            this.set_candidates_button.Name = "set_candidates_button";
            this.set_candidates_button.Size = new System.Drawing.Size(284, 34);
            this.set_candidates_button.TabIndex = 12;
            this.set_candidates_button.Text = "Set Candidates";
            this.set_candidates_button.UseVisualStyleBackColor = true;
            this.set_candidates_button.Click += new System.EventHandler(this.set_candidates_button_Click);
            // 
            // D_candi_textBox
            // 
            this.D_candi_textBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.D_candi_textBox.Location = new System.Drawing.Point(410, 110);
            this.D_candi_textBox.Name = "D_candi_textBox";
            this.D_candi_textBox.Size = new System.Drawing.Size(128, 23);
            this.D_candi_textBox.TabIndex = 11;
            // 
            // C_candi_textBox
            // 
            this.C_candi_textBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_candi_textBox.Location = new System.Drawing.Point(410, 83);
            this.C_candi_textBox.Name = "C_candi_textBox";
            this.C_candi_textBox.Size = new System.Drawing.Size(128, 23);
            this.C_candi_textBox.TabIndex = 10;
            // 
            // B_candi_textBox
            // 
            this.B_candi_textBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_candi_textBox.Location = new System.Drawing.Point(410, 56);
            this.B_candi_textBox.Name = "B_candi_textBox";
            this.B_candi_textBox.Size = new System.Drawing.Size(128, 23);
            this.B_candi_textBox.TabIndex = 9;
            // 
            // A_candi_textBox
            // 
            this.A_candi_textBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_candi_textBox.Location = new System.Drawing.Point(410, 29);
            this.A_candi_textBox.Name = "A_candi_textBox";
            this.A_candi_textBox.Size = new System.Drawing.Size(128, 23);
            this.A_candi_textBox.TabIndex = 8;
            // 
            // D_label
            // 
            this.D_label.AutoSize = true;
            this.D_label.ForeColor = System.Drawing.Color.Green;
            this.D_label.Location = new System.Drawing.Point(271, 106);
            this.D_label.Name = "D_label";
            this.D_label.Size = new System.Drawing.Size(28, 25);
            this.D_label.TabIndex = 7;
            this.D_label.Text = "D";
            // 
            // C_label
            // 
            this.C_label.AutoSize = true;
            this.C_label.ForeColor = System.Drawing.Color.Green;
            this.C_label.Location = new System.Drawing.Point(271, 79);
            this.C_label.Name = "C_label";
            this.C_label.Size = new System.Drawing.Size(28, 25);
            this.C_label.TabIndex = 6;
            this.C_label.Text = "C";
            // 
            // B_label
            // 
            this.B_label.AutoSize = true;
            this.B_label.ForeColor = System.Drawing.Color.Green;
            this.B_label.Location = new System.Drawing.Point(271, 53);
            this.B_label.Name = "B_label";
            this.B_label.Size = new System.Drawing.Size(27, 25);
            this.B_label.TabIndex = 5;
            this.B_label.Text = "B";
            // 
            // A_label
            // 
            this.A_label.AutoSize = true;
            this.A_label.ForeColor = System.Drawing.Color.Green;
            this.A_label.Location = new System.Drawing.Point(271, 25);
            this.A_label.Name = "A_label";
            this.A_label.Size = new System.Drawing.Size(27, 25);
            this.A_label.TabIndex = 4;
            this.A_label.Text = "A";
            // 
            // four_candi_chBx
            // 
            this.four_candi_chBx.AutoSize = true;
            this.four_candi_chBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.four_candi_chBx.ForeColor = System.Drawing.Color.Black;
            this.four_candi_chBx.Location = new System.Drawing.Point(14, 109);
            this.four_candi_chBx.Name = "four_candi_chBx";
            this.four_candi_chBx.Size = new System.Drawing.Size(131, 23);
            this.four_candi_chBx.TabIndex = 3;
            this.four_candi_chBx.Text = "Four Candidate";
            this.four_candi_chBx.UseVisualStyleBackColor = true;
            this.four_candi_chBx.CheckedChanged += new System.EventHandler(this.four_candi_chBx_CheckedChanged);
            // 
            // three_candi_chBx
            // 
            this.three_candi_chBx.AutoSize = true;
            this.three_candi_chBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.three_candi_chBx.ForeColor = System.Drawing.Color.Black;
            this.three_candi_chBx.Location = new System.Drawing.Point(14, 82);
            this.three_candi_chBx.Name = "three_candi_chBx";
            this.three_candi_chBx.Size = new System.Drawing.Size(140, 23);
            this.three_candi_chBx.TabIndex = 2;
            this.three_candi_chBx.Text = "Three Candidate";
            this.three_candi_chBx.UseVisualStyleBackColor = true;
            this.three_candi_chBx.CheckedChanged += new System.EventHandler(this.three_candi_chBx_CheckedChanged);
            // 
            // two_candi_chBx
            // 
            this.two_candi_chBx.AutoSize = true;
            this.two_candi_chBx.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.two_candi_chBx.ForeColor = System.Drawing.Color.Black;
            this.two_candi_chBx.Location = new System.Drawing.Point(14, 55);
            this.two_candi_chBx.Name = "two_candi_chBx";
            this.two_candi_chBx.Size = new System.Drawing.Size(127, 23);
            this.two_candi_chBx.TabIndex = 1;
            this.two_candi_chBx.Text = "Two Candidate";
            this.two_candi_chBx.UseVisualStyleBackColor = true;
            this.two_candi_chBx.CheckedChanged += new System.EventHandler(this.two_candi_chBx_CheckedChanged);
            // 
            // serial_Settings_groupBox
            // 
            this.serial_Settings_groupBox.Controls.Add(this.PortName_label);
            this.serial_Settings_groupBox.Controls.Add(this.ShowNote_label);
            this.serial_Settings_groupBox.Controls.Add(this.ClosePort_btn);
            this.serial_Settings_groupBox.Controls.Add(this.Note_label);
            this.serial_Settings_groupBox.Controls.Add(this.PortName_comboBox);
            this.serial_Settings_groupBox.Controls.Add(this.OpenPort_btn);
            this.serial_Settings_groupBox.Controls.Add(this.BaudRate_comboBox);
            this.serial_Settings_groupBox.Controls.Add(this.StopBits_label);
            this.serial_Settings_groupBox.Controls.Add(this.DataBits_comboBox);
            this.serial_Settings_groupBox.Controls.Add(this.Parity_label);
            this.serial_Settings_groupBox.Controls.Add(this.Parity_comboBox);
            this.serial_Settings_groupBox.Controls.Add(this.DataBits_label);
            this.serial_Settings_groupBox.Controls.Add(this.StopBits_comboBox);
            this.serial_Settings_groupBox.Controls.Add(this.BaudRate_label);
            this.serial_Settings_groupBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serial_Settings_groupBox.Location = new System.Drawing.Point(12, 12);
            this.serial_Settings_groupBox.Name = "serial_Settings_groupBox";
            this.serial_Settings_groupBox.Size = new System.Drawing.Size(227, 220);
            this.serial_Settings_groupBox.TabIndex = 49;
            this.serial_Settings_groupBox.TabStop = false;
            this.serial_Settings_groupBox.Text = "Serial Port Settings";
            // 
            // PortName_label
            // 
            this.PortName_label.AutoSize = true;
            this.PortName_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortName_label.Location = new System.Drawing.Point(14, 26);
            this.PortName_label.Name = "PortName_label";
            this.PortName_label.Size = new System.Drawing.Size(59, 15);
            this.PortName_label.TabIndex = 54;
            this.PortName_label.Text = "Port Name";
            // 
            // ShowNote_label
            // 
            this.ShowNote_label.AutoSize = true;
            this.ShowNote_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowNote_label.Location = new System.Drawing.Point(88, 163);
            this.ShowNote_label.Name = "ShowNote_label";
            this.ShowNote_label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowNote_label.Size = new System.Drawing.Size(0, 15);
            this.ShowNote_label.TabIndex = 61;
            // 
            // ClosePort_btn
            // 
            this.ClosePort_btn.Enabled = false;
            this.ClosePort_btn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClosePort_btn.Location = new System.Drawing.Point(137, 191);
            this.ClosePort_btn.Name = "ClosePort_btn";
            this.ClosePort_btn.Size = new System.Drawing.Size(75, 23);
            this.ClosePort_btn.TabIndex = 62;
            this.ClosePort_btn.Text = "Close Port";
            this.ClosePort_btn.UseVisualStyleBackColor = true;
            this.ClosePort_btn.Click += new System.EventHandler(this.ClosePort_btn_Click);
            // 
            // Note_label
            // 
            this.Note_label.AutoSize = true;
            this.Note_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note_label.Location = new System.Drawing.Point(14, 163);
            this.Note_label.Name = "Note_label";
            this.Note_label.Size = new System.Drawing.Size(40, 15);
            this.Note_label.TabIndex = 60;
            this.Note_label.Text = "Note : ";
            // 
            // PortName_comboBox
            // 
            this.PortName_comboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortName_comboBox.FormattingEnabled = true;
            this.PortName_comboBox.Location = new System.Drawing.Point(91, 23);
            this.PortName_comboBox.Name = "PortName_comboBox";
            this.PortName_comboBox.Size = new System.Drawing.Size(121, 23);
            this.PortName_comboBox.TabIndex = 49;
            // 
            // OpenPort_btn
            // 
            this.OpenPort_btn.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPort_btn.Location = new System.Drawing.Point(17, 192);
            this.OpenPort_btn.Name = "OpenPort_btn";
            this.OpenPort_btn.Size = new System.Drawing.Size(75, 23);
            this.OpenPort_btn.TabIndex = 59;
            this.OpenPort_btn.Text = "Open Port";
            this.OpenPort_btn.UseVisualStyleBackColor = true;
            this.OpenPort_btn.Click += new System.EventHandler(this.OpenPort_btn_Click);
            // 
            // BaudRate_comboBox
            // 
            this.BaudRate_comboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRate_comboBox.FormattingEnabled = true;
            this.BaudRate_comboBox.Location = new System.Drawing.Point(91, 50);
            this.BaudRate_comboBox.Name = "BaudRate_comboBox";
            this.BaudRate_comboBox.Size = new System.Drawing.Size(121, 23);
            this.BaudRate_comboBox.TabIndex = 50;
            // 
            // StopBits_label
            // 
            this.StopBits_label.AutoSize = true;
            this.StopBits_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBits_label.Location = new System.Drawing.Point(14, 131);
            this.StopBits_label.Name = "StopBits_label";
            this.StopBits_label.Size = new System.Drawing.Size(53, 15);
            this.StopBits_label.TabIndex = 58;
            this.StopBits_label.Text = "Stop Bits";
            // 
            // DataBits_comboBox
            // 
            this.DataBits_comboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataBits_comboBox.FormattingEnabled = true;
            this.DataBits_comboBox.Location = new System.Drawing.Point(91, 77);
            this.DataBits_comboBox.Name = "DataBits_comboBox";
            this.DataBits_comboBox.Size = new System.Drawing.Size(121, 23);
            this.DataBits_comboBox.TabIndex = 51;
            // 
            // Parity_label
            // 
            this.Parity_label.AutoSize = true;
            this.Parity_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parity_label.Location = new System.Drawing.Point(14, 107);
            this.Parity_label.Name = "Parity_label";
            this.Parity_label.Size = new System.Drawing.Size(37, 15);
            this.Parity_label.TabIndex = 57;
            this.Parity_label.Text = "Parity";
            // 
            // Parity_comboBox
            // 
            this.Parity_comboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parity_comboBox.FormattingEnabled = true;
            this.Parity_comboBox.Location = new System.Drawing.Point(91, 104);
            this.Parity_comboBox.Name = "Parity_comboBox";
            this.Parity_comboBox.Size = new System.Drawing.Size(121, 23);
            this.Parity_comboBox.TabIndex = 52;
            // 
            // DataBits_label
            // 
            this.DataBits_label.AutoSize = true;
            this.DataBits_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataBits_label.Location = new System.Drawing.Point(14, 80);
            this.DataBits_label.Name = "DataBits_label";
            this.DataBits_label.Size = new System.Drawing.Size(53, 15);
            this.DataBits_label.TabIndex = 56;
            this.DataBits_label.Text = "Data Bits";
            // 
            // StopBits_comboBox
            // 
            this.StopBits_comboBox.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopBits_comboBox.FormattingEnabled = true;
            this.StopBits_comboBox.Location = new System.Drawing.Point(91, 131);
            this.StopBits_comboBox.Name = "StopBits_comboBox";
            this.StopBits_comboBox.Size = new System.Drawing.Size(121, 23);
            this.StopBits_comboBox.TabIndex = 53;
            // 
            // BaudRate_label
            // 
            this.BaudRate_label.AutoSize = true;
            this.BaudRate_label.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRate_label.Location = new System.Drawing.Point(14, 53);
            this.BaudRate_label.Name = "BaudRate_label";
            this.BaudRate_label.Size = new System.Drawing.Size(57, 15);
            this.BaudRate_label.TabIndex = 55;
            this.BaudRate_label.Text = "Baud Rate";
            // 
            // voting_Result_groupBox
            // 
            this.voting_Result_groupBox.Controls.Add(this.result_panel);
            this.voting_Result_groupBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voting_Result_groupBox.ForeColor = System.Drawing.Color.Red;
            this.voting_Result_groupBox.Location = new System.Drawing.Point(247, 232);
            this.voting_Result_groupBox.Name = "voting_Result_groupBox";
            this.voting_Result_groupBox.Size = new System.Drawing.Size(546, 296);
            this.voting_Result_groupBox.TabIndex = 50;
            this.voting_Result_groupBox.TabStop = false;
            this.voting_Result_groupBox.Text = "Voting Result";
            // 
            // result_panel
            // 
            this.result_panel.BackColor = System.Drawing.Color.White;
            this.result_panel.Controls.Add(this.candidates_label);
            this.result_panel.Controls.Add(this.voter_percent_label);
            this.result_panel.Location = new System.Drawing.Point(12, 50);
            this.result_panel.Name = "result_panel";
            this.result_panel.Size = new System.Drawing.Size(524, 258);
            this.result_panel.TabIndex = 0;
            // 
            // vote_Settings_groupBox
            // 
            this.vote_Settings_groupBox.Controls.Add(this.clear_Result_button);
            this.vote_Settings_groupBox.Controls.Add(this.open_Voting_button);
            this.vote_Settings_groupBox.Controls.Add(this.save_Voting_button);
            this.vote_Settings_groupBox.Controls.Add(this.end_Voting_button);
            this.vote_Settings_groupBox.Controls.Add(this.start_Voting_button);
            this.vote_Settings_groupBox.Controls.Add(this.voters_Names_button);
            this.vote_Settings_groupBox.Location = new System.Drawing.Point(12, 232);
            this.vote_Settings_groupBox.Name = "vote_Settings_groupBox";
            this.vote_Settings_groupBox.Size = new System.Drawing.Size(227, 296);
            this.vote_Settings_groupBox.TabIndex = 51;
            this.vote_Settings_groupBox.TabStop = false;
            this.vote_Settings_groupBox.Text = "Voting Settings";
            // 
            // clear_Result_button
            // 
            this.clear_Result_button.Location = new System.Drawing.Point(16, 251);
            this.clear_Result_button.Name = "clear_Result_button";
            this.clear_Result_button.Size = new System.Drawing.Size(195, 30);
            this.clear_Result_button.TabIndex = 36;
            this.clear_Result_button.Text = "Clear Result";
            this.clear_Result_button.UseVisualStyleBackColor = true;
            this.clear_Result_button.Click += new System.EventHandler(this.clear_Result_button_Click);
            // 
            // open_Voting_button
            // 
            this.open_Voting_button.Location = new System.Drawing.Point(17, 207);
            this.open_Voting_button.Name = "open_Voting_button";
            this.open_Voting_button.Size = new System.Drawing.Size(195, 30);
            this.open_Voting_button.TabIndex = 35;
            this.open_Voting_button.Text = "Open Voting Result";
            this.open_Voting_button.UseVisualStyleBackColor = true;
            this.open_Voting_button.Click += new System.EventHandler(this.open_Voting_button_Click);
            // 
            // save_Voting_button
            // 
            this.save_Voting_button.Location = new System.Drawing.Point(17, 163);
            this.save_Voting_button.Name = "save_Voting_button";
            this.save_Voting_button.Size = new System.Drawing.Size(195, 30);
            this.save_Voting_button.TabIndex = 34;
            this.save_Voting_button.Text = "Save Voting Result";
            this.save_Voting_button.UseVisualStyleBackColor = true;
            this.save_Voting_button.Click += new System.EventHandler(this.save_Voting_button_Click);
            // 
            // grid_Numbre_trackBar
            // 
            this.grid_Numbre_trackBar.LargeChange = 1;
            this.grid_Numbre_trackBar.Location = new System.Drawing.Point(6, 146);
            this.grid_Numbre_trackBar.Name = "grid_Numbre_trackBar";
            this.grid_Numbre_trackBar.Size = new System.Drawing.Size(209, 45);
            this.grid_Numbre_trackBar.TabIndex = 52;
            this.grid_Numbre_trackBar.ValueChanged += new System.EventHandler(this.grid_Numbre_trackBar_ValueChanged);
            // 
            // columne_Wigth_trackBar
            // 
            this.columne_Wigth_trackBar.LargeChange = 1;
            this.columne_Wigth_trackBar.Location = new System.Drawing.Point(6, 252);
            this.columne_Wigth_trackBar.Name = "columne_Wigth_trackBar";
            this.columne_Wigth_trackBar.Size = new System.Drawing.Size(209, 45);
            this.columne_Wigth_trackBar.TabIndex = 53;
            this.columne_Wigth_trackBar.ValueChanged += new System.EventHandler(this.columne_Wigth_trackBar_ValueChanged);
            // 
            // candi_Numbre_trackBar
            // 
            this.candi_Numbre_trackBar.LargeChange = 1;
            this.candi_Numbre_trackBar.Location = new System.Drawing.Point(6, 60);
            this.candi_Numbre_trackBar.Name = "candi_Numbre_trackBar";
            this.candi_Numbre_trackBar.Size = new System.Drawing.Size(210, 45);
            this.candi_Numbre_trackBar.TabIndex = 54;
            this.candi_Numbre_trackBar.ValueChanged += new System.EventHandler(this.candi_Numbre_trackBar_ValueChanged);
            // 
            // result_Drawing_groupBox
            // 
            this.result_Drawing_groupBox.Controls.Add(this.candi_Numbre_trackBar);
            this.result_Drawing_groupBox.Controls.Add(this.grid_Numbre_trackBar);
            this.result_Drawing_groupBox.Controls.Add(this.columne_Wigth_trackBar);
            this.result_Drawing_groupBox.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_Drawing_groupBox.ForeColor = System.Drawing.Color.Red;
            this.result_Drawing_groupBox.Location = new System.Drawing.Point(805, 216);
            this.result_Drawing_groupBox.Name = "result_Drawing_groupBox";
            this.result_Drawing_groupBox.Size = new System.Drawing.Size(221, 312);
            this.result_Drawing_groupBox.TabIndex = 55;
            this.result_Drawing_groupBox.TabStop = false;
            this.result_Drawing_groupBox.Text = "Result Drawing";
            // 
            // image_Panel
            // 
            this.image_Panel.BackgroundImage = global::voting_system.Properties.Resources.symbol;
            this.image_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.image_Panel.Location = new System.Drawing.Point(805, 6);
            this.image_Panel.Name = "image_Panel";
            this.image_Panel.Size = new System.Drawing.Size(221, 204);
            this.image_Panel.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(256, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 57;
            this.label1.Text = "Voting Proccess Name";
            // 
            // voting_Name_textBox
            // 
            this.voting_Name_textBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voting_Name_textBox.Location = new System.Drawing.Point(521, 205);
            this.voting_Name_textBox.Name = "voting_Name_textBox";
            this.voting_Name_textBox.Size = new System.Drawing.Size(262, 23);
            this.voting_Name_textBox.TabIndex = 58;
            // 
            // voter_percent_label
            // 
            this.voter_percent_label.AutoSize = true;
            this.voter_percent_label.BackColor = System.Drawing.Color.White;
            this.voter_percent_label.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.voter_percent_label.ForeColor = System.Drawing.Color.Black;
            this.voter_percent_label.Location = new System.Drawing.Point(1, 1);
            this.voter_percent_label.MaximumSize = new System.Drawing.Size(100, 60);
            this.voter_percent_label.Name = "voter_percent_label";
            this.voter_percent_label.Size = new System.Drawing.Size(60, 12);
            this.voter_percent_label.TabIndex = 0;
            this.voter_percent_label.Text = "voter percent";
            this.voter_percent_label.Visible = false;
            // 
            // candidates_label
            // 
            this.candidates_label.AutoSize = true;
            this.candidates_label.BackColor = System.Drawing.Color.White;
            this.candidates_label.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.candidates_label.ForeColor = System.Drawing.Color.Black;
            this.candidates_label.Location = new System.Drawing.Point(469, 214);
            this.candidates_label.Margin = new System.Windows.Forms.Padding(3);
            this.candidates_label.MaximumSize = new System.Drawing.Size(55, 60);
            this.candidates_label.Name = "candidates_label";
            this.candidates_label.Size = new System.Drawing.Size(51, 12);
            this.candidates_label.TabIndex = 1;
            this.candidates_label.Text = "candidates";
            this.candidates_label.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 540);
            this.Controls.Add(this.voting_Name_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.image_Panel);
            this.Controls.Add(this.result_Drawing_groupBox);
            this.Controls.Add(this.vote_Settings_groupBox);
            this.Controls.Add(this.voting_Result_groupBox);
            this.Controls.Add(this.serial_Settings_groupBox);
            this.Controls.Add(this.defined_Candidates_groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "Form1";
            this.Text = "Automated Voting System";
            this.defined_Candidates_groupBox.ResumeLayout(false);
            this.defined_Candidates_groupBox.PerformLayout();
            this.serial_Settings_groupBox.ResumeLayout(false);
            this.serial_Settings_groupBox.PerformLayout();
            this.voting_Result_groupBox.ResumeLayout(false);
            this.result_panel.ResumeLayout(false);
            this.result_panel.PerformLayout();
            this.vote_Settings_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Numbre_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columne_Wigth_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candi_Numbre_trackBar)).EndInit();
            this.result_Drawing_groupBox.ResumeLayout(false);
            this.result_Drawing_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button voters_Names_button;
        private System.Windows.Forms.Button start_Voting_button;
        private System.Windows.Forms.Button end_Voting_button;
        private System.Windows.Forms.CheckBox one_candi_chBx;
        private System.Windows.Forms.GroupBox defined_Candidates_groupBox;
        private System.Windows.Forms.CheckBox four_candi_chBx;
        private System.Windows.Forms.CheckBox three_candi_chBx;
        private System.Windows.Forms.CheckBox two_candi_chBx;
        private System.Windows.Forms.GroupBox serial_Settings_groupBox;
        private System.Windows.Forms.Label PortName_label;
        private System.Windows.Forms.Label ShowNote_label;
        private System.Windows.Forms.Button ClosePort_btn;
        private System.Windows.Forms.Label Note_label;
        private System.Windows.Forms.ComboBox PortName_comboBox;
        private System.Windows.Forms.Button OpenPort_btn;
        private System.Windows.Forms.ComboBox BaudRate_comboBox;
        private System.Windows.Forms.Label StopBits_label;
        private System.Windows.Forms.ComboBox DataBits_comboBox;
        private System.Windows.Forms.Label Parity_label;
        private System.Windows.Forms.ComboBox Parity_comboBox;
        private System.Windows.Forms.Label DataBits_label;
        private System.Windows.Forms.ComboBox StopBits_comboBox;
        private System.Windows.Forms.Label BaudRate_label;
        private System.Windows.Forms.Label D_label;
        private System.Windows.Forms.Label C_label;
        private System.Windows.Forms.Label B_label;
        private System.Windows.Forms.Label A_label;
        private System.Windows.Forms.TextBox D_candi_textBox;
        private System.Windows.Forms.TextBox C_candi_textBox;
        private System.Windows.Forms.TextBox B_candi_textBox;
        private System.Windows.Forms.TextBox A_candi_textBox;
        private System.Windows.Forms.Button set_candidates_button;
        private System.Windows.Forms.GroupBox voting_Result_groupBox;
        private System.Windows.Forms.Panel result_panel;
        private System.Windows.Forms.GroupBox vote_Settings_groupBox;
        private System.Windows.Forms.Button open_Voting_button;
        private System.Windows.Forms.Button save_Voting_button;
        private System.Windows.Forms.Button clear_Result_button;
        private System.Windows.Forms.TrackBar grid_Numbre_trackBar;
        private System.Windows.Forms.TrackBar columne_Wigth_trackBar;
        private System.Windows.Forms.TrackBar candi_Numbre_trackBar;
        private System.Windows.Forms.GroupBox result_Drawing_groupBox;
        private System.Windows.Forms.Panel image_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox voting_Name_textBox;
        private System.Windows.Forms.Label voter_percent_label;
        private System.Windows.Forms.Label candidates_label;
    }
}

