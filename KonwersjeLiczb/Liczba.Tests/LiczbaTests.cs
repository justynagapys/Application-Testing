using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KonwersjeLiczb.Tests
{
    [TestClass]
    public class LiczbaTests
    {
        public Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext { get; set; }

        [TestCase("CLIV", 154)]
        public void naArabska_Calculated(string rzymska, int wartoscOczekiwana)
        {
            Liczba lczb = new Liczba();
            int arabska = lczb.naArabska(rzymska);
            NUnit.Framework.Assert.AreEqual(wartoscOczekiwana, arabska);
        }

        [TestMethod]
        public void naArabska_EqualNull_Exception()
        {
            Liczba lczb = new Liczba();
            var ex = NUnit.Framework.Assert.Throws<FormatException>(
                () => lczb.naArabska(""));

            NUnit.Framework.Assert.That(ex.Message == "Nie podano liczby rzymskiej!");
        }

        [TestMethod]
        public void naArabska_NullOrWhiteSpace_Exception()
        {
            Liczba lczb = new Liczba();
            var ex = NUnit.Framework.Assert.Throws<FormatException>(
                () => lczb.naArabska(" "));

            NUnit.Framework.Assert.That(ex.Message == "Nie podano liczby rzymskiej!");
        }

        [TestCase(154, "CLIV")]
        public void naRzymska_Calculated(int arabska, string wartoscOczekiwana)
        {
            Liczba lczb = new Liczba();
            string rzymska = lczb.naRzymska(arabska);
            NUnit.Framework.Assert.AreEqual(wartoscOczekiwana, rzymska);
        }

        [TestMethod]
        public void naRzymska_LessThanOrEqualZero_Exception()
        {
            Liczba lczb = new Liczba();
            var ex = NUnit.Framework.Assert.Throws<ArgumentException>(
                () => lczb.naRzymska(-5));

            NUnit.Framework.Assert.That(ex.Message == "Podaj liczbę większą od zera!");
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"DaneTestowe.xml","liczby", DataAccessMethod.Sequential)]
        public void daneTestowePlik_naArabska_Calculated()
        {
            string rzymska = TestContext.DataRow["rzymska"].ToString();
            int wartoscOczekiwana = Convert.ToInt32(TestContext.DataRow["arabska"].ToString());

            Liczba lczb = new Liczba();
            int arabska = lczb.naArabska(rzymska);
            NUnit.Framework.Assert.AreEqual(wartoscOczekiwana, arabska);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"DaneTestowe.xml", "liczby", DataAccessMethod.Sequential)]
        public void daneTestowePlik_naRzymska_Calculated()
        {
            string wartoscOczekiwana = TestContext.DataRow["rzymska"].ToString();
            int arabska = Convert.ToInt32(TestContext.DataRow["arabska"].ToString());

            Liczba lczb = new Liczba();
            string rzymska = lczb.naRzymska(arabska);
            NUnit.Framework.Assert.AreEqual(wartoscOczekiwana.ToUpper().Replace(" ", ""), rzymska);
        }
    }
}
