using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.Shared.Utilities.Results;

namespace EasyHR.DemoFormApp.WebUI.Services
{
    public class FormApiService
    {
        private readonly HttpClient _httpClient;

        public FormApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<FormDetailDto>?> CreateFormAsync(FormCreateDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Forms", dto);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<FormDetailDto>>();
            }

            return ApiResponse<FormDetailDto>.ErrorResponse("Form oluşturulamadı.");
        }

        public async Task<ApiResponse<List<FormListDto>>?> GetAllFormsAsync()
        {
            var response = await _httpClient.GetAsync("api/v1/Forms");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<List<FormListDto>>>();
            }

            return ApiResponse<List<FormListDto>>.ErrorResponse("Formlar alınamadı.");
        }

        public async Task<ApiResponse<List<FormListDto>>?> GetAllDeletedFormsAsync()
        {
            var response = await _httpClient.GetAsync("api/v1/Forms/deleted");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<List<FormListDto>>>();
            }

            return ApiResponse<List<FormListDto>>.ErrorResponse("Silinen formlar alınamadı.");
        }

        public async Task<ApiResponse<FormDetailDto>?> GetFormByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/v1/Forms/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<FormDetailDto>>();
            }

            return ApiResponse<FormDetailDto>.ErrorResponse("Form bulunamadı.");
        }

        public async Task<ApiResponse<bool>?> DeleteFormAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/v1/Forms/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse<bool>>();
            }

            return ApiResponse<bool>.ErrorResponse("Form silinemedi.");
        }
    }
}
