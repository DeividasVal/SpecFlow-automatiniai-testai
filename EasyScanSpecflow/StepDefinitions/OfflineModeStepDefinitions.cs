using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.Pages;
using EasyScanSpecflow.StepLogging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace EasyScanSpecflow.StepDefinitions
{
    [Binding]
    public class OfflineModeStepDefinitions
    {
        private MainPage mainPage;
        private BarcodePage barcodeChange;
        private DocumentCreationPage documentCreationPage;
        private readonly ScenarioContext _scenarioContext;

        public OfflineModeStepDefinitions(ScenarioContext scenarioContext)
        {
            mainPage = new MainPage(AppiumDriver.Current, scenarioContext);
            barcodeChange = new BarcodePage(AppiumDriver.Current, scenarioContext);
            documentCreationPage = new DocumentCreationPage(AppiumDriver.Current, scenarioContext);
            _scenarioContext = scenarioContext;
        }

        [Given(@"offline mode is on")]
        public void GivenOfflineModeIsOn()
        {
            AppiumDriver.Current.ConnectionType = ConnectionType.None;
            TimeSpan interval = TimeSpan.FromSeconds(3);
            WebDriverWait wait = new WebDriverWait(AppiumDriver.Current, interval);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.Id("com.sg.qr.easyscanapp:id/statusText")));
        }

        [Then(@"user gets a message that can't sync in offline mode")]
        public void ThenUserGetsAMessageThatCantSyncInOfflineMode()
        {
            try
            {
                Assert.AreEqual(barcodeChange.GetToastMesssage(), "You can't sync in offline mode");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"WIFI is turned back on")]
        public void ThenWIFIIsTurnedBackOn()
         {
            AppiumDriver.Current.ToggleWifi();
            TimeSpan interval = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(AppiumDriver.Current, interval);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id("com.sg.qr.easyscanapp:id/statusText")));
        }

        [Then(@"user syncs items")]
        public void ThenUserSyncsItems()
        {
            documentCreationPage.SyncItems();
        }

        [Then(@"BarCodeWS is changed successfuly")]
        public void ThenBarCodeWSIsChangedSuccessfuly()
        {
            try
            {
                Assert.AreEqual(barcodeChange.GetToastMesssage(), "No new data for send");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
    }
}
