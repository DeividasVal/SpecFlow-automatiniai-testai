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
    public class DocumentCreationStepDefinitions
    {
        private DocumentCreationPage documentCreationPage;
        private List<string> itemBarcodes;
        private List<string> itemQuantities;
        private readonly ScenarioContext _scenarioContext;

        public DocumentCreationStepDefinitions(ScenarioContext scenarioContext)
        {
            documentCreationPage = new DocumentCreationPage(AppiumDriver.Current, scenarioContext);
            itemBarcodes = new List<string>();
            itemQuantities = new List<string>();
            _scenarioContext = scenarioContext;
        }

        [When(@"user enters document (.*)")]
        public void WhenUserEntersDocument(string documentNumber)
        {
            documentCreationPage.EnterDocumentNumber(documentNumber);
        }

        [When(@"user presses add button")]
        public void WhenUserPressesAddButton()
        {
            documentCreationPage.ClickAddButton();
        }

        [When(@"user presses add operation button")]
        public void WhenUserPressesAddOperationButton()
        {
            documentCreationPage.ClickAddOperationButton();
        }

        [Then(@"document (.*) is created successfuly")]
        public void ThenDocumentWriteoffIsCreatedSuccessfuly(string expectedDocumentNumber)
        {
            string actualDocumentNumber = documentCreationPage.GetLatestDocumentNumber();

            try
            {
                Assert.AreEqual(expectedDocumentNumber, actualDocumentNumber);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        [When(@"user enters item '([^']*)'")]

        public void WhenUserEntersItem(string barcode)
        {
            documentCreationPage.EnterProductBarcode(barcode);
        }

        [When(@"user enters item '([^']*)' with numeric keyboard")]
        public void WhenUserEntersItemWithNumericKeyboard(string barcode)
        {
            documentCreationPage.EnterProductBarcodeNumeric(barcode);
        }

        [When(@"user selects latest document")]
        public void WhenUserSelectsLatestDocument()
        {
            documentCreationPage.SelectLatestDocument();
        }

        [When(@"user submits")]
        public void WhenUserSubmits()
        {
            documentCreationPage.PressSubmit();
        }

        [When(@"user submits"), Scope(Tag = "WS")]
        public void WhenUserSubmitsWS()
        {
            documentCreationPage.PressSubmit();
            AppiumDriver.Current.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [When(@"user adds an item (.*)")]
        public void WhenUserAddsAnItem(string barcode)
        {
            documentCreationPage.SelectLatestDocument();
            documentCreationPage.ClickAddButton();
            documentCreationPage.EnterProductBarcode(barcode);
            documentCreationPage.PressSubmit();
        }

        [When(@"user syncs items")]
        public void WhenUserSyncsItems()
        {
            documentCreationPage.SyncItems();
        }

        [Then(@"item (.*) with quantity (.*) is added successfuly")]
        public void ThenItemWithQuantityIsAddedSuccessfuly(string expectedBarcode, string expectedQuantity)
        {
            string actualBarcode = documentCreationPage.GetLatestItemBarcode();
            string actualQuantity = documentCreationPage.GetLatestItemQuantity();
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(expectedBarcode, actualBarcode);
                    Assert.AreEqual("Quantity:" + expectedQuantity, actualQuantity);
                });
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [When(@"user enters quantity (.*)")]
        public void WhenUserEntersQuantity(string quantity)
        {
            documentCreationPage.EnterProductQuantity(quantity);
        }

        [When(@"user presses three dots near the item")]
        public void WhenUserPressesThreeDotsNearTheItem()
        {
            documentCreationPage.ClickLatestProductThreeDotsButton();
        }

        [When(@"user selects delete")]
        public void WhenUserSelectsDelete()
        {
            documentCreationPage.ClickDelete();
        }

        [Then(@"item is deleted and quantity changes to -quantity")]
        public void ThenItemIsDeletedAndQuantityChangesTo_Quantity()
        {
            string deletedItemQuantityString = documentCreationPage.GetLatestItemQuantity().Substring(9);
            string itemQuantityString = documentCreationPage.GetSecondItemQuantity().Substring(9);
            try
            {
                Assert.AreEqual("-" + itemQuantityString, deletedItemQuantityString);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"item is deleted and quantity changes to quantity without -")]
        public void ThenItemIsDeletedAndQuantityChangesToQuantityWithout_()
        {
            string deletedItemQuantityString = documentCreationPage.GetSecondItemQuantity().Substring(9);
            string itemQuantityString = documentCreationPage.GetLatestItemQuantity().Substring(9);
            try
            {
                Assert.AreEqual(deletedItemQuantityString, "-" + itemQuantityString);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [When(@"user submits items:")]
        [Then(@"user submits items:")]
        public void WhenUserSubmitsItems(Table table)
        {
             foreach (var tableRow in table.Rows)
             {
                string barcode = tableRow["Barcode"];
                documentCreationPage.ClickAddButton();
                documentCreationPage.EnterProductBarcode(barcode);
                documentCreationPage.PressSubmit();

                itemBarcodes.Add(documentCreationPage.GetLatestItemBarcode());
                itemQuantities.Add(documentCreationPage.GetLatestItemQuantity());
             }
        }

        [Then(@"items with quantities are added:")]
        public void ThenItemsWithQuantitiesAreAddedSuccessfuly(Table table)
        {
              List<string> actualQuantities = itemQuantities;
              List<string> actualBarcodes = itemBarcodes;
              List<string> expectedQuantities = new List<string>();
              List<string> expectedBarcodes = new List<string>();
              foreach (var tableRow in table.Rows)
              {
                  expectedQuantities.Add(tableRow["ExpectedQuantity"]);
                  expectedBarcodes.Add(tableRow["ExpectedBarcode"]);
              }
                try
                {
                    Assert.AreEqual(actualQuantities.Count(), expectedQuantities.Count());
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite(ex.ToString());
                    _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                    throw;
                }

              for (int i = 0; i < actualQuantities.Count(); i++)
              {
                  string expectedQuantity = expectedQuantities[i];
                  string expectedBarcode = expectedBarcodes[i];
                  string actualQuantity = actualQuantities[i];
                  string actualBarcode = actualBarcodes[i];

                    try
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.AreEqual(expectedBarcode, actualBarcode);
                            Assert.AreEqual("Quantity:" + expectedQuantity, actualQuantity);
                        });
                    }
                    catch (Exception ex)
                    {
                        LogWriter.LogWrite(ex.ToString());
                        _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                        throw;
                    }
              }
        }
        [Then(@"items are synced successfully")]
        public void ThenItemsAreSyncedSuccessfully()
        {
            try
            {
                Assert.AreEqual("Data uploaded successfully", documentCreationPage.GetToastMessage());
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Given(@"document is selected and item is already added and synced")]
        public void GivenDocumentIsSelectedAndItemIsAlreadyAddedAndSynced()
        {
            documentCreationPage.ClickAddOperationButton();
            documentCreationPage.EnterDocumentNumber("test");
            documentCreationPage.PressSubmit();
            documentCreationPage.SelectLatestDocument();

            documentCreationPage.ClickAddButton();
            documentCreationPage.EnterProductBarcode("1");
            documentCreationPage.PressSubmit();
            documentCreationPage.SyncItems();

            try
            {
                Assert.That(Int32.Parse(documentCreationPage.GetLatestItemQuantity().Substring(9)) > 0);

            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Given(@"document is selected and item is already deleted and synced")]
        public void GivenDocumentIsSelectedAndItemIsAlreadyDeletedAndSynced()
        {
            documentCreationPage.ClickAddOperationButton();
            documentCreationPage.EnterDocumentNumber("test");
            documentCreationPage.PressSubmit();
            documentCreationPage.SelectLatestDocument();

            documentCreationPage.ClickAddButton();
            documentCreationPage.EnterProductBarcode("1");
            documentCreationPage.PressSubmit();
            documentCreationPage.SyncItems();

            documentCreationPage.ClickLatestProductThreeDotsButton();
            documentCreationPage.ClickDelete();
            documentCreationPage.SyncItems();

            try
            {
                Assert.That(Int32.Parse(documentCreationPage.GetLatestItemQuantity().Substring(9)) < 0);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        [Then(@"items with quantities are added for item grouping:")]
        public void ThenItemsWithQuantitiesAreAddedForItemGrouping(Table table)
        {
                List<string> actualQuantities = documentCreationPage.GetItemQuantityStrings();
                actualQuantities.Reverse();
                List<string> actualBarcodes = documentCreationPage.GetItemBarcodeStrings();
                actualBarcodes.Reverse();
                List<string> expectedQuantities = new List<string>();
                List<string> expectedBarcodes = new List<string>();
                foreach (var tableRow in table.Rows)
                {
                    expectedQuantities.Add(tableRow["ExpectedQuantity"]);
                    expectedBarcodes.Add(tableRow["ExpectedBarcode"]);
                }
                try
                {
                    Assert.AreEqual(actualQuantities.Count(), expectedQuantities.Count());
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite(ex.ToString());
                    _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                    throw;
                }

                for (int i = 0; i < actualQuantities.Count(); i++)
                {
                    string expectedQuantity = expectedQuantities[i];
                    string expectedBarcode = expectedBarcodes[i];
                    string actualQuantity = actualQuantities[i];
                    string actualBarcode = actualBarcodes[i];
                    try
                    {
                        Assert.Multiple(() =>
                        {
                            Assert.AreEqual(expectedBarcode, actualBarcode);
                            Assert.AreEqual("Quantity:" + expectedQuantity, actualQuantity);
                        });
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
}
