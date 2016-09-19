using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manina.Windows.Forms;

namespace PokemonGoMap
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
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

            var imgfiles = new DirectoryInfo(@"..\hq icons\").GetFiles("*.png").OrderBy(f => f.Name.Length).ToArray();
            
            this.imageListViewPkms.Items.AddRange(PkmIdName.PkmNameIdList.Select(p =>
            {
                var item = new ImageListViewItem()
                {
                    Text = p.Name + " " + p.NameCn,
                    FileName = imgfiles[i++].FullName,
                
                };
                return item;
            }).ToArray());
        }
    }
}
