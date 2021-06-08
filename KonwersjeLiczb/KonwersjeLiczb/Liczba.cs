using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwersjeLiczb
{
    public class Liczba
    {
        public int naArabska(string rzymska)
        {
            Dictionary<char, int> Zamienniki = new Dictionary<char, int>()
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5},
                {'I', 1}
            };
            int arabska = 0;
            rzymska = rzymska.ToUpper();
            char[] rzymskaTab = rzymska.ToCharArray();

            if (rzymska == null)
                throw new ArgumentNullException("Nie podano liczby rzymskiej!");

            if (string.IsNullOrWhiteSpace(rzymska))
                throw new FormatException("Nie podano liczby rzymskiej!");

            foreach (var liczbaRzymska in rzymskaTab)
            {
                Zamienniki.TryGetValue(liczbaRzymska, out int nowaLiczba);
                arabska += nowaLiczba;
            }

            if (rzymska.Contains("CM") || rzymska.Contains("CD"))
            {
                arabska -= 200;
            }

            if (rzymska.Contains("XC") || rzymska.Contains("XL"))
            {
                arabska -= 20;
            }

            if (rzymska.Contains("IX") || rzymska.Contains("IV"))
            {
                arabska -= 2;
            }

            return arabska;
        }
        public string naRzymska(int arabska)
        {
            var rzymska = new StringBuilder();
            Dictionary<int, string> zamienniki = new Dictionary<int, string>()
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"},
            };

            if (arabska.ToString() == null)
                throw new ArgumentNullException("Nie podano liczby arabskiej!");

            if (string.IsNullOrWhiteSpace(arabska.ToString()))
                throw new FormatException("Nie podano liczby arabskiej!");

            if (arabska < 0)
                throw new ArgumentException("Podaj liczbę większą od zera!");                       

            foreach (var liczbaArabska in zamienniki)
            {
                while (arabska >= liczbaArabska.Key)
                {
                    rzymska.Append(liczbaArabska.Value);
                    arabska -= liczbaArabska.Key;
                }
            }
            return rzymska.ToString();
        }
    }
}
