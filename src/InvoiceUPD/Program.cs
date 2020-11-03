using System;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace InvoiceUPD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (args.Length != 0)
            // if (Project.FillSettings(args))
            //{
            Config.ProgSettngs = new Settings();

            string jsonString = File.ReadAllText(Config.PathFile + @"\settings.json");

            Config.ProgSettngs = JsonConvert.DeserializeObject<Settings>(jsonString);

            //Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

            //Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
            //Logging.StartFirstLevel(1);
            //Logging.Comment("Вход в программу");
            //Logging.StopFirstLevel();

            Config.hCntMain = new Procedures(Config.ProgSettngs.ServerK21, Config.ProgSettngs.DataBaseK21, Config.ProgSettngs.Login, Config.ProgSettngs.Password, "");

            Config.hCntMainX14 = new Procedures(Config.ProgSettngs.ServerX14, Config.ProgSettngs.DataBaseX14, Config.ProgSettngs.Login, Config.ProgSettngs.Password, "");

            Application.Run(new frmMain());

            //Logging.StartFirstLevel(2);
            //Logging.Comment("Выход из программы");
            //Logging.StopFirstLevel();

            Project.clearBufferFiles();
            // }
        }
    }
}
