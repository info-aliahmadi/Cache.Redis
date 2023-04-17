using Cache.Redis.Data;
using Cache.Redis.Data.Domain;
using EFCoreSecondLevelCacheInterceptor;
using Microsoft.AspNetCore.Mvc;

namespace Cache.Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {

        private readonly ILogger<AuthorController> _logger;
        private ApplicationDbContext _applicationDbContext;

        public AuthorController(ILogger<AuthorController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [Route("GetAuthors")]
        public IEnumerable<Author> GetAuthors()
        {
            // for cache the data just nedd to call the 'Cacheable' method in the end of your query
            var cachedAuthors = _applicationDbContext.Author.Cacheable().ToList();

            return cachedAuthors;
        }


        [HttpGet]
        [Route("GetContentsAuthor")]
        public IEnumerable<Content> GetContentsAuthor(int authorId)
        {
            // for cache the data just nedd to call the 'Cacheable' method in the end of your query
            var cachedContents = _applicationDbContext.Content.Where(x => x.AuthorId == authorId).Cacheable().ToList();

            return cachedContents;
        }

        //[HttpGet(Name = "GetInfo")]
        //public string GetInfo()
        //{
        //    return "Hello Wolrd;";
        //}
    }
}