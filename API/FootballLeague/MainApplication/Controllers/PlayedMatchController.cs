using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace MainApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedMatchController : ControllerBase
    {
        private readonly IPlayedMatchRepository _repository;

        public PlayedMatchController(IPlayedMatchRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetPlayedMatches")]
        public IActionResult GetPlayedMatches()
        {
            try
            {
                var matches = _repository.GetPlayedMatches();
                if (matches == null)
                    return NotFound();

                return Ok(matches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPlayedMatchesWithId")]
        public IActionResult GetPlayedMatchesWithId(int id)
        {
            try
            {
                var matches = _repository.GetPlayedMatchesWithId(id);
                if (matches == null)
                    return NotFound();

                return Ok(matches);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddPlayedMatch")]
        public async Task<IActionResult> AddPlayedMatchDetails(PlayedMatch objPlayedMatchDetails)
        {
            try
            {
                var matchId = await _repository.AddPlayedMatches(objPlayedMatchDetails);
                if (matchId > 0)
                    return Ok(matchId);
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdatePlayedMatches")]
        public async Task<IActionResult> UpdatePlayedMatches(PlayedMatch objPlayedMatches)
        {
            try
            {
                await _repository.UpdatePlayedMatches(objPlayedMatches);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeletePlayedMatches")]
        public async Task<IActionResult> DeletePlayedMatches(int matchId)
        {
            int result;

            try
            {
                result = await _repository.DeletePlayedMatches(matchId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
