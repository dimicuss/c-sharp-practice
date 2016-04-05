using System;
using System.Collections.Generic;
using Microsoft.CSharp;

namespace OOPLabrab32
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


		public string TestTime(Func<dynamic, string, dynamic, string> fn, string str, dynamic contains)
		{
			var t1 = DateTime.Now;

			var dict = new Dictionary<string, object>();
			dict.Add( "TeamList", _teamList );
			dict.Add( "StringList", _stringList );
			dict.Add( "DictTeamRes", _dictTeamRes );
			dict.Add( "DictStrRes", _dictStrRes );

			var result = fn.Invoke( dict, str, contains );

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
