using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokemonGoMap;

namespace Pgmasst.Main
{
    public partial class FormMain : Form, IMain
    {
        public FormMain()
        {
            InitializeComponent();
            this.tableLayoutPanelSubformCtrl.Dock = DockStyle.Fill;
            this.tableLayoutPanelSubformCtrl.Visible = true;
        }

        public void BindSubForms(Func<Form> form, string text)
        {
            AddButtton(form, text);
        }

        private void AddButtton(Func<Form> form, string text)
        {
            var newButton = new Button()
            {
                Size = this.buttonTemplate.Size,
                Font = this.buttonTemplate.Font,
                Text = text,
                Name = "button" + text,
                TabIndex = this.tableLayoutPanelSubformCtrl.RowCount,
            };

            newButton.Click += (sender, e) =>
            {
                var newForm = form();
                newForm.StartPosition = FormStartPosition.CenterScreen;
                this.Hide();
                var task = Task.Factory.StartNew(newForm.ShowDialog);
                task.Wait();
                this.Focus();
                this.Show();
            };

            if (this.tableLayoutPanelSubformCtrl.RowCount > 1)
                this.tableLayoutPanelSubformCtrl.RowCount += 1;
            this.tableLayoutPanelSubformCtrl.Controls.Add(newButton, 0, this.tableLayoutPanelSubformCtrl.RowCount - 1);            
        }
    }
}
