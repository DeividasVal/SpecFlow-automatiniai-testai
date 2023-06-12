using EasyScanSpecflow.StepLogging;
using NUnit.Framework;
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
    public class MainPage
    {
        private AndroidDriver<AppiumWebElement> driver;
        private readonly ScenarioContext _scenarioContext;

        private AppiumWebElement PriceCheckerButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/price_checker_button"));
        private AppiumWebElement BarcodeChangeButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/barcodeChange"));
        private AppiumWebElement StockaddingButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.Button"));
        private AppiumWebElement StocktakingButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.Button"));
        private AppiumWebElement WriteOffButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[3]/android.widget.Button"));
        private AppiumWebElement SettingsButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.RelativeLayout/" +
                "android.widget.RelativeLayout/android.widget.ImageView"));
        private AppiumWebElement OfflineStatus =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/statusText"));
        private AppiumWebElement AdjustmentButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.Button"));
        private AppiumWebElement PurchaseOrdersButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.Button"));
        private AppiumWebElement SaleButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[3]/android.widget.Button"));
        private AppiumWebElement StockAddingButtonWS =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[4]/android.widget.Button"));
        private AppiumWebElement StockTakingButtonWS =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[5]/android.widget.Button"));
        private AppiumWebElement TransferButton =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[6]/android.widget.Button"));
        private AppiumWebElement WriteOffButtonWS =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/" +
                "android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.ScrollView/" +
                "android.widget.LinearLayout/android.widget.LinearLayout/android.widget.LinearLayout[7]/android.widget.Button"));


        public MainPage(AndroidDriver<AppiumWebElement> driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
        }

        public void PressPriceCheckerButton()
        {
            try
            {
                PriceCheckerButton.Click();
                LogWriter.LogWrite("Action: price checker button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "price checker button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        
        public bool IsPriceCheckerButtonDisplayed()
        {
            try
            {
                return PriceCheckerButton.GetAttribute("displayed") == "true";
            }
            catch(Exception)
            {
                LogWriter.LogWrite("Alert: Price checker button could not be found");
                return false;
                throw;
            }
        }

        public void PressAdjustmentButton()
        {
            try
            {
                AdjustmentButton.Click();
                LogWriter.LogWrite("Action: adjustment button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "adjustment button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressPurchaseOrdersButton()
        {
            try
            {
                PurchaseOrdersButton.Click();
                LogWriter.LogWrite("Action: purchase orders button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "purchase orders button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressSaleButton()
        {
            try
            {
                SaleButton.Click();
                LogWriter.LogWrite("Action: sale button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "sale button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressStockAddingButtonWS()
        {
            try
            {
                StockAddingButtonWS.Click();
                LogWriter.LogWrite("Action: stock adding button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "stock adding button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressStockTakingButtonWS()
        {
            try
            {
                StockTakingButtonWS.Click();
                LogWriter.LogWrite("Action: stock taking button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "stock taking button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressTransferButton()
        {
            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                    "scrollIntoView(new UiSelector().textContains(\"" + "Transfer" + "\").instance(0))");
                TransferButton.Click();
                LogWriter.LogWrite("Action: transfer button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "transfer button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressWriteOffButtonWS()
        {
            try
            {
                driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true).instance(0))." +
                    "scrollIntoView(new UiSelector().textContains(\"" + "Write-off" + "\").instance(0))");
                WriteOffButtonWS.Click();
                LogWriter.LogWrite("Action: write off button button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "write off button button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressBarcodeChangeButton()
        {
            try
            {
                BarcodeChangeButton.Click();
                LogWriter.LogWrite("Action: barcode change button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "barcode change button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressStockaddingButton()
        {
            try
            {
                StockaddingButton.Click();
                LogWriter.LogWrite("Action: stock adding button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "stock adding button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressStocktakingButton()
        {
            try
            {
                StocktakingButton.Click();
                LogWriter.LogWrite("Action: stock taking button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "stock taking button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void PressWriteOffButton()
        {
            try
            {
                WriteOffButton.Click();
                LogWriter.LogWrite("Action: write off button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "write off button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }
        public void PressSettingsButton()
        {
            try
            {
                SettingsButton.Click();
                LogWriter.LogWrite("Action: settings button was pressed");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if (!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = "settings button was pressed";
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public string GetStatusMessage()
        {
            try
            {
                return OfflineStatus.GetAttribute("text");
            }
            catch (Exception)
            {
                LogWriter.LogWrite("Alert: Offline status is gone");
                return "";
                throw;
            }
        }
        public AppiumWebElement? GetOfflineID()
        {
            try
            {
                return OfflineStatus;
            }
            catch(Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return null;
                throw;
            }
        }
    }
}
