using System.Collections.Generic;

namespace OOPLabrab32
{
	class ResearchTeamComparer : IComparer<Paper>
	{
		public int Compare(Paper a, Paper b)
		{
			var aName = a.Autor.GetName();;
			var bName = b.Autor.GetName();

			return aName.CompareTo(bName);
		}
	}
}

	