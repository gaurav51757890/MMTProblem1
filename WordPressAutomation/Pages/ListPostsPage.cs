using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressAutomation
{
    public class ListPostsPage
    {
        private static int lastCount;

        public static int PreviousPostCount
        {
            get { return lastCount; }
        }

        public static int CurrentPostCount
        {
            get { return GetPostCount();  }
        }

        public static void GoTo(PostType postType)
        {
            switch(postType)
            {
                case PostType.Page:
                    LeftNavigation.Pages.AllPages.Select();
                    break;
            }
        }

        public static void SelectPost(string title)
        {
            var postLink = Driver.Instance.FindElement(By.LinkText("Sample Page"));
            postLink.Click();
        }

        public static void StoreCount()
        {
            lastCount = GetPostCount();
        }

        public static bool DoesPostExistWithTitle(string title)
        {
            return Driver.Instance.FindElements(By.LinkText(title)).Any();
        }

        public static void TrashPost(string title)
        {
            var rows = Driver.Instance.FindElements(By.ClassName("post-item__title"));
            foreach (var row in rows)
            {
                ReadOnlyCollection<IWebElement> links = null;
                Driver.NoWait(() => links = row.FindElements(By.LinkText(title)));

                if(links.Count > 0)
                {
                    Actions action = new Actions(Driver.Instance);
                    action.MoveToElement(links[0]);
                    action.Perform();
                    row.FindElement(By.ClassName("ellipsis-menu__toggle")).Click();
                    return;
                }
            }
        }

        public static void SearchForPost(string searchString)
        {
            if(!IsAt)
                GoTo(PostType.Page);

            var searchBoxIcon = Driver.Instance.FindElement(By.ClassName("search__icon-navigation"));
            searchBoxIcon.Click();

            var searchBox = Driver.Instance.FindElement(By.ClassName("search__input"));
            searchBox.SendKeys(searchString);
        }

        public static bool IsAt
        {
            get
            {
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                if (h2s.Count > 0)
                    return h2s[0].Text == "Posts";
                return false;
            }
        }

        private static int GetPostCount()
        {
            var countText = Driver.Instance.FindElement(By.XPath(".//*[@id='primary']/main/div/div[1]/div/div[2]/div[1]/div/ul/li[1]/a/span/span")).Text;
            return int.Parse(countText);
        }
    }

    public enum PostType
    {
        Page,
        Posts
    }
}
