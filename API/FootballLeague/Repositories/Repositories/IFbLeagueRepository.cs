using Database.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public interface IFbLeagueRepository
    {
        //Teams
        Task<List<Team>> GetAllTeams();
        Task<Team> GetTeamsWithId(int id);
        //IEnumerable<Team> GetTeamsWithId(int id);
        Task<int> AddNewTeams(Team objTeamDetail);
        Task UpdateTeams(Team objTeamDetail);
        Task<int> DeleteTeams(int teamId);

    }
}
