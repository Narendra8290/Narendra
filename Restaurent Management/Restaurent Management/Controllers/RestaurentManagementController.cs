using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurent_Management.RestaurentManagement.Models;
using Restaurent_Management.RestaurentManagement.Services;


namespace Restaurent_Management.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class RestaurentManagementController : ControllerBase
    {
        private readonly IRestaurentManagementService _restaurentManagementService;
        public RestaurentManagementController(IRestaurentManagementService restaurentManagementService)
        {
            _restaurentManagementService = restaurentManagementService;
        }


        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            try
            {
                return Ok(await _restaurentManagementService.GetOrder(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("messages")]
        public async Task<ActionResult> GetData()
        {
            try
            {
                return Ok(await _restaurentManagementService.GetData());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [HttpGet("lookUpCalls")]
        public async Task<ActionResult> LookUpCall()
        {
            try
            {
                return Ok(await _restaurentManagementService.LookUpCall());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("SaveData")]
        //http://localhost:5094/api/RestaurentManagement/SaveData
        public async Task<IActionResult> SaveData(menuItemsViewModel menuItemsViewModel)
        {
            try
            {
                return Ok(await _restaurentManagementService.SaveData(menuItemsViewModel));
            } catch (Exception ex) 
            {
                throw ex;
            }
        }

        [HttpPost("AddOrderDetailsToAnExistingMenuItem")]
        public async Task<IActionResult> AddOrderDetailsToAnExistingMenuItem(menuItemsViewModel menuItemsViewModel)
        {
            try
            {
                return Ok(await _restaurentManagementService.AddOrderDetailsToAnExistingMenuItem(menuItemsViewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetDataById")]
        //http://localhost:5094/api/RestaurentManagement/GetDataById?id=6337B5A3-8607-45D0-9583-BAFCD31BB296
        public async Task<IActionResult> GetDataById(Guid id)
        {
            try
            {
                return Ok(await _restaurentManagementService.GetDataById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("DeleteDataById")]
        public async Task<IActionResult> DeleteDataById(Guid id)
        {
            try
            {
                return Ok(await _restaurentManagementService.DeleteDataById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("UpdateData")]
        public async Task<IActionResult> UpdateData(menuItemsViewModel menuItemsViewModel)
        {
            try
            {
                return Ok(await _restaurentManagementService.UpdateData(menuItemsViewModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetTotalData/{filterFoodItemByName}")]
        public async Task<IActionResult> GetTotalData([DataSourceRequest] DataSourceRequest options, string filterFoodItemByName)
        {
            try
            {
                var result =await _restaurentManagementService.GetTotalData(filterFoodItemByName);
                return Ok(result.ToDataSourceResult(options));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("GetTotalDataOfImplementingTheGridInApiSide")]
        public async Task<IActionResult> GetTotalDataOfImplementingTheGridInApiSide([DataSourceRequest] DataSourceRequest options)
        {
            try
            {
                var result = await _restaurentManagementService.GetTotalDataOfImplementingTheGridInApiSide();
                return Ok(result.ToDataSourceResult(options));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpGet("PaggingBySkipAndTake")]
        //public async Task<IActionResult> PaggingBySkipAndTake([DataSourceRequest] DataSourceRequest options , int skip, int take)
        //{
        //    try
        //    {
        //       var paggingBySkipAndTake =await _restaurentManagementService.PaggingBySkipAndTake(skip,take);
        //    }
        //}

    }
}
