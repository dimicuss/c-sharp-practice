﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace OOPLabrab32
{
	enum TimeFrame : int { Year = 1, TwoYears, Long };

	delegate TKey KeySelector<TKey>( ResearchTeam rt);


	class MainClass
	{
		static void Main(string[] args)
		{
			var rnd = new Random();

			var str = new String ("sdd".ToCharArray());
			Console.WriteLine (str);

//			Console.WriteLine("1. --------------------------\n");
//
//			var teamCollection = new ResearchTeamCollection<Team>();
//
//			for (int i = 0; i < 5; i++)
//			{
//				var resTeam = new ResearchTeam( "OrgName " + rnd.Next(), 
//					"ResTheme " + i, 
//					rnd.Next(1, 20), 
//					i %  2 == 0 ? TimeFrame.Long : TimeFrame.TwoYears );
//				var perList = new List<Person>();
//				var pubList = new List<Paper>();
//
//				for (int j = 0; j < rnd.Next(10, 15); j++)
//				{
//					var max = 1000000;
//					var rndNumber = rnd.Next(1, max);
//					var format = new String ( '0', max.ToString().Length );
//					perList.Add(new Person("Name " + rndNumber.ToString(format), 25));
//				}
//
//				for (int j = 0; j < rnd.Next(10, 20); j++)
//				{
//					var max = 1000000;
//					var rndNumber = rnd.Next(1, max);
//					var format = new String ( '0', max.ToString().Length );
//					var date = new DateTime (rnd.Next (1990, 2016), rnd.Next (1, 13), rnd.Next (1, 28));
//						
//					pubList.Add(  new Paper( "New Title " + rndNumber.ToString(format), perList[ rnd.Next(0, 10) ], date )  );
//				}
//
//				resTeam.PubList = pubList;
//				resTeam.PerList = perList;
//				teamCollection.AddResearchTeams(resTeam);
//			}

			//Console.WriteLine(teamCollection);
			//Console.WriteLine("\n\n\n");






//			Console.WriteLine("3. -------------------------\n");
//
//			Console.WriteLine(teamCollection.GetMinRegNumber); 
//			Console.WriteLine();
//
//			foreach(ResearchTeam team in teamCollection.GetTwoYears)
//			{
//				Console.WriteLine(team.ToShortString());
//			}
//
//			Console.WriteLine();
//
//			var counts = teamCollection._teamList.Aggregate(new List<int>(), (acc, elm) =>
//				{
//					if (!acc.Contains(elm.PerList.Count))
//					{
//						acc.Add(elm.PerList.Count);
//						return acc;
//					}
//					return acc;
//				});
//
//			foreach (var count in counts)
//			{
//				Console.WriteLine("Count = " + count + "\n");
//				teamCollection.NGroup(count).ForEach((elm) => Console.WriteLine(elm));
//			}
//
//			Console.WriteLine();
//
//
//
//			Console.WriteLine("4. --------------------------");
//
//			Func<dynamic, string, dynamic, string> fn = ( obj, str, contains ) =>
//			{
//				var collection = obj[str];
//
//				var indexCenter = (int)Math.Floor( (decimal)(obj[str].Count / 2) );
//				var f = Enumerable.First( collection ) + " first in " + str + "\n";
//				var l = Enumerable.Last( collection ) + " last in" + str + "\n";
//				var c = Enumerable.ElementAt( collection, indexCenter ) + " center in " + str + "\n";
//
//				string n;
//
//				var isDict = typeof( IDictionary ).IsAssignableFrom( collection.GetType() );
//
//				if (isDict)
//					n = collection.ContainsKey( contains ).ToString() + "\n\n";
//				else n = collection.Contains( contains ).ToString() + "\n\n";
//
//
//				return f + l + c + n;
//			};
//
//			var testCollection = new TestCollections( 10 );
//
//			var first = testCollection.TestTime( fn, "TeamList", new Team() );
//			var second = testCollection.TestTime( fn, "StringList", "sds" );
//			var third = testCollection.TestTime( fn, "DictTeamRes", new Team() );
//			var forth = testCollection.TestTime( fn, "DictStrRes", "sdd" );
//
//
//
//			Console.WriteLine( first );
//			Console.WriteLine( second );
//			Console.WriteLine( third );
//			Console.WriteLine( forth );
//
//			Console.Read();

		}
	}
}
