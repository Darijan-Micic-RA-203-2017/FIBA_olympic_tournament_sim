namespace FIBA_OT_sim.Model
{
    public class NationalTeam
    {
        private string name;
        private string abbreviation;
        private int fibaRanking;

        public NationalTeam()
        {
            name = "";
            abbreviation = "";
            fibaRanking = 0;
        }

        public NationalTeam(string name, string abbreviation, int fibaRanking)
        {
            this.name = name;
            this.abbreviation = abbreviation;
            this.fibaRanking = fibaRanking;
        }

        public NationalTeam(NationalTeam nationalTeam)
        {
            name = nationalTeam.name;
            abbreviation = nationalTeam.abbreviation;
            fibaRanking = nationalTeam.fibaRanking;
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
    }
}
