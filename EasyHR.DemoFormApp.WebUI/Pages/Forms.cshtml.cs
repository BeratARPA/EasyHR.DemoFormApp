using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyHR.DemoFormApp.WebUI.Pages
{
    public class FormsModel : PageModel
    {
        private readonly FormApiService _formApiService;

        public FormsModel(FormApiService formApiService)
        {
            _formApiService = formApiService;
        }

        public List<FormListDto> Forms { get; set; } = new();

        [TempData]
        public string? SuccessMessage { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _formApiService.GetAllFormsAsync();
            if (result != null && result.Success && result.Data != null)
            {
                Forms = result.Data;
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var result = await _formApiService.DeleteFormAsync(id);

            if (result != null && result.Success)
            {
                SuccessMessage = "Form baþarýyla silindi.";
            }
            else
            {
                ErrorMessage = result?.Message ?? "Form silinirken bir hata oluþtu.";
            }

            return RedirectToPage();
        }
    }
}
