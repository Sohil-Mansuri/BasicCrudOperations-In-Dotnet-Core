using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }

        [ForeignKey("Designation")]
        public int Designation_Id { get; set; }

        public Designation Designation { get; set; }

    }

}
