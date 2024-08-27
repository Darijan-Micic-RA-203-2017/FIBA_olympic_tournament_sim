namespace FIBA_OT_sim.Model
{
    public class NationalTeam
    {
        private string name;
        private string abbreviation;
        private int fibaRanking;
        private StatusOfNationalTeam status;

        public NationalTeam()
        {
            name = "";
            abbreviation = "";
            fibaRanking = 0;
            status = StatusOfNationalTeam.COMPETING_IN_GROUP_PHASE;
        }

        public NationalTeam(string name, string abbreviation, int fibaRanking, StatusOfNationalTeam status)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
            this.status = status;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
            status = nationalTeam.status;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }

        public int FIBARanking
        {
            get { return fibaRanking; }
            set { fibaRanking = value; }
        }

        public StatusOfNationalTeam Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
