using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace Calculator
{
    class Program
    {
        private static WindowsDriver<WindowsElement> Session;
        public static void Main(string[] args)
        {
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Session.Manage().Window.Maximize();
            Session.FindElementByName("Two").Click();
            Session.FindElementByName("Plus").Click();
            Session.FindElementByName("Two").Click();
            Session.FindElementByName("Equals").Click();
            var results = Session.FindElementByAccessibilityId("CalculatorResults");
            Console.WriteLine(results.Text);
            Session.Quit();
        }
    }
}
