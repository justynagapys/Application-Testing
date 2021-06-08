using NUnit.Framework;
using PracownicyMock.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PracownicyTests
{
    [TestFixture]
    public class PracownicyTests
    {
        HomeController hcontrol;
        PracownicyController pcontrol;

        [OneTimeSetUp]
        public void setUp()
        {
            pcontrol = new PracownicyController();
        }

        [Test]
        public void indexPracownicy_returningResult_test()
        {
            ViewResult vresult = pcontrol.Index() as ViewResult;
            Assert.AreEqual("Your application index page with employees.", vresult.ViewBag.Message);
        }

        [Test]
        public void indexPracownicyController_returningList_test()
        {
            ViewResult vresult = pcontrol.Index() as ViewResult;
            Assert.IsNotNull("db.Pracownicy.ToList()");
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            pcontrol = null;
        }

    }
}
