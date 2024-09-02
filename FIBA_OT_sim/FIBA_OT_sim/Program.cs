using FIBA_OT_sim.Services;

namespace FIBA_OT_sim
{
    public class Program
    {
        private static long lastGroupId = 0L;
        private static long lastNationalTeamId = 0L;
        private static long lastMatchId = 0L;
        private static Random randomNumberGenerator = new Random(85);

        public static long LastGroupId
        {
            get { return lastGroupId; }
            set { lastGroupId = value; }
        }

        public static long LastNationalTeamId
        {
            get { return lastNationalTeamId; }
            set { lastNationalTeamId = value; }
        }

        public static long LastMatchId
        {
            get { return lastMatchId; }
            set { lastMatchId = value; }
        }
        
        public static Random RandomNumberGenerator
        {
            get { return randomNumberGenerator; }
            set { randomNumberGenerator = value; }
        }

        public static void Main(string[] args)
        {
            GroupPhaseService groupPhaseService = new GroupPhaseService();
            groupPhaseService.LoadGroupPhaseFromFileSystem("Resources/groups.json");
            groupPhaseService.SimulateGroupPhase();

            EliminationPhaseService eliminationPhaseService = new EliminationPhaseService();
            DrawForEliminationPhaseService drawForEliminationPhaseService = new DrawForEliminationPhaseService();
            drawForEliminationPhaseService.PerformDrawForEliminationPhase();
            eliminationPhaseService.SimulateEliminationPhase();
        }
    }
}
