using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.StepLogging
{
    class XMLSaving
    {
        public static void XMLWrite(string logMessage)
        {
            string? LogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(LogPath + "\\" + "XML.txt"))
                {
                    XML(logMessage, w);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter w = File.AppendText(LogPath + "\\" + "XML.txt"))
                {
                    w.WriteLine(ex.ToString());
                }
            }
        }

        public static void XML(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine(logMessage);
            }
            catch (Exception ex)
            {
                txtWriter.WriteLine(ex.ToString());
            }
        }
    }
}
