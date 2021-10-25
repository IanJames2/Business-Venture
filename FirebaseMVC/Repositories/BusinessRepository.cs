using System;
using BusinessVenture.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace BusinessVenture.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly IConfiguration _config;

        public BusinessRepository(IConfiguration config)
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

        public List<Business> GetAllBusinessesByUserProfileId(int userProfileId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Business.Id, Business.UserProfileId, Business.Title, Business.[Location]
                        FROM Business
                        WHERE Business.UserProfileId = @userProfileId;
                    ";

                    cmd.Parameters.AddWithValue("@userProfileId", userProfileId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Business> businesses = new List<Business>();
                    while (reader.Read())
                    {
                        Business business = new Business
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Location = reader.GetString(reader.GetOrdinal("Location"))

                        };
                        businesses.Add(business);
                    }
                    reader.Close();

                    return businesses;

                }
            }
        }

        public Business GetBusinessById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Business.Id, UserProfile.Name [UserProfile Name], Business.UserProfileId, Business.Title, Business.[Location], Business.Slogan, Business.Equipment, BusinessType.Type [BusinessType Type], Business.BusinessTypeId
                                        FROM Business
                                        INNER JOIN UserProfile ON Business.UserProfileId = UserProfile.Id
                                        INNER JOIN BusinessType ON Business.BusinessTypeId = BusinessType.Id;
";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Business business = new Business
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            Slogan = reader.GetString(reader.GetOrdinal("Slogan")),
                            Equipment = reader.GetString(reader.GetOrdinal("Equipment")),
                            BusinessTypeId = reader.GetInt32(reader.GetOrdinal("BusinessTypeId"))
                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("UserProfileId")))
                        {
                            business.UserProfile = new UserProfile
                            {
                                Name = reader.GetString(reader.GetOrdinal("UserProfile Name"))
                            };
                        }
                        if (!reader.IsDBNull(reader.GetOrdinal("BusinessTypeId")))
                        {
                            business.BusinessType = new BusinessType
                            {
                                Type = reader.GetString(reader.GetOrdinal("BusinessType Type"))
                            };
                        }

                        reader.Close();
                        return business;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

    public void AddBusiness(Business business)
        {
            throw new Exception();
        }

        public void UpdateBusiness(Business business)
        {
            throw new Exception();
        }

        public void DeleteBusiness(int businessId)
        {
            throw new Exception();
        }


    }
}
