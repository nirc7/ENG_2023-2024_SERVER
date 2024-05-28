using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DBServices
    {
        static string consStr = @"Data Source=LAB-G700;Initial Catalog=StudentsDB;Integrated Security=True;TrustServerCertificate=True";

        public static Student Login(string name, string pass) 
        {
            Student stu2Ret = null;
            SqlConnection con = new SqlConnection(consStr);
            SqlCommand cmd = new SqlCommand(
                 " SELECT * " +
                 " FROM TBStudents " +
                $" WHERE Name='{name}' and Password='{pass}'",con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                stu2Ret = new Student() { 
                    ID = (int)rdr["ID"],
                    Name = rdr["Name"].ToString(),
                    Grade = (int)rdr["Grade"]
                };
            }
            con.Close();

            return stu2Ret; 
        }
    }
}
