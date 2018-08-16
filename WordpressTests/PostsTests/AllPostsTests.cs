using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAutomation;
using WordPressAutomation.Workflows;

namespace WordpressTests.PostsTests
{
    [TestClass]
    public class AllPostsTests : WordPressTest
    {
        [TestMethod]
        public void AddedPostsShowUp()
        {
            ListPostsPage.GoTo(PostType.Page);
            ListPostsPage.StoreCount();

            PostCreator.CreatePost();

            ListPostsPage.GoTo(PostType.Posts);
            Assert.AreEqual(ListPostsPage.PreviousPostCount + 1, ListPostsPage.CurrentPostCount, "Count of posts did not increase");

            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));

            ListPostsPage.TrashPost(PostCreator.PreviousTitle);
            Assert.AreEqual(ListPostsPage.PreviousPostCount, ListPostsPage.CurrentPostCount, "Couldn't trash post");
        }

        [TestMethod]
        public void CanSearchPosts()
        {
            PostCreator.CreatePost();
            ListPostsPage.SearchForPost(PostCreator.PreviousTitle);
            Assert.IsTrue(ListPostsPage.DoesPostExistWithTitle(PostCreator.PreviousTitle));
        }


    }
}
