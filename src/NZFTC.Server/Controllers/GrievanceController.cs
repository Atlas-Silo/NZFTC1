// GrievanceController
using Microsoft.AspNetCore.Mvc;
using NZFTC.Shared.Dtos;
using NZFTC.Shared.Interfaces;
using System.Threading.Tasks;

namespace NZFTC.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrievanceController : ControllerBase
    {
        private readonly IGrievanceService _svc;

        public GrievanceController(IGrievanceService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _svc.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrievanceDto dto)
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.GrievanceId }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] GrievanceDto dto)
        {
            if (id != dto.GrievanceId) return BadRequest();
            var updated = await _svc.UpdateAsync(dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _svc.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}