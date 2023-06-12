using EasyScanSpecflow.StepLogging;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyScanSpecflow.Drivers
{
    public class AppiumDriver
    {
        private static readonly Lazy<AndroidDriver<AppiumWebElement>> _currentAppiumDriverLazy =
            new Lazy<AndroidDriver<AppiumWebElement>>(InitializeAppium);

        public static AndroidDriver<AppiumWebElement> Current => _currentAppiumDriverLazy.Value;
        private AppiumDriver(){}

        private static AndroidDriver<AppiumWebElement> InitializeAppium()
        {
            var driverOptions = new AppiumOptions();

            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, Config.configuration["PlatformName"]);
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, Config.configuration["PlatformVersion"]);
            driverOptions.AddAdditionalCapability("appPackage", Config.configuration["AppPackage"]); //comment out if testing settings
            driverOptions.AddAdditionalCapability("appActivity", Config.configuration["AppActivity"]); //comment out if testing settings
            driverOptions.AddAdditionalCapability("noReset", true);
            driverOptions.AddAdditionalCapability("disableWindowAnimation", true);

            try
            {
                return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723/wd/hub"), driverOptions);
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(ex.ToString());
                return null;
            }
        }
    }
}
