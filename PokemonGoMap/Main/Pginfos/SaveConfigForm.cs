using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pgmasst.Main.Pginfos
{
    public partial class SaveConfigForm : Form, IFormOutput<string>
    {
        public SaveConfigForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        public SaveConfigForm(Action<string> output):this()
        {
            this.Output += output;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxConfigName.Text))
            {
                Output(this.textBoxConfigName.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Name not specified!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                return;
            base.OnClosed(e);
        }

        public Action<string> Output { get; }

        
    }
}
