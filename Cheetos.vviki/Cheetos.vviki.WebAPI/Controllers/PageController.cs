using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cheetos.vviki.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {

        private IEnumerable<Page> _pages = new List<Page>()
        {
            new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Teste 1",
                Paragraphs = new List<string>(){ "texto 1 hasdhalsdjhaklsjdh", "Texto 2 sukjhdlakjshdlkasjhdjk" },
                Tags = new Dictionary<string, string>(){ { "author", "a.beltzac" }, { "category", "microsserviços" } }
            },

            new Page()
            {
                Id = Guid.NewGuid(),
                Title = "Teste 2",
                Paragraphs = new List<string>(){ "lksajd alskjd aslkdj  çaskljdç alskd alksjd", "Texto 2 sukjhdlakjshdlkasjhdjk" },
                Tags = new Dictionary<string, string>(){ { "author", "a.beltzac" } }
            }
        };

        private readonly ILogger<PageController> _logger;

        public PageController(ILogger<PageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Page> GetAll()
        {
            return _pages;
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var product = _pages.FirstOrDefault((p) => p.Id.ToString() == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        //[HttpPost]
        //public async Task<Page> Post([FromBody]CreatePage requestModel)
        //{
        //    var item = await _query.Create(requestModel);
        //    var model = _mapper.Map<ExpenseModel>(item);
        //    return model;
        //}

        //[HttpPut("{id}")]
        //public async Task<Page> Put(string id, [FromBody]UpdatePage requestModel)
        //{
        //    var item = await _query.Update(id, requestModel);
        //    var model = _mapper.Map<ExpenseModel>(item);
        //    return model;
        //}

        //[HttpDelete("{id}")]
        //public async Task Delete(string id)
        //{
        //    await _query.Delete(id);
        //}
    }
}
