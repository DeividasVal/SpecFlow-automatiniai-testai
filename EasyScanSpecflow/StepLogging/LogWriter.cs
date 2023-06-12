using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.StepLogging
{
    public class LogWriter
    {
        public static void LogWrite(string logMessage)
        {
            string? LogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(LogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + " log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText(LogPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + " log.txt"))
                {
                    w.WriteLine(ex.ToString());
                }
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0} - " + logMessage, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
            catch (Exception ex)
            {
                txtWriter.WriteLine(ex.ToString());
            }
        }
    }
}
