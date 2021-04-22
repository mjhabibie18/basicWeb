using API.Context;
using API.Models;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class DivisionRepository : IDivisionRepository
    {
        myContext context = new myContext();
        public IEnumerable<Division> GetDivisions()
        {
            var Get = context.Divisions.ToList();
            return Get;
        }
        public Division GetDivision(int id)
        {
            var GetById = context.Divisions.Find(id);
            return GetById;
        }
        public int Insert(Division division)
        {
            context.Divisions.Add(division);
            var Insert = context.SaveChanges();
            return Insert;  
        }

        public int Update(int id, Division division)
        {
            var Put = context.Divisions.Find(id);
            Put.name = division.name;
            Put.about = division.about;
            context.Entry(Put).State = System.Data.Entity.EntityState.Modified;
            var save = context.SaveChanges();
            return save;
        }
        public int Delete(int id)
        {
            var GetById = context.Divisions.Find(id);
            context.Divisions.Remove(GetById);
            var Delete = context.SaveChanges();
            return Delete;
        }
    }
}   