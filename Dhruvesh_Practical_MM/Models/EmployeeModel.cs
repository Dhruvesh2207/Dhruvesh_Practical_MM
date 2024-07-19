namespace Dhruvesh_Practical_MM.Models
{
    public class EmployeeModel
    {
        public int c_empid { get; set; }
        public string c_empname { get; set; }
        public string c_empemail { get; set; }
        public string c_empphone { get; set; }
        public string c_empaddress { get; set; }
        public string c_empstate { get; set; }
        public string c_empcity { get; set; }
        public DateTime c_createddate { get; set; } = DateTime.Now;
    }
}
