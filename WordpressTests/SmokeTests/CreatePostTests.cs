using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressAutomation;

namespace WordpressTests
{
    [TestClass]
    public class CreatePostTests : WordPressTest
    {
        [TestMethod]
        public void CanCreateABasicPost()
        {
            NewPostPage.GoTo();
            NewPostPage.CreatePost("This is the test post title").
                WithBody("Hi, this is the body").
                Publish();
        }
    }
}
