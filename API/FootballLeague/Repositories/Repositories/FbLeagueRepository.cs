using Database.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class FbLeagueRepository : IFbLeagueRepository
    {
        private readonly FootballDbContext _context;

        public FbLeagueRepository(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            if (_context != null) return await _context.Teams.ToListAsync();

            return null;
        }
        public async Task<int> AddNewTeams(Team objTeamDetail)
        {
            if(_context != null)
            {
                await _context.Teams.AddAsync(objTeamDetail);
                await _context.SaveChangesAsync();

                return objTeamDetail.TeamId;
            }

            return 0;
        }

        public async Task UpdateTeams(Team objTeamDetail)
        {
            if(_context != null)
            {
                _context.Teams.Update(objTeamDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteTeams(int teamId)
        {
            int result = 0;
            if(_context != null)
            {
                var team = await _context.Teams.FirstOrDefaultAsync(x => x.TeamId == teamId);

                if(team != null)
                {
                    _context.Remove(team);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<Team> GetTeamsWithId(int id)
        {
            if (_context != null)
            {
                return await _context.Teams.FirstOrDefaultAsync(x => x.TeamId == id);
            }
            return null;
        }
    }
}
