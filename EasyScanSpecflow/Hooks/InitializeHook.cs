using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.StepLogging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.Hooks
{
    [Binding]
    internal class InitializeHook
    {
        [BeforeTestRun]
        public static void Initialize()
        {
            Config.Configure();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                AppiumDriver.Current.Quit(); //comment out if testing settings

                Thread.Sleep(10000);

                int exitCode;
                ProcessStartInfo processInfo;
                Process process;

                string command = "livingdoc test-assembly EasyScanSpecflow.dll " +
                    "-t TestExecution.json";

                processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                processInfo.UseShellExecute = false;
                // *** Redirect the output ***
                processInfo.RedirectStandardError = true;
                processInfo.RedirectStandardOutput = true;

                process = Process.Start(processInfo);

                process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Debug.WriteLine("output>>" + e.Data);
                process.BeginOutputReadLine();

                process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                    Debug.WriteLine("error>>" + e.Data);
                process.BeginErrorReadLine();

                process.WaitForExit();
                exitCode = process.ExitCode;
                Debug.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
                process.Close();

                JObject j = (JObject)TestRail.Client.SendPost("add_attachment_to_run/1418", "LivingDoc.html");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
            }
        }
    }
}

