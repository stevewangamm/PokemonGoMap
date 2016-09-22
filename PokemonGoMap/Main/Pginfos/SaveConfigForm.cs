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
    public partial class SaveConfigForm : Form
    {
        private string _name;
        public SaveConfigForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }
        public SaveConfigForm(ref string name):this()
        {
            this._name = name;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxConfigName.Text))
            {
                this._name = this.textBoxConfigName.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
        }
    }
}
