namespace PokemonGoMap
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
            this.listViewXdws = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListViewPkms = new Manina.Windows.Forms.ImageListView();
            this.SuspendLayout();
            // 
            // listViewXdws
            // 
            this.listViewXdws.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewXdws.Location = new System.Drawing.Point(0, 0);
            this.listViewXdws.Name = "listViewXdws";
            this.listViewXdws.Size = new System.Drawing.Size(284, 261);
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
            this.imageListViewPkms.Size = new System.Drawing.Size(677, 261);
            this.imageListViewPkms.TabIndex = 1;
            this.imageListViewPkms.ThumbnailSize = new System.Drawing.Size(100, 100);
            // 
            // SelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 261);
            this.Controls.Add(this.imageListViewPkms);
            this.Controls.Add(this.listViewXdws);
            this.Name = "SelectForm";
            this.Text = "SelectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewXdws;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private Manina.Windows.Forms.ImageListView imageListViewPkms;
    }
}