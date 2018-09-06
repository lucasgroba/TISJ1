using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DataAccessLayer
{
    public class DALEmployeesNativeSQL : IDALEmployees
    {
        


        public void AddEmployee(Employee emp)
        {
            String query;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTEntitiesFinal"].ConnectionString))
            {
                con.Open();

                if (emp is PartTimeEmployee)
                {
                    PartTimeEmployee Temp = (PartTimeEmployee)emp;
                    query = "INSERT INTO Employee (Emp_Id, Name, Start_date,Rate, Type_Emp) values (" +
                    Temp.Id.ToString() + " ," +"'"+
                    Temp.Name.ToString()+ "'"+ " ," + "'" +
                    Temp.StartDate.Day.ToString() + "/" + Temp.StartDate.Month.ToString() + "/" + Temp.StartDate.Year.ToString() + "'" + " ," +
                    Temp.HourlyRate.ToString() + " ," + " 1 "
                    + ")";
                }
                else
                {
                    FullTimeEmployee Temp = (FullTimeEmployee)emp;
                    query = "INSERT INTO Employee (Emp_Id, Name, Start_date,Salary, Type_Emp) values (" +"'"+
                    Temp.Id.ToString() + " ," +"'"+
                    Temp.Name.ToString() +"'"+ " ," +"'"+
                    Temp.StartDate.Day.ToString()+ "/"+Temp.StartDate.Month.ToString() + "/"+Temp.StartDate.Year.ToString()+"'"+ " ," +
                    Temp.Salary.ToString() + " ," + " 0 "
                    + ")";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteEmployee(int id)
        {
            String query;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTEntitiesFinal"].ConnectionString))
            {
                con.Open();
                query = "DELETE FROM Employee WHERE Emp_Id = " + id.ToString();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

            }



        }

        public void UpdateEmployee(Employee emp)
        {
            String query;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTEntitiesFinal"].ConnectionString))
            {
                con.Open();
                if (emp is PartTimeEmployee)
                {
                    PartTimeEmployee Temp = (PartTimeEmployee)emp;
                        query = "UPDATE Employee SET Name = " +"'"+
                    Temp.Name.ToString() +"'"+ " ," + "Start_date =" + "'" +
                    Temp.StartDate.Day.ToString() + "/" + Temp.StartDate.Month.ToString() + "/" + Temp.StartDate.Year.ToString() + "'"+ " ," +
                        "Rate = " + Temp.HourlyRate.ToString() + ", Type_Emp = 1"+ "WHERE Emp_id ="+Temp.Id.ToString();

                }
                else
                {
                    FullTimeEmployee Temp = (FullTimeEmployee)emp;
                        query = "UPDATE Employee SET Name = " +"'"+
                    Temp.Name.ToString() +"'"+ " ,"+"Start_date =" + "'" +
                    Temp.StartDate.Day.ToString() + "/" + Temp.StartDate.Month.ToString() + "/" + Temp.StartDate.Year.ToString() + "'" + " ," +
                        " Salary = " + Temp.Salary.ToString() + ", Type_Emp = 0" + "WHERE Emp_id =" + Temp.Id.ToString();

                }
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();


            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> listaEmp = new List<Employee>();
          
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTEntitiesFinal"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) {
                    while (dr.Read())
                    {
                        if (Convert.ToInt32(dr["Type_Emp"]) == 0)
                        {
                            FullTimeEmployee emp = new FullTimeEmployee();
                            emp.Id = Convert.ToInt32(dr["Emp_id"]);
                            emp.Name = Convert.ToString(dr["Name"]);
                            emp.Salary = Convert.ToInt32(dr["Salary"]);
                            emp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            listaEmp.Add(emp);
                        }
                        else
                        {
                            PartTimeEmployee emp = new PartTimeEmployee();
                            emp.Id = Convert.ToInt32(dr["Emp_id"]);
                            emp.Name = Convert.ToString(dr["Name"]);
                            emp.HourlyRate = Convert.ToDouble(dr["Rate"]);
                            emp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                            listaEmp.Add(emp);
                        }


                    }
                }

                
                return listaEmp;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TESTEntitiesFinal"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee WHERE Emp_id = "+id.ToString(), con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (Convert.ToInt32(dr["Type_Emp"]) == 0) {
                        FullTimeEmployee emp = new FullTimeEmployee();
                        emp.Id = Convert.ToInt32(dr["Emp_id"]);
                        emp.Name = Convert.ToString(dr["Name"]);
                        emp.Salary = Convert.ToInt32(dr["Salary"]);
                        emp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                        return emp;
                    }
                    else
                    {
                        PartTimeEmployee emp = new PartTimeEmployee();
                        emp.Id = Convert.ToInt32(dr["Emp_id"]);
                        emp.Name = Convert.ToString(dr["Name"]);
                        emp.HourlyRate = Convert.ToDouble(dr["Rate"]);
                        emp.StartDate = Convert.ToDateTime(dr["Start_Date"]);
                        return emp;
                    }
                    

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
