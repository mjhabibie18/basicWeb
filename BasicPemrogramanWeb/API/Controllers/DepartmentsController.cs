using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DepartmentsController : ApiController
    {
        DepartementRepository departmentRepository = new DepartementRepository();
        public IHttpActionResult Post(Departement departments)
        {
            var Post = departmentRepository.Insert(departments);
            if(Post == 1)
            {
                return Ok("Data Berhasil diinput");
            }
            return BadRequest("Gagal input data");
        }
        public IHttpActionResult Get()
        {
            var Get = departmentRepository.GetDepartements();
            if (Get.Count() == 0)
            {
                return BadRequest("Tidak ada Datanya!!!");
            }
            else
            {
                return Ok(Get);
            }
        }
        public IHttpActionResult GetById(int id)
        {
            var GetById = departmentRepository.GetDepartement(id);
            if (GetById == null)
            {
                return BadRequest("Data tidak ada");
            }
            else
            {
                return Ok(GetById);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            var delete = departmentRepository.Delete(id);
            if (delete == null)
            {
                return BadRequest("Data belum dihapus");
            }
            else
            {
                return Ok("data berhasil dihapus");
            }
        }
        public IHttpActionResult Put(int id, Departement departements)
        {
            try
            {
                var Put = departmentRepository.Update(id, departements);
                if (Put == 1)
                {
                    return Ok("Pesan Berhasil Diganti");
                }
                else
                {
                    return Ok("Data diganti namun isinya sama");
                }
            }
            catch(System.NullReferenceException)
            {
                return BadRequest("Data gagal diinput atau tidak ada");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return BadRequest("Nama dibarisan ada yang Beda");
            }
        }
    }
}

