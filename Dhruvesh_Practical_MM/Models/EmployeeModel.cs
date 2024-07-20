using System;
using System.ComponentModel.DataAnnotations;

namespace Dhruvesh_Practical_MM.Models
{
    public class EmployeeModel
    {
        [Key]
        public int c_empid { get; set; }

        public string c_empname { get; set; }

       
        public string c_empemail { get; set; }

       
        public string c_empphone { get; set; }

       
        public string c_empaddress { get; set; }

        //[Required(ErrorMessage = "Employee state is required")]
        public string c_empstate { get; set; }

        //[Required(ErrorMessage = "Employee city is required")]
        public string c_empcity { get; set; }

        public DateTime c_createddate { get; set; } = DateTime.Now;
    }
}
