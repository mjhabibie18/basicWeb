using API.Models;
using API.Repositories;
using API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class DivisionsController : ApiController
    {
        DivisionRepository divisionRepository = new DivisionRepository();
        public IHttpActionResult Post(Division division) 
        {
            var Post = divisionRepository.Insert(division);
            return Ok(Post);
        }
        public IHttpActionResult Get()
        {
            var Get = divisionRepository.GetDivisions();
            return Ok(Get);
        }
        public IHttpActionResult GetById(int id)
        {
            var GetById = divisionRepository.GetDivision(id);
            return Ok(GetById);
        }
        public IHttpActionResult Delete(int id )
        {
            var delete = divisionRepository.Delete(id);
            return Ok(delete);
        }
        public IHttpActionResult Put(int id, Division division)
        {
            var Put = divisionRepository.Update(id, division);
            return Ok(Put);
        }
    }
}
