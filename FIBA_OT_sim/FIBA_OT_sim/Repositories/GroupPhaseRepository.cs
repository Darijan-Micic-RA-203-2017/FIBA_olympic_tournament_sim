using FIBA_OT_sim.Model;
using System.Text.Json;

namespace FIBA_OT_sim.Repositories
{
    public class GroupPhaseRepository
    {
        private GroupPhase groupPhase;

        public GroupPhaseRepository()
        {
            groupPhase = new GroupPhase();
        }

        public GroupPhase GroupPhase
        {
            get { return groupPhase; }
            set { groupPhase = value; }
        }

        /// <summary>
        /// <para>
        /// Loads groups and national teams allocated to each group from file on specified <paramref name="filePath" />
        /// and stores them inside a <see cref="Model.GroupPhase" /> object.
        /// </para>
        /// <para>
        /// REFERENCES:<br />
        /// <see href="https://learn.microsoft.com/en-us/answers/questions/699941/read-and-process-json-file-with-c" /><br />
        /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/deserialization" /><br />
        /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom" />
        /// </para>
        /// </summary>
        /// <param name="filePath">Path of JSON file containing groups and national teams.</param>
        public void LoadGroupPhaseFromFileSystem(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement rootElement = document.RootElement;

                foreach (JsonProperty groupProperty in rootElement.EnumerateObject())
                {
                    Group group = new Group(groupProperty.Name, new List<NationalTeam>(), new List<Match>());

                    foreach (JsonElement nationalTeamElement in groupProperty.Value.EnumerateArray())
                    {
                        string? name = nationalTeamElement.GetProperty("Team").GetString();
                        if (name == null)
                        {
                            groupPhase = new GroupPhase();

                            return;
                        }
                        string? abbreviation = nationalTeamElement.GetProperty("ISOCode").GetString();
                        if (abbreviation == null)
                        {
                            groupPhase = new GroupPhase();

                            return;
                        }
                        int fibaRanking = nationalTeamElement.GetProperty("FIBARanking").GetInt32();
                        int winsInGroup = 0;
                        int lossesInGroup = 0;
                        int scoredPointsInGroup = 0;
                        int allowedPointsInGroup = 0;
                        int pointsDifferentialInGroup = 0;
                        int pointsInGroup = 0;
                        int groupRanking = 0;
                        int groupPhaseRanking = 0;
                        StatusOfNationalTeam status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;

                        NationalTeam nationalTeam = new NationalTeam(name, abbreviation, fibaRanking, 
                            winsInGroup, lossesInGroup, scoredPointsInGroup, allowedPointsInGroup, 
                            pointsDifferentialInGroup, pointsInGroup, groupRanking, groupPhaseRanking, status, 
                            new List<Match>());
                        group.Teams.Add(nationalTeam);
                    }

                    groupPhase.Groups.Add(group);
                }
            }
        }
    }
}
