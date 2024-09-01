using FIBA_OT_sim.Model;

namespace FIBA_OT_sim.Services
{
    public class DrawForEliminationPhaseService
    {
        private static DrawForEliminationPhase draw;

        public DrawForEliminationPhaseService()
        {
            draw = new DrawForEliminationPhase();
        }

        public static DrawForEliminationPhase Draw
        {
            get { return draw; }
            set { draw = value; }
        }

        public static void PerformDrawForEliminationPhase()
        {
            PlaceNationalTeamsIntoCorrectPots();
        }

        public static void PlaceNationalTeamsIntoCorrectPots()
        {
            IList<NationalTeam> nationalTeamsQualifiedToEliminationPhase = 
                NationalTeamService.GetNationalTeamsQualifiedToEliminationPhase();
            foreach (NationalTeam nationalTeam in nationalTeamsQualifiedToEliminationPhase)
            {
                if (nationalTeam.GroupPhaseRanking <= 2)
                {
                    draw.PotD.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 4)
                {
                    draw.PotE.Add(nationalTeam);
                }
                else if (nationalTeam.GroupPhaseRanking <= 6)
                {
                    draw.PotF.Add(nationalTeam);
                }
                else
                {
                    draw.PotG.Add(nationalTeam);
                }
            }
        }
    }
}
