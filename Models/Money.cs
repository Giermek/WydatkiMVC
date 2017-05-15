using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WydatkiMVC.Models
{
    public class Money
    {
        public int MoneyId { get; set; }

        public decimal Kwota { get; set; }


        public string Opis { get; set; }

        public Category Kategoria { get; set; }
    }

    public class MoneyContext : DbContext
    {
        public DbSet<Money> Moneys { get; set; }
    }
}
