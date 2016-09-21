﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonGoMap
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormStatResult());
            //Application.Run(new Form1());
            //Application.Run(new SelectForm());

            //DownloadData.StoreStat();
            //DownloadData.ShowStat();
            //CreateReport.Run();
            //CommitReport.Run();
        }
    }
}
