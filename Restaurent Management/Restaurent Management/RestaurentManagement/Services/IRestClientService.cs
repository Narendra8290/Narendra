
using Restaurent_Management.RestaurentManagement.Models;
using static Restaurent_Management.RestaurentManagement.Models.restClientViewModel;

namespace Restaurent_Management.RestaurentManagement.Services
{
    public interface IRestClientService
    {
        Task<ProductViewModel> GetProductByIdAsync(int id);

        Task<List<restClientViewModel>> GetAllPosts();

        Task<restClientViewModel> CreatePostAsync(restClientViewModel postData);

        Task<restClientViewModel> UpdatePostAsync(int id, restClientViewModel postData);
        Task<bool> DeletePostAsync(int id);
        
    }
}
