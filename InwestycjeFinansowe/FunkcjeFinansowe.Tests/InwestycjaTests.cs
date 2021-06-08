using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkcjeFinansowe.Tests
{
    [TestFixture] //cała klasa z testami powinna to mieć wpisane, by być zauważalna przez środowisko
    public class InwestycjaTests
    {
        Inwestycja inw;

        [OneTimeSetUp]
        public void setUp()
        {
            //Arrange - przygotuj warunki
            inw = new Inwestycja();
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            inw = null;
        }

        [TestCase(200, 250, 1, 0.25)]
        //[TestCase(200, 0, 1, -1.00)]
        [TestCase(200, 250.22, 2, 0.5022)]
        [TestCase(200.22, 250, 3, 0.74588)]
        [TestCase(200.22, 250.22, 4, 0.9989)]
        public void wyliczStope_RozneWartosci_Calculated(double kwotaPoczatkowa, double kwotaKoncowa, int liczbaOkresow, double wartoscOdniesienia)
        {
            //Act - zrób coś, co jest pokryte aktem testowania
            double stopa = inw.wyliczStope(kwotaPoczatkowa, kwotaKoncowa, liczbaOkresow);

            //Assert - oceń, co z tego wyszło
            Assert.AreEqual(Math.Round(stopa, 5), wartoscOdniesienia);
        }

        [Test]
        public void wyliczStope_WartoscPoczatkowaWiekszaNizKoncowa_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>() //weryfikacja rodzaju wyjątku
                .And.Message.EqualTo("Kwota początkowa nie może być większa niż kwota końcowa"),
                delegate //wywołanie funkcji, która spowoduje ten wyjątek
                {
                    inw.wyliczStope(3000.00, 1000.00, 2);
                });
        }

        [Test]
        public void wyliczStope_DzieleniePrzezZero_Exception()
        {
            Assert.Throws(Is.TypeOf<DivideByZeroException>()
                .And.Message.EqualTo("Nie można dzielić przez zero"),
                delegate
                {
                    inw.wyliczStope(0.00, 1000.00, 2);
                });
        }

        [Test]
        public void wyliczStope_KwotaPoczatkowaUjemna_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wyliczStope(-1000,3000, 1));

            Assert.That(ex.Message == "Kwota początkowa nie może być ujemna");
        }

        [Test]
        public void wyliczStope_KwotaKoncowaUjemna_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wyliczStope(1000, -3000, 1));

            Assert.That(ex.Message == "Kwota końcowa nie może być ujemna");
        }

        [Test]
        public void wyliczStope_LiczbaOkresowUjemna_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>()
                .And.Message.EqualTo("Liczba okresów nie może być ujemna"),
                delegate
                {
                    inw.wyliczStope(1000.00, 3000.00, -2);
                });
        }

        [Test] //musi być wypisane przed każdym testem
        //void, bo testy nie zwracają żadnych wartości
        //nazwa z 3 członów -> 1. testowana funkcja, 2. warunki testowe, 3. jaki wynik jest oczekiwany
        //[Ignore("A tego testu nie odpalamy, bo nudny")] //ignoruje nam dany test
        public void wartoscPrzyszla_KwotaIntOprocentowanieInt_Calculated()
        {
            //Act - zrób coś, co jest pokryte aktem testowania
            double kwota = inw.wartoscPrzyszla(1000, 1, 1);

            //Assert - oceń, co z tego wyszło
            Assert.AreEqual(kwota, 2000.00);
        }

        [Test]
        public void wartoscPrzyszla_KwotaDoubleOprocentowanieDouble_Calculated()
        {
            //Act
            double kwota = inw.wartoscPrzyszla(1000.00, 0.04, 1);

            //Assert
            Assert.AreEqual(kwota, 1040.00);
        }

        [Test]
        public void wartoscPrzyszla_KwotaIntOprocentowanieDouble_Calculated()
        {
            //Act
            double kwota = inw.wartoscPrzyszla(1000, 0.04, 1);

            //Assert
            Assert.AreEqual(kwota, 1040.00);
        }

        [Test]
        public void wartoscPrzyszla_KwotaDoubleOprocentowanieInt_Calculated()
        {
            //Act
            double kwota = inw.wartoscPrzyszla(1000.00, 1, 1);

            //Assert
            Assert.AreEqual(kwota, 2000.00);
        }

        [TestCase(200, 0.22, 1, 244)]
        [TestCase(200.22, 2, 2, 1801.98)]
        [TestCase(200.22, 0.4, 3, 549.40368)]
        public void wartoscPrzyszla_RozneWartosci_Calculated(double kwotaPoczatkowa, double oprocentowanie, int liczbaOkresow, double wartoscOdniesienia)
        {
            //Act - zrób coś, co jest pokryte aktem testowania
            double kwota = inw.wartoscPrzyszla(kwotaPoczatkowa, oprocentowanie, liczbaOkresow);

            //Assert - oceń, co z tego wyszło
            Assert.AreEqual(Math.Round(kwota, 5), wartoscOdniesienia);
        }

        [Test]
        public void wartoscPrzyszla_KwotaUjemna_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wartoscPrzyszla(-1000, 0.004, 1));

            Assert.That(ex.Message == "Kwota nie może być ujemna");
        }

        [Test]
        public void wartoscPrzyszla_OprocentowanieUjemne_Exception()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => inw.wartoscPrzyszla(1000, -0.4, 1));

            Assert.That(ex.Message == "Oprocentowanie nie może być ujemne");
        }

        [Test]
        public void wartoscPrzyszla_LiczbaOkresowUjemna_Exception()
        {
            Assert.Throws(Is.TypeOf<ArgumentException>()
                .And.Message.EqualTo("Liczba okresów nie może być ujemna"),
                delegate
                {
                    inw.wartoscPrzyszla(1000, 0.004, -2);
                });
        }

        [Test]
        public void wartoscPrzyszla_PrzepelnienieKwoty_Exception()
        {
            Assert.Throws(Is.TypeOf<OverflowException>()
                .And.Message.EqualTo("Nastąpiło przepełnienie zmiennej"),
                delegate
                {
                    inw.wartoscPrzyszla(999, 99, 999);
                });
        }
    }
}
