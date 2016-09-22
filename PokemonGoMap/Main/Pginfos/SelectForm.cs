using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Manina.Windows.Forms;
using PokemonGoMap;

namespace Pgmasst.Main.Pginfos
{
    public partial class SelectForm : Form
    {
        //rare
        //super rare
        //....

        private readonly List<ImageListViewItem> hidedImgListItems = new List<ImageListViewItem>();

        private readonly List<int[]> _recommends = new List<int[]>();

        private readonly List<string> _recommendsNames = new List<string>();

        private readonly List<int> _selectedIndexes;

        public SelectForm()
        {
            this._selectedIndexes = new List<int>();
            InitializeComponent();
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

        public SelectForm(out List<int> selectedIndexes):this()
        {
            selectedIndexes = this._selectedIndexes;
        }

        private void GetConfig()
        {
            foreach (var l in File.ReadAllLines(@"..\watchlist.txt"))
            {
                if (string.IsNullOrEmpty(l.Trim()))
                    continue;
                var splitFields = l.Split(',');
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

        protected override void OnClosed(EventArgs e)
        {
            this._selectedIndexes.AddRange(this.imageListViewPkms.SelectedItems.Select(item => item.Index + 1));
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            var name = "";
            var result = new SaveConfigForm(ref name).ShowDialog();
        }
    }
}
