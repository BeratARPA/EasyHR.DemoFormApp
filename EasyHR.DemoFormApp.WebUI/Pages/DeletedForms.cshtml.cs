using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyHR.DemoFormApp.WebUI.Pages
{
    public class DeletedFormsModel : PageModel
    {
        private readonly FormApiService _formApiService;

        public DeletedFormsModel(FormApiService formApiService)
        {
            _formApiService = formApiService;
        }

        public List<FormListDto> DeletedForms { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _formApiService.GetAllDeletedFormsAsync();
            if (result != null && result.Success && result.Data != null)
            {
                DeletedForms = result.Data;
            }
        }

        public async Task<IActionResult> OnPostPermanentDeleteAsync(Guid id)
        {
            var result = await _formApiService.DeleteFormAsync(id);

            if (result != null && result.Success)
            {
                SuccessMessage = "Form kalýcý olarak silindi.";
            }
            else
            {
                ErrorMessage = result?.Message ?? "Form silinirken bir hata oluþtu.";
            }

            return RedirectToPage();
        }
    }
}
