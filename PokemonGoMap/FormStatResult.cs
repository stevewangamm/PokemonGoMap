using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace PokemonGoMap
{
    public partial class FormStatResult : Form
    {
        private GMapOverlay objects = new GMapOverlay("objects"); //放置marker的图层
        public FormStatResult()
        {
            InitializeComponent();

        }
        private void FormStatResult_Load(object sender, EventArgs e)
        {
            //use google provider
            this.gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            this.gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            //not use proxy
            GMapProvider.WebProxy = null;
            //center map on moscow
            this.gMapControl1.Position = new PointLatLng(1.323911f, 103.663055f);

            //zoom min/max; default both = 2
            this.gMapControl1.MinZoom = 1;
            this.gMapControl1.MaxZoom = 20;
            //set zoom
            this.gMapControl1.Zoom = 10;
            gMapControl1.MarkersEnabled = true;
            gMapControl1.Overlays.Add(objects);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var img = Image.FromFile(@"..\..\P.ico");
            var gpMarker = new GMapMarkerImage(new PointLatLng(1.323911f, 103.663055f), img );

            objects.Markers.Add(gpMarker);
            
            this.gMapControl1.Refresh();
        }
    }
}
