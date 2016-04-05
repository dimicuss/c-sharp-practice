using System.Collections.Generic;
using System.Linq;

namespace OOPLabrab3
{
    class ResearchTeamCollection
    {
        public List<ResearchTeam> _teamList = new List<ResearchTeam>();
        public int GetMinRegNumber
        {
            get { return _teamList.Count != 0 ? _teamList.Min((elm) => elm.RegNumber) : 0; }
        }
        public IEnumerable<ResearchTeam> GetTwoYears
        {
            get { return _teamList.Where( (elm) => elm.ResTime == TimeFrame.TwoYears ); }
        }


        public void AddDefaults(int n)
        {
            for (int i = 0; i < n; i++)
                _teamList.Add(new ResearchTeam());

        }

        public void AddResearchTeams(params ResearchTeam[] teams)
        {

            for (int i = 0; i < teams.Length; i++)
                _teamList.Add(teams[i]);

        }

        public override string ToString()
        {
            var str = "";

            for (int i = 0; i < _teamList.Count; i++)
                str = str + _teamList[i].ToString();

            return str;
        }

        public string ToShortString()
        {
            var str = "";

            for (int i = 0; i < _teamList.Count; i++)
                str = str + _teamList[i].ToShortString() + ","
                          + _teamList[i].PerList.Count + ","
                          + _teamList[i].PubList.Count + ";";

            return str;
        }

        public List<ResearchTeam> DeepCopy()
        {
            List<ResearchTeam> clonedList = new List<ResearchTeam>();

            for (int i = 0; i < _teamList.Count; i++)
            {
                clonedList.Add((ResearchTeam)_teamList[i].DeepCopy());
            }

            return clonedList;
        }

        public void SortByRegNumber()
        {
            _teamList.Sort( (b, a) => a.CompareTo(b) );
        }

        public void SortByOrgName()
        {
            var Comparer = new ResearchTeam();
            _teamList.Sort( (a, b) => Comparer.Compare(a, b) );
        }

        public void SortByPubCount()
        {
            var comparer = new ResearchTeamComparer();
            _teamList.Sort(comparer);
        }

        public List<ResearchTeam> NGroup(int value)
        {
            var grouped = _teamList
                .GroupBy(elm => elm.PerList.Count,
                          elm => elm,
                          (key, elms) => new { Key = key, Elms = elms.ToList() });

            List<ResearchTeam> list = new List<ResearchTeam>();

            foreach( var obj in grouped )
            {
                if (obj.Key == value)
                    list = obj.Elms;
            }

            return list;
        }
    }
}
