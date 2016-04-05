using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab32
{
	class Paper : IComparable, IComparer<Paper>
	{
		public string Title;
		public Person Autor;
		public DateTime PublicationDate;


		public override string ToString()
		{
			return Title + ',' + Autor.GetName() + ',' + PublicationDate.ToString() + ";\n";
		}

		public virtual object DeepCopy()
		{
			return new Paper(Title, (Person)Autor.DeepCopy(), PublicationDate);
		}


		public int Compare(Paper a, Paper b)
		{
			var aTicks = a.PublicationDate.Ticks;
			var bTicks = b.PublicationDate.Ticks;

			if (aTicks > bTicks)
				return 1;
			else if (a == b)
				return 0;
			else return -1;
		}

		public int CompareTo(object obj)
		{
			var typedObj = obj as Paper;
			return Title.CompareTo(typedObj.Title);
		}

		public Paper(string title, Person autor, DateTime publicationDate)
		{
			Title = title;
			Autor = autor;
			PublicationDate = publicationDate;
		}

		public Paper()
		{
			Title = "";
			Autor = new Person();
			PublicationDate = new DateTime();
		}
	}
}

