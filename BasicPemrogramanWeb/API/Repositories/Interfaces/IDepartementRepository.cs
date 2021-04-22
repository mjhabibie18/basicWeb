using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface IDepartementRepository
    {
        IEnumerable<Departement> GetDepartements();
        Departement GetDepartement(int id);
        int Insert(Departement departement);
        int Update(int id, Departement departement);
        int Delete(int id);
    }
}
