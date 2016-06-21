using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Fenykep
    {
        public int FenykepID { get; set; }
        public string Fajlnev { get; set; }
        public byte[] Kep { get; set; }
        public string FelhasznaloNev { get; set; }
    }
    public class AdatBazis : DbContext
    {
        public DbSet<Fenykep> fenykepek { get; set; }

    }
}