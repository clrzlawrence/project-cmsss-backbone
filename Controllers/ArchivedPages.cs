using Microsoft.AspNetCore.Mvc;
using ProjectCms.Models;
using ProjectCms.Services;

namespace ProjectCms.Controllers
{
    [ApiController]
    [Route("api/ArchivedPages")]
    public class ArchivedPagesController : ControllerBase
    {
        private readonly ArchivedPageService _archivedPageService;

        public ArchivedPagesController(ArchivedPageService archivedPageService)
        {
            _archivedPageService = archivedPageService;
        }

        // GET: /api/ArchivedPages
        [HttpGet]
        public async Task<ActionResult<List<ArchivedPage>>> GetAll()
        {
            var items = await _archivedPageService.GetAsync();
            return Ok(items);
        }

        // GET: /api/ArchivedPages/deleted
        [HttpGet("deleted")]
        public async Task<ActionResult<List<ArchivedPage>>> GetDeleted()
        {
            var items = await _archivedPageService.GetByTypeAsync("Deleted");
            return Ok(items);
        }
    }
}
