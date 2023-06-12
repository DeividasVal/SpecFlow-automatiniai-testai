using EasyScanSpecflow.Drivers;
using EasyScanSpecflow.StepLogging;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.Pages
{
    public class PriceCheckerPage
    {
        private AndroidDriver<AppiumWebElement> driver;
        private readonly ScenarioContext _scenarioContext;

        private AppiumWebElement AddButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/addItem"));
        private AppiumWebElement BackButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/back_button"));
        private AppiumWebElement SubmitProductButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/submit"));
        private AppiumWebElement ProductCodeTextField =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/itemName"));
        private AppiumWebElement CancelProductButton =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/cancel_button"));
        private AppiumWebElement ProductTitle =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/priceCheckTitle"));
        private AppiumWebElement ProductCode =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/itemCode"));
        private AppiumWebElement ProductPrice =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/itemPrice"));
        private AppiumWebElement ProductStock =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/stock"));
        private AppiumWebElement ProductDescription =>
            driver.FindElement(By.Id("com.sg.qr.easyscanapp:id/labelDescription"));
        private AppiumWebElement ToastMessage =>
            driver.FindElement(By.XPath("/hierarchy/android.widget.Toast[1]"));

        public PriceCheckerPage(AndroidDriver<AppiumWebElement> driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            _scenarioContext = scenarioContext;
        }

        public void PressAddButton()
        {
            string action = "add button was pressed";
            try
            {
                AddButton.Click();
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

        public void PressBackButton()
        {
            string action = "back button was pressed";
            try
            {
                BackButton.Click();
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

        public void EnterProductCode(string code)
        {
            string action = "product code was entered - " + code;
            try
            {
                ProductCodeTextField.SendKeys(code);
                LogWriter.LogWrite("Action: " + action);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                if(!_scenarioContext.ContainsKey("FailedAction"))
                    _scenarioContext["FailedAction"] = action;
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public void EnterProductCodeNumeric(string code)
        {
            string action = "product code was entered - " + code;
            try
            {
                ProductCodeTextField.Click();
                foreach(char digit in code)
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
                LogWriter.LogWrite("Action: " + action);
                driver.HideKeyboard();
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

        public void PressSubmitButton()
        {
            string action = "submit button was pressed";
            try
            {
                SubmitProductButton.Click();
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

        public void PressCancelButton()
        {
            string action = "cancel button was pressed";
            try
            {
                CancelProductButton.Click();
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

        public string GetProductTitle()
        {
            try
            {
                return ProductTitle.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                throw;
            }
        }

        public string GetProductCode()
        {
            try
            {
                return ProductCode.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string GetProductPrice()
        {
            try
            {
                return ProductPrice.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string GetProductStock()
        {
            try
            {
                return ProductStock.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string getToastMessage()
        {
            try
            {
                return ToastMessage.GetAttribute("text");
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                _scenarioContext["ExceptionMessage"] += ex.ToString() + "\n";
                return "";
                throw;
            }
        }

        public string GetProductDescription()
        {
            try
            {
                return ProductDescription.GetAttribute("text");
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
    }
}
