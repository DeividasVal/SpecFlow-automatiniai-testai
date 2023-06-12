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
    class SettingsPage
    {
        private AndroidDriver<AppiumWebElement> driver;
        private readonly ScenarioContext _scenarioContext;

        public SettingsPage(AndroidDriver<AppiumWebElement> driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
        }

        private AppiumWebElement APIKeyField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/apiKey"));
        private AppiumWebElement SaveButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/save"));
        private AppiumWebElement LastDigitCheck =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/discardLastDigit"));
        private AppiumWebElement BackButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/back_button"));
        public AppiumWebElement NumericBarcodeToggleSwitch =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/numericBarcode"));
        public AppiumWebElement ItemGroupingToggleSwitch =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/itemGrouping"));
        public AppiumWebElement StockIDField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/storeId"));
        private AppiumWebElement ToastMessage =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.Toast[1]"));

        public void EnterAPIKey(string key)
        {
            string action = "API key entered -" + key;
            try
            {
                APIKeyField.SendKeys(key);
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                    "scrollIntoView(new UiSelector().textContains(\"" + "Save" + "\").instance(0))").Click();
                LogWriter.LogWrite("Action: " + action);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void ClickSaveButton()
        {
            string action = "save button clicked";
            try
            {
                SaveButton.Click();
                LogWriter.LogWrite("Action: " + action);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
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

        public void ClickDownloadSettingsButton()
        {
            string action = "download settings button clicked";
            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                    "scrollIntoView(new UiSelector().textContains(\"" + "DOWNLOAD SETTINGS" + "\").instance(0))").Click();
                LogWriter.LogWrite("Action: " + action);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void DiscardLastDigitCheck()
        {
            string action = "";
            try
            {
                if (!StockIDField.GetAttribute("text").Equals("discard"))
                {
                    StockIDField.SendKeys("discard");
                    action = "save settings button pressed";
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                        "scrollIntoView(new UiSelector().textContains(\"" + "Save" + "\").instance(0))").Click();
                    LogWriter.LogWrite("Action: " + action);
                }
                else
                {
                    action = "back button pressed";
                    BackButton.Click();
                    LogWriter.LogWrite("Action: " + action);
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
       
        public void NumericBarcodeCheck()
        {
            string action = "";
            try
            {
                if (!StockIDField.GetAttribute("text").Equals("numeric"))
                {
                    StockIDField.SendKeys("numeric");
                    action = "save settings button pressed";
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                        "scrollIntoView(new UiSelector().textContains(\"" + "Save" + "\").instance(0))").Click();
                    LogWriter.LogWrite("Action: " + action);
                }
                else
                {
                    action = "back button pressed";
                    BackButton.Click();
                    LogWriter.LogWrite("Action: " + action);
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        public void ItemGroupingCheck()
        {
            string action = "";
            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                    "scrollIntoView(new UiSelector().textContains(\"" + "Item grouping" + "\").instance(0))");
                if (ItemGroupingToggleSwitch.GetAttribute("checked").Equals("true"))
                {
                    action = "back button pressed";
                    BackButton.Click();
                    LogWriter.LogWrite("Action: " + action);
                }
                else
                {
                    action = "item grouping setting checked";
                    ItemGroupingToggleSwitch.Click();
                    LogWriter.LogWrite("Action: " + action);
                    action = "save settings button pressed";
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                        "scrollIntoView(new UiSelector().textContains(\"" + "Save" + "\").instance(0))").Click();
                    LogWriter.LogWrite("Action: " + action);
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void DiscardedAndNumericCheck()
        {
            string action = "";
            try
            {
                if (!StockIDField.GetAttribute("text").Equals("both"))
                {
                    StockIDField.SendKeys("both");
                    action = "save settings button pressed";
                    driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                        "scrollIntoView(new UiSelector().textContains(\"" + "Save" + "\").instance(0))").Click();
                    LogWriter.LogWrite("Action: " + action);
                }
                else
                {
                    action = "back button pressed";
                    BackButton.Click();
                    LogWriter.LogWrite("Action: " + action);
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
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
    }
}
