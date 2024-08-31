using FIBA_OT_sim.Model;
using FIBA_OT_sim.Repositories;
using FIBA_OT_sim.Services;

namespace FIBA_OT_sim_Tests
{
    /* References:
     * https://learn.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
     * https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest
     * https://learn.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2022
    */
    [TestClass]
    public class SimulateGroupPhaseTests
    {
        public SimulateGroupPhaseTests() { }

        [TestMethod]
        public void Rank_national_teams_in_group_stage_of_FIBA_olympic_tournament_in_Paris_2024()
        {
            GroupPhaseService groupPhaseService = new GroupPhaseService();
            
            Group groupA = new Group("A", new List<NationalTeam>(), new List<Match>());

            NationalTeam australia = new NationalTeam("Australija", "AUS", 5, 1, 2, 246, 250, -4, 4, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupA.Teams.Add(australia);
            NationalTeam canada = new NationalTeam("Kanada", "CAN", 7, 3, 0, 267, 247, 20, 6, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupA.Teams.Add(canada);
            NationalTeam greece = new NationalTeam("Grčka", "GRE", 14, 1, 2, 233, 241, -8, 4, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupA.Teams.Add(greece);
            NationalTeam spain = new NationalTeam("Španija", "ESP", 2, 1, 2, 249, 257, -8, 4, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupA.Teams.Add(spain);
            
            Match australiaVsSpain = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                australia, spain, new MatchResult(92, 80));
            groupA.Matches.Add(australiaVsSpain);
            australia.Matches.Add(australiaVsSpain);
            spain.Matches.Add(australiaVsSpain);
            Match greeceVsCanada = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE,
                greece, canada, new MatchResult(79, 86));
            groupA.Matches.Add(greeceVsCanada);
            greece.Matches.Add(greeceVsCanada);
            canada.Matches.Add(greeceVsCanada);
            Match spainVsGreece = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE,
                spain, greece, new MatchResult(84, 77));
            groupA.Matches.Add(spainVsGreece);
            spain.Matches.Add(spainVsGreece);
            greece.Matches.Add(spainVsGreece);
            Match canadaVsAustralia = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                canada, australia, new MatchResult(93, 83));
            groupA.Matches.Add(canadaVsAustralia);
            canada.Matches.Add(canadaVsAustralia);
            australia.Matches.Add(canadaVsAustralia);
            Match australiaVsGreece = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                australia, greece, new MatchResult(71, 77));
            groupA.Matches.Add(australiaVsGreece);
            australia.Matches.Add(australiaVsGreece);
            greece.Matches.Add(australiaVsGreece);
            Match canadaVsSpain = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                canada, spain, new MatchResult(88, 85));
            groupA.Matches.Add(canadaVsSpain);
            canada.Matches.Add(canadaVsSpain);
            spain.Matches.Add(canadaVsSpain);

            GroupPhaseRepository.GroupPhase.Groups.Add(groupA);

            Group groupB = new Group("B", new List<NationalTeam>(), new List<Match>());

