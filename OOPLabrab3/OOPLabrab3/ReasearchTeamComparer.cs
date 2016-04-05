using System.Collections.Generic;

namespace OOPLabrab3
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            var xCount = x.PubList.Count;
            var yCount = y.PubList.Count;

            if (xCount > yCount)
                return -1;
            if (xCount < yCount)
                return 1;
            else return 0;
        }
    }
}
