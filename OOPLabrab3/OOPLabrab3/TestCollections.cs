using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
  
    class TestCollections
    {
        List<Team> _teamList = new List<Team>();
        List<string> _stringList = new List<string>();
        Dictionary<Team, ResearchTeam> _dictTeamRes = new Dictionary<Team, ResearchTeam>();
        Dictionary<string, ResearchTeam> _dictStrRes = new Dictionary<string, ResearchTeam>();

        public static ResearchTeam MakeResTeam(int i)
        {
            return new ResearchTeam("Org Name " + i, "ResTheme " + i, i, TimeFrame.Long);
        }


        public string TestTime(Func<dynamic, string> fn)
        {
            var t1 = DateTime.Now;

            var result = fn.Invoke((new {  TeamList = _teamList,
                                           StringList = _stringList,
                                           DictTeamRes = _dictTeamRes,
                                           DictStrRes = _dictStrRes    }));

            var t2 = DateTime.Now;

            return string.Format("Time: {0}\nResult:\n{1}", t2 - t1, result);
        }


        public TestCollections(int i)
        {
            for(int j = 0; j < i; j++)
            {
                var team = MakeResTeam(j);  
                _teamList.Add(team.baseTeam);
                _stringList.Add(team.OrgName);
                _dictTeamRes.Add(team.baseTeam, team);
                _dictStrRes.Add(team.OrgName, team);
            }
        }
    }
}
