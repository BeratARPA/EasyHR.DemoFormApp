using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.Shared.Utilities.Results;

namespace EasyHR.DemoFormApp.Business.Abstract
{
    public interface IFormService
    {
        Task<ApiResponse<FormDetailDto>> CreateForm(FormCreateDto dto);
        Task<ApiResponse<List<FormListDto>>> GetAllForms();
        Task<ApiResponse<List<FormListDto>>> GetAllDeletedForms();
        Task<ApiResponse<FormDetailDto>> GetFormById(Guid id);
        Task<ApiResponse<bool>> HardDeleteForm(Guid id);
        Task<ApiResponse<bool>> SoftDeleteForm(Guid id);
    }
}
