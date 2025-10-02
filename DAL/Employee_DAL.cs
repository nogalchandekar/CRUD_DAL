using CRUD_DAL.Models.DataModel;
using CRUD_DAL.Models.ViewModel;
using System;
using System.Linq;

namespace CRUD_DAL.DAL
{
	public class Employee_DAL
	{
        db_CRUD_DALEntities db = new db_CRUD_DALEntities();

        //========== Add Employee ==========//
        public string AddEmployee(VMEmployee vMEmployee)
        {
            using (var transcations = db.Database.BeginTransaction())
            {
                try
                {
                    tbl_Employee employee = db.tbl_Employee.FirstOrDefault(x=>x.Emp_Id==vMEmployee.Emp_Id);
                    if (employee == null)
                    { 
                        bool isDuplicate = db.tbl_Employee.Any(x => x.Emp_MobileNo == vMEmployee.Emp_MobileNo);
                        if (isDuplicate)
                        {
                            return "Mobile No is Already Exists";
                        }
                        employee = new tbl_Employee
                        {
                            Emp_Name = vMEmployee.Emp_Name,
                            Emp_Designation = vMEmployee.Emp_Designation,
                            Emp_Age = vMEmployee.Emp_Age,
                            Emp_Salary = vMEmployee.Emp_Salary,
                            Emp_MobileNo = vMEmployee.Emp_MobileNo,
                            Emp_Gender = vMEmployee.Emp_Gender,
                            Emp_Address = vMEmployee.Emp_Address,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now,
                        };
                        db.tbl_Employee.Add(employee);
                        db.SaveChanges();
                        transcations.Commit();
                        return "Employee Added Successfully";
                    }
                    else
                    {
                        employee.Emp_Id = vMEmployee.Emp_Id;
                        employee.Emp_Name = vMEmployee.Emp_Name;
                        employee.Emp_Designation = vMEmployee.Emp_Designation;
                        employee.Emp_Age = vMEmployee.Emp_Age;
                        employee.Emp_Salary = vMEmployee.Emp_Salary;
                        employee.Emp_MobileNo = vMEmployee.Emp_MobileNo;
                        employee.Emp_Gender = vMEmployee.Emp_Gender;
                        employee.Emp_Address = vMEmployee.Emp_Address;
                        employee.ModifiedBy= "Admin";
                        employee.ModifiedDate = DateTime.Now;
                        db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transcations.Commit();
                        return "Employee Updated Successfully";
                    }

                }
                catch (Exception ex)
                {
                    transcations.Rollback();
                    Console.WriteLine(ex.Message);
                }
                return "Something Wents Wrong Please try Again Later";
            }
        }
    }
}