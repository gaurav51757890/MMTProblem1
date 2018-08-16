using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordPressAutomation
{
    public class NewPostPage
    {
        public static void GoTo()
        {
            LeftNavigation.Posts.AddNew.Select();
        }

        public static CreatePostCommand CreatePost(string title)
        {
            return new CreatePostCommand(title);
        }

        public class CreatePostCommand
        {
            private readonly string title;
            private string body;

            public CreatePostCommand(string title)
            {
                this.title = title;
            }

            public CreatePostCommand WithBody(string body)
            {
                this.body = body;
                return this;
            }

            public void Publish()
            {
                Driver.Instance.FindElement(By.XPath(".//*[@placeholder='Title']")).SendKeys(title);

                Driver.Instance.SwitchTo().Frame("tinymce-1_ifr");
                Driver.Instance.SwitchTo().ActiveElement().SendKeys(body);
                Driver.Instance.SwitchTo().DefaultContent();

                Driver.Wait(TimeSpan.FromSeconds(1));

                Driver.Instance.FindElement(By.ClassName("editor-publish-button")).Click();

                Driver.Wait(TimeSpan.FromSeconds(1));

                Driver.Instance.FindElement(By.XPath(".//*[@class='button']")).Click();
            }
        }

        public static bool IsInEditMode()
        {
            return Driver.Instance.FindElement(By.XPath("//span[.='Preview']")) != null;
        }

        public static string Title
        {
            get
            {
                var title = Driver.Instance.FindElement(By.XPath(".//*[@placeholder='Title']"));
                if (title != null)
                    return title.GetAttribute("value");
                return string.Empty;
            }
        }
    }
}
