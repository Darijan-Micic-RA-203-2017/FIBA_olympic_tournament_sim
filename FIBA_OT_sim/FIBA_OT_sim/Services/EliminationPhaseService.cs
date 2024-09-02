using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class EliminationPhaseService
    {
        private static EliminationPhase eliminationPhase;

        public EliminationPhaseService()
        {
            eliminationPhase = new EliminationPhase();
        }

        public static EliminationPhase EliminationPhase
        {
            get { return eliminationPhase; }
            set { eliminationPhase = value; }
        }

        public void SimulateEliminationPhase()
        {
            SimulateQuarterFinals();
            PrintingService.PrintEliminationPhase();
        }

        public void SimulateQuarterFinals()
        {
            foreach (Match quarterFinal in eliminationPhase.QuarterFinals)
            {
                MatchService.DetermineResultOfMatch(quarterFinal);
                NationalTeamService.ChangeStatusesOfNationalTeamsAfterQuarterFinalsMatch(quarterFinal);
            }
        }
    }
}
