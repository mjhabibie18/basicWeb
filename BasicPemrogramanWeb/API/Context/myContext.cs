using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API.Context
{
    public class myContext : DbContext
    {
        public myContext() : base("myConnection") { }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Departement> Departments { get; set; }
    }
}