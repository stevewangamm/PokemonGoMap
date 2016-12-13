namespace Pgmasst.Main.Watcher
{
    partial class FormWatcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWatcher));
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.checkBoxNotifiHighIv = new System.Windows.Forms.CheckBox();
            this.checkBoxNotifiOnDistance = new System.Windows.Forms.CheckBox();
            this.checkBoxOnlyshowhighiv = new System.Windows.Forms.CheckBox();
            this.checkBoxMapVisible = new System.Windows.Forms.CheckBox();
            this.numericUpDownHighIv = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThreshhold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownQueryInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTipQueryInterval = new System.Windows.Forms.ToolTip(this.components);
            this.gMapControlWatcher = new GMap.NET.WindowsForms.GMapControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.timerShowTime = new System.Windows.Forms.Timer(this.components);
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighIv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshhold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueryInterval)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.Gray;
            this.panelToolbar.Controls.Add(this.textBoxTime);
            this.panelToolbar.Controls.Add(this.checkBoxNotifiHighIv);
            this.panelToolbar.Controls.Add(this.checkBoxNotifiOnDistance);
            this.panelToolbar.Controls.Add(this.checkBoxOnlyshowhighiv);
            this.panelToolbar.Controls.Add(this.checkBoxMapVisible);
            this.panelToolbar.Controls.Add(this.numericUpDownHighIv);
            this.panelToolbar.Controls.Add(this.numericUpDownThreshhold);
            this.panelToolbar.Controls.Add(this.numericUpDownQueryInterval);
            this.panelToolbar.Controls.Add(this.buttonSelect);
            this.panelToolbar.Controls.Add(this.buttonStart);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(873, 39);
            this.panelToolbar.TabIndex = 0;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTime.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxTime.Enabled = false;
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTime.Location = new System.Drawing.Point(767, 7);
            this.textBoxTime.Multiline = true;
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(94, 25);
            this.textBoxTime.TabIndex = 5;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxNotifiHighIv
            // 
            this.checkBoxNotifiHighIv.AutoSize = true;
            this.checkBoxNotifiHighIv.Checked = true;
            this.checkBoxNotifiHighIv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNotifiHighIv.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNotifiHighIv.Location = new System.Drawing.Point(601, 7);
            this.checkBoxNotifiHighIv.Name = "checkBoxNotifiHighIv";
            this.checkBoxNotifiHighIv.Size = new System.Drawing.Size(74, 23);
            this.checkBoxNotifiHighIv.TabIndex = 4;
            this.checkBoxNotifiHighIv.Text = "High IV";
            this.toolTipQueryInterval.SetToolTip(this.checkBoxNotifiHighIv, "Notificate when high IV");
            this.checkBoxNotifiHighIv.UseVisualStyleBackColor = true;
            this.checkBoxNotifiHighIv.CheckedChanged += new System.EventHandler(this.checkBoxNotifiHighIv_CheckedChanged);
            // 
            // checkBoxNotifiOnDistance
            // 
            this.checkBoxNotifiOnDistance.AutoSize = true;
            this.checkBoxNotifiOnDistance.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxNotifiOnDistance.Location = new System.Drawing.Point(514, 7);
            this.checkBoxNotifiOnDistance.Name = "checkBoxNotifiOnDistance";
            this.checkBoxNotifiOnDistance.Size = new System.Drawing.Size(81, 23);
            this.checkBoxNotifiOnDistance.TabIndex = 4;
            this.checkBoxNotifiOnDistance.Text = "Distance";
            this.toolTipQueryInterval.SetToolTip(this.checkBoxNotifiOnDistance, "Notification in nearby area");
            this.checkBoxNotifiOnDistance.UseVisualStyleBackColor = true;
            this.checkBoxNotifiOnDistance.CheckedChanged += new System.EventHandler(this.checkBoxNotifiOnDistance_CheckedChanged);
            // 
            // checkBoxOnlyshowhighiv
            // 
            this.checkBoxOnlyshowhighiv.AutoSize = true;
            this.checkBoxOnlyshowhighiv.Checked = true;
            this.checkBoxOnlyshowhighiv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOnlyshowhighiv.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxOnlyshowhighiv.Location = new System.Drawing.Point(400, 8);
            this.checkBoxOnlyshowhighiv.Name = "checkBoxOnlyshowhighiv";
            this.checkBoxOnlyshowhighiv.Size = new System.Drawing.Size(108, 23);
            this.checkBoxOnlyshowhighiv.TabIndex = 4;
            this.checkBoxOnlyshowhighiv.Text = "Filter High IV";
            this.toolTipQueryInterval.SetToolTip(this.checkBoxOnlyshowhighiv, "Only show high IV");
            this.checkBoxOnlyshowhighiv.UseVisualStyleBackColor = true;
            this.checkBoxOnlyshowhighiv.CheckedChanged += new System.EventHandler(this.checkBoxOnlyshowhighiv_CheckedChanged);
            // 
            // checkBoxMapVisible
            // 
            this.checkBoxMapVisible.AutoSize = true;
            this.checkBoxMapVisible.Checked = true;
            this.checkBoxMapVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMapVisible.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMapVisible.Location = new System.Drawing.Point(263, 8);
            this.checkBoxMapVisible.Name = "checkBoxMapVisible";
            this.checkBoxMapVisible.Size = new System.Drawing.Size(67, 23);
            this.checkBoxMapVisible.TabIndex = 4;
            this.checkBoxMapVisible.Text = "Visible";
            this.toolTipQueryInterval.SetToolTip(this.checkBoxMapVisible, "Map visible");
            this.checkBoxMapVisible.UseVisualStyleBackColor = true;
            this.checkBoxMapVisible.CheckedChanged += new System.EventHandler(this.checkBoxMapVisible_CheckedChanged);
            // 
            // numericUpDownHighIv
            // 
            this.numericUpDownHighIv.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHighIv.Location = new System.Drawing.Point(336, 6);
            this.numericUpDownHighIv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHighIv.Name = "numericUpDownHighIv";
            this.numericUpDownHighIv.ReadOnly = true;
            this.numericUpDownHighIv.Size = new System.Drawing.Size(58, 25);
            this.numericUpDownHighIv.TabIndex = 3;
            this.toolTipQueryInterval.SetToolTip(this.numericUpDownHighIv, "High IV threshhold");
            this.numericUpDownHighIv.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numericUpDownHighIv.ValueChanged += new System.EventHandler(this.numericUpDownHighIv_ValueChanged);
            // 
            // numericUpDownThreshhold
            // 
            this.numericUpDownThreshhold.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownThreshhold.Location = new System.Drawing.Point(199, 7);
            this.numericUpDownThreshhold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThreshhold.Name = "numericUpDownThreshhold";
            this.numericUpDownThreshhold.ReadOnly = true;
            this.numericUpDownThreshhold.Size = new System.Drawing.Size(58, 25);
            this.numericUpDownThreshhold.TabIndex = 3;
            this.toolTipQueryInterval.SetToolTip(this.numericUpDownThreshhold, "Distance Threshhold (By Km)");
            this.numericUpDownThreshhold.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownThreshhold.ValueChanged += new System.EventHandler(this.numericUpDownThreshhold_ValueChanged);
            // 
            // numericUpDownQueryInterval
            // 
            this.numericUpDownQueryInterval.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownQueryInterval.Location = new System.Drawing.Point(135, 7);
            this.numericUpDownQueryInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownQueryInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQueryInterval.Name = "numericUpDownQueryInterval";
            this.numericUpDownQueryInterval.ReadOnly = true;
            this.numericUpDownQueryInterval.Size = new System.Drawing.Size(58, 25);
            this.numericUpDownQueryInterval.TabIndex = 3;
            this.toolTipQueryInterval.SetToolTip(this.numericUpDownQueryInterval, "Query Interval (by Minutes)");
            this.numericUpDownQueryInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQueryInterval.ValueChanged += new System.EventHandler(this.numericUpDownQueryInterval_ValueChanged);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.Location = new System.Drawing.Point(3, 4);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(60, 29);
            this.buttonSelect.TabIndex = 1;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(69, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(60, 29);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            // 
            // toolTipQueryInterval
            // 
            this.toolTipQueryInterval.IsBalloon = true;
            this.toolTipQueryInterval.ToolTipTitle = "Note";
            // 
            // gMapControlWatcher
            // 
            this.gMapControlWatcher.Bearing = 0F;
            this.gMapControlWatcher.CanDragMap = true;
            this.gMapControlWatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControlWatcher.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlWatcher.GrayScaleMode = false;
            this.gMapControlWatcher.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlWatcher.LevelsKeepInMemmory = 5;
            this.gMapControlWatcher.Location = new System.Drawing.Point(3, 3);
            this.gMapControlWatcher.MarkersEnabled = true;
            this.gMapControlWatcher.MaxZoom = 2;
            this.gMapControlWatcher.MinZoom = 2;
            this.gMapControlWatcher.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControlWatcher.Name = "gMapControlWatcher";
            this.gMapControlWatcher.NegativeMode = false;
            this.gMapControlWatcher.PolygonsEnabled = true;
            this.gMapControlWatcher.RetryLoadTile = 0;
            this.gMapControlWatcher.RoutesEnabled = true;
            this.gMapControlWatcher.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlWatcher.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlWatcher.ShowTileGridLines = false;
            this.gMapControlWatcher.Size = new System.Drawing.Size(867, 466);
            this.gMapControlWatcher.TabIndex = 1;
            this.gMapControlWatcher.Visible = false;
            this.gMapControlWatcher.Zoom = 0D;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.gMapControlWatcher, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxStatus, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 591);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(3, 475);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(867, 113);
            this.textBoxStatus.TabIndex = 2;
            // 
            // timerShowTime
            // 
            this.timerShowTime.Interval = 1000;
            this.timerShowTime.Tick += new System.EventHandler(this.timerShowTime_Tick);
            // 
            // FormWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 630);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 510);
            this.Name = "FormWatcher";
            this.Text = "FormWatcher";
            this.Load += new System.EventHandler(this.FormWatcher_Load);
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHighIv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshhold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueryInterval)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.NumericUpDown numericUpDownQueryInterval;
        private System.Windows.Forms.CheckBox checkBoxMapVisible;
        private System.Windows.Forms.ToolTip toolTipQueryInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshhold;
        private System.Windows.Forms.CheckBox checkBoxOnlyshowhighiv;
        private System.Windows.Forms.NumericUpDown numericUpDownHighIv;
        private System.Windows.Forms.CheckBox checkBoxNotifiHighIv;
        private System.Windows.Forms.CheckBox checkBoxNotifiOnDistance;
        private GMap.NET.WindowsForms.GMapControl gMapControlWatcher;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Timer timerShowTime;
    }
}