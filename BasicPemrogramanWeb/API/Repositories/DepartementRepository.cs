using API.Context;
using API.Models;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class DepartementRepository : IDepartementRepository
    {
        myContext context = new myContext();
       
        public Departement GetDepartement(int id)
        {
            var GetById = context.Departments.Include("Division").FirstOrDefault(a => a.id == id);
            return (GetById);
        }
        public int Insert (Departement departement)
        {
            context.Departments.Add(departement);
            var Insert = context.SaveChanges();
            return Insert;
        }
        public int Update(int id, Departement departement)
        {
            var Put = context.Departments.Find(id);
            Put.name = departement.name;
            Put.divisionId = departement.divisionId;
            context.Entry(Put).State = System.Data.Entity.EntityState.Modified;
            var save = context.SaveChanges();
            return save;
        }
        public int Delete(int id)
        {
            var GetById = context.Departments.Find(id);
            context.Departments.Remove(GetById);
            var Delete = context.SaveChanges();
            return Delete;
        }

        public IEnumerable<Departement> GetDepartements()
        {
            var Get = context.Departments.Include("Division").ToList();
            return Get;
        }
    }    
}