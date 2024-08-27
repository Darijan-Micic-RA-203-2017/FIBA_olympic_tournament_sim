using FIBA_OT_sim.Repositories;

namespace FIBA_OT_sim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GroupPhaseRepository groupPhaseRepository = new GroupPhaseRepository();
            groupPhaseRepository.LoadGroupPhaseFromFileSystem();

            Console.WriteLine(groupPhaseRepository.GroupPhase.Groups[1].Teams[2].Name);
        }
    }
}
