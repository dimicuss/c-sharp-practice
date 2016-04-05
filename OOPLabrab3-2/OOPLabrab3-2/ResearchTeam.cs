using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace OOPLabrab32
{
	class ResearchTeam : Team, INameAndCopy
	{
		private string _resTheme;
		private TimeFrame _resTime;
		private List<Person> _perList = new List<Person>();
		private List<Paper> _pubList = new List<Paper>();
		public List<Paper> PubList
		{
			get { return _pubList; }
			set { _pubList = value; }
		}
		public List<Person> PerList
		{
			get { return _perList; }
			set { _perList = value; }
		}
		public Team baseTeam
		{
			get { return new Team(_orgName, _regNumber); }
			set
			{
				_orgName = value.OrgName;
				_regNumber = value.RegNumber;
			}
		}
		public TimeFrame ResTime
		{
			get { return _resTime; }
		}


		public Paper LatestPub
		{
			get {
				Func<Paper, Paper, Paper> fn = (first, second) => {
					var value = first.PublicationDate.CompareTo (second.PublicationDate);
					if (value >= 0)
						return first;
					else
						return second;
				};

				if (_pubList.Count > 0)
					return _pubList.Aggregate (fn);
				else
					return null;
			}
		}


		public void AddPapers(params Paper[] papers)
		{
			for (int i = 0; i < papers.Length; i++)
				_pubList.Add(papers[i]);
		}


		public void AddMembers(params Person[] persons)
		{
			for (int i = 0; i < persons.Length; i++)
				_perList.Add(persons[i]);
		}


		public override string ToString()
		{
			var str = _resTheme + "," + _orgName + "," + _regNumber + "," + _resTime + ";\n";

			var PublicationList = _pubList.ToArray();
			var PersonList = _perList.ToArray();

			for (var i = 0; i < PersonList.Length; i++)
				str = str + PersonList[i].ToString();

			for (var i = 0; i < PublicationList.Length; i++)
				str = str + PublicationList[i].ToString();

			return str + "\n";
		}


		public virtual string ToShortString()
		{
			return _orgName + ',' + _regNumber + ',' + _resTheme + ',' + _resTime + ';';
		}


		public override object DeepCopy()
		{
			var obj = new ResearchTeam(_orgName, _resTheme, _regNumber, _resTime);

			List<Paper> clonedPubList = new List<Paper>();
			List<Person> clonedPerList = new List<Person>();


			for (int i = 0; i < _pubList.Count; i++)
			{
				clonedPubList.Add((Paper) _pubList[i].DeepCopy());
			}

			for (int i = 0; i < _perList.Count; i++)
			{
				clonedPerList.Add((Person) _perList[i].DeepCopy());
			}


			obj.PubList = clonedPubList;
			obj.PerList = clonedPerList;

			return obj;
		}


		public void SortByDate() 
		{	var comparer = new Paper();
			_pubList.Sort( (a, b) =>  comparer.Compare(a, b) );
		}


		public void SortByTitle()
		{
			_pubList.Sort( (a, b) => a.CompareTo(b) );
		}


		public void SortByAutorName()
		{
			_pubList.Sort( new ResearchTeamComparer() );
		}

	
		public ResearchTeam(string orgName, string resTheme, int regNmber, TimeFrame resTime)
		{
			_orgName = orgName;
			_resTheme = resTheme;
			_regNumber = regNmber;
			_resTime = resTime;
		}


		public ResearchTeam()
		{
			_orgName = "";
			_resTheme = "";
			_regNumber = 0;
			_resTime = 0;
		}

	}
}