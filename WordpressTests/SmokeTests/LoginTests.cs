using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using WordPressAutomation;


namespace WordpressTests
{
    [TestClass]
    public class LoginTests : WordPressTest
    {
        [TestMethod]
        public void AdminUserCanLogin()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login.");
        }

        [TestMethod]
        public void WorldcupProblemUI()
        {
            
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl("https://www.makemytrip.com");
            Driver.Instance.Manage().Window.Maximize();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (Driver.Instance.FindElements(By.XPath("//a[@class='close']")).Count!=0)
            {
                Driver.Instance.FindElement(By.XPath("//a[@class='close']")).Click();
            }
            Driver.Instance.FindElement(By.XPath("//span[text()='Flights']")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Instance.FindElement(By.XPath("//span[text()='From']")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Instance.FindElement(By.XPath("//input[@placeholder='From']")).SendKeys("Delhi");
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Driver.Instance.FindElement(By.XPath("//span[text()='To']")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            Driver.Instance.FindElement(By.XPath("//input[@placeholder='To']")).SendKeys("Bengaluru");
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Instance.FindElement(By.XPath("//span[text()='From']")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Instance.FindElement(By.XPath("//a[text()='Search']")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            String max_price = null;
            String min_Price = null;
            String First_flight = null;
            string last_flight = null;

            Driver.Instance.FindElement(By.XPath("//span[text()='Price']")).Click();
            if (Driver.Instance.FindElements(By.XPath("//span[text()='Price']/following-sibling::span[@class=' appendLeft10 up sort-arrow']")).Count!=0)
                    {

                min_Price = Driver.Instance.FindElement(By.XPath("//div[@class='priceSection']//p")).Text;

            }

            else
            {
                max_price = Driver.Instance.FindElement(By.XPath("//div[@class='priceSection']//p")).Text;
            }

            Driver.Instance.FindElement(By.XPath("//span[text()='Price']")).Click();

            if (Driver.Instance.FindElements(By.XPath("//span[text()='Price']/following-sibling::span[@class=' appendLeft10 down sort-arrow']")).Count != 0)
            {

                max_price = Driver.Instance.FindElement(By.XPath("//div[@class='priceSection']//p")).Text;

            }
            else
            {
                min_Price = Driver.Instance.FindElement(By.XPath("//div[@class='priceSection']//p")).Text;
            }




            Driver.Instance.FindElement(By.XPath("//span[text()='Departure']")).Click();
            if (Driver.Instance.FindElements(By.XPath("//span[text()='Departure']/following-sibling::span[@class=' appendLeft10 up sort-arrow']")).Count != 0)
            {
                First_flight = Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']/preceding-sibling::p")).Text;
                First_flight = First_flight +  Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']")).Text;

            }

            else
            {
                last_flight = Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']/preceding-sibling::p")).Text;
                last_flight = last_flight + Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']")).Text;
            }

            Driver.Instance.FindElement(By.XPath("//span[text()='Departure']")).Click();

            if (Driver.Instance.FindElements(By.XPath("//span[text()='Departure']/following-sibling::span[@class=' appendLeft10 down sort-arrow']")).Count != 0)
            {

                last_flight = Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']/preceding-sibling::p")).Text;
                last_flight = last_flight + Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']")).Text;

            }
            else
            {
                First_flight = Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']/preceding-sibling::p")).Text;
                First_flight = First_flight + Driver.Instance.FindElement(By.XPath("//p[@class='fliCode']")).Text;
            }




            IList<IWebElement> NumberOfStops = Driver.Instance.FindElements(By.XPath("//p[contains(text(),'Stops')]/following-sibling::div//span[@class='filterName']"));
            var StopList = new List<KeyValuePair<string, int>>();
            for (int i = 0;i<NumberOfStops.Count;i++)
                {
                NumberOfStops[i].Click();
                
                StopList.Add(new KeyValuePair<string, int>(NumberOfStops[i].Text, Driver.Instance.FindElements(By.XPath("//p[@class='fliCode']")).Count));

            }


            var AirlineNameAndPrice = new List<KeyValuePair<string, string>>();

            IList<IWebElement> Name = Driver.Instance.FindElements(By.XPath("//p[@class='fliCode']/preceding-sibling::p"));
            IList<IWebElement> Price = Driver.Instance.FindElements(By.XPath("//div[@class='priceSection']//p"));


            var NamePrice = new List<KeyValuePair<string, String>>();
            for (int i = 0; i < Name.Count; i++)
            {
                

                NamePrice.Add(new KeyValuePair<string, string>(Name[i].Text,Price[i].Text));

            }






        }
    }
}
