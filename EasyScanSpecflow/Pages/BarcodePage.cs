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
    internal class BarcodePage
    {
        private AndroidDriver<AppiumWebElement> driver;
        private readonly ScenarioContext _scenarioContext;

        private AppiumWebElement ChangeButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/change")); //save button uses the same id
        private AppiumWebElement DocumentNumber =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/documentId"));
        private AppiumWebElement NewBarcode =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/newBarcode"));
        private AppiumWebElement OldBarcode=>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/oldBarcode"));
        private AppiumWebElement ToastMessage =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.Toast[1]"));

        public BarcodePage(AndroidDriver<AppiumWebElement> driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
        }

        public void ClickChangeButton()
        {
            try
            {
                ChangeButton.Click();
                LogWriter.LogWrite("Action: change button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "change button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void ClickSaveButton()
        {
            try
            {
                ChangeButton.Click();
                LogWriter.LogWrite("Action: save button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "save button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterDocumentNumber(string number)
        {
            try
            {
                DocumentNumber.SendKeys(number);
                LogWriter.LogWrite("Action: document number was entered - " + number);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "document number was entered - " + number;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterNewBarcode(string number)
        {
            try
            {
                NewBarcode.SendKeys(number);
                LogWriter.LogWrite("Action: new barcode number was entered - " + number);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "new barcode number was entered - " + number;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        public string GetNewBarcode()
        {
            try
            {
                return NewBarcode.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }
        public string GetOldBarcode()
        {
            try
            {
                return OldBarcode.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }
        public string GetDocumentId()
        {
            try
            {
                return DocumentNumber.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string GetToastMesssage()
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
    }
}
