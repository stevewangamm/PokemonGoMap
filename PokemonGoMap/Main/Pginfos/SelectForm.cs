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

        private readonly List<int[]> _recommends = new List<int[]>
        {
            new [] { 1, 2, 3, 4, 5, 6, 9, 25, 26, 59, 65, 68, 77, 89, 103, 106, 107, 108, 113, 130, 131, 134, 135, 136, 137, 138, 139, 140, 142, 143, 144, 148, 149, 150, 151 },
        };

        private readonly List<string> _recommendsNames = new List<string>
        {
            "MyNormal",
        };

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
                };
                return item;
            }).ToArray());
        }

        public SelectForm(out List<int> selectedIndexes):this()
        {
            selectedIndexes = this._selectedIndexes;
        }

        /// <summary>
        /// init the combobox
        /// </summary>
        private void AddRecommendSelections()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
            this.toolStripSelection.Visible = false;
        }

        private void toolStripButtonShowoption_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //update imagelistview items
            if (this.toolStripButtonShowoption.Text.Equals("Show Selected Only"))
            {
                this.toolStripButtonShowoption.Text = "Show All";
            }
            else
            {
                this.toolStripButtonShowoption.Text = "Show Selected Only";
            }
            this.toolStripSelection.Visible = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            this._selectedIndexes.AddRange(this.imageListViewPkms.SelectedItems.Select(item => item.Index + 1));
        }
    }
}
