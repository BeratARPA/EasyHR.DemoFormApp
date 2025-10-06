using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyHR.DemoFormApp.WebUI.Pages
{
    public class FormDetailModel : PageModel
    {
        private readonly FormApiService _formApiService;

        public FormDetailModel(FormApiService formApiService)
        {
            _formApiService = formApiService;
        }

        public FormDetailDto? FormDetail { get; set; }

        [TempData]
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var result = await _formApiService.GetFormByIdAsync(id);

            if (result != null && result.Success && result.Data != null)
            {
                FormDetail = result.Data;
                return Page();
            }

            ErrorMessage = "Form bulunamadý.";
            return RedirectToPage("/Forms");
        }
    }
}
