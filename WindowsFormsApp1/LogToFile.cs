using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace WindowsFormsApp1
{
    public static class LogToFile
    {
        private static string m_exePath = string.Empty;
        private static DateTime thisDay = DateTime.Today;
        private static string date = thisDay.ToString("d");

        public static void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!File.Exists(m_exePath + "\\" + $"log {date}.txt"))
            {
                FileStream fs = File.Create(m_exePath + "\\" + $"log {date}.txt");
                fs.Close();
            }

            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + $"log {date}.txt"))
                    AppendLog(logMessage, w);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog ieraksts : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("");
                txtWriter.WriteLine(logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }

        }
    }
}

