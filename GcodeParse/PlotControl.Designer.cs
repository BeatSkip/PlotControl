namespace GcodeParse
{
    partial class PlotControl
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.RatioLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MouseLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SelectedIndexLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabMain = new System.Windows.Forms.TabControl();
            this.TabStart = new System.Windows.Forms.TabPage();
            this.lstDrawings = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnLoadNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblScale = new System.Windows.Forms.Label();
            this.btnScaleP = new System.Windows.Forms.Button();
            this.btnScaleN = new System.Windows.Forms.Button();
            this.txtDegStep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRotation = new System.Windows.Forms.Label();
            this.lblZeroPoint = new System.Windows.Forms.Label();
            this.btnRotRight = new System.Windows.Forms.Button();
            this.btnRotLeft = new System.Windows.Forms.Button();
            this.txtMoveStep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.tabDrawing = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabMachSettings = new System.Windows.Forms.TabPage();
            this.lstSettings = new System.Windows.Forms.ListView();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.skControl1 = new SkiaSharp.Views.Desktop.SKControl();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.TabMain.SuspendLayout();
            this.TabStart.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabDrawing.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabMachSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1223, 538);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1223, 560);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusMain,
            this.RatioLabel,
            this.MouseLabel,
            this.SelectedIndexLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1223, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // lblStatusMain
            // 
            this.lblStatusMain.Name = "lblStatusMain";
            this.lblStatusMain.Size = new System.Drawing.Size(35, 17);
            this.lblStatusMain.Text = "Idle...";
            // 
            // RatioLabel
            // 
            this.RatioLabel.Name = "RatioLabel";
            this.RatioLabel.Size = new System.Drawing.Size(118, 17);
            this.RatioLabel.Text = "toolStripStatusLabel1";
            // 
            // MouseLabel
            // 
            this.MouseLabel.Name = "MouseLabel";
            this.MouseLabel.Size = new System.Drawing.Size(118, 17);
            this.MouseLabel.Text = "toolStripStatusLabel1";
            // 
            // SelectedIndexLabel
            // 
            this.SelectedIndexLabel.Name = "SelectedIndexLabel";
            this.SelectedIndexLabel.Size = new System.Drawing.Size(107, 17);
            this.SelectedIndexLabel.Text = "SelectedIndexLabel";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TabMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.skControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panelSerial);
            this.splitContainer1.Size = new System.Drawing.Size(1223, 538);
            this.splitContainer1.SplitterDistance = 285;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // TabMain
            // 
            this.TabMain.Controls.Add(this.TabStart);
            this.TabMain.Controls.Add(this.tabDrawing);
            this.TabMain.Controls.Add(this.tabDebug);
            this.TabMain.Controls.Add(this.tabMachSettings);
            this.TabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMain.Location = new System.Drawing.Point(0, 0);
            this.TabMain.Name = "TabMain";
            this.TabMain.SelectedIndex = 0;
            this.TabMain.Size = new System.Drawing.Size(285, 538);
            this.TabMain.TabIndex = 0;
            // 
            // TabStart
            // 
            this.TabStart.Controls.Add(this.lstDrawings);
            this.TabStart.Controls.Add(this.panel4);
            this.TabStart.Controls.Add(this.panel2);
            this.TabStart.Location = new System.Drawing.Point(4, 22);
            this.TabStart.Name = "TabStart";
            this.TabStart.Padding = new System.Windows.Forms.Padding(3);
            this.TabStart.Size = new System.Drawing.Size(277, 512);
            this.TabStart.TabIndex = 0;
            this.TabStart.Text = "Drawings";
            this.TabStart.UseVisualStyleBackColor = true;
            // 
            // lstDrawings
            // 
            this.lstDrawings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDrawings.FormattingEnabled = true;
            this.lstDrawings.Location = new System.Drawing.Point(3, 160);
            this.lstDrawings.Name = "lstDrawings";
            this.lstDrawings.Size = new System.Drawing.Size(271, 320);
            this.lstDrawings.TabIndex = 6;
            this.lstDrawings.SelectedIndexChanged += new System.EventHandler(this.lstDrawings_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.btnRemove);
            this.panel4.Controls.Add(this.btnLoadNew);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 480);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(271, 29);
            this.panel4.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(95, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnLoadNew
            // 
            this.btnLoadNew.Location = new System.Drawing.Point(5, 3);
            this.btnLoadNew.Name = "btnLoadNew";
            this.btnLoadNew.Size = new System.Drawing.Size(84, 23);
            this.btnLoadNew.TabIndex = 0;
            this.btnLoadNew.Text = "Load G-code";
            this.btnLoadNew.UseVisualStyleBackColor = true;
            this.btnLoadNew.Click += new System.EventHandler(this.btnLoadNew_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblScale);
            this.panel2.Controls.Add(this.btnScaleP);
            this.panel2.Controls.Add(this.btnScaleN);
            this.panel2.Controls.Add(this.txtDegStep);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblRotation);
            this.panel2.Controls.Add(this.lblZeroPoint);
            this.panel2.Controls.Add(this.btnRotRight);
            this.panel2.Controls.Add(this.btnRotLeft);
            this.panel2.Controls.Add(this.txtMoveStep);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnRight);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(271, 157);
            this.panel2.TabIndex = 0;
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(173, 95);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(35, 13);
            this.lblScale.TabIndex = 12;
            this.lblScale.Text = "label3";
            // 
            // btnScaleP
            // 
            this.btnScaleP.Location = new System.Drawing.Point(86, 90);
            this.btnScaleP.Name = "btnScaleP";
            this.btnScaleP.Size = new System.Drawing.Size(75, 23);
            this.btnScaleP.TabIndex = 11;
            this.btnScaleP.Text = "Scale -";
            this.btnScaleP.UseVisualStyleBackColor = true;
            // 
            // btnScaleN
            // 
            this.btnScaleN.Location = new System.Drawing.Point(86, 119);
            this.btnScaleN.Name = "btnScaleN";
            this.btnScaleN.Size = new System.Drawing.Size(75, 23);
            this.btnScaleN.TabIndex = 10;
            this.btnScaleN.Text = "Scale +";
            this.btnScaleN.UseVisualStyleBackColor = true;
            // 
            // txtDegStep
            // 
            this.txtDegStep.Location = new System.Drawing.Point(149, 31);
            this.txtDegStep.Name = "txtDegStep";
            this.txtDegStep.Size = new System.Drawing.Size(88, 20);
            this.txtDegStep.TabIndex = 8;
            this.txtDegStep.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Step deg:";
            // 
            // lblRotation
            // 
            this.lblRotation.AutoSize = true;
            this.lblRotation.Location = new System.Drawing.Point(171, 61);
            this.lblRotation.Name = "lblRotation";
            this.lblRotation.Size = new System.Drawing.Size(35, 13);
            this.lblRotation.TabIndex = 9;
            this.lblRotation.Text = "label3";
            // 
            // lblZeroPoint
            // 
            this.lblZeroPoint.AutoSize = true;
            this.lblZeroPoint.Location = new System.Drawing.Point(92, 61);
            this.lblZeroPoint.Name = "lblZeroPoint";
            this.lblZeroPoint.Size = new System.Drawing.Size(35, 13);
            this.lblZeroPoint.TabIndex = 8;
            this.lblZeroPoint.Text = "label2";
            // 
            // btnRotRight
            // 
            this.btnRotRight.Location = new System.Drawing.Point(5, 119);
            this.btnRotRight.Name = "btnRotRight";
            this.btnRotRight.Size = new System.Drawing.Size(75, 23);
            this.btnRotRight.TabIndex = 7;
            this.btnRotRight.Text = "Rotate Right";
            this.btnRotRight.UseVisualStyleBackColor = true;
            // 
            // btnRotLeft
            // 
            this.btnRotLeft.Location = new System.Drawing.Point(5, 90);
            this.btnRotLeft.Name = "btnRotLeft";
            this.btnRotLeft.Size = new System.Drawing.Size(75, 23);
            this.btnRotLeft.TabIndex = 6;
            this.btnRotLeft.Text = "Rotate Left";
            this.btnRotLeft.UseVisualStyleBackColor = true;
            // 
            // txtMoveStep
            // 
            this.txtMoveStep.Location = new System.Drawing.Point(149, 5);
            this.txtMoveStep.Name = "txtMoveStep";
            this.txtMoveStep.Size = new System.Drawing.Size(88, 20);
            this.txtMoveStep.TabIndex = 5;
            this.txtMoveStep.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Step move:";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(5, 61);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(47, 32);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(33, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(5, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(5, 32);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(36, 23);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // tabDrawing
            // 
            this.tabDrawing.Controls.Add(this.linkLabel1);
            this.tabDrawing.Controls.Add(this.label3);
            this.tabDrawing.Location = new System.Drawing.Point(4, 22);
            this.tabDrawing.Name = "tabDrawing";
            this.tabDrawing.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrawing.Size = new System.Drawing.Size(277, 419);
            this.tabDrawing.TabIndex = 1;
            this.tabDrawing.Text = "tabPage2";
            this.tabDrawing.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(112, 262);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.txtFile);
            this.tabDebug.Controls.Add(this.btnExport);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Size = new System.Drawing.Size(277, 419);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(8, 5);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(185, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(199, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabMachSettings
            // 
            this.tabMachSettings.Controls.Add(this.lstSettings);
            this.tabMachSettings.Controls.Add(this.btnSaveSettings);
            this.tabMachSettings.Controls.Add(this.btnLoadSettings);
            this.tabMachSettings.Location = new System.Drawing.Point(4, 22);
            this.tabMachSettings.Name = "tabMachSettings";
            this.tabMachSettings.Size = new System.Drawing.Size(277, 419);
            this.tabMachSettings.TabIndex = 3;
            this.tabMachSettings.Text = "Settings";
            this.tabMachSettings.UseVisualStyleBackColor = true;
            // 
            // lstSettings
            // 
            this.lstSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSettings.Location = new System.Drawing.Point(0, 23);
            this.lstSettings.Name = "lstSettings";
            this.lstSettings.Size = new System.Drawing.Size(277, 373);
            this.lstSettings.TabIndex = 2;
            this.lstSettings.UseCompatibleStateImageBehavior = false;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveSettings.Location = new System.Drawing.Point(0, 396);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(277, 23);
            this.btnSaveSettings.TabIndex = 1;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLoadSettings.Location = new System.Drawing.Point(0, 0);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(277, 23);
            this.btnLoadSettings.TabIndex = 0;
            this.btnLoadSettings.Text = "Load";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            // 
            // skControl1
            // 
            this.skControl1.BackColor = System.Drawing.Color.White;
            this.skControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skControl1.Location = new System.Drawing.Point(0, 0);
            this.skControl1.MinimumSize = new System.Drawing.Size(110, 100);
            this.skControl1.Name = "skControl1";
            this.skControl1.Size = new System.Drawing.Size(638, 538);
            this.skControl1.TabIndex = 0;
            this.skControl1.Text = "skControl1";
            // 
            // panelSerial
            // 
            this.panelSerial.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSerial.Location = new System.Drawing.Point(638, 0);
            this.panelSerial.MaximumSize = new System.Drawing.Size(296, 0);
            this.panelSerial.MinimumSize = new System.Drawing.Size(296, 480);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(296, 538);
            this.panelSerial.TabIndex = 0;
            // 
            // PlotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 560);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "PlotControl";
            this.Text = "Plotter Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.TabMain.ResumeLayout(false);
            this.TabStart.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabDrawing.ResumeLayout(false);
            this.tabDrawing.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabMachSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl TabMain;
        private System.Windows.Forms.TabPage TabStart;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnLoadNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabDrawing;
        //private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripStatusLabel RatioLabel;
        private SkiaSharp.Views.Desktop.SKControl skControl1;
        private System.Windows.Forms.ToolStripStatusLabel MouseLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label lblRotation;
        private System.Windows.Forms.Label lblZeroPoint;
        private System.Windows.Forms.Button btnRotRight;
        private System.Windows.Forms.Button btnRotLeft;
        private System.Windows.Forms.TextBox txtMoveStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ListBox lstDrawings;
        private System.Windows.Forms.TextBox txtDegStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Button btnScaleP;
        private System.Windows.Forms.Button btnScaleN;
        private System.Windows.Forms.ToolStripStatusLabel SelectedIndexLabel;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabMachSettings;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.ListView lstSettings;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelSerial;
    }
}

