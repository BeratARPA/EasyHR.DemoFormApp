using EasyHR.DemoFormApp.Business.Abstract;
using EasyHR.DemoFormApp.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EasyHR.DemoFormApp.API.Controllers
{
    public class FormsController : BaseController
    {
        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FormCreateDto dto)
        {
            var result = await _formService.CreateForm(dto);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _formService.GetAllForms();
            return Ok(result);
        }

        [HttpGet("deleted")]
        public async Task<IActionResult> GetAllDeleted()
        {
            var result = await _formService.GetAllDeletedForms();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _formService.GetFormById(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _formService.GetFormById(id);

            if (!result.Success || result.Data == null)
                return NotFound(result);

            if (result.Data.IsDeleted)
            {
                var hardDeleteResult = await _formService.HardDeleteForm(id);
                if (!hardDeleteResult.Success)
                    return BadRequest(hardDeleteResult);

                return Ok(hardDeleteResult);
            }

            var softDeleteResult = await _formService.SoftDeleteForm(id);
            if (!softDeleteResult.Success)
                return BadRequest(softDeleteResult);

            return Ok(softDeleteResult);
        }
    }
}
