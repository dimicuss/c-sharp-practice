using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace OOPLabrab3
{
    enum TimeFrame : int { Year = 1, TwoYears, Long };

 
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();



            Console.WriteLine("1. --------------------------\n");

            var teamCollection = new ResearchTeamCollection();
            var teamList = new List<ResearchTeam>();

            for (int i = 0; i < 5; i++)
            {
                var resTeam = new ResearchTeam( "OrgName " + rnd.Next(), 
                                                "ResTheme " + i, 
                                                rnd.Next(1, 20), 
                                                i %  2 == 0 ? TimeFrame.Long : TimeFrame.TwoYears );
                var perList = new List<Person>();
                var pubList = new List<Paper>();

                for (int j = 0; j < rnd.Next(10, 15); j++)
                {
                    perList.Add(new Person("Name " + rnd.Next(), 25));
                }

                for (int j = 0; j < rnd.Next(10, 20); j++)
                {
                    pubList.Add(new Paper("New Tiele " + rnd.Next(), perList[ rnd.Next(0, 10) ], DateTime.Now));
                }

                resTeam.PubList = pubList;
                resTeam.PerList = perList;
                teamCollection.AddResearchTeams(resTeam);
            }

            Console.WriteLine(teamCollection);
            Console.WriteLine("\n\n\n");




            Console.WriteLine("2. --------------------------\n");

            teamCollection.SortByRegNumber();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n\n");

            teamCollection.SortByOrgName();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n\n");

            teamCollection.SortByPubCount();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n");




            Console.WriteLine("3. -------------------------\n");

            Console.WriteLine(teamCollection.GetMinRegNumber); 
            Console.WriteLine();

            foreach(ResearchTeam team in teamCollection.GetTwoYears)
            {
                Console.WriteLine(team.ToShortString());
            }

            Console.WriteLine();

            var counts = teamCollection._teamList.Aggregate(new List<int>(), (acc, elm) =>
            {
                if (!acc.Contains(elm.PerList.Count))
                {
                    acc.Add(elm.PerList.Count);
                    return acc;
                }
                return acc;
            });

            foreach (var count in counts)
            {
                Console.WriteLine("Count = " + count + "\n");
                teamCollection.NGroup(count).ForEach((elm) => Console.WriteLine(elm));
            }

            Console.WriteLine();



            Console.WriteLine("4. --------------------------");

            Func<dynamic, string, dynamic, string> fn = ( obj, str, contains ) =>
            {
                var collection = obj[str];

                var indexCenter = (int)Math.Floor( (decimal)(obj[str].Count / 2) );
                var f = Enumerable.First( collection ) + " first in " + str + "\n";
                var l = Enumerable.Last( collection ) + " last in" + str + "\n";
                var c = Enumerable.ElementAt( collection, indexCenter ) + " center in " + str + "\n";

                string n;

                if (collection is IDictionary)
                    n = collection.ContainsKey( contains ).ToString() + "\n\n";
                else n = collection.Contains( contains ).ToString() + "\n\n";


                    return f + l + c + n;
            };

            var testCollection = new TestCollections( 10 );

            var first = testCollection.TestTime( fn, "TeamList", new Team() );
            var second = testCollection.TestTime( fn, "StringList", "sds" );
            var third = testCollection.TestTime( fn, "DictTeamRes", new Team() );
            var forth = testCollection.TestTime( fn, "DictStrRes", "sdd" );



            Console.WriteLine( first );
            Console.WriteLine( second );
            Console.WriteLine( third );
            Console.WriteLine( forth );

            Console.Read();

        }
    }
}
