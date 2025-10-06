using EasyHR.DemoFormApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EasyHR.DemoFormApp.WebUI.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly FormApiService _formApiService;

        public DashboardModel(FormApiService formApiService)
        {
            _formApiService = formApiService;
        }

        public int TotalForms { get; set; }
        public int DeletedForms { get; set; }
        public int ActiveForms { get; set; }

        public async Task OnGetAsync()
        {
            var allForms = await _formApiService.GetAllFormsAsync();
            var deletedForms = await _formApiService.GetAllDeletedFormsAsync();

            ActiveForms = allForms?.Data?.Count ?? 0;
            DeletedForms = deletedForms?.Data?.Count ?? 0;
            TotalForms = ActiveForms + DeletedForms;
        }
    }
}
