using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkcjeFinansowe
{
    public class Inwestycja
    {
        public double wartoscPrzyszla(double kwotaPoczatkowa, double oprocentowanie, int liczbaOkresow)
        {
            //throw new NotImplementedException(); //wyrzucenie błędu dla niezaimpelentowanej funkcji
            if (kwotaPoczatkowa < 0)
                throw new ArgumentException("Kwota nie może być ujemna");
            if (oprocentowanie < 0)
                throw new ArgumentException("Oprocentowanie nie może być ujemne");
            if (liczbaOkresow < 0)
                throw new ArgumentException("Liczba okresów nie może być ujemna");

            double wartoscPrzyszla = kwotaPoczatkowa * Math.Pow((1 + oprocentowanie), liczbaOkresow);

            if (wartoscPrzyszla > Double.MaxValue)
                throw new OverflowException("Nastąpiło przepełnienie zmiennej");

            return wartoscPrzyszla;
        }
        public double wyliczStope(double kwotaPoczatkowa, double kwotaKoncowa, int liczbaOkresow)
        {
            //throw new NotImplementedException();
            if (kwotaPoczatkowa == 0)
                throw new DivideByZeroException("Nie można dzielić przez zero");
            if (kwotaPoczatkowa < 0)
                throw new ArgumentException("Kwota początkowa nie może być ujemna");
            if (kwotaKoncowa< 0)
                throw new ArgumentException("Kwota końcowa nie może być ujemna");
            if (kwotaPoczatkowa > kwotaKoncowa)
                throw new ArgumentException("Kwota początkowa nie może być większa niż kwota końcowa");
            if (liczbaOkresow < 0)
                throw new ArgumentException("Liczba okresów nie może być ujemna");

            double stopa = ((kwotaKoncowa / kwotaPoczatkowa) - 1) * liczbaOkresow;
            return stopa;
        }
    }
}
