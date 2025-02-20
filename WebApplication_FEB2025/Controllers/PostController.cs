using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_FEB2025.DTOs;
using WebApplication_FEB2025.Services;

namespace WebApplication_FEB2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _titleService;

        public PostController( IPostService titleServices)
        {
            _titleService = titleServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => await _titleService.Get();
    }
}
