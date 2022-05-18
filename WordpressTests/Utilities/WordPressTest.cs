using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressAutomation;
using WordPressAutomation.Workflows;

namespace WordpressTests
{
    public class WordPressTest
    {
        [TestInitialize]
        public void Init()
        {
            //Driver.Initialize();
            //PostCreator.Initialize();

            //LoginPage.GoTo();
           //LoginPage.LoginAs("govindarai1988").WithPassword("ggoovvii@123").Login();
        }

        [TestCleanup]
        public void Cleanup()
        {
            PostCreator.Cleanup();
            Driver.Close();
        }

    }
}
