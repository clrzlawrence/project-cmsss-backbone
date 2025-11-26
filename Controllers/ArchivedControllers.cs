using Microsoft.AspNetCore.Mvc;
using ProjectCms.Services;
using ProjectCms.Models;

namespace ProjectCms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchivesController : ControllerBase
    {
        private readonly ArchivedBannerService _archivedBannerService;
        private readonly ArchivedPageService _archivedPageService;

        public ArchivesController(
            ArchivedBannerService archivedBannerService,
            ArchivedPageService archivedPageService)
        {
            _archivedBannerService = archivedBannerService;
            _archivedPageService = archivedPageService;
        }

        // GET: /api/Archives/count
        // -> returns total + breakdown (banners, pages)
        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var archivedBanners = await _archivedBannerService.GetAsync();
            var archivedPages = await _archivedPageService.GetAsync();

            var bannerCount = archivedBanners.Count;
            var pageCount = archivedPages.Count;
            var total = bannerCount + pageCount;

            return Ok(new
            {
                total,
                banners = bannerCount,
                pages = pageCount
            });
        }
    }
}
