
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class PageTests : WordPressTest
    {
        [TestMethod]
        public void CanEditAPage()
        {
            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
        }
    }
}
