using System.Collections.Generic;
using System.Linq;
using System;

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

        public List<ResearchTeam> SortByRegNumber()
        {
            var clonedList = DeepCopy();
            var sortedList = new List<ResearchTeam>();
            ResearchTeam most;

            while (clonedList.Count > 0)
            {
                most = clonedList.Aggregate( (x, y) => x.CompareTo(y) > 0 ? x : y );
                sortedList.Add(most);
                clonedList.Remove(most);
            }

            return sortedList;
        }

        public List<ResearchTeam> SortByOrgName()
        {
            var clonedList = DeepCopy();
            var sortedList = new List<ResearchTeam>();
            var Comparer = new ResearchTeam();
            ResearchTeam most;

            while (clonedList.Count > 0)
            {
                most = clonedList.Aggregate( (x, y) => Comparer.Compare(x, y) > 0 ? x : y );
                sortedList.Add(most);
                clonedList.Remove(most);
            }

            return sortedList;
        }

        public List<ResearchTeam> SortByPubCount()
        {
            var clonedList = DeepCopy();
            var comparer = new ResearchTeamComparer();

            clonedList.Sort(comparer);

            return clonedList;
        }

        public List<ResearchTeam> NGroup(int value)
        {
            var grouped = _teamList
                .GroupBy( elm => elm.PerList.Count,
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
