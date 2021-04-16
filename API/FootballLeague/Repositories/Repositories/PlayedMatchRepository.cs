using Database.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class PlayedMatchRepository : IPlayedMatchRepository
    {
        private readonly FootballDbContext _context;
        public PlayedMatchRepository(FootballDbContext context)
        {
            _context = context;
        }
        //public async Task<List<PlayedMatch>> GetPlayedMatches()
        //{
        //    if (_context != null) return await _context.PlayedMatches.ToListAsync();

        //    return null;
        //}

        public IEnumerable<PlayedMatchList> GetPlayedMatches()
        {
            var output = from t in _context.Teams
                          join p in _context.PlayedMatches on t.TeamId equals p.TeamId
                          select new PlayedMatchList
                          {
                              ID = p.ID,
                              TeamName = t.TeamName,
                              MatchesPlayed = p.MatchesPlayed,
                              Won = p.Won,
                              Lost = p.Lost,
                              Draw = p.Draw,
                              Points = p.Points,
                              TeamId = p.TeamId
                          };
            return output;
        }

        public async Task<int> AddPlayedMatches(PlayedMatch objPlayedMatch)
        {
            if (_context != null)
            {
                var won = objPlayedMatch.Won * 3;
                var lost = objPlayedMatch.Lost * 0;
                var draw = objPlayedMatch.Draw * 1;
                objPlayedMatch.Points = won + lost + draw;
                await _context.PlayedMatches.AddAsync(objPlayedMatch);
                await _context.SaveChangesAsync();

                return objPlayedMatch.ID;
            }

            return 0;
        }

        public async Task UpdatePlayedMatches(PlayedMatch objPlayedMatch)
        {
            if (_context != null)
            {
                var won = objPlayedMatch.Won * 3;
                var lost = objPlayedMatch.Lost * 0;
                var draw = objPlayedMatch.Draw * 1;
                objPlayedMatch.Points = won + lost + draw;
                _context.PlayedMatches.Update(objPlayedMatch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> DeletePlayedMatches(int matchId)
        {
            int result = 0;
            if (_context != null)
            {
                var match = await _context.PlayedMatches.FirstOrDefaultAsync(x => x.ID == matchId);

                if (match != null)
                {
                    _context.Remove(match);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

            public IEnumerable<PlayedMatchList> GetPlayedMatchesWithId(int id)
            {
                var output = from t in _context.Teams
                             join p in _context.PlayedMatches on t.TeamId equals p.TeamId
                             where p.TeamId == id
                             select new PlayedMatchList
                             {
                                 ID = p.ID,
                                 TeamName = t.TeamName,
                                 MatchesPlayed = p.MatchesPlayed,
                                 Won = p.Won,
                                 Lost = p.Lost,
                                 Draw = p.Draw,
                                 Points = p.Points,
                                 TeamId = p.TeamId
                             };
                return output;
            }
    }
}
