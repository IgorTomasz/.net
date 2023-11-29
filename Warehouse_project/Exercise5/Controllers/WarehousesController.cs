using Exercise5.Models;
using Exercise5.Models.DTOs;
using Exercise5.Respositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Transactions;

namespace Exercise5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehousesController(IConfiguration configuration, IWarehouseRepository warehouseRepository)
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
            //sprawdzic czy produkt istnieje
            if (! await _warehouseRepository.productExists(regProd.IdProduct))
            {
                return NotFound($"Product with id={regProd.IdProduct} wasn't found");
            }
            //sprawdzic czy magazyn istnieje
            if (! await _warehouseRepository.warehouseExists(regProd.IdWarehouse))
            {
                return NotFound($"Warehouse with id={regProd.IdWarehouse} wasn't found");
            }

            //czy amount jest wieksze od 0
            if (regProd.Amount <= 0) return BadRequest("Amount less or equal 0");

            //mozna dodac tylko jesli w order istnieje zlecenie zakupu produktu idProduct i amount sie zgadzaja a createdAt/order < createdAt/zadania
            var idOrder = await _warehouseRepository.orderExists(regProd.Amount, regProd.IdProduct, regProd.CreatedAt);
            if ( idOrder == -1) return BadRequest("There is no order for request");

            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //aktualizacja pola fulfilled aktualna data (update)
                await _warehouseRepository.updateFulfilled(idOrder);

                //wstawic rekord do tabeli Product_warehouse, price = amount*cenaProduktu, createdAt = aktualna data (insert)
                var id = await _warehouseRepository.addProduct(regProd, idOrder);

                scope.Complete();

                //zwrocic klucz glowny dla nowego rekordu
                return Created("", id);
                
            }
            

            
            
        }
    }
}
