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
        private readonly IPageRepository _pageRepository;

        public PageController(ILogger<PageController> logger, IPageRepository pageRepository)
        {
            _logger = logger;
            _pageRepository = pageRepository;
        }

        [HttpGet]
        public IEnumerable<Page> GetAll()
        {
            return _pageRepository.SelectAll();
        }

        [HttpGet("{id}")]
        public Page Get(string id)
        {
            return _pageRepository.Select(Guid.Parse(id));
        }

        [HttpPost]
        public async Task Post([FromBody]Page requestModel) //Criar
        {
            _pageRepository.Insert(requestModel);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody]Page requestModel) //Atualizar
        {
            requestModel.Id = Guid.Parse(id);
            _pageRepository.Update(requestModel);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            _pageRepository.Delete(Guid.Parse(id));
        }

        [HttpGet("Search/Tag/{tag}")]
        public IEnumerable<Page> GetByTag(string tag)
        {
            return _pageRepository.SelectByTag(tag);
        }

        [HttpGet("Search/Tag/{tag}/Value/{value}")]
        public IEnumerable<Page> GetByTagAndValue(string tag, string value)
        {
            return _pageRepository.SelectByTag(tag, value);
        }

        [HttpGet("Search/Text/{text}")]
        public IEnumerable<Page> GetByText(string text)
        {
            return _pageRepository.SelectByText(text);
        }
    }
}
