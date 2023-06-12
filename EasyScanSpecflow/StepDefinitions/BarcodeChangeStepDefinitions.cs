using EasyScanSpecflow.Pages;
using EasyScanSpecflow.StepLogging;
using EasyScanSpecflow.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using TechTalk.SpecFlow;

namespace EasyScanSpecflow.StepDefinitions
{
    [Binding]
    public class BarcodeChangeStepDefinitions
    {
        private BarcodePage barcodeChange;
        private readonly ScenarioContext _scenarioContext;

        public BarcodeChangeStepDefinitions(ScenarioContext scenarioContext)
        {
            barcodeChange = new BarcodePage(AppiumDriver.Current, scenarioContext);
            _scenarioContext = scenarioContext;
        }

        [When(@"user presses change button")]
        public void WhenUserPressesChangeButton()
        {
            barcodeChange.ClickChangeButton();
        }

        [When(@"user enters new (.*) and document (.*)")]
        public void WhenUserEntersNewAnd(int newBarcodeNumber, int docNumber)
        {
            barcodeChange.EnterNewBarcode(newBarcodeNumber.ToString());
            barcodeChange.EnterDocumentNumber(docNumber.ToString());
        }

        [When(@"user presses save")]
        public void WhenUserPressesSave()
        {
            barcodeChange.ClickSaveButton(); //change and save use the same id
        }

        [Then(@"BarCode is changed successfuly")]
        public void ThenBarCodeIsChangedSuccessfuly()
        {
            //Assert.IsTrue(barcodeChange.IsToastMessageDisplayed("Data uploaded successfully"));

            try
            {
                Assert.AreEqual(barcodeChange.GetToastMesssage(), "Data uploaded successfully");
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
