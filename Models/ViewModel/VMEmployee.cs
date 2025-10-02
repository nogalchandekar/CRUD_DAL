using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CRUD_DAL.Models.ViewModel
{
	public class VMEmployee
	{
        public int Emp_Id { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Designation { get; set; }
        public Nullable<int> Emp_Age { get; set; }
        public Nullable<decimal> Emp_Salary { get; set; }
        public Nullable<decimal> Emp_MobileNo { get; set; }
        public string Emp_Gender { get; set; }
        public string Emp_Address { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}