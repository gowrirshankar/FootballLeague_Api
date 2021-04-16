using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories.Repositories;
using System;
using System.Threading.Tasks;

namespace MainApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballController : ControllerBase
    {
        private readonly IFbLeagueRepository _repository;

        public FootballController(IFbLeagueRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetTeams")]
        public async Task<IActionResult> GetAllTeams()
        {
            try
            {
                var teams = await _repository.GetAllTeams();
                if (teams == null)
                    return NotFound();
                return Ok(teams);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetTeamswithId")]
        public async Task<IActionResult> GetTeamsWithId(int id)
        {
            try
            {
                var teams = await _repository.GetTeamsWithId(id);
                if (teams == null)
                    return NotFound();
                return Ok(teams);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddTeams")]
        public async Task<IActionResult> AddTeamDetails(Team objTeamDetails)
        {
            try
            {
                var teamId = await _repository.AddNewTeams(objTeamDetails);
                if (teamId > 0)
                    return Ok(teamId);
                else
                   return NotFound(); 
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateTeams")]
        public async Task<IActionResult> UpdateTeamDetails(Team objTeamDetails)
        {
            try
            {
               await _repository.UpdateTeams(objTeamDetails);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeleteTeams")]
        public async Task<IActionResult> DeleteTeamDetails(int teamId)
        {
            int result;

            try
            {
                result = await _repository.DeleteTeams(teamId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
