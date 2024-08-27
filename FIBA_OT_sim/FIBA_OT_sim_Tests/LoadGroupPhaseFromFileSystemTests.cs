using FIBA_OT_sim.Repositories;

namespace FIBA_OT_sim_Tests
{
    /* References:
     * https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
     * https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest
     * https://learn.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2022
    */
    [TestClass]
    public class LoadGroupPhaseFromFileSystemTests
    {
        public LoadGroupPhaseFromFileSystemTests() { }

        [TestMethod]
        public void Load_group_phase_from_file_system()
        {
            GroupPhaseRepository groupPhaseRepository = new GroupPhaseRepository();

            groupPhaseRepository.LoadGroupPhaseFromFileSystem("../../../../../FIBA_OT_sim/Resources/groups.json");

            Assert.IsNotNull(groupPhaseRepository.GroupPhase);
            Assert.AreEqual(3, groupPhaseRepository.GroupPhase.Groups.Count);

            Assert.AreEqual("A", groupPhaseRepository.GroupPhase.Groups[0].Name);
            Assert.AreEqual(4, groupPhaseRepository.GroupPhase.Groups[0].Teams.Count);
            Assert.AreEqual("Kanada", groupPhaseRepository.GroupPhase.Groups[0].Teams[0].Name);
            Assert.AreEqual("CAN", groupPhaseRepository.GroupPhase.Groups[0].Teams[0].Abbreviation);
            Assert.AreEqual(7, groupPhaseRepository.GroupPhase.Groups[0].Teams[0].FIBARanking);
            Assert.AreEqual("Australija", groupPhaseRepository.GroupPhase.Groups[0].Teams[1].Name);
            Assert.AreEqual("AUS", groupPhaseRepository.GroupPhase.Groups[0].Teams[1].Abbreviation);
            Assert.AreEqual(5, groupPhaseRepository.GroupPhase.Groups[0].Teams[1].FIBARanking);
            Assert.AreEqual("Grčka", groupPhaseRepository.GroupPhase.Groups[0].Teams[2].Name);
            Assert.AreEqual("GRE", groupPhaseRepository.GroupPhase.Groups[0].Teams[2].Abbreviation);
            Assert.AreEqual(14, groupPhaseRepository.GroupPhase.Groups[0].Teams[2].FIBARanking);
            Assert.AreEqual("Španija", groupPhaseRepository.GroupPhase.Groups[0].Teams[3].Name);
            Assert.AreEqual("ESP", groupPhaseRepository.GroupPhase.Groups[0].Teams[3].Abbreviation);
            Assert.AreEqual(2, groupPhaseRepository.GroupPhase.Groups[0].Teams[3].FIBARanking);

            Assert.AreEqual("B", groupPhaseRepository.GroupPhase.Groups[1].Name);
            Assert.AreEqual(4, groupPhaseRepository.GroupPhase.Groups[1].Teams.Count);
            Assert.AreEqual("Nemačka", groupPhaseRepository.GroupPhase.Groups[1].Teams[0].Name);
            Assert.AreEqual("GER", groupPhaseRepository.GroupPhase.Groups[1].Teams[0].Abbreviation);
            Assert.AreEqual(3, groupPhaseRepository.GroupPhase.Groups[1].Teams[0].FIBARanking);
            Assert.AreEqual("Francuska", groupPhaseRepository.GroupPhase.Groups[1].Teams[1].Name);
            Assert.AreEqual("FRA", groupPhaseRepository.GroupPhase.Groups[1].Teams[1].Abbreviation);
            Assert.AreEqual(9, groupPhaseRepository.GroupPhase.Groups[1].Teams[1].FIBARanking);
            Assert.AreEqual("Brazil", groupPhaseRepository.GroupPhase.Groups[1].Teams[2].Name);
            Assert.AreEqual("BRA", groupPhaseRepository.GroupPhase.Groups[1].Teams[2].Abbreviation);
            Assert.AreEqual(12, groupPhaseRepository.GroupPhase.Groups[1].Teams[2].FIBARanking);
            Assert.AreEqual("Japan", groupPhaseRepository.GroupPhase.Groups[1].Teams[3].Name);
            Assert.AreEqual("JPN", groupPhaseRepository.GroupPhase.Groups[1].Teams[3].Abbreviation);
            Assert.AreEqual(26, groupPhaseRepository.GroupPhase.Groups[1].Teams[3].FIBARanking);

            Assert.AreEqual("C", groupPhaseRepository.GroupPhase.Groups[2].Name);
            Assert.AreEqual(4, groupPhaseRepository.GroupPhase.Groups[2].Teams.Count);
            Assert.AreEqual("Sjedinjene Države", groupPhaseRepository.GroupPhase.Groups[2].Teams[0].Name);
            Assert.AreEqual("USA", groupPhaseRepository.GroupPhase.Groups[2].Teams[0].Abbreviation);
            Assert.AreEqual(1, groupPhaseRepository.GroupPhase.Groups[2].Teams[0].FIBARanking);
            Assert.AreEqual("Srbija", groupPhaseRepository.GroupPhase.Groups[2].Teams[1].Name);
            Assert.AreEqual("SRB", groupPhaseRepository.GroupPhase.Groups[2].Teams[1].Abbreviation);
            Assert.AreEqual(4, groupPhaseRepository.GroupPhase.Groups[2].Teams[1].FIBARanking);
            Assert.AreEqual("Južni Sudan", groupPhaseRepository.GroupPhase.Groups[2].Teams[2].Name);
            Assert.AreEqual("SSD", groupPhaseRepository.GroupPhase.Groups[2].Teams[2].Abbreviation);
            Assert.AreEqual(34, groupPhaseRepository.GroupPhase.Groups[2].Teams[2].FIBARanking);
            Assert.AreEqual("Puerto Riko", groupPhaseRepository.GroupPhase.Groups[2].Teams[3].Name);
            Assert.AreEqual("PRI", groupPhaseRepository.GroupPhase.Groups[2].Teams[3].Abbreviation);
            Assert.AreEqual(16, groupPhaseRepository.GroupPhase.Groups[2].Teams[3].FIBARanking);
        }
    }
}
