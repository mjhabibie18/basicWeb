using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Departement
    {
        public int id { get; set; }
        public string name { get; set; }
        public int divisionId { get; set; }
        [ForeignKey("divisionId")]
        public Division Division { get; set; }
    }
}