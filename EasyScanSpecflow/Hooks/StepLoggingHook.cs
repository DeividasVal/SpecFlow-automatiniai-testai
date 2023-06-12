using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.StepLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.Hooks
{
    [Binding]
    internal class StepLoggingHook
    {
        private readonly ScenarioContext _scenarioContext;

        public StepLoggingHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeStep]
        public void LogStepInfo()
        {
            AppiumDriver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LogWriter.LogWrite("Step: " + _scenarioContext.StepContext.StepInfo.Text);
        }
    }
}
