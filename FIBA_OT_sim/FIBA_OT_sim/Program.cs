using FIBA_OT_sim.Services;

namespace FIBA_OT_sim
{
    public class Program
    {
        public const int TOTAL_NUMBER_OF_TEAMS = 12;
        public const int NUMBER_OF_GROUPS = 3;
        public const int NUMBER_OF_TEAMS_IN_EACH_GROUP = 4;

        public static void Main(string[] args)
        {
            GroupPhaseService groupPhaseService = new GroupPhaseService();
            groupPhaseService.LoadGroupPhaseFromFileSystem("../../../../Resources/groups.json");

            Console.WriteLine(groupPhaseService.GroupPhaseRepository.GroupPhase.Groups[1].Teams[2].Name);
        }
    }
}
