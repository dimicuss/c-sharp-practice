using System.Collections.Generic;
using System.Linq;
using System;

namespace OOPLabrab32
{
	class ResearchTeamCollection<Tkey>
	{
		Dictionary<Tkey, ResearchTeam> _teamList = new Dictionary<Tkey, ResearchTeam>();
		KeySelector<Tkey> GetKey;


		public void AddDefaults(int n) 
		{
			var rnd = new Random();
			for (int i = 0; i < n; i++){
				var resTeam = new ResearchTeam("OrgName " + i, "ResTeam " + rnd.Next(), rnd.Next(), 
					(i % 2) == 0 ? TimeFrame.Long : TimeFrame.TwoYears );
				_teamList.Add ( GetKey( resTeam ), resTeam );
			}
		}


		public void AddResearchTeams(params ResearchTeam[] teams)
		{
			for (int i = 0; i < teams.Length; i++) {
				_teamList.Add(  GetKey( teams[i] ), teams [i]  );
			}
		}


		public override string ToString()
		{
			var str = "";
			var keys = _teamList.Keys;

			for (int i = 0; i < keys.Count; i++)
				str = str + _teamList[ keys.ElementAt(i) ].ToString();
	
			return str;
		}


		public string ToShortString()
		{
			var str = "";
			var keys = _teamList.Keys;

			for (int i = 0; i < keys.Count; i++)
				str = str + _teamList[ keys.ElementAt(i) ].ToShortString() + ","
					+ _teamList[ keys.ElementAt(i) ].PerList.Count + ","
					+ _teamList[ keys.ElementAt(i) ].PubList.Count + ";";

			return str;
		}


		public DateTime MaxDateTime
		{ 
			get 
			{ 
				return _teamList.Max (elm => 
				{
					return elm.Value.PubList.Max( entireElm => entireElm.PublicationDate );
				}); 
			}
		}


		public IEnumerable<KeyValuePair<Tkey,ResearchTeam>>TimeFrameGroup (TimeFrame value)
		{
			return _teamList.Where( (elm) => elm.Value.ResTime == value );
		}


		public IEnumerable<  IGrouping<TimeFrame, KeyValuePair<Tkey,ResearchTeam>>  > Group
		{ 
			get {
				var grouped = _teamList
					.GroupBy (elm => elm.Value.ResTime,
						elm => elm);
				return grouped;
			}
		}


		public ResearchTeamCollection(KeySelector<Tkey> fn) {
			GetKey = fn;
		}
	}
}