using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracownicyMock.Models
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public double PensjaPodstawowa { get; set; }
    }

    public class PracownikDB : DbContext
    {
        public System.Data.Entity.DbSet<PracownicyMock.Models.Pracownik> Pracownicy { get; set; }
    }
}