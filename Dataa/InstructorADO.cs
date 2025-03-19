using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WebApplication1.Modelss;

namespace WebApplication1.Dataa
{
    public class InstructorADO : IInstructor
    {
        private IConfiguration _configuration;
        private string strCon = string.Empty;

        public InstructorADO(IConfiguration configuration)
        {
            _configuration = configuration;
            strCon = _configuration.GetConnectionString("DefaultConnection");
        }
        public Instructor AddInstructor(Instructor instructor)
        {
            using(SqlConnection conn = new SqlConnection(strCon)){
                string strSql = @"INSERT INTO Instructor(InstructorName, InstructorEmail, InstructorPhone, InstructorAddress, InstructorCity)
                VALUES(@InstructorName, @InstructorEmail, @InstructorPhone, @InstructorAddress, @InstructorCity); SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try{
                    
                    cmd.Parameters.AddWithValue("@InstructorName", instructor.InstructorName);
                    cmd.Parameters.AddWithValue("@InstructorEmail", instructor.InstructorEmail);
                    cmd.Parameters.AddWithValue("@InstructorPhone", instructor.InstructorPhone);
                    cmd.Parameters.AddWithValue("@InstructorAddress", instructor.InstructorAddress);
                    cmd.Parameters.AddWithValue("@InstructorCity", instructor.InstructorCity);
                    
                    conn.Open();
                    int InstructorId = Convert.ToInt32(cmd.ExecuteScalar());
                    instructor.InstructorId = InstructorId;
                    return instructor;

                }
                catch (Exception ex){
                    throw new Exception(ex.Message);
                }
                finally{
                    conn.Close();
                }      
            }
        }
        public void DeleteInstructor(int instructorId)
        {
            using (SqlConnection conn = new SqlConnection(strCon)){
                string strSql = @"DELETE FROM Instructor WHERE InstructorId = @InstructorId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try{
                    cmd.Parameters.AddWithValue("@InstructorId", instructorId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex){
                    throw new Exception(ex.Message);
                }
                finally{
                    conn.Close();
                }
            }
        }

        public Instructor GetInstructorById(int instructorId)
        {
            Instructor instructor = new ();
            using (SqlConnection conn = new SqlConnection(strCon)){
                string strSql = @"SELECT * FROM Instructor WHERE InstructorId = @InstructorId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@InstructorId", instructorId);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows){
                    dr.Read();
                    
                    instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                    instructor.InstructorName = dr["InstructorName"].ToString();
                    instructor.InstructorEmail = dr["InstructorEmail"].ToString();
                    instructor.InstructorPhone = dr["InstructorPhone"].ToString();
                    instructor.InstructorAddress = dr["InstructorAddress"].ToString();
                    instructor.InstructorCity = dr["InstructorCity"].ToString();
                }else{
                    throw new Exception("Instructor not found");
                }
            }
            return instructor;    
        }

        public IEnumerable<Instructor> GetInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();
            using (SqlConnection conn = new SqlConnection(strCon)){
                string strSql = @"SELECT * FROM Instructor order by InstructorName";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows){
                    while (dr.Read()){
                        Instructor instructor = new Instructor();
                        instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                        instructor.InstructorName = dr["InstructorName"].ToString();
                        instructor.InstructorEmail = dr["InstructorEmail"].ToString();
                        instructor.InstructorPhone = dr["InstructorPhone"].ToString();
                        instructor.InstructorAddress = dr["InstructorAddress"].ToString();
                        instructor.InstructorCity = dr["InstructorCity"].ToString();
                        instructors.Add(instructor);
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return instructors;
        }

        public Instructor updateInstructor(Instructor instructor)
        {
            using(SqlConnection conn = new SqlConnection(strCon)){
                string strSql = @"UPDATE Instructor SET InstructorName = @InstructorName, InstructorEmail = @InstructorEmail, InstructorPhone = @InstructorPhone, InstructorAddress = @InstructorAddress, InstructorCity = @InstructorCity
                WHERE InstructorId = @InstructorId";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                try{
                    cmd.Parameters.AddWithValue("@InstructorName", instructor.InstructorName);
                    cmd.Parameters.AddWithValue("@InstructorEmail", instructor.InstructorEmail);
                    cmd.Parameters.AddWithValue("@InstructorPhone", instructor.InstructorPhone);
                    cmd.Parameters.AddWithValue("@InstructorAddress", instructor.InstructorAddress);
                    cmd.Parameters.AddWithValue("@InstructorCity", instructor.InstructorCity);
                    cmd.Parameters.AddWithValue("@InstructorId", instructor.InstructorId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return instructor;
                }
                catch (Exception ex){
                    throw new Exception(ex.Message);
                }
                finally{
                    conn.Close();
                }
            }
        }
    }
}