using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMapWinFormDemo;
using Pgmasst.Main.Pginfos;
using Pgmasst.Properties;
using Pgmasst.Utility;
using Pgmasst.WebApi;

namespace Pgmasst.Main.Watcher
{
    public partial class FormWatcher : Form
    {
        #region attributes
        private readonly double _currentLat = 1.339515;
        private readonly double _currentLng = 103.745707;

        private double _distanceThreshhold = 5.0;
        private int _highIvThreshhold = 90;
        private bool _onlyHighIv;
        private bool _notifiHighIv;
        private bool _notifiNearby;

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

        //private readonly Task _downloadingTask;
        private readonly Thread _downloadingThread;
        //private readonly Task _reportingTask;
        private readonly Thread _reportingThread;

        private readonly Image[] _markerImgs;

        private readonly Queue<List<Sprite>> _que;

        private WorkingStatus _workingStatus;

        /// <summary>
        /// unit: seconds
        /// </summary>
        private int _queryInterval;

        private bool _reportingLoop;

        private bool _downloadingLoop;
        #endregion

        #region constructor and init

        public FormWatcher()
        {
            this._markerImgs =
                new DirectoryInfo(Settings.Default.IconsDirectory).GetFiles("*.png")
                    .OrderBy(f => f.Name.Length)
                    .Select(f => Image.FromFile(f.FullName))
                    .ToArray();
            this._errorColor = Color.Red;
            this._runningColor = Color.DarkSeaGreen;
            this._pauseColor = Color.LightYellow;
            this._stopColor = Color.Gray;

            InitializeComponent();
            LoadConfig();
            this._since = "0";
            this._distanceThreshhold = (double) this.numericUpDownThreshhold.Value;
            this._highIvThreshhold = (int) this.numericUpDownHighIv.Value;
            this._notifiHighIv = (bool)this.checkBoxNotifiHighIv.Checked;
            this._notifiNearby = (bool)this.checkBoxNotifiOnDistance.Checked;

            this._onlyHighIv = this.checkBoxOnlyshowhighiv.Checked;
            this._que = new Queue<List<Sprite>>();
            this._watchIndexes = new List<string>();

            this._downloadingThread = new Thread(DownloadData)
            {
                IsBackground = true,
            };
            //this._downloadingTask = new Task(DownloadData);
            
            this._reportingThread = new Thread(Reporting)
            {
                IsBackground = true,
            };
            //this._reportingTask = new Task(Reporting);
            this._workingStatus = WorkingStatus.Stop;

            this._queryInterval = 1;
            this.timerUpdate.Tick += TimerUpdate_Tick;

            this._downloadingLoop = true;
            //this._downloadingTask.Start();
            this._downloadingThread.Start();

            this._reportingLoop = true;
            //this._reportingTask.Start();
            this._reportingThread.Start();
            Debug.WriteLine("timerShowTime true");
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
            this.gMapControlWatcher.Visible = this.checkBoxMapVisible.Checked;
            if (this.gMapControlWatcher.Visible)
            {
                this.timerShowTime.Enabled = true;
                this.timerUpdate.Enabled = true;
            }
        }

        private void LoadConfig()
        {
            this.checkBoxNotifiHighIv.Checked = Settings.Default.NotifiHighIv;
            this.checkBoxNotifiOnDistance.Checked = Settings.Default.NotifiDistance;
            this.checkBoxOnlyshowhighiv.Checked = Settings.Default.FilterHighIv;
            this.numericUpDownHighIv.Value = Settings.Default.IvThreshhold;
            this.checkBoxMapVisible.Checked = Settings.Default.MapVisible;
            this.numericUpDownThreshhold.Value = Settings.Default.DistanceThreshhold;
            this.numericUpDownQueryInterval.Value = Settings.Default.QueryInterval;
        }

        private void SaveConfig()
        {
            Settings.Default.NotifiHighIv = this.checkBoxNotifiHighIv.Checked ;
            Settings.Default.NotifiDistance = this.checkBoxNotifiOnDistance.Checked ;
            Settings.Default.FilterHighIv = this.checkBoxOnlyshowhighiv.Checked;
            Settings.Default.IvThreshhold = (int) this.numericUpDownHighIv.Value;
            Settings.Default.MapVisible = this.checkBoxMapVisible.Checked;
            Settings.Default.DistanceThreshhold = (int) this.numericUpDownThreshhold.Value;
            Settings.Default.QueryInterval = (int) this.numericUpDownQueryInterval.Value;
            Settings.Default.Save();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveConfig();
            base.OnClosing(e);
        }

