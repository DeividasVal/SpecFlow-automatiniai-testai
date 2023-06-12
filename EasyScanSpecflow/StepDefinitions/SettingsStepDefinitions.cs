using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.Pages;
using EasyScanSpecflow.StepLogging;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using TechTalk.SpecFlow;

namespace EasyScanSpecflow.StepDefinitions
{
    [Binding]
    public class SettingsStepDefinitions
    {
        private MainPage mainPage;
        private SettingsPage settingsPage;
        private readonly ScenarioContext _scenarioContext;

        public SettingsStepDefinitions(ScenarioContext scenarioContext)
        {
            mainPage = new MainPage(AppiumDriver.Current, scenarioContext);
            settingsPage = new SettingsPage(AppiumDriver.Current, scenarioContext);
            _scenarioContext = scenarioContext;
        }

        [Given(@"the user is on settings page")]
        public void GivenTheUserIsOnSettingsPage()
        {
            mainPage.PressSettingsButton();
        }

        [When(@"user inputs ""([^""]*)"" in API text field and presses save")]
        public void WhenUserInputsInAPITextFieldAndPressesSave(string key)
        {
            settingsPage.EnterAPIKey(key);
        }

        [Given(@"WIFI on phone is off")]
        public void GivenWIFIOnPhoneIsOff()
        {
            AppiumDriver.Current.ConnectionType = ConnectionType.None;
        }

        [Given(@"WIFI on phone is on")]
        public void GivenWIFIOnPhoneIsOn()
        {
            AppiumDriver.Current.ConnectionType = ConnectionType.WifiOnly;
        }

        [When(@"user tries to download settings")]
        public void WhenUserTriesToDownloadSettings()
        {
            settingsPage.ClickDownloadSettingsButton();
        }

        [Then(@"toast ""([^""]*)"" shows up")]
        public void ThenToastShowsUp(string message)
        {
            try
            {
                Assert.AreEqual(settingsPage.GetToastMessage(), message);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Given(@"last digit discard setting is on")]
        public void GivenLastDigitDiscardSettingIsOn()
        {
            settingsPage.DiscardLastDigitCheck();
        }
        [Given(@"numeric barcode is on")]
        public void GivenNumericBarcodeIsOn()
        {
            settingsPage.NumericBarcodeCheck();
        }
        [Given(@"item grouping is on")]
        public void GivenItemGroupingIsOn()
        {
            settingsPage.ItemGroupingCheck();
        }

        [Given(@"last digit discard and numeric barcode is on")]
        public void GivenLastDigitDiscardAndNumericBarcodeIsOn()
        {
            settingsPage.DiscardedAndNumericCheck();
        }
    }
}
