using System;
namespace HR.Business.Utilities.Helper;

public enum Menu {Create_company=1,                 //Company
                  Deactive_Company,
                  Get_all_department_inCompany,
                  Show_all_company,
                  Find_company_with_id,//_________________________
                  Create_department,             //Department
                  Deactive_department,
                  Add_employee_to_department,
                  Update_department,         
                  Get_employees_inDepartment,
                  Show_department_details,   
                  Show_all_departments,//_________________________
                  Create_employee,               //Employee
                  Deactive_employee,
                  Show_all_employees,
                  Change_department,
                  Update_Employee_Salary,//____________________________
                  Quit}                          //Quit
public enum SalaryMenu {increase=1,
                        decrease}
