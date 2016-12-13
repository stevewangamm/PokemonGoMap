using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using GMapWinFormDemo;
using Manina.Windows.Forms;
using Pgmasst.Main.Pginfos;
using Pgmasst.WebApi;

namespace PokemonGoMap
{
    public partial class FormStatResult : Form
    {
        private GMapOverlay objects = new GMapOverlay("objects"); //放置marker的图层

        private Sprite _spriteToCount;

        public FormStatResult()
        {
            InitializeComponent();
            this.listBoxPglist.Items.AddRange(
                PkmIdName.PkmNameIdList.Select(p => p.Id.ToString() + " " + p.Name + " " + p.NameCn).ToArray());
        }
        private void FormStatResult_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance;
            this.gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            GMapProvider.WebProxy = null;
            this.gMapControl1.Position = new PointLatLng(1.323911f, 103.663055f);

            this.gMapControl1.MinZoom = 1;
            this.gMapControl1.MaxZoom = 20;
            this.gMapControl1.Zoom = 11;
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.Overlays.Add(this.objects);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateWithNormalOp();
            this.gMapControl1.Refresh();
        }

        private void UpdateWithEf()
        {
            //var img = Image.FromFile(@"D:\VS15Projects\Projects\PokemonGoMap\PokemonGoMap\icons\25.png");

            var img = this._spriteToCount.SmallIcon;

            using (var db = new XdwContext())
            {
                //db.Database.CreateIfNotExists();
                var count = db.Xdws.Count(p => p.XdwId == this._spriteToCount.Id);

                Debug.WriteLine(count + " " + this._spriteToCount.Name + " found.");
                if (count > 1000)
                {
                    MessageBox.Show(count + " " + this._spriteToCount.Name + " found.");
                }
                else
                {
                    //var foundList = db.Xdws.Where(p => p.XdwId == this.pkmToCount.Id).ToArray();
                    foreach (var p in db.Xdws.Where(p => p.XdwId == this._spriteToCount.Id))
                    {
                        var gpMarker = new GMapMarkerImage(new PointLatLng(double.Parse(p.XdwLat),
                            double.Parse(p.XdwLon)), img);
                        this.objects.Markers.Add(gpMarker);
                    }
                }
            }
        }

        private void UpdateWithNormalOp()
        {
            var img = this._spriteToCount.SmallIcon;
            var dbConnection = new SQLiteConnection("Data Source=pg.sqlite;Version=3;");
            dbConnection.Open();
            var sql = "SELECT * FROM Xdws WHERE XdwId = 25";
            var command = new SQLiteCommand(sql, dbConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Debug.WriteLine("Name: " + reader["XdwName"] + "\tXdwLat: " + reader["XdwLat"] + "\tXdwLon " + reader["XdwLon"]);
                var gpMarker = new GMapMarkerImage( new PointLatLng(double.Parse(reader["XdwLat"].ToString()),double.Parse(reader["XdwLon"].ToString())), img);
                this.objects.Markers.Add(gpMarker);
            }
            reader.Close();
            dbConnection.Close();
        }

        private void listBoxPglist_Click(object sender, EventArgs e)
        {
            var selectedIndex = this.listBoxPglist.SelectedIndex;
            this._spriteToCount = PkmIdName.PkmNameIdList[selectedIndex];
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.toolStrip1.Visible)
                {
                    this.toolStrip1.Visible = false;return;
                }
                this.toolStrip1.Location = new Point(
                    this.gMapControl1.Left + e.Location.X,
                    this.gMapControl1.Top + e.Location.Y);
                this.toolStrip1.Visible = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.objects.Markers.Clear();
            this.gMapControl1.Refresh();
        }
    }
}
