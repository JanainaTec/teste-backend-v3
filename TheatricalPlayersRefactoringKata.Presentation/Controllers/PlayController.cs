using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : Controller
    {
        public readonly IPlayService _playService;

        public PlayController(IPlayService playService)
        {
            _playService = playService;
        }

        [HttpPost]
        public IActionResult OnPostPlay([FromBody] PlayModel model)
        {
            try
            {
                _playService.AddPlay(model);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<PlayModel>))]
        public IActionResult OnGetPlay()
        {
            try
            {
                var result = _playService.GetAllPlay();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(PlayModel))]
        public IActionResult OnGetPlay(string id)
        {
            try
            {
                var result = _playService.GetPlay(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesDefaultResponseType(typeof(PlayDto))]
        public IActionResult OnPutPlay([FromBody] PlayDto model , string id)
        {
            try
            {
                var result = _playService.UpdatePlay(id , model);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult OnDeletePlay(string id)
        {
            try
            {
                _playService.RemovePlay(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
