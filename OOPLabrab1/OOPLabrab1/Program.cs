using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab1
{
    enum TimeFrame : int {Year = 1, TwoYears, Long};



    class Person
    {
        private string Name;
        private int Age;


        public string getName()
        {
            return Name;
        }

        public int getAge()
        {
            return Age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Person()
        {
            Name = "";
            Age = 0;
        }

    }



    class Paper
    {
        public string Title;
        public Person Autor;
        public DateTime PublicationDate;


        public Paper(string title, Person autor, DateTime publicatioDate)
        {
            Title = title;
            Autor = autor;
            PublicationDate = publicatioDate;
        }

        public Paper()
        {
            Title = "";
            Autor = new Person();
            PublicationDate = new DateTime();
        }

        public override string ToString()
        {
            return Title + " " + Autor.getName() + " " + PublicationDate.ToString();
        }
    }



    class ResearchTeam {
        string ResearchTitle;
        string OrganisationName;
        int RegNumber;
        TimeFrame ResearchTime;
        Paper[] PublicationList;

        
        public string getResTitle
        {
            get {

                return ResearchTitle;
            }
            set
            {

                ResearchTitle = value;
            }
        }

        public string getOrgName
        {
            get {
                return OrganisationName;
            }
            set
            {
                OrganisationName = value;
            }
        }

        public int getRegNumber
        {
            get {
                return RegNumber;
            }
            set
            {
                RegNumber = value;
            }
        }

        public TimeFrame getTimeFrame
        {
            get {
                return ResearchTime;
            }
            set
            {
                ResearchTime = value;
            }

        }

        public Paper[] getPubList
        {
            get {
                return PublicationList;
            }
            set
            {
                PublicationList = value;
            }
        }

        public Paper latePub
        {
            get
            {
                var a = PublicationList[0];

                if (PublicationList.Length > 0)
                {
                    for (var i = 1; i < PublicationList.Length - 1; i++)
                    { 
                        var b = PublicationList[i];
                        if (a.PublicationDate.CompareTo(b.PublicationDate) > 0)
                            a = PublicationList[i];
                    }
                }
                return a;
            }
        }

        public bool this[TimeFrame tf]
        {
            get
            {
                return tf == ResearchTime;
            }
        }



        public void AddPapers(Paper paper)
        {
            var list = PublicationList.ToList();
            list.Add(paper);
            PublicationList = list.ToArray();
        }

        public override string ToString()
        {
            var str = ResearchTitle + " " + OrganisationName + " " + RegNumber + " " + ResearchTime + " ";

            for(var i=0; i < PublicationList.Length; i++)
            {
                str = str + PublicationList[i].ToString();
            }

            return str;
        }

        public virtual string ToShortString()
        {
            return ResearchTitle + " " + OrganisationName + " " + RegNumber + " " + ResearchTime;
        }

        public ResearchTeam(string resTitle, string orgName, int regNumber, TimeFrame resTime, Paper[] pubList)
        {
            ResearchTitle = resTitle;
            OrganisationName = orgName;
            RegNumber = regNumber;
            ResearchTime = resTime;
            PublicationList = pubList;
        }

        public ResearchTeam()
        {
            ResearchTitle = "";
            OrganisationName = "";
            RegNumber = 0;
            ResearchTime = 0;
            PublicationList = new Paper[0];
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Paper[] pubList = new Paper[10];

            for(var i = 0; i < pubList.Length; i++)
            {   
                pubList[i] = new Paper("How to degenerate your brain", new Person("dimicuss", 19), new DateTime(2, 2, 3));
            }

            ResearchTeam resTeam = new ResearchTeam("Brain degeneration", "Dimciuss's org", 1996, TimeFrame.Year, pubList);

            Console.WriteLine(resTeam.ToShortString());
            Console.WriteLine(resTeam[TimeFrame.TwoYears]);

            resTeam.getOrgName = "new Orgname";
            resTeam.getResTitle = "new title";
            resTeam.getRegNumber = 1996;
            resTeam.getTimeFrame = TimeFrame.Year;


            for (var i = 0; i < pubList.Length; i++)
            {
                pubList[i] = new Paper("How to degenerate your brain", new Person("dimicuss", 19), new DateTime(i+1, i+1, i+7));
            }

            Console.WriteLine(resTeam.ToString());
            Console.WriteLine();

            resTeam.AddPapers(new Paper("New name", new Person("some person", 30), new DateTime(1996, 10, 31)));
            Console.WriteLine(resTeam.ToString());
            Console.WriteLine();
            Console.WriteLine(resTeam.latePub.ToString());
            Console.ReadLine();
        }
    }
}
