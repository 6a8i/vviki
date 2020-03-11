using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cheetos.vviki.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<PageController> _logger;
        private readonly IPageRepository _pageRepository;

        public TagController(ILogger<PageController> logger, IPageRepository pageRepository)
        {
            _logger = logger;
            _pageRepository = pageRepository;
        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return _pageRepository.SelectTags();
        }

        [HttpGet("{tag}")]
        public IEnumerable<string> Get(string tag)
        {
            return _pageRepository.SelectTagValues(tag);
        }
    }
}
