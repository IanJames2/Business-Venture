using System;
using BusinessVenture.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;



namespace BusinessVenture.Repositories
{
    public class ProductOrServiceRepository : IProductOrServiceRepository
    {
        private readonly IConfiguration _config;

        public ProductOrServiceRepository(IConfiguration config)
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

        public List<ProductOrService> GetAllProductsOrServicesByUserProfileId(int userProfileId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT ProductOrService.Id, ProductOrService.BusinessId, Business.UserProfileId, ProductOrService.NameOfProductOrService, ProductOrService.Cost 
                        FROM ProductOrService
                        INNER JOIN Business 
                        ON ProductOrService.BusinessId = Business.Id
                        WHERE Business.UserProfileId = @userProfileId";

                    cmd.Parameters.AddWithValue("@userProfileId", userProfileId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ProductOrService> productsOrServices = new List<ProductOrService>();
                    while (reader.Read())
                    {
                        ProductOrService productOrService = new ProductOrService
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            BusinessId = reader.GetInt32(reader.GetOrdinal("BusinessId")),
                            NameOfProductOrService = reader.GetString(reader.GetOrdinal("NameOfProductOrService")),
                            Cost = reader.GetInt32(reader.GetOrdinal("Cost"))

                        };
                        productsOrServices.Add(productOrService);
                    }
                    reader.Close();

                    return productsOrServices;

                }
            }
        }

        public ProductOrService GetProductOrServiceById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT ProductOrService.Id AS Id, ProductOrService.BusinessId, Business.Id, Business.Title [Business Title], ProductOrService.NameOfProductOrService, ProductOrService.Cost 
                                        FROM ProductOrService
                                        INNER JOIN Business ON ProductOrService.BusinessId = Business.Id
                                        WHERE ProductOrService.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ProductOrService productOrService  = new ProductOrService
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            BusinessId = reader.GetInt32(reader.GetOrdinal("BusinessId")),
                            NameOfProductOrService = reader.GetString(reader.GetOrdinal("NameOfProductOrService")),
                            Cost = reader.GetInt32(reader.GetOrdinal("Cost"))
                        };
                        
                        if (!reader.IsDBNull(reader.GetOrdinal("BusinessId")))
                        {
                            productOrService.Business = new Business
                            {
                                Title = reader.GetString(reader.GetOrdinal("Business Title"))
                            };
                        }
                        

                        reader.Close();
                        return productOrService;
                    }
                    else
                    {
                        reader.Close();
                        return null;
                    }
                }
            }
        }

        public void AddProductOrService(ProductOrService productOrService)
        {
            throw new Exception();
        }

        public void UpdateProductOrService(ProductOrService productOrService)
        {
            throw new Exception();
        }

        public void DeleteProductOrService(int productOrServiceId)
        {
            throw new Exception();
        }
    }
}
