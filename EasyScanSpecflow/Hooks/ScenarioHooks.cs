using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.Pages;
using EasyScanSpecflow.StepLogging;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
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
    internal class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private MainPage mainPage;

        public ScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            mainPage = new MainPage(AppiumDriver.Current, scenarioContext);
        }

        [BeforeTestRun] 
        public static void CreateTestRunTestRail()
        {
            try
            {
                TestRail.InitializeTestRail();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
            }
        }

        [AfterStep]
        public void GetFirstFailedStep()
        {
            if(((string)_scenarioContext["ExceptionMessage"]).Length > 0 && !_scenarioContext.ContainsKey("FailedStep"))
            {
                _scenarioContext["FailedStep"] = _scenarioContext.StepContext.StepInfo.Text;
            }
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                LogWriter.LogWrite("Started test: " + TestContext.CurrentContext.Test.Name);
                _scenarioContext["ExceptionMessage"] = "";

                if (AppiumDriver.Current.GetAppState(Config.configuration["AppPackage"]) != OpenQA.Selenium.Appium.Enums.AppState.RunningInForeground)
                {
                    LogWriter.LogWrite("Alert: opening the app");
                    AppiumDriver.Current.ActivateApp(Config.configuration["AppPackage"]);
                }

                bool isOnMainScreen;
                for (int i = 0; i < 7; i++)
                {
                    isOnMainScreen = mainPage.IsPriceCheckerButtonDisplayed();
                    if (isOnMainScreen)
                    {
                        break;
                    }
                    else if(i >= 6)
                    {
                        LogWriter.LogWrite("Alert: Could not load main screen");
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                LogWriter.LogWrite("Test ended.");

                var tags = _scenarioContext.ScenarioInfo.Tags;
                var testCaseIds = tags
                    .Where(i => i.StartsWith("TC")) //get all entries that start with TC
                    .Select(i => i.Substring(2)) //get only the part after TC
                    .ToList();

                if (testCaseIds.Count == 1) // Send result if scenario has test rail case id tag
                {
                    Dictionary<string, object> testResult = new Dictionary<string, object>();
                    if (TestContext.CurrentContext.Result.FailCount > 0)
                    {
                        testResult["status_id"] = "5"; //failed;
                        testResult["comment"] = "";
                        if (_scenarioContext.ContainsKey("FailedStep"))
                        {
                            testResult["comment"] += "Failed at step: " + _scenarioContext["FailedStep"] + "\n";
                        }
                        if (_scenarioContext.ContainsKey("FailedAction"))
                        {
                            testResult["comment"] += "Failed at action: " + _scenarioContext["FailedAction"] + "\n";
                        }
                        if (_scenarioContext.ContainsKey("ExceptionMessage"))
                        {
                            testResult["comment"] += "Exception message: \n" + _scenarioContext["ExceptionMessage"];
                        }
                    }
                    else
                    {
                        testResult["status_id"] = "1"; //passed
                    }

                    // testCaseIds[0] case id
                    TestRail.Client.SendPost("add_result_for_case/" + 1418 + "/" + testCaseIds[0], testResult);
                }

                bool isOnMainScreen;
                int i;
                for(i = 0; i < 8; i++)
                {
                    isOnMainScreen = mainPage.IsPriceCheckerButtonDisplayed();
                    if (isOnMainScreen)
                    {
                        break;
                    }
                    AppiumDriver.Current.PressKeyCode(AndroidKeyCode.Back);
                    LogWriter.LogWrite("Action: back keycode was pressed");
                }

                if (i >= 8)// close app if stuck in some menu
                {
                    LogWriter.LogWrite("Alert: Could not go back to main screen");
                    LogWriter.LogWrite("Alert: Closing the app");
                    AppiumDriver.Current.CloseApp(); //comment out if testing settings
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
            }
        }
    }
}

