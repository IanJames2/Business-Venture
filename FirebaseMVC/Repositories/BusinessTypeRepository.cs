using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BusinessVenture.Models;
using Microsoft.Data.SqlClient;

namespace BusinessVenture.Repositories
{
    public class BusinessTypeRepository : IBusinessTypeRepository
    {
        private readonly IConfiguration _config;

        public BusinessTypeRepository(IConfiguration config)
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

        public List<BusinessType> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Type FROM BusinessType";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<BusinessType> businessTypes = new List<BusinessType>();

                    while (reader.Read())
                    {
                        BusinessType businessType = new BusinessType()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Type = reader.GetString(reader.GetOrdinal("Type"))
                        };
                        businessTypes.Add(businessType);
                    }

                    reader.Close();

                    return businessTypes;
                }
            }
        }
    }
}
