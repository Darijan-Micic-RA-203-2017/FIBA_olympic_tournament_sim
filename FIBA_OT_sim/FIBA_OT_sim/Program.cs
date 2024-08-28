using FIBA_OT_sim.Services;

namespace FIBA_OT_sim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GroupPhaseService groupPhaseService = new GroupPhaseService();
            groupPhaseService.LoadGroupPhaseFromFileSystem("../../../../Resources/groups.json");

            Console.WriteLine(groupPhaseService.GroupPhaseRepository.GroupPhase.Groups[1].Teams[2].Name);
        }
    }
}
