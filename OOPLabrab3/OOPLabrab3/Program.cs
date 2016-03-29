using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
    enum TimeFrame : int { Year = 1, TwoYears, Long };

 
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();


            //1. --------------------------

            var teamCollection = new ResearchTeamCollection();
            var teamList = new List<ResearchTeam>();

            for (int i = 0; i < 10; i++)
            {
                var resTeam = new ResearchTeam( "OrgName " + rnd.Next(), 
                                                "ResTheme " + i, 
                                                rnd.Next(1, 20), 
                                                i %  2 == 0 ? TimeFrame.Long : TimeFrame.TwoYears );
                var perList = new List<Person>();
                var pubList = new List<Paper>();

                for (int j = 0; j < 10; j++)
                {
                    perList.Add(new Person("Name " + rnd.Next(), 25));
                }

                for (int j = 0; j < rnd.Next(10, 20); j++)
                {
                    pubList.Add(new Paper("New Tiele " + rnd.Next(), perList[0], DateTime.Now));
                }

                resTeam.PubList = pubList;
                resTeam.PerList = perList;
                teamCollection.AddResearchTeams(resTeam);
            }

            Console.WriteLine(teamCollection);
            Console.WriteLine("\n\n\n");


            //2. --------------------------

            teamCollection.SortByRegNumber();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n\n");

            teamCollection.SortByOrgName();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n\n");

            teamCollection.SortByPubCount();
            Console.WriteLine(teamCollection);

            Console.WriteLine("\n\n");


            //3. --------------------------

            Console.WriteLine(teamCollection.GetMinRegNumber);
            Console.WriteLine();

            foreach(ResearchTeam team in teamCollection.GetTwoYears)
            {
                Console.WriteLine(team.ToShortString());
            }

            Console.WriteLine();

            

            var testCollection = new TestCollections(10);
            var first = testCollection.TestTime((obj) =>
            {
                var indexCenter = (int)Math.Floor( (decimal)(obj.TeamList.Count / 2) );
                var f = Enumerable.First(obj.TeamList).ToString() + " first in TeamList\n";
                var l = Enumerable.Last(obj.TeamList).ToString() + " last in TeamList\n";
                var c = obj.TeamList[indexCenter].ToString() + " center in TeamList\n";
                var n = obj.TeamList.Contains(new ResearchTeam()) + " contains in TeamList\n\n";

                return f + l + c + n;
            });

            var second = testCollection.TestTime((obj) =>
            {
                var indexCenter = (int)Math.Floor( (decimal)(obj.StringList.Count / 2) );
                var f = Enumerable.First( obj.StringList ).ToString() + " first in StringList\n";
                var l = Enumerable.Last( obj.StringList ).ToString() + " last in StringList\n";
                var c = obj.StringList[ indexCenter ].ToString() + " center in StringList\n";
                var n = obj.StringList.Contains("") + " contains in StringList\n\n";

                return f + l + c + n;
            });





            Console.WriteLine(first);
            Console.WriteLine(second);

            Console.Read();
        }
    }
}
