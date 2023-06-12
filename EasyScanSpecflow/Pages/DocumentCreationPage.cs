using EasyScanSpecflow.StepLogging;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.Pages
{
    public class DocumentCreationPage
    {
        private AndroidDriver<AppiumWebElement> driver;
        private readonly ScenarioContext _scenarioContext;

        private AppiumWebElement AddOperationButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/addOperation"));
        private AppiumWebElement AddItemButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/addItem"));
        private AppiumWebElement SyncButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/syncButton"));
        private AppiumWebElement DocumentNumberTextField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/opVisualId"));
        private AppiumWebElement DocumentCommentTextField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/comment"));
        private AppiumWebElement SubmitButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/submit"));
        private AppiumWebElement CancelButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/cancel_button"));
        private AppiumWebElement ProductBarcode =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/itemName"));
        private AppiumWebElement ProductQuantityField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/quantity"));
        private AppiumWebElement ProductDeleteButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/unknownDeleteButton"));
        private AppiumWebElement LatestDocumentNumber =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.LinearLayout/" +
                "android.widget.RelativeLayout/android.widget.TextView[1]"));
        private AppiumWebElement LatestDocument =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.LinearLayout"));
        private AppiumWebElement LatestProductBarcode =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.LinearLayout/" +
                "android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.TextView[2]"));
        private AppiumWebElement LatestProductQuantity =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.LinearLayout/" +
                "android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.TextView[2]"));
        private AppiumWebElement LatestProductThreeDotsButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[1]/android.widget.LinearLayout/" +
                "android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.ImageView"));
        private AppiumWebElement SecondProductQuantity =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/" +
                "androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[2]/android.widget.LinearLayout/" +
                "android.widget.RelativeLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.TextView[2]"));
        private List<AppiumWebElement> ProductQuantities =>
           driver.FindElements(By.Id("com.sg.qr.easyscanapp:id/quantity")).ToList();
        private List<AppiumWebElement> ProductBarcodes =>
           driver.FindElements(By.Id("com.sg.qr.easyscanapp:id/code")).ToList();
        private AppiumWebElement PackageField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/noItemsText"));
        private AppiumWebElement ToastMessage =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.Toast[1]"));

        public DocumentCreationPage(AndroidDriver<AppiumWebElement> driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
        }

        public void ClickAddOperationButton()
        {
            try
            {
                AddOperationButton.Click();
                LogWriter.LogWrite("Action: add operation button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "add operation button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public string GetToastMessage()
        {
            try
            {
                return ToastMessage.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        public void ClickAddButton()
        {
            try
            {
                AddItemButton.Click();
                LogWriter.LogWrite("Action: add button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "add button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterDocumentNumber(string documentNumber)
        {
            try
            {
                DocumentNumberTextField.SendKeys(documentNumber);
                LogWriter.LogWrite("Action: document number was entered - " + documentNumber);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "document number was entered - " + documentNumber;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterDocumentComment(string documentComment)
        {
            try
            {
                DocumentCommentTextField.SendKeys(documentComment);
                LogWriter.LogWrite("Action: document comment was entered - " + documentComment);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "document comment was entered - " + documentComment;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressSubmit()
        {
            try
            {
                SubmitButton.Click();
                LogWriter.LogWrite("Action: submit button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "submit button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressCancel()
        {
            try
            {
                CancelButton.Click();
                LogWriter.LogWrite("Action: cancel button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "cancel button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public string GetLatestDocumentNumber()
        {
            try
            {
                return LatestDocumentNumber.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public void SelectLatestDocument()
        {
            try
            {
                LatestDocument.Click();
                LogWriter.LogWrite("Action: latest document was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "latest document was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterProductBarcode(string barcode)
        {
            try
            {
                ProductBarcode.SendKeys(barcode);
                LogWriter.LogWrite("Action: barcode was entered - " + barcode);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "barcode was entered - " + barcode;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void SyncItems()
        {
            try
            {
                SyncButton.Click();
                LogWriter.LogWrite("Action: sync button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "sync button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public string GetLatestItemBarcode()
        {
            try
            {
                return LatestProductBarcode.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string GetLatestItemQuantity()
        {
            try
            {
                return LatestProductQuantity.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public bool IsToastMessageDisplayed(string message)
        {
            try
            {
                XMLSaving.XMLWrite(driver.PageSource);

                bool output = false;
                foreach (var line in File.ReadLines("XML.txt"))
                {
                    if (!output && line.Contains(message))
                    {
                        output = true;
                        break;
                    }
                }
                File.WriteAllText("XML.txt", String.Empty);

                return output;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return false;
                throw;
            }
        }

        public void EnterProductQuantity(string quantity)
        {
            try
            {
                ProductQuantityField.SendKeys(quantity);
                LogWriter.LogWrite("Action: quantity was entered - " + quantity);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "quantity was entered - " + quantity;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void ClickLatestProductThreeDotsButton()
        {
            try
            {
                LatestProductThreeDotsButton.Click();
                LogWriter.LogWrite("Action: latest three dot button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "latest three dot button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void ClickDelete()
        {
            try
            {
                ProductDeleteButton.Click();
                LogWriter.LogWrite("Action: product delete button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "product delete button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        
        public string GetSecondItemQuantity()
        {
            try
            {
                return SecondProductQuantity.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public List<string> GetItemQuantityStrings()
        {
            try
            {
                List<string> quantities = new List<string>();
                foreach (var element in ProductQuantities)
                {
                    quantities.Add(element.GetAttribute("text"));
                }
                return quantities;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return null;
                throw;
            }
        }

        public List<string> GetItemBarcodeStrings()
        {
            try
            {
                List<string> barcodes = new List<string>();
                foreach (var element in ProductBarcodes)
                {
                    barcodes.Add(element.GetAttribute("text"));
                }
                return barcodes;
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return null;
                throw;
            }
        }

        public string GetPackageFieldText()
        {
            try
            {
                return PackageField.GetAttribute("text");
            }
            catch(Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public void EnterProductBarcodeNumeric(string barcode)
        {
            try
            {
                ProductBarcode.Click();
                foreach (char digit in barcode)
                {
                    switch (digit)
                    {
                        case '1':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_1);
                            break;
                        case '2':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_2);
                            break;
                        case '3':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_3);
                            break;
                        case '4':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_4);
                            break;
                        case '5':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_5);
                            break;
                        case '6':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_6);
                            break;
                        case '7':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_7);
                            break;
                        case '8':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_8);
                            break;
                        case '9':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_9);
                            break;
                        case '0':
                            driver.PressKeyCode(AndroidKeyCode.KeycodeNumpad_0);
                            break;
                    }
                }
                LogWriter.LogWrite("Action: product code was entered - " + barcode);
                driver.HideKeyboard();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "product code was entered - " + barcode;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
    }
}
