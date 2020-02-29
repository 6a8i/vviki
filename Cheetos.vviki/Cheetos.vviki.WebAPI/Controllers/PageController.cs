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
    public class PageController : ControllerBase
    {
        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Page> GetAll()
        {
            return new PageRepository().SelectAll();
        }

        [HttpGet("{id}")]
        public Page Get(string id)
        {
            return new PageRepository().Select(id);
        }

        [HttpPost]
        public async Task Post([FromBody]Page requestModel) //Criar
        {
            new PageRepository().Insert(requestModel);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Page requestModel) //Atualizar
        {
            requestModel.Id = id;
            new PageRepository().Update(requestModel);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            new PageRepository().Delete(id);
        }

        [HttpGet("Search/Tag/{tag}")]
        public IEnumerable<Page> GetByTag(string tag)
        {
            return new PageRepository().SelectByTag(tag);
        }

        [HttpGet("Search/Tag/{tag}/Value/{value}")]
        public IEnumerable<Page> GetByTagAndValue(string tag, string value)
        {
            return new PageRepository().SelectByTag(tag, value);
        }

        [HttpGet("Search/Text/{text}")]
        public IEnumerable<Page> GetByText(string text)
        {
            return new PageRepository().SelectByText(text);
        }
    }
}
