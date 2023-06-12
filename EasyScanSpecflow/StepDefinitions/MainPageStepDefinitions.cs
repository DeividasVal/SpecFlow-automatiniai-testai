using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.Pages;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EasyScanSpecflow.StepLogging;

namespace EasyScanSpecflow.StepDefinitions
{
    [Binding]
    public class MainPageStepDefinitions
    {
        private MainPage mainPage;
        private readonly ScenarioContext _scenarioContext;

        public MainPageStepDefinitions(ScenarioContext scenarioContext)
        {
            mainPage = new MainPage(AppiumDriver.Current, scenarioContext);
            _scenarioContext = scenarioContext;
        }
        [When(@"user selects price checker")]
        public void WhenUserSelectsPriceChecker()
        {
            mainPage.PressPriceCheckerButton();
        }

        [Given(@"user selects stockadding")]
        [When(@"user selects stockadding")]
        public void WhenUserSelectsStockadding()
        {
            mainPage.PressStockaddingButton();
        }

        [Scope(Tag = "WS")]
        [Given(@"user selects stockadding")]
        [When(@"user selects stockadding")]
        public void WhenUserSelectsStockaddingInWS()
        {
            mainPage.PressStockAddingButtonWS();
        }

        [Given(@"user selects stocktaking")]
        [When(@"user selects stocktaking")]
        public void WhenUserSelectsStocktaking()
        {
            mainPage.PressStocktakingButton();
        }

        [Given(@"user selects write-off")]
        [When(@"user selects write-off")]
        public void WhenUserSelectsWrite_Off()
        {
            mainPage.PressWriteOffButton();
        }

        [When(@"user selects WriteoffWS")]
        public void WhenUserSelectsWriteoffWS()
        {
            mainPage.PressWriteOffButtonWS();
        }

        [When(@"user selects stocktakingWS")]
        public void WhenUserSelectsStocktakingWS()
        {
            mainPage.PressStockTakingButtonWS();
        }

        [When(@"user selects Barcode change")]
        public void WhenUserSelectsBarcodeChange()
        {
            mainPage.PressBarcodeChangeButton();
        }
        [When(@"user selects stockaddingWS")]
        public void WhenUserSelectsStockaddingWS()
        {
            mainPage.PressStockAddingButtonWS();
        }

        [When(@"user selects adjustment")]
        public void WhenUserSelectsAdjustment()
        {
            mainPage.PressAdjustmentButton();
        }

        [When(@"user selects purchaseOrders")]
        public void WhenUserSelectsPurchaseOrders()
        {
            mainPage.PressPurchaseOrdersButton();
        }

        [When(@"user selects sale")]
        public void WhenUserSelectsSale()
        {
            mainPage.PressSaleButton();
        }
    }
}
