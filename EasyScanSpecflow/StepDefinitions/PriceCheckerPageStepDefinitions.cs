using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.Pages;
using EasyScanSpecflow.StepLogging;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.StepDefinitions
{
    [Binding]
    public class PriceCheckerPageStepDefinitions
    {
        private PriceCheckerPage priceCheckerPage;
        private readonly ScenarioContext _scenarioContext;

        public PriceCheckerPageStepDefinitions(ScenarioContext scenarioContext)
        {
            priceCheckerPage = new PriceCheckerPage(AppiumDriver.Current, scenarioContext);
            _scenarioContext = scenarioContext;
        }

        [When(@"Plus button is pressed")]
        public void WhenPlusButtonIsPressed()
        {
            priceCheckerPage.PressAddButton();
        }

        [When(@"Product code (.*) is entered and submitted")]
        public void WhenProductCodeIsEnteredAndSubmitted(string productCode)
        {
            priceCheckerPage.EnterProductCode(productCode);
            priceCheckerPage.PressSubmitButton();
        }

        [When(@"Product code (.*) is entered and submitted with numeric keyboard")]
        public void WhenProductCodeIsEnteredAndSubmittedWithNumericKeyboard(string productCode)
        {
            priceCheckerPage.EnterProductCodeNumeric(productCode);
            priceCheckerPage.PressSubmitButton();
        }


        [Then(@"Product (.*) should be displayed")]
        public void ThenProductShouldBeDisplayed(string expectedProductTitle)
        {
            string actualTitle = priceCheckerPage.GetProductTitle();
            try
            {
                Assert.AreEqual(expectedProductTitle, actualTitle);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"Product code should be (.*)")]
        public void ThenProductCodeShouldBe(string expectedProductCode)
        {
            string actualCode = priceCheckerPage.GetProductCode();
            try
            {
                Assert.AreEqual("Code:\r\n  " + expectedProductCode, actualCode);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"Product price should be (.*)")]
        public void ThenProductPriceShouldBe(string expectedPrice)
        {
            string actualPrice = priceCheckerPage.GetProductPrice();
            try
            {
                Assert.AreEqual("Price:\r\n  " + expectedPrice + "€", actualPrice);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"Product stock should be (.*)")]
        public void ThenProductStockShouldBe(string expectedProductStock)
        {
            string actualStock = priceCheckerPage.GetProductStock();
            try
            {
                Assert.AreEqual("Stock:\r\n  " + expectedProductStock.ToString(), actualStock);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"Product description should be (.*)")]
        public void ThenProductDescriptionShouldBe(string expectedProductDescription)
        {
            string actualDescription = priceCheckerPage.GetProductDescription();
            try
            {
                Assert.AreEqual("Description:\r\n  " + expectedProductDescription, actualDescription);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"app return message that item not found")]
        public void ThenAppReturnMessageThatItemNotFound()
        {
            try
            {
                Assert.AreEqual(priceCheckerPage.getToastMessage(), "Information about barcode not found");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"app should return message '([^']*)'")]
        public void ThenAppShouldReturnMessage(string expectedToastMessage)
        {
            try
            {
                Assert.AreEqual(priceCheckerPage.getToastMessage(), expectedToastMessage);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"user checks items by barcode and their values match:")]
        public void ThenUserChecksItemsByBarcodeAndTheirValuesMatch(Table table)
        {
                foreach (var tableRow in table.Rows)
                {
                    priceCheckerPage.PressAddButton();
                    string productBarcode = tableRow["Barcode"];
                    WhenProductCodeIsEnteredAndSubmitted(productBarcode);

                    ThenProductShouldBeDisplayed(tableRow["Name"]);
                    ThenProductCodeShouldBe(productBarcode);
                    ThenProductPriceShouldBe(tableRow["Price"]);
                    ThenProductStockShouldBe(tableRow["Stock"]);
                    ThenProductDescriptionShouldBe(tableRow["Name"]);
                }
        }

        [Then(@"user checks items by discarded barcode and their values match:")]
        public void ThenUserChecksItemsByDiscardedBarcodeAndTheirValuesMatch(Table table)
        {
                foreach (var tableRow in table.Rows)
                {
                    priceCheckerPage.PressAddButton();
                    string productBarcode = tableRow["Barcode"];
                    string productBarcodeDiscarded = tableRow["ExpectedBarcode"];
                    WhenProductCodeIsEnteredAndSubmitted(productBarcode);

                    ThenProductShouldBeDisplayed(tableRow["Name"]);
                    ThenProductCodeShouldBe(productBarcodeDiscarded);
                    ThenProductPriceShouldBe(tableRow["Price"]);
                    ThenProductStockShouldBe(tableRow["Stock"]);
                    ThenProductDescriptionShouldBe(tableRow["Name"]);
                }
        }
        [Then(@"user checks items by barcode and their values match with the numeric barcode setting:")]
        public void ThenUserChecksItemsByBarcodeAndTheirValuesMatchWithTheSetting(Table table)
        {
                foreach (var tableRow in table.Rows)
                {
                    priceCheckerPage.PressAddButton();
                    string productBarcode = tableRow["Barcode"];
                    priceCheckerPage.EnterProductCodeNumeric(productBarcode);
                    priceCheckerPage.PressSubmitButton();

                    ThenProductShouldBeDisplayed(tableRow["Name"]);
                    ThenProductCodeShouldBe(productBarcode);
                    ThenProductPriceShouldBe(tableRow["Price"]);
                    ThenProductStockShouldBe(tableRow["Stock"]);
                    ThenProductDescriptionShouldBe(tableRow["Name"]);
                }
        }

        [Then(@"user checks items by discarded barcode and numeric and their values match:")]
        public void ThenUserChecksItemsByDiscardedBarcodeAndNumericAndTheirValuesMatch(Table table)
        {
                foreach (var tableRow in table.Rows)
                {
                    priceCheckerPage.PressAddButton();
                    string productBarcode = tableRow["Barcode"];
                    string productBarcodeDiscarded = tableRow["ExpectedBarcode"];
                    priceCheckerPage.EnterProductCodeNumeric(productBarcode);
                    priceCheckerPage.PressSubmitButton();

                    ThenProductShouldBeDisplayed(tableRow["Name"]);
                    ThenProductCodeShouldBe(productBarcodeDiscarded);
                    ThenProductPriceShouldBe(tableRow["Price"]);
                    ThenProductStockShouldBe(tableRow["Stock"]);
                    ThenProductDescriptionShouldBe(tableRow["Name"]);
                }
        }
    }
}
