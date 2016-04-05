using System.Collections.Generic;
using System.Linq;
using System;

namespace OOPLabrab32
{
	class ResearchTeamCollection<Tkey> where Tkey : new()
	{
		public Dictionary<Tkey, ResearchTeam> _teamList = new Dictionary<Tkey, ResearchTeam>();
		KeySelector<Tkey> GetKey;


		public void AddDefaults(int n) 
		{
			for (int i = 0; i < n; i++) {
				var resTeam = new ResearchTeam();
				var charArray = i.ToString ().ToCharArray ();
				var key = (Tkey) Activator.CreateInstance(typeof(Tkey), charArray);

				_teamList.Add (key, resTeam);
			}
		}

		public void AddResearchTeams(params ResearchTeam[] teams)
		{
			for (int i = 0; i < teams.Length; i++) {
				var charArray = teams[i].Name.ToCharArray();
				var key = (Tkey) Activator.CreateInstance(typeof(Tkey), charArray);
				_teamList.Add (key, teams [i]);
			}
		}
//
//		public override string ToString()
//		{
//			var str = "";
//
//			for (int i = 0; i < _teamList.Count; i++)
//				str = str + _teamList[i].ToString();
//
//			return str;
//		}
//
//		public string ToShortString()
//		{
//			var str = "";
//
//			for (int i = 0; i < _teamList.Count; i++)
//				str = str + _teamList[i].ToShortString() + ","
//					+ _teamList[i].PerList.Count + ","
//					+ _teamList[i].PubList.Count + ";";
//
//			return str;
//		}
//			
//
//
//		public List<ResearchTeam> NGroup(int value)
//		{
//			var grouped = _teamList
//				.GroupBy(elm => elm.Value,
//					elm => elm,
//					(key, elms) => new { Key = key, Elms = elms.ToList() });
//
//			List<ResearchTeam> list = new List<ResearchTeam>();
//
//			foreach( var obj in grouped )
//			{
//				if (obj.Key == value)
//					list = obj.Elms;
//			}

			//return list;
		//}

		ResearchTeamCollection(KeySelector<Tkey> fn) {
			GetKey = fn;
		}
	}
}