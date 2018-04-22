namespace PlotControl
{
    partial class SerialControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStopDrawing = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstSerial = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDrawOnPlotter = new System.Windows.Forms.Button();
            this.btnParseBoardForPlotter = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbComPorts = new System.Windows.Forms.ComboBox();
            this.btnConnectSerial = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Controls.Add(this.btnPause);
            this.groupBox4.Controls.Add(this.btnStopDrawing);
            this.groupBox4.Controls.Add(this.lstSerial);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(5, 183);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 292);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Serial";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(156, 19);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(59, 23);
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "toggle";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStopDrawing
            // 
            this.btnStopDrawing.Location = new System.Drawing.Point(221, 19);
            this.btnStopDrawing.Name = "btnStopDrawing";
            this.btnStopDrawing.Size = new System.Drawing.Size(59, 23);
            this.btnStopDrawing.TabIndex = 3;
            this.btnStopDrawing.Text = "STOP";
            this.btnStopDrawing.UseVisualStyleBackColor = true;
            this.btnStopDrawing.Click += new System.EventHandler(this.btnStopDrawing_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 24);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "lblStatus";
            // 
            // lstSerial
            // 
            this.lstSerial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstSerial.FormattingEnabled = true;
            this.lstSerial.Location = new System.Drawing.Point(3, 51);
            this.lstSerial.Name = "lstSerial";
            this.lstSerial.Size = new System.Drawing.Size(280, 238);
            this.lstSerial.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDrawOnPlotter);
            this.groupBox3.Controls.Add(this.btnParseBoardForPlotter);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(5, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 60);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Draw";
            // 
            // btnDrawOnPlotter
            // 
            this.btnDrawOnPlotter.Location = new System.Drawing.Point(148, 19);
            this.btnDrawOnPlotter.Name = "btnDrawOnPlotter";
            this.btnDrawOnPlotter.Size = new System.Drawing.Size(75, 23);
            this.btnDrawOnPlotter.TabIndex = 1;
            this.btnDrawOnPlotter.Text = "Draw!";
            this.btnDrawOnPlotter.UseVisualStyleBackColor = true;
            this.btnDrawOnPlotter.Click += new System.EventHandler(this.btnDrawOnPlotter_Click);
            // 
            // btnParseBoardForPlotter
            // 
            this.btnParseBoardForPlotter.Location = new System.Drawing.Point(42, 19);
            this.btnParseBoardForPlotter.Name = "btnParseBoardForPlotter";
            this.btnParseBoardForPlotter.Size = new System.Drawing.Size(75, 23);
            this.btnParseBoardForPlotter.TabIndex = 0;
            this.btnParseBoardForPlotter.Text = "Parse!";
            this.btnParseBoardForPlotter.UseVisualStyleBackColor = true;
            this.btnParseBoardForPlotter.Click += new System.EventHandler(this.btnParseBoardForPlotter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 61);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commands";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(132, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Unlock";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(71, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbComPorts);
            this.groupBox1.Controls.Add(this.btnConnectSerial);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 57);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // cmbComPorts
            // 
            this.cmbComPorts.FormattingEnabled = true;
            this.cmbComPorts.Location = new System.Drawing.Point(6, 20);
            this.cmbComPorts.Name = "cmbComPorts";
            this.cmbComPorts.Size = new System.Drawing.Size(193, 21);
            this.cmbComPorts.TabIndex = 3;
            this.cmbComPorts.SelectedIndexChanged += new System.EventHandler(this.cmbComPorts_SelectedIndexChanged);
            // 
            // btnConnectSerial
            // 
            this.btnConnectSerial.Location = new System.Drawing.Point(205, 20);
            this.btnConnectSerial.Name = "btnConnectSerial";
            this.btnConnectSerial.Size = new System.Drawing.Size(75, 23);
            this.btnConnectSerial.TabIndex = 2;
            this.btnConnectSerial.Text = "Connect";
            this.btnConnectSerial.UseVisualStyleBackColor = true;
            this.btnConnectSerial.Click += new System.EventHandler(this.btnConnectSerial_Click);
            // 
            // SerialControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(296, 0);
            this.MinimumSize = new System.Drawing.Size(296, 480);
            this.Name = "SerialControl";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(296, 480);
            this.Load += new System.EventHandler(this.SerialControl_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstSerial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDrawOnPlotter;
        private System.Windows.Forms.Button btnParseBoardForPlotter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbComPorts;
        private System.Windows.Forms.Button btnConnectSerial;
        private System.Windows.Forms.Button btnStopDrawing;
        private System.Windows.Forms.Button btnPause;
    }
}
