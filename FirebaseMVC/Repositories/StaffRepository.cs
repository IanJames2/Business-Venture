using System;
using BusinessVenture.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace BusinessVenture.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly IConfiguration _config;

        public StaffRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Staff> GetAllStaffByUserProfileId(int userProfileId)
        {
            //Establishes SQL Connection to retrieve data
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT s.Id, s.[Name], s.Email, s.PhoneNumber, s.[Address], b.UserProfileId, b.Title, b.[Location], bs.Id, bs.DateEmployed, bs.positionTitle
                    FROM BusinessStaff bs
                    LEFT JOIN Business b ON bs.BusinessId = b.Id
                    LEFT JOIN Staff s ON s.Id = bs.StaffId
                    WHERE b.UserProfileId = @userProfileId;
                    ";
                    //Converts SQL Query To C# Lang
                    cmd.Parameters.AddWithValue("@userProfileId", userProfileId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Staff> staffMembers = new List<Staff>();
                    while (reader.Read())
                    {
                        Staff staff = new Staff
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Address = reader.GetString(reader.GetOrdinal("Address"))
                            Business = new Business
                            {
                                
                            }
                        };
                    }
                }


                public Staff GetStaffById(int id)
        {
            throw new InvalidOperationException("Logfile cannot be read-only");
        }

        public void AddStaffMember(Staff staff)
        {
            throw new InvalidOperationException("Logfile cannot be read-only");
        }

        public void UpdateStaff(Staff staff)
        {
            throw new InvalidOperationException("Logfile cannot be read-only");
        }

        public void DeleteStaff(int staffId)
        {
            throw new InvalidOperationException("Logfile cannot be read-only");
        }

    }
}
