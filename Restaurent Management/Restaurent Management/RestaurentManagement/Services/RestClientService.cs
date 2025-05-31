 using System.Text.Json;
using Restaurent_Management.RestaurentManagement.Models;
using RestSharp;
using static Restaurent_Management.RestaurentManagement.Models.restClientViewModel;

namespace Restaurent_Management.RestaurentManagement.Services
{
    public class RestClientService : IRestClientService
    {
        private readonly RestClient _restClient;

        public RestClientService()
        {
            _restClient = new RestClient("https://fakestoreapi.com");
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            try
            {
                var request = new RestRequest($"/products/{id}", Method.Get);
                var response = await _restClient.ExecuteAsync(request);

                if (!response.IsSuccessful || response.Content == null)
                {
                    throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Message: {response.ErrorMessage}");
                }

                return JsonSerializer.Deserialize<ProductViewModel>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new ProductViewModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetProductByIdAsync: {ex.Message}");
                throw;
            }
        }




        public async Task<List<restClientViewModel>> GetAllPosts()
        {
            try
            {
                var request = new RestRequest("/products", Method.Get);
                var response = await _restClient.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return JsonSerializer.Deserialize<List<restClientViewModel>>(response.Content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<restClientViewModel>();
                }
                throw new Exception("Failed to fetch posts");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<restClientViewModel> CreatePostAsync(restClientViewModel postData)
        {
            try
            {
                var request = new RestRequest("/products", Method.Post);
                request.AddJsonBody(postData); 

                var response = await _restClient.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Message: {response.ErrorMessage}");
                }

                return JsonSerializer.Deserialize<restClientViewModel>(response.Content ?? string.Empty, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new restClientViewModel();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error in CreatePostAsync: {ex.Message}");

                throw;
            }
        }

        public async Task<restClientViewModel> UpdatePostAsync(int id, restClientViewModel postData)
        {
            try
            {
                var request = new RestRequest($"/products/{id}", Method.Put);
                request.AddJsonBody(postData); 

                var response = await _restClient.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Message: {response.ErrorMessage}");
                }

                return JsonSerializer.Deserialize<restClientViewModel>(response.Content ?? string.Empty, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new restClientViewModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdatePostAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            try
            {
                var request = new RestRequest($"/products/{id}", Method.Delete);

                var response = await _restClient.ExecuteAsync(request);

                if (!response.IsSuccessful)
                {
                    throw new HttpRequestException($"Request failed with status: {response.StatusCode}, Message: {response.ErrorMessage}");
                }

                return true; // Successfully deleted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeletePostAsync: {ex.Message}");
                throw;
            }
        }

        
    }
}
