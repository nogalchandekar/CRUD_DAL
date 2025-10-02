using CRUD_DAL.Models.DataModel;
using CRUD_DAL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_DAL.DAL
{
	public class Employee_DAL
	{
        db_CRUD_DALEntities db = new db_CRUD_DALEntities();


        //========== Add / Update Employee ==========///
        public string AddEmployee(VMEmployee vMEmployee)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Check if employee already exists by ID
                    tbl_Employee employee = db.tbl_Employee
                        .FirstOrDefault(x => x.Emp_Id == vMEmployee.Emp_Id);

                    if (employee == null) // ====== ADD ======
                    {
                        // Check for duplicate Mobile No
                        bool isDuplicate = db.tbl_Employee
                            .Any(x => x.Emp_MobileNo == vMEmployee.Emp_MobileNo);

                        if (isDuplicate)
                        {
                            return "Mobile No already exists";
                        }

                        employee = new tbl_Employee
                        {
                            Emp_Name = vMEmployee.Emp_Name,
                            Emp_Designation = vMEmployee.Emp_Designation,
                            Emp_Age = vMEmployee.Emp_Age,
                            Emp_Salary = vMEmployee.Emp_Salary,
                            Emp_MobileNo = vMEmployee.Emp_MobileNo, // string (nvarchar) now
                            Emp_Gender = vMEmployee.Emp_Gender,
                            Emp_Address = vMEmployee.Emp_Address,
                            CreatedBy = "Admin",
                            CreatedDate = DateTime.Now
                        };

                        db.tbl_Employee.Add(employee);
                        db.SaveChanges();
                        transaction.Commit();

                        return "Employee Added Successfully";
                    }
                    else // ====== UPDATE ======
                    {
                        // Check duplicate mobile number (exclude current employee)
                        bool isDuplicate = db.tbl_Employee
                            .Any(x => x.Emp_MobileNo == vMEmployee.Emp_MobileNo && x.Emp_Id != vMEmployee.Emp_Id);

                        if (isDuplicate)
                        {
                            return "Mobile No already exists for another employee";
                        }

                        // Do not update Emp_Id (Identity column)
                        employee.Emp_Name = vMEmployee.Emp_Name;
                        employee.Emp_Designation = vMEmployee.Emp_Designation;
                        employee.Emp_Age = vMEmployee.Emp_Age;
                        employee.Emp_Salary = vMEmployee.Emp_Salary;
                        employee.Emp_MobileNo = vMEmployee.Emp_MobileNo;
                        employee.Emp_Gender = vMEmployee.Emp_Gender;
                        employee.Emp_Address = vMEmployee.Emp_Address;
                        employee.ModifiedBy = "Admin";
                        employee.ModifiedDate = DateTime.Now;

                        db.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();

                        return "Employee Updated Successfully";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    // Capture inner exception for actual SQL error
                    var errorMessage = ex.InnerException?.InnerException?.Message ?? ex.Message;
                    return "Error: " + errorMessage;
                }
            }
        }

        ///============= get List ===========================///
        public List<VMEmployee> getList()
        {
            List<VMEmployee> vMEmployees = new List<VMEmployee>();
            try
            {
                vMEmployees = (from s in db.tbl_Employee
                               select new VMEmployee
                               {
                                   Emp_Id = s.Emp_Id,
                                   Emp_Name = s.Emp_Name,
                                   Emp_Designation = s.Emp_Designation,
                                   Emp_Age = s.Emp_Age,
                                   Emp_Salary = s.Emp_Salary,
                                   Emp_MobileNo = s.Emp_MobileNo,
                                   Emp_Gender = s.Emp_Gender,
                                   Emp_Address = s.Emp_Address,
                               }).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error"+ex.Message);
            }
            return vMEmployees;
        }

        ///============ get DataById=================///
        public VMEmployee getDataById(int Emp_Id)
        {
            VMEmployee vMEmployee = new VMEmployee();
            try
            {
                vMEmployee = (from s in db.tbl_Employee
                              where  s.Emp_Id == Emp_Id
                              select new VMEmployee
                              {
                                  Emp_Id = s.Emp_Id,
                                  Emp_Name = s.Emp_Name,
                                  Emp_Designation = s.Emp_Designation,
                                  Emp_Age = s.Emp_Age,
                                  Emp_Salary = s.Emp_Salary,
                                  Emp_MobileNo = s.Emp_MobileNo,
                                  Emp_Gender = s.Emp_Gender,
                                  Emp_Address = s.Emp_Address,
                              }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            return vMEmployee;
        }

       ///================= get Delete By Id ===================///
        public string DeleteById(int Emp_Id)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var employee = db.tbl_Employee
                        .FirstOrDefault(x => x.Emp_Id == Emp_Id);
                    if (employee != null)
                    {
                        db.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                        return "Employee Deleted Successfully";
                    }
                    else
                    {
                        return "Employee not found";
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    var errorMessage = ex.InnerException?.InnerException?.Message ?? ex.Message;
                    return "Error: " + errorMessage;
                }
            }
        }


    }
}