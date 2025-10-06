using AutoMapper;
using EasyHR.DemoFormApp.Business.Abstract;
using EasyHR.DemoFormApp.DataAccess.Abstract;
using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.Entities.Entities;
using EasyHR.DemoFormApp.Shared.Utilities.Results;

namespace EasyHR.DemoFormApp.Business.Concrete
{
    public class FormService : IFormService
    {
        private readonly IGenericRepository<Form> _formRepository;
        private readonly IMapper _mapper;

        public FormService(IGenericRepository<Form> formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FormDetailDto>> CreateForm(FormCreateDto dto)
        {
            var existingForm = await _formRepository.GetAsync(x => x.Email == dto.Email && !x.IsDeleted);
            if (existingForm != null)
            {
                return ApiResponse<FormDetailDto>.ErrorResponse("Bu email ile zaten bir form mevcut.");
            }

            var form = _mapper.Map<Form>(dto);
            await _formRepository.AddAsync(form);

            var formDetailDto = _mapper.Map<FormDetailDto>(form);
            return ApiResponse<FormDetailDto>.SuccessResponse(formDetailDto, "Form oluşturuldu.");
        }

        public async Task<ApiResponse<bool>> HardDeleteForm(Guid id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null)
            {
                return ApiResponse<bool>.ErrorResponse("Form bulunamadı.");
            }

            await _formRepository.DeleteAsync(form.Id);

            return ApiResponse<bool>.SuccessResponse(true);
        }

        public async Task<ApiResponse<List<FormListDto>>> GetAllForms()
        {
            var forms = await _formRepository.GetAllAsync(x => !x.IsDeleted);
            var dtoList = _mapper.Map<List<FormListDto>>(forms);

            return ApiResponse<List<FormListDto>>.SuccessResponse(dtoList, "Formlar başarıyla alındı.");
        }

        public async Task<ApiResponse<List<FormListDto>>> GetAllDeletedForms()
        {
            var forms = await _formRepository.GetAllAsync(x => x.IsDeleted);
            var dtoList = _mapper.Map<List<FormListDto>>(forms);

            return ApiResponse<List<FormListDto>>.SuccessResponse(dtoList, "Formlar başarıyla alındı.");
        }

        public async Task<ApiResponse<FormDetailDto>> GetFormById(Guid id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null)
            {
                return ApiResponse<FormDetailDto>.ErrorResponse("Form bulunamadı.");
            }

            var dto = _mapper.Map<FormDetailDto>(form);
            return ApiResponse<FormDetailDto>.SuccessResponse(dto, "Form başarıyla alındı.");
        }

        public async Task<ApiResponse<bool>> SoftDeleteForm(Guid id)
        {
            var form = await _formRepository.GetByIdAsync(id);
            if (form == null)
            {
                return ApiResponse<bool>.ErrorResponse("Form bulunamadı.");
            }

            form.IsDeleted = true;
            form.DeletedAt = DateTime.UtcNow;
            await _formRepository.UpdateAsync(form);

            return ApiResponse<bool>.SuccessResponse(true, "Form başarıyla silindi.");
        }
    }
}
