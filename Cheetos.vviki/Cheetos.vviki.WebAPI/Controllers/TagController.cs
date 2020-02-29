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

        public TagController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new PageRepository().SelectTags();
        }

        [HttpGet("{tag}")]
        public IEnumerable<string> Get(string tag)
        {
            return new PageRepository().SelectTagValues(tag);
        }
    }
}
