using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using CommonLibrary;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Restaurent_Management.RestaurentManagement.Context;
using Restaurent_Management.RestaurentManagement.Entities;
using Restaurent_Management.RestaurentManagement.Models;
using Restaurent_Management.RestaurentManagement.RestaurentLoggers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restaurent_Management.RestaurentManagement.Services
{
    public class restaurentManagementService : IRestaurentManagementService
    {
        private string ApiKey = "5E43074A215644A790754E26FC0984C5";
        private readonly restaurentManamentContext _context;
        private readonly Serilog.ILogger _logger;
        public restaurentManagementService(restaurentManamentContext context, Serilog.ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<InheritanceOrderViewModel> GetOrder(Guid id)
        {
            try
            {
                var getOrderDetails = await _context.orderDetails.Where(x => x.menuItemsId == id).Include(x => x.MenuItemsEntity).FirstOrDefaultAsync();
                if (getOrderDetails != null)
                {
                    var inheritanceViewModel = new InheritanceOrderViewModel
                    {
                        paymentMethod = getOrderDetails.paymentMethod,
                        IsPaid = getOrderDetails.IsPaid,
                        itemId = getOrderDetails.MenuItemsEntity.itemId,
                        itemName = getOrderDetails.MenuItemsEntity.itemName,
                        Price = getOrderDetails.MenuItemsEntity.Price,
                        Discription = getOrderDetails.MenuItemsEntity.Discription,
                        availabilityStatus = getOrderDetails.MenuItemsEntity.availabilityStatus,
                        manufacturedDate = getOrderDetails.MenuItemsEntity.manufacturedDate,
                        expiryDate = getOrderDetails.MenuItemsEntity.expiryDate,
                    };
                    return inheritanceViewModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> GetData()
        {
            return await Class1.Message();
        }
        public async Task<object?> LookUpCall()
        {
            try
            {
                var getLookUpCAll = await _context.menuItems.OrderBy(x => x.itemName).Select(x => new menuItemsViewModel
                {
                    itemId = x.itemId,
                    itemName = x.itemName,
                    ////
                    orderDetailsViewModel = x.orderDetailsEntity.OrderBy(x => x.Quantity).Select(y => new orderDetailsViewModel
                    {
                        orderDetailsId = y.orderDetailsId,
                        Quantity = y.Quantity,
                        menuItemsId = y.menuItemsId

                    }).ToList()
                    ////
                }).ToListAsync();
                return getLookUpCAll;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<menuItemsViewModel> AddOrderDetailsToAnExistingMenuItem(menuItemsViewModel menuItemsViewModel)
        {
            try
            {
                var addOrderDetailsToAnExistingMenuItem = _context.menuItems.Where(x => x.itemId == menuItemsViewModel.itemId).FirstOrDefault();
                if (addOrderDetailsToAnExistingMenuItem != null)
                {
                    foreach (var orderDetail in menuItemsViewModel.orderDetailsViewModel)
                    {
                        orderDetailsEntity orderDetailsEntity = new orderDetailsEntity();
                        orderDetailsEntity.orderDetailsId = Guid.NewGuid();
                        orderDetailsEntity.menuItemsId = addOrderDetailsToAnExistingMenuItem.itemId;
                        orderDetailsEntity.Quantity = orderDetail.Quantity;
                        orderDetailsEntity.subTotal = orderDetail.subTotal;
                        orderDetailsEntity.preparationTime = orderDetail.preparationTime;
                        orderDetailsEntity.Ingredients = orderDetail.Ingredients;
                        orderDetailsEntity.Calories = orderDetail.Calories;
                        orderDetailsEntity.ServingSize = orderDetail.ServingSize;
                        orderDetailsEntity.ServingType = orderDetail.ServingType;
                        orderDetailsEntity.OrderDate = DateTime.Now;
                        orderDetailsEntity.isVegan = orderDetail.isVegan;
                        orderDetailsEntity.Mobile = orderDetail.Mobile;
                        orderDetailsEntity.paymentMethod = orderDetail.paymentMethod;
                        orderDetailsEntity.IsPaid = orderDetail.IsPaid;
                        _context.orderDetails.Add(orderDetailsEntity);
                    }
                }
                await _context.SaveChangesAsync();
                return menuItemsViewModel;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public async Task<string> DeleteDataById(Guid id)
        {
            var deleteDataById = await _context.menuItems.Where(x => x.itemId == id).Include(x => x.orderDetailsEntity).FirstOrDefaultAsync();
            if (deleteDataById != null)
            {
                _context.menuItems.Remove(deleteDataById);
            }
            await _context.SaveChangesAsync();
            return "record deleted successfully";
        }
        public async Task<getTotalDataViewModel> GetDataById(Guid id)
        {
            try
            {
                string userName = JsonConvert.SerializeObject("Narendra");
                _logger.Information(LoggerMessages.GetDataById_Method_Execution_Started_in_Service, userName, id);
                var getDataById = await _context.menuItems.Where(x => x.itemId == id).Include(x => x.orderDetailsEntity).FirstOrDefaultAsync();
                getTotalDataViewModel getTotalDataViewModel = new getTotalDataViewModel();
                if (getDataById != null)
                {
                    getTotalDataViewModel.itemId = getDataById.itemId;
                    getTotalDataViewModel.itemName = getDataById.itemName;
                    getTotalDataViewModel.Price = getDataById.Price;
                    getTotalDataViewModel.Discription = getDataById.Discription;
                    getTotalDataViewModel.availabilityStatus = getDataById.availabilityStatus;
                    getTotalDataViewModel.expiryDate = getDataById.expiryDate;
                    getTotalDataViewModel.Quantity = getDataById.orderDetailsEntity.Select(x => x.Quantity).FirstOrDefault();
                    getTotalDataViewModel.subTotal = getDataById.orderDetailsEntity.Select(x => x.subTotal).FirstOrDefault();
                    getTotalDataViewModel.preparationTime = getDataById.orderDetailsEntity.Select(x => x.preparationTime).FirstOrDefault();
                    getTotalDataViewModel.Ingredients = getDataById.orderDetailsEntity.Select(x => x.Ingredients).FirstOrDefault();
                    getTotalDataViewModel.Calories = getDataById.orderDetailsEntity.Select(x => x.Calories).FirstOrDefault();
                    getTotalDataViewModel.ServingSize = getDataById.orderDetailsEntity.Select(x => x.ServingSize).FirstOrDefault();
                    getTotalDataViewModel.ServingType = getDataById.orderDetailsEntity.Select(x => x.ServingType).FirstOrDefault();
                    getTotalDataViewModel.OrderDate = getDataById.orderDetailsEntity.Select(x => x.OrderDate).FirstOrDefault();
                    getTotalDataViewModel.isVegan = getDataById.orderDetailsEntity.Select(x => x.isVegan).FirstOrDefault();
                    getTotalDataViewModel.Mobile = getDataById.orderDetailsEntity.Select(x => x.Mobile).FirstOrDefault();
                    getTotalDataViewModel.paymentMethod = getDataById.orderDetailsEntity.Select(x => x.paymentMethod).FirstOrDefault();
                    getTotalDataViewModel.IsPaid = getDataById.orderDetailsEntity.Select(x => x.IsPaid).FirstOrDefault();
                }
                return getTotalDataViewModel;
            }
            catch (Exception ex)
            {
                _logger.Error(LoggerMessages.Error_Occured_At_GetDataById_Method, ex.Message);
                throw ex;
            }
        }
        public async Task<List<getTotalDataViewModel>> GetTotalData(string filterFoodItemByName)
        {
            var getTotalData = await (from items in _context.menuItems
                                      join
                                      orders in _context.orderDetails
                                      on items.itemId equals orders.menuItemsId
                                      where filterFoodItemByName == "All" ? true : items.itemName.ToLower() == filterFoodItemByName
                                      select new getTotalDataViewModel
                                      {
                                          itemId = items.itemId,
                                          itemName = items.itemName,
                                          Price = items.Price,
                                          Discription = items.Discription,
                                          availabilityStatus = items.availabilityStatus,
                                          manufacturedDate = items.manufacturedDate,
                                          expiryDate = items.expiryDate,
                                          Quantity = orders.Quantity,
                                          subTotal = orders.subTotal,
                                          preparationTime = orders.preparationTime,
                                          Ingredients = orders.Ingredients,
                                          Calories = orders.Calories,
                                          ServingSize = orders.ServingSize,
                                          ServingType = orders.ServingType,
                                          OrderDate = orders.OrderDate,
                                          isVegan = orders.isVegan,
                                          Mobile = orders.Mobile,
                                          paymentMethod = orders.paymentMethod,
                                          IsPaid = orders.IsPaid
                                      }).ToListAsync();

            return getTotalData;
        }
        public async Task<List<getTotalDataViewModel>> GetTotalDataOfImplementingTheGridInApiSide()
        {
            var getTotalData = await (from items in _context.menuItems
                                      join
                                      orders in _context.orderDetails
                                      on items.itemId equals orders.menuItemsId
                                      select new getTotalDataViewModel
                                      {
                                          itemId = items.itemId,
                                          itemName = items.itemName,
                                          Price = items.Price,
                                          Discription = items.Discription,
                                          availabilityStatus = items.availabilityStatus,
                                          manufacturedDate = items.manufacturedDate,
                                          expiryDate = items.expiryDate,
                                          Quantity = orders.Quantity,
                                          subTotal = orders.subTotal,
                                          preparationTime = orders.preparationTime,
                                          Ingredients = orders.Ingredients,
                                          Calories = orders.Calories,
                                          ServingSize = orders.ServingSize,
                                          ServingType = orders.ServingType,
                                          OrderDate = orders.OrderDate,
                                          isVegan = orders.isVegan,
                                          Mobile = orders.Mobile,
                                          paymentMethod = orders.paymentMethod,
                                          IsPaid = orders.IsPaid
                                      }).ToListAsync();
            return getTotalData;
        }
        public async Task<menuItemsViewModel> SaveData(menuItemsViewModel menuItemsViewModel)
        {
            menuItemsEntity menuItemsEntity = new menuItemsEntity();
            menuItemsEntity.itemId = Guid.NewGuid();
            menuItemsEntity.itemName = menuItemsViewModel.itemName;
            menuItemsEntity.Price = menuItemsViewModel.Price;
            menuItemsEntity.Discription = menuItemsViewModel.Discription;
            menuItemsEntity.availabilityStatus = menuItemsViewModel.availabilityStatus;
            menuItemsEntity.manufacturedDate = DateTime.Now;
            menuItemsEntity.expiryDate = DateTime.Now.AddHours(3);
            _context.menuItems.Add(menuItemsEntity);
            foreach (var orderDetail in menuItemsViewModel.orderDetailsViewModel)
            {
                orderDetailsEntity orderDetailsEntity = new orderDetailsEntity();
                orderDetailsEntity.orderDetailsId = Guid.NewGuid();
                orderDetailsEntity.menuItemsId = menuItemsEntity.itemId;
                orderDetailsEntity.Quantity = orderDetail.Quantity;
                orderDetailsEntity.subTotal = orderDetail.subTotal;
                orderDetailsEntity.preparationTime = orderDetail.preparationTime;
                orderDetailsEntity.Ingredients = orderDetail.Ingredients;
                orderDetailsEntity.Calories = orderDetail.Calories;
                orderDetailsEntity.ServingSize = orderDetail.ServingSize;
                orderDetailsEntity.ServingType = orderDetail.ServingType;
                orderDetailsEntity.OrderDate = DateTime.Now;
                orderDetailsEntity.isVegan = orderDetail.isVegan;
                orderDetailsEntity.Mobile = orderDetail.Mobile;
                orderDetailsEntity.paymentMethod = orderDetail.paymentMethod;
                orderDetailsEntity.IsPaid = orderDetail.IsPaid;

                _context.orderDetails.Add(orderDetailsEntity);
            }
            await _context.SaveChangesAsync();
            return menuItemsViewModel;
        }
        public async Task<menuItemsViewModel> UpdateData(menuItemsViewModel menuItemsViewModel)
        {
            var updateMenuItems = await _context.menuItems.Where(x => x.itemId == menuItemsViewModel.itemId).FirstOrDefaultAsync();
            if (updateMenuItems != null)
            {

                updateMenuItems.itemName = menuItemsViewModel.itemName;
                updateMenuItems.Price = menuItemsViewModel.Price;
                updateMenuItems.Discription = menuItemsViewModel.Discription;
                updateMenuItems.availabilityStatus = menuItemsViewModel.availabilityStatus;
                updateMenuItems.manufacturedDate = menuItemsViewModel.manufacturedDate;
                updateMenuItems.expiryDate = menuItemsViewModel.expiryDate;

                _context.menuItems.Update(updateMenuItems);

                foreach (var item in menuItemsViewModel.orderDetailsViewModel)
                {
                    var updateOrderDetails = await _context.orderDetails.Where(x => x.orderDetailsId == item.orderDetailsId).FirstOrDefaultAsync();
                    if (updateOrderDetails != null)
                    {
                        updateOrderDetails.Quantity = item.Quantity;
                        updateOrderDetails.subTotal = item.subTotal;
                        updateOrderDetails.preparationTime = item.preparationTime;
                        updateOrderDetails.Ingredients = item.Ingredients;
                        updateOrderDetails.Calories = item.Calories;
                        updateOrderDetails.ServingSize = item.ServingSize;
                        updateOrderDetails.ServingType = item.ServingType;
                        updateOrderDetails.OrderDate = DateTime.Now;
                        updateOrderDetails.isVegan = item.isVegan;
                        updateOrderDetails.Mobile = item.Mobile;
                        updateOrderDetails.paymentMethod = item.paymentMethod;
                        updateOrderDetails.IsPaid = item.IsPaid;

                        _context.orderDetails.Update(updateOrderDetails);
                    }
                }
                await _context.SaveChangesAsync();
            }
            return menuItemsViewModel;
        }
    }
}