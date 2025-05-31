using Restaurent_Management.RestaurentManagement.Models;

namespace Restaurent_Management.RestaurentManagement.Services
{
    public interface IRestaurentManagementService
    {
        Task<menuItemsViewModel> AddOrderDetailsToAnExistingMenuItem(menuItemsViewModel menuItemsViewModel);
        Task<string> DeleteDataById(Guid id);
        Task<getTotalDataViewModel> GetDataById(Guid id);
        Task<List<getTotalDataViewModel>> GetTotalData(string filterFoodItemByName);
      
        Task<List<getTotalDataViewModel>> GetTotalDataOfImplementingTheGridInApiSide();
        Task<menuItemsViewModel> SaveData(menuItemsViewModel menuItemsViewModel);
        Task<menuItemsViewModel> UpdateData(menuItemsViewModel menuItemsViewModel);
        Task<object?> LookUpCall();
        Task<string> GetData();
        Task<InheritanceOrderViewModel> GetOrder(Guid id);
    }
}
