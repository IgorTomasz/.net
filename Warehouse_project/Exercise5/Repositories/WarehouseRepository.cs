using Exercise5.Models;
using Exercise5.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.SqlClient;

namespace Exercise5.Respositories
{
    public interface IWarehouseRepository
    {
        public Task<bool> productExists(int id);
        public Task<bool> warehouseExists(int id);
        public Task<int> orderExists(int amount, int idProduct, DateTime createdAt);
        public Task updateFulfilled(int idOrder);
        public Task<decimal> getProductPrice(int idProduct, int amount);
        public Task<string> addProduct(RegisterNewProductWarehouse productWarehouse, int idOrder);
    }
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly IConfiguration _configuration;
        public WarehouseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> productExists(int id)
        {
            using(var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"select IdProduct from Product where IdProduct=@1";
                command.Parameters.AddWithValue("@1", id);
                await connection.OpenAsync();
                if (await command.ExecuteScalarAsync() is not null)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> warehouseExists(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"select IdWarehouse from warehouse where IdWarehouse=@1";
                command.Parameters.AddWithValue("@1", id);
                await connection.OpenAsync();
                if (await command.ExecuteScalarAsync() is not null)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<int> orderExists(int amount, int idProduct,DateTime createdAt)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"select idOrder from \"order\" where amount=@1 and idProduct=@2 and createdAt<@3";
                command.Parameters.AddWithValue("@1", amount);
                command.Parameters.AddWithValue("@2", idProduct);
                command.Parameters.AddWithValue("@3", createdAt);
                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();
                if (result is not null)
                {
                    return (int)result;
                }
                return -1;
            }
        }

        public async Task updateFulfilled(int idOrder)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"update \"order\" set FulfilledAt=@1 where idOrder=@2";
                command.Parameters.AddWithValue("@1", DateTime.Now);
                command.Parameters.AddWithValue("@2", idOrder);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<string> addProduct(RegisterNewProductWarehouse productWarehouse, int idOrder)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                decimal price = await getProductPrice(productWarehouse.IdProduct, productWarehouse.Amount);
                var command = connection.CreateCommand();
                command.CommandText = $"insert into product_warehouse (IdWarehouse, IdProduct, idOrder, Amount, Price, CreatedAt) Values" +
                    $"(@1,@2,@3,@4,@5,@6); Select SCOPE_IDENTITY();";
                command.Parameters.AddWithValue("@1", productWarehouse.IdWarehouse);
                command.Parameters.AddWithValue("@2", productWarehouse.IdProduct);
                command.Parameters.AddWithValue("@3", idOrder);
                command.Parameters.AddWithValue("@4", productWarehouse.Amount);
                command.Parameters.AddWithValue("@5", price);
                command.Parameters.AddWithValue("@6", DateTime.Now);
                await connection.OpenAsync();
                
                return Convert.ToString(await command.ExecuteScalarAsync());
            }
        }

        public async Task<decimal> getProductPrice(int idProduct, int amount)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"select price from product where idProduct=@1";
                command.Parameters.AddWithValue("@1", idProduct);
                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();
                if (result is not null)
                {
                    var price = (decimal)result * amount;
                    return price;
                }
                return -1;
            }
        }

    }
}
