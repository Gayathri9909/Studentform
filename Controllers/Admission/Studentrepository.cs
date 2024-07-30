using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace StudentApp.Controllers.Admission
{
    public class Studentrepository
    {
        public string InsertData(StudentAdmission obj)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId",obj.StudentId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@phoneNUmber", obj.phoneNumber);
                cmd.Parameters.AddWithValue("@DateofBirth", obj.DateOfBirth);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Course",obj.Course);
                cmd.Parameters.AddWithValue("@Photo",obj.Photo);
                cmd.Parameters.AddWithValue("@Resume", obj.Resume);
                cmd.Parameters.AddWithValue("@Query", 1);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }
        public string UpdateData(StudentAdmission obj)
        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", obj.StudentId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@phoneNUmber", obj.phoneNumber);
                cmd.Parameters.AddWithValue("@DateofBirth", obj.DateOfBirth);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Course", obj.Course);
                cmd.Parameters.AddWithValue("@Photo", obj.Photo);
                cmd.Parameters.AddWithValue("@Resume", obj.Resume);
                cmd.Parameters.AddWithValue("@Query", 2);
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteData(int StudentId)
        {
            SqlConnection con = null;
            int result;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@phoneNUmber", null);
                cmd.Parameters.AddWithValue("@DateofBirth", null);
                cmd.Parameters.AddWithValue("@Email", null);
                cmd.Parameters.AddWithValue("@Course", null);
                cmd.Parameters.AddWithValue("@Photo", null);
                cmd.Parameters.AddWithValue("@Resume", null);
                cmd.Parameters.AddWithValue("@Query", 3);
                con.Open();
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch
            {
                return result = 0;
            }
            finally
            {
                con.Close();
            }
        }
        public List<StudentAdmission> Selectalldata()
        {
            SqlConnection con = null;
            DataSet ds = null;
            List<StudentAdmission> stdlist = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", null);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@phoneNUmber", null);
                cmd.Parameters.AddWithValue("@DateofBirth", null);
                cmd.Parameters.AddWithValue("@Email", null);
                cmd.Parameters.AddWithValue("@Course", null);
                cmd.Parameters.AddWithValue("@Photo", null);
                cmd.Parameters.AddWithValue("@Resume", null);
                cmd.Parameters.AddWithValue("@Query", 4);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                /* stdlist = new List<StudentAdmission>();
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     StudentAdmission cobj = new StudentAdmission();
                     cobj.StudentId = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                     cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                     cobj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                     cobj.phoneNumber = ds.Tables[0].Rows[i]["phoneNumber"].ToString();
                     cobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                     cobj.DateOfBirth = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateofBirth"].ToString());
                     cobj.Course = ds.Tables[0].Rows[i]["Course"].ToString();
                     cobj.Photo = Convert.ToBase64String((byte[])ds.Tables[0].Rows[i]["Photo"]);
                     cobj.Resume = Convert.ToBase64String((byte[])ds.Tables[0].Rows[i]["Resume"]);

                     stdlist.Add(cobj);*/
                var stdList = new List<StudentAdmission>();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var obj = new StudentAdmission
                        {
                            StudentId = Convert.ToInt32(row["StudentId"]),
                            Name = row["Name"].ToString(),
                            Address = row["Address"].ToString(),
                            phoneNumber = row["PhoneNumber"].ToString(),
                            Email = row["Email"].ToString(),
                            DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                            Course = row["Course"].ToString(),
                            Photo = row["Photo"] as byte[],
                            Resume = row["Resume"] as byte[]
                        };
                        stdList.Add(obj);
                    }
                }
                return stdlist;
            }
            catch
            {
                return stdlist;
            }
            finally
            {
                con.Close();
            }
        }
        public StudentAdmission SelectDatabyID(int StudentId)
        {
            SqlConnection con = null;
            DataSet ds = null;
            StudentAdmission cobj = null;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", StudentId);
                cmd.Parameters.AddWithValue("@Name", null);
                cmd.Parameters.AddWithValue("@Address", null);
                cmd.Parameters.AddWithValue("@phoneNUmber", null);
                cmd.Parameters.AddWithValue("@DateofBirth", null);
                cmd.Parameters.AddWithValue("@Email", null);
                cmd.Parameters.AddWithValue("@Course", null);
                cmd.Parameters.AddWithValue("@Photo", null);
                cmd.Parameters.AddWithValue("@Resume", null);
                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    var row = ds.Tables[0].Rows[0];
                    return new StudentAdmission
                    {
                        StudentId = Convert.ToInt32(row["StudentId"]),
                        Name = row["Name"].ToString(),
                        Address = row["Address"].ToString(),
                        phoneNumber = row["PhoneNumber"].ToString(),
                        Email = row["Email"].ToString(),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        Course = row["Course"].ToString(),
                        Photo = row["Photo"] as byte[],
                        Resume = row["Resume"] as byte[]
                    };
                }
                return null;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }
    }
        
    
}