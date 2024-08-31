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

            Assert.IsNotNull(GroupPhaseRepository.GroupPhase);
            Assert.AreEqual(3, GroupPhaseRepository.GroupPhase.Groups.Count);

            Assert.AreEqual("A", GroupPhaseRepository.GroupPhase.Groups[0].Name);
            Assert.AreEqual(4, GroupPhaseRepository.GroupPhase.Groups[0].Teams.Count);
            Assert.AreEqual("Kanada", GroupPhaseRepository.GroupPhase.Groups[0].Teams[0].Name);
            Assert.AreEqual("CAN", GroupPhaseRepository.GroupPhase.Groups[0].Teams[0].Abbreviation);
            Assert.AreEqual(7, GroupPhaseRepository.GroupPhase.Groups[0].Teams[0].FIBARanking);
            Assert.AreEqual("Australija", GroupPhaseRepository.GroupPhase.Groups[0].Teams[1].Name);
            Assert.AreEqual("AUS", GroupPhaseRepository.GroupPhase.Groups[0].Teams[1].Abbreviation);
            Assert.AreEqual(5, GroupPhaseRepository.GroupPhase.Groups[0].Teams[1].FIBARanking);
            Assert.AreEqual("Grčka", GroupPhaseRepository.GroupPhase.Groups[0].Teams[2].Name);
            Assert.AreEqual("GRE", GroupPhaseRepository.GroupPhase.Groups[0].Teams[2].Abbreviation);
            Assert.AreEqual(14, GroupPhaseRepository.GroupPhase.Groups[0].Teams[2].FIBARanking);
            Assert.AreEqual("Španija", GroupPhaseRepository.GroupPhase.Groups[0].Teams[3].Name);
            Assert.AreEqual("ESP", GroupPhaseRepository.GroupPhase.Groups[0].Teams[3].Abbreviation);
            Assert.AreEqual(2, GroupPhaseRepository.GroupPhase.Groups[0].Teams[3].FIBARanking);

            Assert.AreEqual("B", GroupPhaseRepository.GroupPhase.Groups[1].Name);
            Assert.AreEqual(4, GroupPhaseRepository.GroupPhase.Groups[1].Teams.Count);
            Assert.AreEqual("Nemačka", GroupPhaseRepository.GroupPhase.Groups[1].Teams[0].Name);
            Assert.AreEqual("GER", GroupPhaseRepository.GroupPhase.Groups[1].Teams[0].Abbreviation);
            Assert.AreEqual(3, GroupPhaseRepository.GroupPhase.Groups[1].Teams[0].FIBARanking);
            Assert.AreEqual("Francuska", GroupPhaseRepository.GroupPhase.Groups[1].Teams[1].Name);
            Assert.AreEqual("FRA", GroupPhaseRepository.GroupPhase.Groups[1].Teams[1].Abbreviation);
            Assert.AreEqual(9, GroupPhaseRepository.GroupPhase.Groups[1].Teams[1].FIBARanking);
            Assert.AreEqual("Brazil", GroupPhaseRepository.GroupPhase.Groups[1].Teams[2].Name);
            Assert.AreEqual("BRA", GroupPhaseRepository.GroupPhase.Groups[1].Teams[2].Abbreviation);
            Assert.AreEqual(12, GroupPhaseRepository.GroupPhase.Groups[1].Teams[2].FIBARanking);
            Assert.AreEqual("Japan", GroupPhaseRepository.GroupPhase.Groups[1].Teams[3].Name);
            Assert.AreEqual("JPN", GroupPhaseRepository.GroupPhase.Groups[1].Teams[3].Abbreviation);
            Assert.AreEqual(26, GroupPhaseRepository.GroupPhase.Groups[1].Teams[3].FIBARanking);

            Assert.AreEqual("C", GroupPhaseRepository.GroupPhase.Groups[2].Name);
            Assert.AreEqual(4, GroupPhaseRepository.GroupPhase.Groups[2].Teams.Count);
            Assert.AreEqual("Sjedinjene Države", GroupPhaseRepository.GroupPhase.Groups[2].Teams[0].Name);
            Assert.AreEqual("USA", GroupPhaseRepository.GroupPhase.Groups[2].Teams[0].Abbreviation);
            Assert.AreEqual(1, GroupPhaseRepository.GroupPhase.Groups[2].Teams[0].FIBARanking);
            Assert.AreEqual("Srbija", GroupPhaseRepository.GroupPhase.Groups[2].Teams[1].Name);
            Assert.AreEqual("SRB", GroupPhaseRepository.GroupPhase.Groups[2].Teams[1].Abbreviation);
            Assert.AreEqual(4, GroupPhaseRepository.GroupPhase.Groups[2].Teams[1].FIBARanking);
            Assert.AreEqual("Južni Sudan", GroupPhaseRepository.GroupPhase.Groups[2].Teams[2].Name);
            Assert.AreEqual("SSD", GroupPhaseRepository.GroupPhase.Groups[2].Teams[2].Abbreviation);
            Assert.AreEqual(34, GroupPhaseRepository.GroupPhase.Groups[2].Teams[2].FIBARanking);
            Assert.AreEqual("Puerto Riko", GroupPhaseRepository.GroupPhase.Groups[2].Teams[3].Name);
            Assert.AreEqual("PRI", GroupPhaseRepository.GroupPhase.Groups[2].Teams[3].Abbreviation);
            Assert.AreEqual(16, GroupPhaseRepository.GroupPhase.Groups[2].Teams[3].FIBARanking);
        }
    }
}
