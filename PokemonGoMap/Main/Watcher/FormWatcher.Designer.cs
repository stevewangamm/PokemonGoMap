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
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.checkBoxMapVisible = new System.Windows.Forms.CheckBox();
            this.numericUpDownThreshhold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownQueryInterval = new System.Windows.Forms.NumericUpDown();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.gMapControlWatcher = new GMap.NET.WindowsForms.GMapControl();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.toolTipQueryInterval = new System.Windows.Forms.ToolTip(this.components);
            this.panelToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshhold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueryInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // panelToolbar
            // 
            this.panelToolbar.BackColor = System.Drawing.Color.Gray;
            this.panelToolbar.Controls.Add(this.checkBoxMapVisible);
            this.panelToolbar.Controls.Add(this.numericUpDownThreshhold);
            this.panelToolbar.Controls.Add(this.numericUpDownQueryInterval);
            this.panelToolbar.Controls.Add(this.buttonSelect);
            this.panelToolbar.Controls.Add(this.buttonStart);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.Size = new System.Drawing.Size(662, 39);
            this.panelToolbar.TabIndex = 0;
            // 
            // checkBoxMapVisible
            // 
            this.checkBoxMapVisible.AutoSize = true;
            this.checkBoxMapVisible.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMapVisible.Location = new System.Drawing.Point(263, 8);
            this.checkBoxMapVisible.Name = "checkBoxMapVisible";
            this.checkBoxMapVisible.Size = new System.Drawing.Size(67, 23);
            this.checkBoxMapVisible.TabIndex = 4;
            this.checkBoxMapVisible.Text = "Visible";
            this.checkBoxMapVisible.UseVisualStyleBackColor = true;
            this.checkBoxMapVisible.CheckedChanged += new System.EventHandler(this.checkBoxMapVisible_CheckedChanged);
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
            this.toolTipQueryInterval.SetToolTip(this.numericUpDownThreshhold, "Distance Threshhold");
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
            this.toolTipQueryInterval.SetToolTip(this.numericUpDownQueryInterval, "Query Interval");
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
            // gMapControlWatcher
            // 
            this.gMapControlWatcher.Bearing = 0F;
            this.gMapControlWatcher.CanDragMap = true;
            this.gMapControlWatcher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControlWatcher.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlWatcher.GrayScaleMode = false;
            this.gMapControlWatcher.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlWatcher.LevelsKeepInMemmory = 5;
            this.gMapControlWatcher.Location = new System.Drawing.Point(0, 39);
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
            this.gMapControlWatcher.Size = new System.Drawing.Size(662, 390);
            this.gMapControlWatcher.TabIndex = 1;
            this.gMapControlWatcher.Visible = false;
            this.gMapControlWatcher.Zoom = 0D;
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
            // FormWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 429);
            this.Controls.Add(this.gMapControlWatcher);
            this.Controls.Add(this.panelToolbar);
            this.MinimumSize = new System.Drawing.Size(300, 78);
            this.Name = "FormWatcher";
            this.Text = "FormWatcher";
            this.Load += new System.EventHandler(this.FormWatcher_Load);
            this.panelToolbar.ResumeLayout(false);
            this.panelToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreshhold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQueryInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSelect;
        private GMap.NET.WindowsForms.GMapControl gMapControlWatcher;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.NumericUpDown numericUpDownQueryInterval;
        private System.Windows.Forms.CheckBox checkBoxMapVisible;
        private System.Windows.Forms.ToolTip toolTipQueryInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownThreshhold;
    }
}