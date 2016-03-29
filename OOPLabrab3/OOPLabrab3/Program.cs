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
