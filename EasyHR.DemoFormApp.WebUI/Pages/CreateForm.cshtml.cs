using EasyHR.DemoFormApp.Entities.DTOs;
using EasyHR.DemoFormApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyHR.DemoFormApp.WebUI.Pages
{
    public class CreateFormModel : PageModel
    {
        private readonly FormApiService _formApiService;

        public CreateFormModel(FormApiService formApiService)
        {
            _formApiService = formApiService;
        }

        [BindProperty]
        public FormCreateDto FormData { get; set; } = new();

        [TempData]
        public string? ErrorMessage { get; set; }

        [TempData]
        public string? SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _formApiService.CreateFormAsync(FormData);

            if (result != null && result.Success)
            {
                SuccessMessage = result.Message;
                return RedirectToPage("/Index");
            }

            ErrorMessage = result?.Message ?? "Bir hata oluþtu.";
            return Page();
        }
    }
}
