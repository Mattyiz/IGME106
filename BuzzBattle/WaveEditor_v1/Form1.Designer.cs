namespace WaveEditor_v1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addWaveButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteWaveButton1 = new System.Windows.Forms.ToolStripButton();
            this.EditWaveButton1 = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton13 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.waveNumTop = new System.Windows.Forms.NumericUpDown();
            this.waveNumLeft = new System.Windows.Forms.NumericUpDown();
            this.waveNumRight = new System.Windows.Forms.NumericUpDown();
            this.waveNumBottom = new System.Windows.Forms.NumericUpDown();
            this.enemySpawnsLabel = new System.Windows.Forms.Label();
            this.selectedWaveLabel = new System.Windows.Forms.Label();
            this.waveNumLabelTop = new System.Windows.Forms.Label();
            this.waveNumLabelLeft = new System.Windows.Forms.Label();
            this.waveNumLabelRight = new System.Windows.Forms.Label();
            this.waveNumLabelBottom = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumBottom)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(101, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 300);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Click += new System.EventHandler(this.splitContainer1_Panel1_Click);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.waveNumTop);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumLeft);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumRight);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumBottom);
            this.splitContainer1.Panel2.Controls.Add(this.enemySpawnsLabel);
            this.splitContainer1.Panel2.Controls.Add(this.selectedWaveLabel);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumLabelTop);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumLabelLeft);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumLabelRight);
            this.splitContainer1.Panel2.Controls.Add(this.waveNumLabelBottom);
            this.splitContainer1.Size = new System.Drawing.Size(600, 300);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWaveButton,
            this.DeleteWaveButton1,
            this.EditWaveButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 275);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(300, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addWaveButton
            // 
            this.addWaveButton.AutoToolTip = false;
            this.addWaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addWaveButton.Image = ((System.Drawing.Image)(resources.GetObject("addWaveButton.Image")));
            this.addWaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addWaveButton.Name = "addWaveButton";
            this.addWaveButton.Size = new System.Drawing.Size(74, 22);
            this.addWaveButton.Text = "Add a Wave";
            this.addWaveButton.Click += new System.EventHandler(this.addWaveButton_Click);
            // 
            // DeleteWaveButton1
            // 
            this.DeleteWaveButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteWaveButton1.AutoToolTip = false;
            this.DeleteWaveButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteWaveButton1.Image = ((System.Drawing.Image)(resources.GetObject("DeleteWaveButton1.Image")));
            this.DeleteWaveButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteWaveButton1.Name = "DeleteWaveButton1";
            this.DeleteWaveButton1.Size = new System.Drawing.Size(95, 22);
            this.DeleteWaveButton1.Text = "Remove a Wave";
            this.DeleteWaveButton1.Click += new System.EventHandler(this.DeleteWaveButton1_Click);
            // 
            // EditWaveButton1
            // 
            this.EditWaveButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EditWaveButton1.AutoSize = false;
            this.EditWaveButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditWaveButton1.Enabled = false;
            this.EditWaveButton1.Image = ((System.Drawing.Image)(resources.GetObject("EditWaveButton1.Image")));
            this.EditWaveButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditWaveButton1.Name = "EditWaveButton1";
            this.EditWaveButton1.Size = new System.Drawing.Size(84, 22);
            this.EditWaveButton1.Text = "Edit Wave";
            this.EditWaveButton1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.toolStrip3);
            this.flowLayoutPanel1.Controls.Add(this.toolStrip5);
            this.flowLayoutPanel1.Controls.Add(this.toolStrip4);
            this.flowLayoutPanel1.Controls.Add(this.toolStrip2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 275);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Enabled = false;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.toolStripButton7});
            this.toolStrip3.Location = new System.Drawing.Point(1, 1);
            this.toolStrip3.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip3.Size = new System.Drawing.Size(294, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStrip3.Visible = false;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(40, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 20);
            this.toolStripLabel2.Text = "Wave 1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton5.Text = "✎";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.toolStripSeparator2.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton6.Text = "🡅";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton7.Text = "🡇";
            // 
            // toolStrip5
            // 
            this.toolStrip5.AutoSize = false;
            this.toolStrip5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip5.Enabled = false;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.toolStripButton11,
            this.toolStripSeparator4,
            this.toolStripButton12,
            this.toolStripButton13});
            this.toolStrip5.Location = new System.Drawing.Point(1, 1);
            this.toolStrip5.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip5.Size = new System.Drawing.Size(294, 25);
            this.toolStrip5.TabIndex = 3;
            this.toolStrip5.Text = "toolStrip5";
            this.toolStrip5.Visible = false;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Margin = new System.Windows.Forms.Padding(40, 1, 0, 2);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 20);
            this.toolStripLabel4.Text = "Wave 2";
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton11.Text = "✎";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Margin = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.toolStripSeparator4.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton12.Text = "🡅";
            // 
            // toolStripButton13
            // 
            this.toolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton13.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton13.Image")));
            this.toolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton13.Name = "toolStripButton13";
            this.toolStripButton13.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton13.Text = "🡇";
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.Enabled = false;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripButton8,
            this.toolStripSeparator3,
            this.toolStripButton9,
            this.toolStripButton10});
            this.toolStrip4.Location = new System.Drawing.Point(1, 1);
            this.toolStrip4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip4.Size = new System.Drawing.Size(294, 25);
            this.toolStrip4.TabIndex = 2;
            this.toolStrip4.Text = "toolStrip4";
            this.toolStrip4.Visible = false;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(40, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(45, 20);
            this.toolStripLabel3.Text = "Wave 3";
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton8.Text = "✎";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(90, 0, 0, 0);
            this.toolStripSeparator3.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton9.Text = "🡅";
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton10.Text = "🡇";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Enabled = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(1, 1);
            this.toolStrip2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(1);
            this.toolStrip2.Size = new System.Drawing.Size(294, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Visible = false;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(40, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 20);
            this.toolStripLabel1.Text = "Boss Wave";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton2.Text = "✎";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.toolStripSeparator1.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "🡅";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton4.Text = "🡇";
            // 
            // waveNumTop
            // 
            this.waveNumTop.BackColor = System.Drawing.SystemColors.Window;
            this.waveNumTop.Enabled = false;
            this.waveNumTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumTop.Location = new System.Drawing.Point(121, 142);
            this.waveNumTop.Name = "waveNumTop";
            this.waveNumTop.Size = new System.Drawing.Size(55, 26);
            this.waveNumTop.TabIndex = 0;
            this.waveNumTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waveNumTop.ValueChanged += new System.EventHandler(this.waveNumTop_ValueChanged);
            // 
            // waveNumLeft
            // 
            this.waveNumLeft.Enabled = false;
            this.waveNumLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumLeft.Location = new System.Drawing.Point(28, 193);
            this.waveNumLeft.Name = "waveNumLeft";
            this.waveNumLeft.Size = new System.Drawing.Size(55, 26);
            this.waveNumLeft.TabIndex = 1;
            this.waveNumLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waveNumLeft.ValueChanged += new System.EventHandler(this.waveNumLeft_ValueChanged);
            // 
            // waveNumRight
            // 
            this.waveNumRight.Enabled = false;
            this.waveNumRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumRight.Location = new System.Drawing.Point(215, 193);
            this.waveNumRight.Name = "waveNumRight";
            this.waveNumRight.Size = new System.Drawing.Size(55, 26);
            this.waveNumRight.TabIndex = 2;
            this.waveNumRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waveNumRight.ValueChanged += new System.EventHandler(this.waveNumRight_ValueChanged);
            // 
            // waveNumBottom
            // 
            this.waveNumBottom.Enabled = false;
            this.waveNumBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumBottom.Location = new System.Drawing.Point(121, 247);
            this.waveNumBottom.Name = "waveNumBottom";
            this.waveNumBottom.Size = new System.Drawing.Size(55, 26);
            this.waveNumBottom.TabIndex = 3;
            this.waveNumBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.waveNumBottom.ValueChanged += new System.EventHandler(this.waveNumBottom_ValueChanged);
            // 
            // enemySpawnsLabel
            // 
            this.enemySpawnsLabel.AutoSize = true;
            this.enemySpawnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemySpawnsLabel.Location = new System.Drawing.Point(80, 9);
            this.enemySpawnsLabel.Name = "enemySpawnsLabel";
            this.enemySpawnsLabel.Size = new System.Drawing.Size(136, 20);
            this.enemySpawnsLabel.TabIndex = 7;
            this.enemySpawnsLabel.Text = "Enemy Spawns:";
            this.enemySpawnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedWaveLabel
            // 
            this.selectedWaveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedWaveLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.selectedWaveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedWaveLabel.Location = new System.Drawing.Point(20, 44);
            this.selectedWaveLabel.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.selectedWaveLabel.Name = "selectedWaveLabel";
            this.selectedWaveLabel.Size = new System.Drawing.Size(256, 30);
            this.selectedWaveLabel.TabIndex = 18;
            this.selectedWaveLabel.Text = "(wave list is empty)";
            this.selectedWaveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waveNumLabelTop
            // 
            this.waveNumLabelTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.waveNumLabelTop.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.waveNumLabelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveNumLabelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumLabelTop.Location = new System.Drawing.Point(108, 109);
            this.waveNumLabelTop.Name = "waveNumLabelTop";
            this.waveNumLabelTop.Size = new System.Drawing.Size(80, 30);
            this.waveNumLabelTop.TabIndex = 0;
            this.waveNumLabelTop.Text = "Top";
            this.waveNumLabelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waveNumLabelLeft
            // 
            this.waveNumLabelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.waveNumLabelLeft.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.waveNumLabelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveNumLabelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumLabelLeft.Location = new System.Drawing.Point(15, 160);
            this.waveNumLabelLeft.Name = "waveNumLabelLeft";
            this.waveNumLabelLeft.Size = new System.Drawing.Size(80, 30);
            this.waveNumLabelLeft.TabIndex = 14;
            this.waveNumLabelLeft.Text = "Left";
            this.waveNumLabelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waveNumLabelRight
            // 
            this.waveNumLabelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.waveNumLabelRight.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.waveNumLabelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveNumLabelRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumLabelRight.Location = new System.Drawing.Point(202, 160);
            this.waveNumLabelRight.Name = "waveNumLabelRight";
            this.waveNumLabelRight.Size = new System.Drawing.Size(80, 30);
            this.waveNumLabelRight.TabIndex = 12;
            this.waveNumLabelRight.Text = "Right";
            this.waveNumLabelRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // waveNumLabelBottom
            // 
            this.waveNumLabelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.waveNumLabelBottom.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.waveNumLabelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waveNumLabelBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waveNumLabelBottom.Location = new System.Drawing.Point(108, 214);
            this.waveNumLabelBottom.Name = "waveNumLabelBottom";
            this.waveNumLabelBottom.Size = new System.Drawing.Size(80, 30);
            this.waveNumLabelBottom.TabIndex = 16;
            this.waveNumLabelBottom.Text = "Bottom";
            this.waveNumLabelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buzz Battle - Wave Editor v338";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waveNumBottom)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addWaveButton;
        private System.Windows.Forms.ToolStripButton EditWaveButton1;
        private System.Windows.Forms.ToolStripButton DeleteWaveButton1;
        private System.Windows.Forms.Label waveNumLabelTop;
        private System.Windows.Forms.Label enemySpawnsLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown waveNumTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown waveNumBottom;
        private System.Windows.Forms.Label waveNumLabelBottom;
        private System.Windows.Forms.NumericUpDown waveNumLeft;
        private System.Windows.Forms.Label waveNumLabelLeft;
        private System.Windows.Forms.NumericUpDown waveNumRight;
        private System.Windows.Forms.Label waveNumLabelRight;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripButton toolStripButton13;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Label selectedWaveLabel;
    }
}