        #endregion

        #region controls
        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Action<List<string>> setIndexes = list =>
            {
                this._watchIndexes.Clear();
                this._watchIndexes.AddRange(list);
                OutputStatus("Watcher list set.");
            };
            var selectForm = new SelectForm(setIndexes, Settings.Default.SettingName);
            var result = selectForm.ShowDialog();
            if (result == DialogResult.None || result == DialogResult.Cancel)
                MessageBox.Show("Did not select any setting");
            else
                Settings.Default.SettingName = selectForm.SettingName;
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
                    this._since = "0";
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
            Task.Factory.StartNew(() =>
            {
                lock (this._objects.Markers)
                {
                    var unixTimeNow = (int) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    foreach (var marker in this._objects.Markers)
                    {
                        if ((int) marker.Tag < unixTimeNow)
                            this._objects.Markers.Remove(marker);
                    }
                }
            });
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

        private void numericUpDownHighIv_ValueChanged(object sender, EventArgs e)
        {
            this._highIvThreshhold = (int) ((sender as NumericUpDown).Value);
        }

        private void checkBoxOnlyshowhighiv_CheckedChanged(object sender, EventArgs e)
        {
            this._onlyHighIv = this.checkBoxOnlyshowhighiv.Checked;
        }

        protected override void OnClosed(EventArgs e)
        {
            //this._workingStatus = WorkingStatus.Exit;
            //this.timerUpdate.Enabled = false;
            //this.gMapControlWatcher.Visible = false;
            base.OnClosed(e);
        }

        private void checkBoxNotifiOnDistance_CheckedChanged(object sender, EventArgs e)
        {
            this._notifiNearby = ((CheckBox) sender).Checked;
        }

        private void checkBoxNotifiHighIv_CheckedChanged(object sender, EventArgs e)
        {
            this._notifiHighIv = ((CheckBox) sender).Checked;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this._reportingLoop = false;
            this._downloadingLoop = false;
            try
            {
                this._downloadingThread.Abort();
                this._reportingThread.Abort();
            }
            catch (Exception ex)
            {
            }
            base.OnFormClosed(e);
        }

        private void OutputStatus(string str)
        {
            if (this.textBoxStatus.InvokeRequired)
            {
                this.textBoxStatus.Invoke(new Action<string>(OutputStatus), str);
            }
            else
            {
                this.textBoxStatus.Text += str+ Environment.NewLine;
            }
        }

        private void timerShowTime_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("timerShowTime_Tick");
            var showTimeAction = new Action<string>(str => this.textBoxTime.Text = str);
            if (this.textBoxTime.InvokeRequired)
            {
                this.textBoxTime.Invoke(showTimeAction, DateTime.Now.TimeOfDay);
            }
            else
                this.textBoxTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

        }
        #endregion controls

        #region watcher
        private void DownloadData()
        {
            var sgpkmapi = new SgpkmApi();
            var downloadAction = new Action(() =>
            {
                switch (this._workingStatus)
                {
                    case WorkingStatus.Error:
                        break;
                    case WorkingStatus.Exit:
                        this._downloadingLoop = false;
                        Thread.Sleep(100);
                        break;
                    case WorkingStatus.Pause:
                        break;
                    case WorkingStatus.Running:
                        if (this._watchIndexes?.Count == 0)
                        {
                            MessageBox.Show("Select the indexes 1st.");
                            Thread.Sleep(100);
                            break;
                        }
                        var currentPkms = sgpkmapi.GetCurrentSprites(this._since, this._watchIndexes)?.ToList();
                        Debug.WriteLine("Received " + currentPkms?.Count);
                        this._since = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds.ToString();
                        OutputStatus("Received " + currentPkms.Count);
                        //if (this.gMapControlWatcher.Visible)
                        //lock (this.gMapControlWatcher)
                        var filteredCount = 0;
                        lock (this._objects.Markers)
                        {                            
                            currentPkms?.ForEach(p =>
                            {
                                if (this._onlyHighIv && p.Iv <= this._highIvThreshhold)
                                    return;
                                var gpMarker = new GMapMarkerImage(new PointLatLng(p.Lat, p.Lng), this._markerImgs[p.Id - 1])
                                {
                                    Tag = p.DeSpawn,
                                    ToolTipText = p.Iv.ToString() + "%" + Environment.NewLine + DatetimeUtility.UnixTimeStampToDateTime(p.DeSpawn).ToString("hh:mm:ss"),
                                };
                                this._objects.Markers.Add(gpMarker);
                                filteredCount++;
                            });
                        }
                        OutputStatus("After filtered " + filteredCount);
                        this._que.Enqueue(currentPkms);
                        Thread.Sleep(1000*60*this._queryInterval);
                        break;
                    case WorkingStatus.Stop:
                        Thread.Sleep(100);
                        break;
                }
            });
            while (this._downloadingLoop)
            {
                try
                {
                    downloadAction();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in DownloadData: " + ex);
                }
            }
        }

