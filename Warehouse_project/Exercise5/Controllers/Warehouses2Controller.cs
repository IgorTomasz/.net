using Exercise5.Models.DTOs;
using Exercise5.Models;
using Exercise5.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Transactions;

namespace Exercise5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Warehouses2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWarehouseRepository _warehouseRepository;

        public Warehouses2Controller(IConfiguration configuration, IWarehouseRepository warehouseRepository)
        {
            _configuration = configuration;
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getProducts()
        {
            var products = new List<ProductWarehouse>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"select * from product_warehouse";
                await connection.OpenAsync();

                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    products.Add(new ProductWarehouse
                    {
                        IdProductWarehouse = reader.GetInt32(0),
                        IdWarehouse = reader.GetInt32(1),
                        IdProduct = reader.GetInt32(2),
                        IdOrder = reader.GetInt32(3),
                        Amount = reader.GetInt32(4),
                        Price = reader.GetDecimal(5),
                        CreatedAt = reader.GetDateTime(6)
                    });
                }

            }

            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> addProductToWarehouse(RegisterNewProductWarehouse regProd)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AddProductToWarehouse";
                command.Parameters.AddWithValue("@IdProduct", regProd.IdProduct);
                command.Parameters.AddWithValue("@IdWarehouse", regProd.IdWarehouse);
                command.Parameters.AddWithValue("@Amount", regProd.Amount);
                command.Parameters.AddWithValue("@CreatedAt", regProd.CreatedAt);
                await connection.OpenAsync();
                return Created("", Convert.ToString(await command.ExecuteScalarAsync()));

            }
                
        }
    }
}
