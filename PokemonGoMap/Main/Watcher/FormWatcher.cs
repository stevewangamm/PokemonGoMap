using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMapWinFormDemo;
using Pgmasst.Api;
using Pgmasst.Main.Pginfos;
using Pgmasst.Utility;

namespace Pgmasst.Main.Watcher
{
    public partial class FormWatcher : Form
    {
        private double _currentLat = 1.339515;
        private double _currentLng = 103.745707;

        private double _distanceThreshhold = 5.0;

        private enum WorkingStatus
        {
            Error,
            Running,
            Pause,
            Stop,
            Exit,
        }

        private readonly Color _errorColor;
        private readonly Color _runningColor;
        private readonly Color _pauseColor;
        private readonly Color _stopColor;

        private string _since;

        private readonly List<string> _watchIndexes;

        private readonly GMapOverlay _objects = new GMapOverlay("objects"); //放置marker的图层

        private Task _downloadingTask;

        private Image[] _markerImgs;

        private Queue<List<Sprite>> _que;

        private WorkingStatus _workingStatus;

        /// <summary>
        /// unit: seconds
        /// </summary>
        private int _queryInterval;

        public FormWatcher()
        {
            this._markerImgs = new DirectoryInfo(@"..\icons\").GetFiles("*.png").OrderBy(f => f.Name.Length).Select(f => Image.FromFile(f.FullName)).ToArray();
            this._errorColor = Color.Red;
            this._runningColor = Color.DarkSeaGreen;
            this._pauseColor = Color.LightYellow;
            this._stopColor = Color.Gray;
            InitializeComponent();
            this._since = "0";
            this._que = new Queue<List<Sprite>>();
            this._watchIndexes = new List<string>();
            this._downloadingTask = new Task(DownloadData);
            this._workingStatus = WorkingStatus.Stop;
            this._queryInterval = 1;
            this.timerUpdate.Tick += TimerUpdate_Tick;
            this._downloadingTask.Start();
        }

        private void FormWatcher_Load(object sender, EventArgs e)
        {
            this.gMapControlWatcher.MapProvider = GoogleMapProvider.Instance;
            this.gMapControlWatcher.Manager.Mode = AccessMode.ServerOnly;
            GMapProvider.WebProxy = null;
            this.gMapControlWatcher.Position = new PointLatLng(this._currentLat, this._currentLng);

            this.gMapControlWatcher.MinZoom = 1;
            this.gMapControlWatcher.MaxZoom = 20;
            this.gMapControlWatcher.Zoom = 11;
            this.gMapControlWatcher.MarkersEnabled = true;
            this.gMapControlWatcher.Overlays.Add(this._objects);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Action<List<string>> setIndexes = list =>
            {
                this._watchIndexes.Clear();
                this._watchIndexes.AddRange(list);
            };
            var result = new SelectForm(setIndexes).ShowDialog();
            if (result == DialogResult.None || result == DialogResult.Cancel)
                MessageBox.Show("Did not select any");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._workingStatus == WorkingStatus.Stop)
                {
                    this._workingStatus = WorkingStatus.Running;
                    this.buttonStart.Text = "Stop";
                    this.panelToolbar.BackColor = this._runningColor;
                }
                else if(this._workingStatus == WorkingStatus.Running)
                {
                    this._workingStatus = WorkingStatus.Stop;
                    this.buttonStart.Text = "Start";
                    this.panelToolbar.BackColor = this._stopColor;
                }
            }
            catch
            {
                this.panelToolbar.BackColor = this._errorColor;
            }
            finally
            {
            }
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            lock(this.gMapControlWatcher)
            {
                var unixTimeNow = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                foreach (var marker in this._objects.Markers)
                {
                    if((int)marker.Tag  < unixTimeNow)
                        this._objects.Markers.Remove(marker);
                }
            }
        }

        private void numericUpDownQueryInterval_ValueChanged(object sender, EventArgs e)
        {
            this._queryInterval = (int) ((NumericUpDown)sender).Value;
        }

        private void numericUpDownThreshhold_ValueChanged(object sender, EventArgs e)
        {
            this._distanceThreshhold = (int)((NumericUpDown)sender).Value;
        }

        private void checkBoxMapVisible_CheckedChanged(object sender, EventArgs e)
        {
            lock (this.gMapControlWatcher)
            {
                if (((CheckBox) sender).Checked)
                {
                    this.gMapControlWatcher.Visible = true;
                    this.timerUpdate.Enabled = true;
                }
                else
                {
                    this.timerUpdate.Enabled = false;
                    this.gMapControlWatcher.Visible = false;
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            this._workingStatus = WorkingStatus.Exit;
            this.timerUpdate.Enabled = false;
            this.gMapControlWatcher.Visible = false;
            base.OnClosed(e);
        }

        private void DownloadData()
        {
            var sgpkmapi = new SgpkmApi();
            var loop = true;
            while (loop)
            {
                switch (this._workingStatus)
                {
                    case WorkingStatus.Error:
                        break;
                    case WorkingStatus.Exit:
                        loop = false;
                        Thread.Sleep(100);
                        break;
                    case WorkingStatus.Pause:
                        break;
                    case WorkingStatus.Running:
                        var currentPkms = sgpkmapi.GetCurrentSprites(this._since, this._watchIndexes)?.ToList();
                        this._since = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();

                        if (this.gMapControlWatcher.Visible)
                            lock (this.gMapControlWatcher)
                            {
                                currentPkms?.ForEach(p =>
                                {
                                    var gpMarker = new GMapMarkerImage(new PointLatLng(p.Lat, p.Lng),
                                        this._markerImgs[p.Id - 1]) {Tag = p.DeSpawn};
                                    this._objects.Markers.Add(gpMarker);
                                });
                            }
                        Thread.Sleep(1000 * 60 *this._queryInterval);
                        break;
                    case WorkingStatus.Stop:
                        Thread.Sleep(100);
                        break;
                }
            }
        }

        private void Reporting()
        {
            var loop = true;
            while (loop)
            {
                switch (this._workingStatus)
                {
                    case WorkingStatus.Exit:
                        loop = false;
                        Thread.Sleep(100);
                        break;
                    case WorkingStatus.Running:
                        if (this._que.Count != 0)
                        {
                            var sprites = this._que.Dequeue();
                            sprites.ForEach(s =>
                            {
                                var distance = GeoUtility.CalcuDeistance(this._currentLat, this._currentLng,
                                    s.Lat, s.Lng, 'K');
                                if (distance <= this._distanceThreshhold)
                                {
                                    var address = GeoUtility.GetAdress(s.Lat, s.Lng);
                                    var dt = DatetimeUtility.UnixTimeStampToDateTime(s.DeSpawn);

                                    var wordsEn = string.Format("Found {0} at {1}, {2} minutes {3} seconds left only.", PkmIdName.GetName(s.Id), address, (dt - DateTime.Now).Minutes, (dt - DateTime.Now).Seconds);
                                    SpeechUtil.SpeakSync(wordsEn);

                                    var wordsCn = string.Format("发现 {0} 在 {1}, 还有{2}分{3}秒。", PkmIdName.GetCnName(s.Id), address, (dt - DateTime.Now).Minutes, (dt - DateTime.Now).Seconds);
                                    SpeechUtil.SpeakSync(wordsCn);
                                }
                            });
                        }
                        Thread.Sleep(1000 * 60 * this._queryInterval);
                        break;
                    case WorkingStatus.Pause:
                    case WorkingStatus.Error:
                    case WorkingStatus.Stop:
                        Thread.Sleep(100);
                        break;
                }
            }
        }
    }
}
