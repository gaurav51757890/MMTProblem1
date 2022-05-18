using OpenQA.Selenium;
using System;

namespace WordPressAutomation
{
    public class LeftNavigation
    {
        public class Posts
        {
            public class AddNew
            {
                public static void Select()
                {
                    Driver.Wait(TimeSpan.FromSeconds(1));
                    var addNew = Driver.Instance.FindElement(By.XPath(".//*[@id='header']/div[1]/a/span"));
                    addNew.Click();
                }
            }
        }

        public class Pages
        {
            public class AllPages
            {
                public static void Select()
                {
                    Driver.Instance.FindElement(By.XPath("//span[.='My Sites']")).Click();
                    Driver.Instance.FindElement(By.XPath("//span[.='Blog Posts']")).Click();
                }
            }
        }
    }
}
