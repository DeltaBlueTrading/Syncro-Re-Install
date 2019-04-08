using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Windows.Forms;



using Microsoft.Win32;


//using Mineware.Systems.Production;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace EmailMponengManagers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //PDFExport pdf = new PDFExport();
        

        public string ExtractBeforeColon(string TheString)
        {
            if (TheString != "")
            {
                string BeforeColon;

                int index = TheString.IndexOf(":");

                BeforeColon = TheString.Substring(0, index);

                return BeforeColon;
            }
            else
            {
                return "";
            }
        }

        public string ExtractAfterColon(string TheString)
        {
            string AfterColon;

            int index = TheString.IndexOf(":"); // Kry die postion van die :

            AfterColon = TheString.Substring(index + 1); // kry alles na :

            return AfterColon;
        }


        int Prod = 201902;
        public void ProdMonthCalc(int ProdMonth1)
        {
            //int Prod;
            Decimal month = Convert.ToDecimal(ProdMonth1);
            String PMonth = month.ToString();
            PMonth.Substring(4, 2);
            if (Convert.ToInt32(PMonth.Substring(4, 2)) > 12)
            {
                int M = Convert.ToInt32(PMonth.Substring(0, 4));
                M++;
                PMonth = M.ToString();
                PMonth = PMonth + "01";
                ProdMonth1 = Convert.ToInt32(PMonth);
            }
            else
            {
                if (Convert.ToInt32(PMonth.Substring(4, 2)) < 1)
                {
                    int M = Convert.ToInt32(PMonth.Substring(0, 4));
                    M--;
                    PMonth = M.ToString();
                    PMonth = PMonth + "12";
                    ProdMonth1 = Convert.ToInt32(PMonth);
                }
            }
            Prod = ProdMonth1;
        }

        private RegistryKey baseRegistryKey = Registry.CurrentUser;
        private void Form1_Load(object sender, EventArgs e)
        {
            //object RegReadKeyValue = null;
            //RegReadKeyValue = baseRegistryKey.GetValue(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine", "Version");
            // baseRegistryKey.DeleteSubKeyTree(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine");
            //try
            //{
            //    baseRegistryKey.DeleteSubKey(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine");
            //}
            //catch { };            
            //baseRegistryKey.DeleteKey(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine", "Version");
            //@"HKEY_CURRENT_USER\Software\Mineware\Syncromine\"
           // Registry.SetValue(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine", "Version", "0.0.0.1");

            ///Delete the registry key

            //const string userRoot = "HKEY_CURRENT_USER";
            //const string subkey = "RegistrySetValueExample";
            //const string keyName = userRoot + "\\" + subkey;


            //Registry.SetValue(keyName, "TestExpand", "My path: %path%");
            //Registry.SetValue(keyName, "TestExpand2","My path: %path%",
            //    RegistryValueKind.ExpandString);


         


            ////Delete Icon
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //if (System.IO.File.Exists(Path.Combine(desktopPath, "Syncromine.lnk")))
            //{
            //    System.IO.File.Delete(Path.Combine(desktopPath, "Syncromine.lnk"));
            //}



            //MWDataManager.clsDataAccess _dbMan = new MWDataManager.clsDataAccess();
            //_dbMan.ConnectionString = "server=10.10.101.132;database=Syncromine;user id=MINEWARE;password=P@55@123";
            //_dbMan.SqlStatement = " Select * from tblSysSet ";
            //_dbMan.SqlStatement = _dbMan.SqlStatement + "  ";
            //_dbMan.SqlStatement = _dbMan.SqlStatement + " ";
            //_dbMan.SqlStatement = _dbMan.SqlStatement + " ";
            //_dbMan.SqlStatement = _dbMan.SqlStatement + " ";
            //_dbMan.queryExecutionType = MWDataManager.ExecutionType.GeneralSQLStatement;
            //_dbMan.queryReturnType = MWDataManager.ReturnType.DataTable;
            //_dbMan.ExecuteInstruction();


            //DataTable SubA = _dbMan.ResultsDataTable;

            //string VersionNo = SubA.Rows[0]["SyncroVersion"].ToString();
            //string SetupFileLocation = @"\\172.22.1.213\Mineware\Syncromine_Latest\setup.exe";


            //DirectoryInfo aa = new DirectoryInfo(@"\\10.10.101.132\Syncromine\Mineware_Software\Syncromine_Latest\Current\Syncromine");
            //DirectoryInfo ProdData = new DirectoryInfo(@"\\10.10.101.132\Syncromine\Mineware_Software\Syncromine_Latest\Current\Syncromine");
            //DirectoryInfo bb = new DirectoryInfo(@"C:\mineware\Syncromine");

            ////InstallSyncromine
            //DirectoryInfo ReInst = new DirectoryInfo(@"\\10.10.101.132\Syncromine\Mineware_Software\ReInstallSyncromine");
            ////Class1 aa = Class1.WaitForExitAsync
            //CopyFilesRecursively(aa, bb);
            //CopyFilesRecursively(ProdData, bb);
            //CopyFilesRecursively(ReInst, bb);
            ///Process.Start(SetupFileLocation);

            //if (process.HasExited) tcs.TrySetResult(null);

            //Application.Exit();



        }



        public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
            {
                try
                {
                    file.CopyTo(Path.Combine(target.FullName, file.Name));
                }
                catch { };
            }
        }



        public static void DeleteDirectory(string path)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectory(directory);
                }

                try
                {
                    Directory.Delete(path, true);
                }
                catch (IOException)
                {
                    Directory.Delete(path, true);
                }
                catch (UnauthorizedAccessException)
                {
                    Directory.Delete(path, true);
                }
            }
            catch (IOException)
            {
                
            }
        }

        private void ABSBtn_Click(object sender, EventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\Mineware\Syncromine", "Version", "0.0.0.1");

            string SourcePath = @"C:\mineware\Syncromine";
            //Delete Syncromine Directory
            try
            {
                foreach (string files in Directory.GetFiles(SourcePath))
                {
                    FileInfo fileInfo = new FileInfo(files);
                    fileInfo.Delete(); //delete the files first. 

                    //Delete Read Only Files
                    //Process.Start("cmd.exe", "/c " + @"rmdir /s/q C:\mineware\TestSyncromineDelete");
                }


                DeleteDirectory(SourcePath);

                Directory.Delete(SourcePath, false);// delete the directory as it is empty now.
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string VersionNo = SubA.Rows[0]["SyncroVersion"].ToString();
            string SetupFileLocation = @"\\172.22.1.213\Mineware\VMR_Syncromine\setup.exe";
            Process.Start(SetupFileLocation);
        }
    }
}
