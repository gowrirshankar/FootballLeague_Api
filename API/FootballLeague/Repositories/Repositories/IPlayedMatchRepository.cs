using Database.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public interface IPlayedMatchRepository
    {
        //Task<List<PlayedMatch>> GetPlayedMatches();
        IEnumerable<PlayedMatchList> GetPlayedMatches();
        IEnumerable<PlayedMatchList> GetPlayedMatchesWithId(int id);

        Task<int> AddPlayedMatches(PlayedMatch objPlayedMatch);
        Task UpdatePlayedMatches(PlayedMatch objPlayedMatch);
        Task<int> DeletePlayedMatches(int matchId);
    }
}
