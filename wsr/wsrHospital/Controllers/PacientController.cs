using Microsoft.AspNetCore.Mvc;
using wsrHospital.Repos;

namespace wsrHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientController : ControllerBase
    {
        private readonly IPacient _service;
        public PacientController(IPacient service)
        {

            _service = service;

        }

        [HttpGet("All")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _service.GetById(id));
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpPost("new")]
        public async Task<IActionResult> Post(PacientDto pacientDto)
        {
            try
            {
                await _service.Create(pacientDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put(int id, PacientDto pacientDto)
        {
            try
            {
                await _service.Put(id, pacientDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}
