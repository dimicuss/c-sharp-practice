using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
    class Paper
    {
        public string Title;
        public Person Autor;
        public DateTime PublicationDate;


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

        public override string ToString()
        {
            return Title + ',' + Autor.GetName() + ',' + PublicationDate.ToString() + ";\n";
        }

        public virtual object DeepCopy()
        {
            return new Paper(Title, (Person)Autor.DeepCopy(), PublicationDate);
        }
    }
}
