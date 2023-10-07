using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.Controllers.Api
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPiesRepository _piesRepository;

        public SearchController(IPiesRepository piesRepository)
        {
            _piesRepository = piesRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _piesRepository.AllPies;
            return Ok(allPies);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(!_piesRepository.AllPies.Any(u=>u.PiesId == id))
                return NotFound();

            return Ok(_piesRepository.AllPies.Where(u => u.PiesId == id));

        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pies> pies = new List<Pies>();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _piesRepository.SearchPies(searchQuery);
            }

            return new JsonResult(pies);
                
        }
    }
}