        private void CheckNearby(List<Sprite> sprites)
        {
            sprites.ForEach(s =>
            {
                //_notifiNearby

                var distance = GeoUtility.CalcuDeistance(this._currentLat, this._currentLng,
                    s.Lat, s.Lng, 'K');
                if (distance <= this._distanceThreshhold)
                {
                    var address = GeoUtility.GetAdress(s.Lat, s.Lng);
                    var dt = DatetimeUtility.UnixTimeStampToDateTime(s.DeSpawn);

                    //var wordsEn = string.Format("Found {0} at {1}, {2} minutes {3} seconds left only.", PkmIdName.GetName(s.Id), address, (dt - DateTime.Now).Minutes, (dt - DateTime.Now).Seconds);
                    //SpeechUtil.SpeakSync(wordsEn);

                    var wordsCn = string.Format("发现 {0} 在 {1}, 还有{2}分{3}秒。",
                        PkmIdName.GetCnName(s.Id),
                        string.IsNullOrWhiteSpace(address)
                            ? string.Format("距离{0}千米",
                                distance.ToString(CultureInfo.InvariantCulture).Substring(0, 3))
                            : address,
                        (dt - DateTime.Now).Minutes,
                        (dt - DateTime.Now).Seconds);
                    SpeechUtil.SpeakSync(wordsCn);
                }
            });
        }

        private void CheckHighIv(List<Sprite> sprites)
        {
            sprites.ForEach(s =>
            {
                if (s.Iv >= this._highIvThreshhold)
                {
                    var distance = GeoUtility.CalcuDeistance(this._currentLat, this._currentLng,
                        s.Lat, s.Lng, 'K');

                    var address = GeoUtility.GetAdress(s.Lat, s.Lng);
                    var dt = DatetimeUtility.UnixTimeStampToDateTime(s.DeSpawn);

                    //var wordsEn = string.Format("Found {0} at {1}, {2} minutes {3} seconds left only.", PkmIdName.GetName(s.Id), address, (dt - DateTime.Now).Minutes, (dt - DateTime.Now).Seconds);
                    //SpeechUtil.SpeakSync(wordsEn);

                    var wordsCn = string.Format("发现 IV{4}的{0}在 {1}, 还有{2}分{3}秒。",
                        PkmIdName.GetCnName(s.Id),
                        string.IsNullOrWhiteSpace(address)
                            ? string.Format("距离{0}千米",
                                distance.ToString(CultureInfo.InvariantCulture).Substring(0, 3))
                            : address,
                        (dt - DateTime.Now).Minutes,
                        (dt - DateTime.Now).Seconds,
                        s.Iv);
                    SpeechUtil.SpeakSync(wordsCn);
                }
            });
        }

        private void Reporting()
        {
            var statusOperation = new Action(() =>
            {
                switch (this._workingStatus)
                {
                    case WorkingStatus.Exit:
                        this._reportingLoop = false;
                        Thread.Sleep(100);
                        break;
                    case WorkingStatus.Running:
                        if (this._que.Count != 0)
                        {
                            var sprites = this._que.Dequeue();
                            if (this._notifiHighIv)
                                CheckHighIv(sprites);
                            if(this._notifiNearby)
                                CheckNearby(sprites);
                        }
                        Thread.Sleep(1000*60*this._queryInterval);
                        break;
                    case WorkingStatus.Pause:
                    case WorkingStatus.Error:
                    case WorkingStatus.Stop:
                        Thread.Sleep(100);
                        break;
                }
            });

            while (this._reportingLoop)
            {
                try
                {
                    statusOperation();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error in Reporting: " + ex);
                }
            }
        }
        #endregion
    }
}
