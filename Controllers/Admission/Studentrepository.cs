using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentApp.Controllers.Admission
{
    public class Studentrepository
    {
        private readonly string _connectionString;

        public Studentrepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["mycon"].ToString();
        }

        public string InsertData(StudentAdmission obj)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", obj.Name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", obj.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", obj.phoneNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth == DateTime.MinValue ? (object)DBNull.Value : obj.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Email", obj.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Course", obj.Course ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", string.IsNullOrEmpty(obj.Photo) ? (object)DBNull.Value : obj.Photo);
                        cmd.Parameters.AddWithValue("@Resume", string.IsNullOrEmpty(obj.Resume) ? (object)DBNull.Value : obj.Resume);
                        cmd.Parameters.AddWithValue("@Query", 1);

                        con.Open();
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex.Message) if needed
                    return $"Error: {ex.Message}";
                }
            }
        }

        public string UpdateData(StudentAdmission obj)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", obj.Name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", obj.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", obj.phoneNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth == DateTime.MinValue ? (object)DBNull.Value : obj.DateOfBirth);
                        cmd.Parameters.AddWithValue("@Email", obj.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Course", obj.Course ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", string.IsNullOrEmpty(obj.Photo) ? (object)DBNull.Value : obj.Photo);
                        cmd.Parameters.AddWithValue("@Resume", string.IsNullOrEmpty(obj.Resume) ? (object)DBNull.Value : obj.Resume);
                        cmd.Parameters.AddWithValue("@Query", 2);

                        con.Open();
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex.Message) if needed
                    return $"Error: {ex.Message}";
                }
            }
        }

        public string DeleteData(string Email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Course", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Resume", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Query", 3);

                        con.Open();
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex.Message) if needed
                    return $"Error: {ex.Message}";
                }
            }
        }

        public List<StudentAdmission> SelectAllData()
        {
            var stdList = new List<StudentAdmission>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Course", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Resume", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Query", 4);

                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            var ds = new DataSet();
                            da.Fill(ds);

                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    var obj = new StudentAdmission
                                    {
                                        Name = row["Name"].ToString(),
                                        Address = row["Address"].ToString(),
                                        phoneNumber = row["PhoneNumber"].ToString(),
                                        Email = row["Email"].ToString(),
                                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                                        Course = row["Course"].ToString(),
                                        Photo = row["Photo"] != DBNull.Value ? Convert.ToBase64String((byte[])row["Photo"]) : null,
                                        Resume = row["Resume"] != DBNull.Value ? Convert.ToBase64String((byte[])row["Resume"]) : null
                                    };
                                    stdList.Add(obj);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception (ex.Message) if needed
                    return new List<StudentAdmission>();
                }
            }

            return stdList;
        }

        public StudentAdmission SelectDataByID(string Email)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertUpdateDelete_Student", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Name", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Address", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@PhoneNumber", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@DateOfBirth", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Course", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Photo", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Resume", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Query", 5);

                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            var ds = new DataSet();
                            da.Fill(ds);

                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                var row = ds.Tables[0].Rows[0];
                                return new StudentAdmission
                                {
                                    Name = row["Name"].ToString(),
                                    Address = row["Address"].ToString(),
                                    phoneNumber = row["PhoneNumber"].ToString(),
                                    Email = row["Email"].ToString(),
                                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                                    Course = row["Course"].ToString(),
                                    Photo = row["Photo"] != DBNull.Value ? Convert.ToBase64String((byte[])row["Photo"]) : null,
                                    Resume = row["Resume"] != DBNull.Value ? Convert.ToBase64String((byte[])row["Resume"]) : null
                                };
                            }

                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}