            NationalTeam brazil = new NationalTeam("Brazil", "BRA", 12, 1, 2, 241, 248, -7, 4, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupB.Teams.Add(brazil);
            NationalTeam france = new NationalTeam("Francuska", "FRA", 9, 2, 1, 243, 241, 2, 5, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupB.Teams.Add(france);
            NationalTeam germany = new NationalTeam("Nemačka", "GER", 3, 3, 0, 268, 221, 47, 6, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupB.Teams.Add(germany);
            NationalTeam japan = new NationalTeam("Japan", "JPN", 26, 0, 3, 251, 293, -42, 3, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupB.Teams.Add(japan);

            Match germanyVsJapan = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                germany, japan, new MatchResult(97, 77));
            groupB.Matches.Add(germanyVsJapan);
            germany.Matches.Add(germanyVsJapan);
            japan.Matches.Add(germanyVsJapan);
            Match franceVsBrazil = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                france, brazil, new MatchResult(78, 66));
            groupB.Matches.Add(franceVsBrazil);
            france.Matches.Add(franceVsBrazil);
            brazil.Matches.Add(franceVsBrazil);
            Match brazilVsGermany = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                brazil, germany, new MatchResult(73, 86));
            groupB.Matches.Add(brazilVsGermany);
            brazil.Matches.Add(brazilVsGermany);
            germany.Matches.Add(brazilVsGermany);
            Match japanVsFrance = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                japan, france, new MatchResult(90, 94));
            groupB.Matches.Add(japanVsFrance);
            japan.Matches.Add(japanVsFrance);
            france.Matches.Add(japanVsFrance);
            Match japanVsBrazil = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                japan, brazil, new MatchResult(84, 102));
            groupB.Matches.Add(japanVsBrazil);
            japan.Matches.Add(japanVsBrazil);
            brazil.Matches.Add(japanVsBrazil);
            Match franceVsGermany = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                france, germany, new MatchResult(71, 85));
            groupB.Matches.Add(franceVsGermany);
            france.Matches.Add(franceVsGermany);
            germany.Matches.Add(franceVsGermany);

            GroupPhaseRepository.GroupPhase.Groups.Add(groupB);

            Group groupC = new Group("C", new List<NationalTeam>(), new List<Match>());

            NationalTeam puertoRico = new NationalTeam("Portoriko", "PUR", 16, 0, 3, 228, 301, -73, 3, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupC.Teams.Add(puertoRico);
            NationalTeam serbia = new NationalTeam("Srbija", "SRB", 4, 2, 1, 287, 261, 26, 5, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupC.Teams.Add(serbia);
            NationalTeam unitedStatesOfAmerica = new NationalTeam("Sjedinjene Američke države", "USA", 1, 3, 
                0, 317, 253, 64, 6, 0, 0, StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupC.Teams.Add(unitedStatesOfAmerica);
            NationalTeam southSudan = new NationalTeam("Južni Sudan", "SSD", 34, 1, 2, 261, 278, -17, 4, 0, 0, 
                StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE, new List<Match>());
            groupC.Teams.Add(southSudan);

            Match southSudanVsPuertoRico = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                southSudan, puertoRico, new MatchResult(90, 79));
            groupC.Matches.Add(southSudanVsPuertoRico);
            southSudan.Matches.Add(southSudanVsPuertoRico);
            puertoRico.Matches.Add(southSudanVsPuertoRico);
            Match serbiaVsUnitedStatesOfAmerica = new Match(TournamentPhaseOfMatch.FIRST_ROUND_OF_GROUP_PHASE, 
                serbia, unitedStatesOfAmerica, new MatchResult(84, 110));
            groupC.Matches.Add(serbiaVsUnitedStatesOfAmerica);
            serbia.Matches.Add(serbiaVsUnitedStatesOfAmerica);
            unitedStatesOfAmerica.Matches.Add(serbiaVsUnitedStatesOfAmerica);
            Match puertoRicoVsSerbia = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                puertoRico, serbia, new MatchResult(66, 107));
            groupC.Matches.Add(puertoRicoVsSerbia);
            puertoRico.Matches.Add(puertoRicoVsSerbia);
            serbia.Matches.Add(puertoRicoVsSerbia);
            Match unitedStatesOfAmericaVsSouthSudan = new Match(TournamentPhaseOfMatch.SECOND_ROUND_OF_GROUP_PHASE, 
                unitedStatesOfAmerica, southSudan, new MatchResult(103, 86));
            groupC.Matches.Add(unitedStatesOfAmericaVsSouthSudan);
            unitedStatesOfAmerica.Matches.Add(unitedStatesOfAmericaVsSouthSudan);
            southSudan.Matches.Add(unitedStatesOfAmericaVsSouthSudan);
            Match serbiaVsSouthSudan = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                serbia, southSudan, new MatchResult(96, 85));
            groupC.Matches.Add(serbiaVsSouthSudan);
            serbia.Matches.Add(serbiaVsSouthSudan);
            southSudan.Matches.Add(serbiaVsSouthSudan);
            Match puertoRicoVsUnitedStatesOfAmerica = new Match(TournamentPhaseOfMatch.THIRD_ROUND_OF_GROUP_PHASE, 
                puertoRico, unitedStatesOfAmerica, new MatchResult(83, 104));
            groupC.Matches.Add(puertoRicoVsUnitedStatesOfAmerica);
            puertoRico.Matches.Add(puertoRicoVsUnitedStatesOfAmerica);
            unitedStatesOfAmerica.Matches.Add(puertoRicoVsUnitedStatesOfAmerica);

            GroupPhaseRepository.GroupPhase.Groups.Add(groupC);

            groupPhaseService.RankNationalTeamsInGroup(groupA);
            groupPhaseService.RankNationalTeamsInGroup(groupB);
            groupPhaseService.RankNationalTeamsInGroup(groupC);

            Assert.AreEqual("Kanada", groupA.Teams[0].Name);
            Assert.AreEqual(1, groupA.Teams[0].GroupRanking);
            Assert.AreEqual("Australija", groupA.Teams[1].Name);
            Assert.AreEqual(2, groupA.Teams[1].GroupRanking);
            Assert.AreEqual("Grčka", groupA.Teams[2].Name);
            Assert.AreEqual(3, groupA.Teams[2].GroupRanking);
            Assert.AreEqual("Španija", groupA.Teams[3].Name);
            Assert.AreEqual(4, groupA.Teams[3].GroupRanking);

            Assert.AreEqual("Nemačka", groupB.Teams[0].Name);
            Assert.AreEqual(1, groupB.Teams[0].GroupRanking);
            Assert.AreEqual("Francuska", groupB.Teams[1].Name);
            Assert.AreEqual(2, groupB.Teams[1].GroupRanking);
            Assert.AreEqual("Brazil", groupB.Teams[2].Name);
            Assert.AreEqual(3, groupB.Teams[2].GroupRanking);
            Assert.AreEqual("Japan", groupB.Teams[3].Name);
            Assert.AreEqual(4, groupB.Teams[3].GroupRanking);

            Assert.AreEqual("Sjedinjene Američke Države", groupC.Teams[0].Name);
            Assert.AreEqual(1, groupC.Teams[0].GroupRanking);
            Assert.AreEqual("Srbija", groupC.Teams[1].Name);
            Assert.AreEqual(2, groupC.Teams[1].GroupRanking);
            Assert.AreEqual("Južni Sudan", groupC.Teams[2].Name);
            Assert.AreEqual(3, groupC.Teams[2].GroupRanking);
            Assert.AreEqual("Portoriko", groupC.Teams[3].Name);
            Assert.AreEqual(4, groupC.Teams[3].GroupRanking);
        }
    }
}
