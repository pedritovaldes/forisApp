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

namespace ForisApp
{
    public partial class Form1 : Form
    {

        public string ServStartupPath = @"C:\ForisApp\Config";

        private List<string> List_Student = new List<string>();
        private Dictionary<string, Presence> Dict_Presence = new Dictionary<string, Presence>();

        public Form1()
        {
            InitializeComponent();
        }

        private void procesarConfig_Click(object sender, EventArgs e)
        {
           Boolean procesed =  LoadConfigurationFile();

            if(procesed)
            {
                ComprobarNoPresence();
                foreach (var stack in Dict_Presence.OrderByDescending(x => x.Value.TotalMinutes))
                {
                    if(stack.Value.TotalMinutes > 0)
                    {
                        listStudents.Items.Add(stack.Value.StudentName + ": " + stack.Value.TotalMinutes + " minutes in " + stack.Value.TotalDays + " day(s)");
                    }
                    else
                    {
                        listStudents.Items.Add(stack.Value.StudentName + ": " + stack.Value.TotalMinutes + " minutes");
                    }
                }
            }
            else
            {
                listStudents.Items.Add("No se ha podido procesar el archivo de configuración");
            }
        }

        private void ComprobarNoPresence()
        {
            foreach (string student in List_Student)
            {
                if (!Dict_Presence.ContainsKey(student))
                {
                    Presence presence = new Presence(student, 0, 0);
                    Dict_Presence.Add(student, presence);
                }
            }
        }

        private bool LoadConfigurationFile()
        {
            string msg;
            bool procesed;

            try
            {
                string StartupPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\Config.txt";
                if (!File.Exists(StartupPath))
                {
                    using (File.Create(StartupPath)) ;

                    using (FileStream fsIni = new FileStream(StartupPath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                    {
                        StreamWriter rwLogList = new StreamWriter(fsIni);
                        rwLogList.WriteLine("Student Marco");
                        rwLogList.WriteLine("Student David");
                        rwLogList.WriteLine("Student Fran");
                        rwLogList.WriteLine("Presence Marco 1 09:02 10:17 R100");
                        rwLogList.WriteLine("Presence Marco 3 10:58 12:05 R205");
                        rwLogList.WriteLine("Presence David 5 14:02 15:46 F505");
                        rwLogList.Close();
                    }
                }
                
                using (FileStream fsIniConfig = new FileStream(StartupPath, FileMode.Open, FileAccess.Read))
                {
                    StreamReader rwLogConfig = new StreamReader(fsIniConfig);
                    while (!rwLogConfig.EndOfStream)
                    {
                        string Line = rwLogConfig.ReadLine();
                        string[] Data = Line.Split(' ');
                        string Header = Data[0];

                        if (Data.Length > 1)
                        {
                            switch (Header)
                            {
                                case "Student":
                                    AddStudent(Data[1]);
                                    break;
                                case "Presence":
                                    AddPresence(Data);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    rwLogConfig.Close();
                }

                procesed = true;
            }
            catch (Exception ex)
            {
                msg = "Unexpected error in LoadConfigurationFile " + ex.ToString();
                procesed = false;
            }

            return procesed;
        }

        private void AddStudent(string nameStudent)
        {
            if (!List_Student.Contains(nameStudent))
            {
                List_Student.Add(nameStudent);  
            }
        }

        private void AddPresence(string[] line)
        {
            string name = line[1];
            Int32.TryParse(line[2], out int day);
            string timeIni = line[3];
            string timeEnd = line[4];
            string classRoom = line[5];

            if(List_Student.Contains(name))
            {
                TimeSpan tiempoI = TimeSpan.Parse(timeIni);
                TimeSpan tiempoF = TimeSpan.Parse(timeEnd);

                TimeSpan resta = tiempoF - tiempoI;
                double totalMinutes = resta.TotalMinutes;

                if (!Dict_Presence.ContainsKey(name))
                {
                    Presence presence = new Presence(name, totalMinutes, 1);
                    Dict_Presence.Add(name, presence);
                }
                else
                {
                    Dict_Presence[name].TotalMinutes = Dict_Presence[name].TotalMinutes + totalMinutes;
                    Dict_Presence[name].TotalDays++;
                }
            }
        }
    }
}
