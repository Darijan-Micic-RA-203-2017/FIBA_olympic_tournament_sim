using FIBA_OT_sim.Services;

namespace FIBA_OT_sim
{
    public class Program
    {
        private static Random randomNumberGenerator = new Random(85);

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
        }
    }
}
