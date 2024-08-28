using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;

namespace FIBA_OT_sim.Services
{
    public class GroupPhaseService
    {
        private GroupPhaseRepository groupPhaseRepository;

        public GroupPhaseService()
        {
            groupPhaseRepository = new GroupPhaseRepository();
        }

        public GroupPhaseRepository GroupPhaseRepository
        {
            get { return groupPhaseRepository; }
            set { groupPhaseRepository = value; }
        }

        public void LoadGroupPhaseFromFileSystem(string filePath)
        {
            groupPhaseRepository.LoadGroupPhaseFromFileSystem(filePath);
        }

        public void ScheduleGroupPhaseMatches()
        {
            foreach (Group group in groupPhaseRepository.GroupPhase.Groups)
            {
                Match match1 = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                    group.Teams[0], group.Teams[3], new MatchResult());
                group.Matches.Add(match1);
                group.Teams[0].Matches.Add(match1);
                group.Teams[3].Matches.Add(match1);

                Match match2 = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                    group.Teams[2], group.Teams[1], new MatchResult());
                group.Matches.Add(match2);
                group.Teams[2].Matches.Add(match2);
                group.Teams[1].Matches.Add(match2);

                Match match3 = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                    group.Teams[1], group.Teams[0], new MatchResult());
                group.Matches.Add(match3);
                group.Teams[1].Matches.Add(match3);
                group.Teams[0].Matches.Add(match3);

                Match match4 = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                    group.Teams[3], group.Teams[2], new MatchResult());
                group.Matches.Add(match4);
                group.Teams[3].Matches.Add(match4);
                group.Teams[2].Matches.Add(match4);

                Match match5 = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                    group.Teams[0], group.Teams[2], new MatchResult());
                group.Matches.Add(match5);
                group.Teams[0].Matches.Add(match5);
                group.Teams[2].Matches.Add(match5);

                Match match6 = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                    group.Teams[1], group.Teams[3], new MatchResult());
                group.Matches.Add(match6);
                group.Teams[1].Matches.Add(match6);
                group.Teams[3].Matches.Add(match6);
            }
        }
    }
}
