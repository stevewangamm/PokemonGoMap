namespace Pgmasst.Main.Pginfos
{
    partial class SelectForm
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectForm));
            this.listViewXdws = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListViewPkms = new Manina.Windows.Forms.ImageListView();
            this.toolStripSelection = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxRecommends = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonShowoption = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectionDone = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewXdws
            // 
            this.listViewXdws.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewXdws.Location = new System.Drawing.Point(28, 127);
            this.listViewXdws.Name = "listViewXdws";
            this.listViewXdws.Size = new System.Drawing.Size(45, 33);
            this.listViewXdws.TabIndex = 0;
            this.listViewXdws.UseCompatibleStateImageBehavior = false;
            this.listViewXdws.View = System.Windows.Forms.View.Tile;
            this.listViewXdws.Visible = false;
            // 
            // imageListViewPkms
            // 
            this.imageListViewPkms.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.imageListViewPkms.Columns.AddRange(new Manina.Windows.Forms.ImageListView.ImageListViewColumnHeader[] {
            new Manina.Windows.Forms.ImageListView.ImageListViewColumnHeader(Manina.Windows.Forms.ColumnType.Name, "", 100, 0, true)});
            this.imageListViewPkms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListViewPkms.GroupHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.imageListViewPkms.Location = new System.Drawing.Point(0, 0);
            this.imageListViewPkms.Name = "imageListViewPkms";
            this.imageListViewPkms.PersistentCacheDirectory = "";
            this.imageListViewPkms.PersistentCacheSize = ((long)(100));
            this.imageListViewPkms.Size = new System.Drawing.Size(636, 392);
            this.imageListViewPkms.TabIndex = 1;
            this.imageListViewPkms.ThumbnailSize = new System.Drawing.Size(100, 100);
            this.imageListViewPkms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageListViewPkms_MouseDown);
            this.imageListViewPkms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageListViewPkms_MouseUp);
            // 
            // toolStripSelection
            // 
            this.toolStripSelection.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripSelection.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxRecommends,
            this.toolStripButtonShowoption,
            this.toolStripButtonSave,
            this.toolStripButtonSelectionDone,
            this.toolStripButtonExit});
            this.toolStripSelection.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStripSelection.Location = new System.Drawing.Point(123, 192);
            this.toolStripSelection.Name = "toolStripSelection";
            this.toolStripSelection.Size = new System.Drawing.Size(123, 156);
            this.toolStripSelection.TabIndex = 2;
            this.toolStripSelection.Text = "toolStripFormSelection";
            this.toolStripSelection.Visible = false;
            // 
            // toolStripComboBoxRecommends
            // 
            this.toolStripComboBoxRecommends.AutoToolTip = true;
            this.toolStripComboBoxRecommends.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripComboBoxRecommends.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxRecommends.Name = "toolStripComboBoxRecommends";
            this.toolStripComboBoxRecommends.Size = new System.Drawing.Size(119, 23);
            this.toolStripComboBoxRecommends.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRecommends_SelectedIndexChanged);
            // 
            // toolStripButtonShowoption
            // 
            this.toolStripButtonShowoption.AutoSize = false;
            this.toolStripButtonShowoption.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripButtonShowoption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShowoption.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowoption.Image")));
            this.toolStripButtonShowoption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowoption.Name = "toolStripButtonShowoption";
            this.toolStripButtonShowoption.Size = new System.Drawing.Size(122, 25);
            this.toolStripButtonShowoption.Text = "Show Selected Only";
            this.toolStripButtonShowoption.ToolTipText = "Show Selected Only";
            this.toolStripButtonShowoption.Click += new System.EventHandler(this.toolStripButtonShowoption_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.AutoSize = false;
            this.toolStripButtonSave.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(122, 25);
            this.toolStripButtonSave.Text = "Save Selection";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonSelectionDone
            // 
            this.toolStripButtonSelectionDone.AutoSize = false;
            this.toolStripButtonSelectionDone.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripButtonSelectionDone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelectionDone.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectionDone.Image")));
            this.toolStripButtonSelectionDone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectionDone.Name = "toolStripButtonSelectionDone";
            this.toolStripButtonSelectionDone.Size = new System.Drawing.Size(122, 25);
            this.toolStripButtonSelectionDone.Text = "Selection Done";
            this.toolStripButtonSelectionDone.Click += new System.EventHandler(this.toolStripButtonSelectionDone_Click);
            // 
            // toolStripButtonExit
            // 
            this.toolStripButtonExit.AutoSize = false;
            this.toolStripButtonExit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
            this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExit.Name = "toolStripButtonExit";
            this.toolStripButtonExit.Size = new System.Drawing.Size(122, 25);
            this.toolStripButtonExit.Text = "Exit";
            this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 392);
            this.Controls.Add(this.toolStripSelection);
            this.Controls.Add(this.imageListViewPkms);
            this.Controls.Add(this.listViewXdws);
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            this.toolStripSelection.ResumeLayout(false);
            this.toolStripSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewXdws;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Manina.Windows.Forms.ImageListView imageListViewPkms;
        private System.Windows.Forms.ToolStrip toolStripSelection;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxRecommends;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowoption;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectionDone;
        private System.Windows.Forms.ToolStripButton toolStripButtonExit;
    }
}