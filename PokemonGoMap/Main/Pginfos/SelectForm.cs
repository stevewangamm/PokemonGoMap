using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Manina.Windows.Forms;
using PokemonGoMap;

namespace Pgmasst.Main.Pginfos
{
    public partial class SelectForm : Form, IFormOutput<List<string>>
    {
        //rare
        //super rare
        //....
        private readonly string configFile = @"..\watchlist.txt";

        private readonly List<ImageListViewItem> hidedImgListItems = new List<ImageListViewItem>();

        private readonly List<int[]> _recommends = new List<int[]>();

        private readonly List<string> _recommendsNames = new List<string>();

        public SelectForm()
        {
            InitializeComponent(); this.DialogResult = DialogResult.None;
            var i = 0;
            //var imgList = new ImageList();
            //imgList.Images.AddRange(new DirectoryInfo(@"..\hq icons\").GetFiles("*.png").OrderBy(f => f.Name.Length).Select(f => Image.FromFile(f.FullName)).ToArray());
            //this.listViewXdws.LargeImageList = imgList;
            //this.listViewXdws.Items.AddRange(PkmIdName.PkmNameIdList.Select(p =>
            //{
            //    var item = new ListViewItem()
            //    {
            //        Text = p.Name + " " + p.NameCn ,
            //        ImageIndex = i++,
            //    };
            //    return item;
            //}).ToArray());

            var imgfiles = new DirectoryInfo(@"..\icons\").GetFiles("*.png").OrderBy(f => f.Name.Length).ToArray();
            //var imgfiles = new DirectoryInfo(@"..\hq icons\").GetFiles("*.png").OrderBy(f => f.Name.Length).ToArray();

            this.imageListViewPkms.Items.AddRange(PkmIdName.PkmNameIdList.Select(p =>
            {
                var item = new ImageListViewItem()
                {
                    Text =p.Id.ToString() + " " +  p.Name + " " + p.NameCn,
                    FileName = imgfiles[i++].FullName,
                    Tag = p.Id -1,
                };
                return item;
            }).ToArray());

            GetConfig();
            AddRecommendSelections();
        }

        public SelectForm(Action<List<string>> setIndexes):this()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Output = setIndexes;
        }

        private void GetConfig()
        {
            foreach (var l in File.ReadAllLines(this.configFile))
            {
                if (string.IsNullOrEmpty(l.Trim()))
                    continue;
                var splitFields = l.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
                var configName = splitFields[0];
                this._recommendsNames.Add(configName);
                var indexes = splitFields.Skip(1).Select(n => int.Parse(n)).ToArray();
                this._recommends.Add(indexes);
            }
        }

        /// <summary>
        /// init the combobox
        /// </summary>
        private void AddRecommendSelections()
        {
            this.toolStripComboBoxRecommends.Items.AddRange(this._recommendsNames.ToArray());
            this.toolStripComboBoxRecommends.SelectedIndex = 0;
        }

        private void imageListViewPkms_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                this.toolStripSelection.Location = e.Location;
                this.toolStripSelection.Visible = true;
            }
        }

        private void imageListViewPkms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.toolStripSelection.Visible)
            {
                this.toolStripSelection.Visible = false;
                return;
            }
        }

        private void toolStripComboBoxRecommends_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.toolStripSelection.Visible = false;
            var index = this.toolStripComboBoxRecommends.SelectedIndex;
            var targetIndexes = this._recommends[index];
            foreach (var i in targetIndexes)
            {
                this.imageListViewPkms.Items[i -1].Selected  = true;
            }
        }

        private void toolStripButtonShowoption_Click(object sender, EventArgs e)
        {
            //update imagelistview items
            if (this.toolStripButtonShowoption.Text.Equals("Show Selected Only"))
            {
                this.hidedImgListItems.AddRange(this.imageListViewPkms.Items.Where(i => i.Selected = false));
                this.hidedImgListItems.ForEach(i => this.imageListViewPkms.Items.Remove(i));
                this.toolStripButtonShowoption.Text = "Show All";
            }
            else
            {
                this.imageListViewPkms.Items.AddRange(this.hidedImgListItems.ToArray());
                this.imageListViewPkms.Items.OrderBy(i => int.Parse(i.Tag.ToString()));
                this.hidedImgListItems.Clear();
                this.toolStripButtonShowoption.Text = "Show Selected Only";
            }
            this.toolStripSelection.Visible = false;
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            var name = "";
            Action<string> setNameDel = n =>  name = n ;
            if (new SaveConfigForm(setNameDel).ShowDialog() == DialogResult.OK)
            {
                if (_recommendsNames.Contains(name))
                {
                    MessageBox.Show("Name exists already");
                    return;
                }
                //Debug.WriteLine(string.Format("{0}, {1}", name, this.imageListViewPkms.Items.Where(i => i.Selected).Select(i => (int.Parse(i.Tag.ToString()) + 1).ToString()).Aggregate((i1, i2)=> i1+","+i2)));

                var selectedIndexes = this.imageListViewPkms.Items.Where(i => i.Selected)
                    .Select(i => (int.Parse(i.Tag.ToString()) + 1)).ToArray();
                this._recommends.Add(selectedIndexes);
                this._recommendsNames.Add(name);

                File.AppendAllText(this.configFile, string.Format("{0}, {1}", name,
                    selectedIndexes.Select(i => i.ToString()).Aggregate((i1, i2) => i1 + "," + i2)));
            }
        }

        private void toolStripButtonSelectionDone_Click(object sender, EventArgs e)
        {
            this.Output(this.imageListViewPkms.Items
                .Where(i => i.Selected)
                .Select(i => (int.Parse(i.Tag.ToString()) + 1).ToString())
                .ToList());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Action<List<string>> Output { get; }
    }
}
