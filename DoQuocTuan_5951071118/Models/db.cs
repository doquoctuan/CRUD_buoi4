using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DoQuocTuan_5951071118.Models
{
    public class db
    {
        static string conSTR = @"Data Source=DESKTOP-E7SCDHU\SQLEXPRESS;Initial Catalog=quanli;Integrated Security=True";
        SqlConnection con = new SqlConnection(conSTR);
        // select
        public DataSet EmpGet(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand command = new SqlCommand("Sp_Employee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("id", emp.Id);
                command.Parameters.AddWithValue("name", emp.Name);
                command.Parameters.AddWithValue("city", emp.City);
                command.Parameters.AddWithValue("state", emp.State);
                command.Parameters.AddWithValue("country", emp.Country);
                command.Parameters.AddWithValue("department", emp.Department);
                command.Parameters.AddWithValue("flag", emp.Flag);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);   
                dataAdapter.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        public DataSet Empdml(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand command = new SqlCommand("Sp_Employee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("id", emp.Id);
                command.Parameters.AddWithValue("name", emp.Name);
                command.Parameters.AddWithValue("city", emp.City);
                command.Parameters.AddWithValue("state", emp.State);
                command.Parameters.AddWithValue("country", emp.Country);
                command.Parameters.AddWithValue("department", emp.Department);
                command.Parameters.AddWithValue("flag", emp.Flag);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return ds;
            }
        }
    }
}
