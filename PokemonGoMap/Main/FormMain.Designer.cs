namespace Pgmasst.Main
{
    partial class FormMain
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
            this.buttonTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanelSubformCtrl = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonTemplate
            // 
            this.buttonTemplate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTemplate.Location = new System.Drawing.Point(37, 134);
            this.buttonTemplate.Name = "buttonTemplate";
            this.buttonTemplate.Size = new System.Drawing.Size(100, 40);
            this.buttonTemplate.TabIndex = 0;
            this.buttonTemplate.Text = "text";
            this.buttonTemplate.UseVisualStyleBackColor = true;
            this.buttonTemplate.Visible = false;
            // 
            // tableLayoutPanelSubformCtrl
            // 
            this.tableLayoutPanelSubformCtrl.AutoSize = true;
            this.tableLayoutPanelSubformCtrl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelSubformCtrl.ColumnCount = 1;
            this.tableLayoutPanelSubformCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubformCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubformCtrl.Location = new System.Drawing.Point(50, 93);
            this.tableLayoutPanelSubformCtrl.Name = "tableLayoutPanelSubformCtrl";
            this.tableLayoutPanelSubformCtrl.RowCount = 1;
            this.tableLayoutPanelSubformCtrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubformCtrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSubformCtrl.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanelSubformCtrl.TabIndex = 1;
            this.tableLayoutPanelSubformCtrl.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonTemplate);
            this.Controls.Add(this.tableLayoutPanelSubformCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(124, 39);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSubformCtrl;
    }
}