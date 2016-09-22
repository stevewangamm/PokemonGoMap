using System;
using System.Diagnostics;
using System.Windows.Forms;
using Pgmasst.Main;
using Pgmasst.Main.Pginfos;
using Pgmasst.Main.Watcher;
using Pgmasst.Utility;
using PokemonGoMap;

namespace Pgmasst
{
    static class Program
    {
        [MTAThread]
        static void Main(String[] args)
        {

            //var addresses = GeoUtility.GetAdresses(1.340507f, 103.747237f);
            //SpeechUtil.SpeakAsync(addresses);
            //Debug.WriteLine(GeoUtility.CalcuDeistance(32.9697, -96.80322, 29.46786, -98.53506, 'K'));

            RunForms();

            //DownloadData.StoreStat();
            //DownloadData.ShowStat();
            //CreateReport.Run();
            //CommitReport.Run();
        }

        private static void RunForms()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Func<Form> statForm = ()=> new FormStatResult();
            Func<Form> selForm = () => new SelectForm();
            Func<Form> watcherForm = () => new FormWatcher();

            var mainForm = new FormMain();
            mainForm.BindSubForms(statForm, "Stat");
            mainForm.BindSubForms(selForm, "Show");
            mainForm.BindSubForms(watcherForm, "Watcher");

            Application.Run(mainForm);
        }
    }
}
