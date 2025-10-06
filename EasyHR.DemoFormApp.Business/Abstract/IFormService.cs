using EasyHR.DemoFormApp.Entities.DTOs;

namespace EasyHR.DemoFormApp.Business.Abstract
{
    public interface IFormService
    {
        void SubmitForm(FormCreateDto dto);

    }
}
