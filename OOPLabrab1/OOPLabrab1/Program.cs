using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
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
            return Title + ", " + Autor.getName() + ", " + PublicationDate.ToString() + "; ";
        }
    }



    class ResearchTeam {
        string ResearchTitle;
        string OrganisationName;
        int RegNumber;
        TimeFrame ResearchTime;
        Paper[] PublicationList;
        Paper[,] PublicationList2D;
        Paper[][] PublicationListStaged;


        public string getResTitle
        {
            get { return ResearchTitle; }
            set { ResearchTitle = value; }
        }

        public string getOrgName
        {
            get { return OrganisationName; }
            set { OrganisationName = value; }
        }

        public int getRegNumber
        {
            get { return RegNumber; }
            set { RegNumber = value; }
        }

        public TimeFrame getTimeFrame
        {
            get { return ResearchTime; }
            set { ResearchTime = value; }
        }

        public Paper[] getPubList
        {
            get { return PublicationList; }
            set { PublicationList = value; }
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
            var str = ResearchTitle + ", " + OrganisationName + ", " + RegNumber + ", " + ResearchTime + ": ";

            for(var i = 0; i < PublicationList.Length; i++)
                str = str + PublicationList[i].ToString();
            

            return str;
        }



        public string ToStringStaged()
        {
            var str = ResearchTitle + ", " + OrganisationName + ", " + RegNumber + ", " + ResearchTime + ": ";

            for (var i = 0; i < PublicationListStaged.Length; i++)
                for(var j = 0; j < PublicationListStaged[i].Length; j++)
                str = str + PublicationListStaged[i][j].ToString();


            return str;
        }



        public string ToString2D()
        {
            var str = ResearchTitle + ", " + OrganisationName + ", " + RegNumber + ", " + ResearchTime + ": ";

            for (var i = 0; i < PublicationList2D.GetLength(0); i++)
                for(var j = 0; j < PublicationList2D.GetLength(1); j++)
                {
                    str += PublicationList2D[i, j].ToString();
                }


            return str;
        }



        public virtual string ToShortString()
        {
            return ResearchTitle + ", " + OrganisationName + ", " + RegNumber + ", " + ResearchTime + ";";
        }


        public ResearchTeam(string resTitle, string orgName, int regNumber, TimeFrame resTime, Paper[] pubList)
        {
            ResearchTitle = resTitle;
            OrganisationName = orgName;
            RegNumber = regNumber;
            ResearchTime = resTime;
            PublicationList = pubList;
        }



        public ResearchTeam(string resTitle, string orgName, int regNumber, TimeFrame resTime, Paper[,] pubList)
        {
            ResearchTitle = resTitle;
            OrganisationName = orgName;
            RegNumber = regNumber;
            ResearchTime = resTime;
            PublicationList2D = pubList;
        }



        public ResearchTeam(string resTitle, string orgName, int regNumber, TimeFrame resTime, Paper[][] pubList)
        {
            ResearchTitle = resTitle;
            OrganisationName = orgName;
            RegNumber = regNumber;
            ResearchTime = resTime;
            PublicationListStaged = pubList;
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
            var pubList = new Paper[10];
            var pubList2d = new Paper[2, 5];
            var pubListStaged = new Paper[3][];
            var rand = new Random();
            Stopwatch time;

            for (var i = 0; i < pubList.Length; i++)
            {
                pubList[i] = new Paper("How to degenerate your brain",
                                       new Person("dimicuss", 19),
                                       new DateTime(rand.Next(2000, 2016), rand.Next(1, 12), rand.Next(1, 28)));
            }

            ResearchTeam resTeam = new ResearchTeam("Brain degeneration",
                                                    "Dimciuss's org",
                                                    1996,
                                                    TimeFrame.TwoYears,
                                                    pubList);


            Console.WriteLine(resTeam.ToShortString() + "\n");
            Console.WriteLine(resTeam[TimeFrame.TwoYears] + "\n");


            resTeam.getOrgName = "New Orgname";
            resTeam.getResTitle = "New title";
            resTeam.getRegNumber = 2020;
            resTeam.getTimeFrame = TimeFrame.TwoYears;


            for (var i = 0; i < pubList.Length; i++)
            {
                pubList[i] = new Paper("How to degenerate your brain",
                                       new Person("dimicuss", 19),
                                       new DateTime(rand.Next(2000, 2016), rand.Next(1, 12), rand.Next(1, 28)));
            }

            Console.WriteLine(resTeam.ToString());
            Console.WriteLine();

            resTeam.AddPapers(new Paper("New name", new Person("Some Person", 30), new DateTime(1996, 10, 31)));
            Console.WriteLine(resTeam.ToString() + "\n");
            Console.WriteLine(resTeam.latePub.ToString() + "\n");



            //--------------------Одномерный
            time = Stopwatch.StartNew();

            pubList = new Paper[10];
            rand = new Random();

            for (var i = 0; i < pubList.Length; i++)
                pubList[i] = new Paper("How to degenerate your brain",
                                       new Person("dimicuss", 19),
                                       new DateTime(rand.Next(2000, 2016), rand.Next(1, 12), rand.Next(1, 28)));
            

            resTeam = new ResearchTeam("Brain degeneration",
                                       "Dimciuss's org",
                                       1996,
                                       TimeFrame.TwoYears,
                                       pubList);
            resTeam.ToString();

            time.Stop();
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

            //---------------------Двумерный-прямоугольный
            time = Stopwatch.StartNew();

            for (int i = 0; i < pubList2d.GetLength(0); i++)
                for(int j = 0; j < pubList2d.GetLength(1); j++)
                    pubList2d[i,j] = new Paper("How to degenerate your brain " + i + " " + j,
                                       new Person("dimicuss", 19),
                                       new DateTime(rand.Next(2000, 2016), rand.Next(1, 12), rand.Next(1, 28)));
                
            ResearchTeam resTeam2D = new ResearchTeam("Brain degeneration",
                                                    "Dimciuss's org",
                                                    1996,
                                                    TimeFrame.TwoYears,
                                                    pubList2d);
            resTeam2D.ToString2D();

            time.Stop();
            Console.WriteLine(time.Elapsed.TotalMilliseconds);


            //---------------------Ступенчатый
            time = Stopwatch.StartNew();

            pubListStaged[0] = new Paper[2];
            pubListStaged[1] = new Paper[3];
            pubListStaged[2] = new Paper[5];

            for (int i = 0; i < pubListStaged.Length; i++)
                for (int j = 0; j < pubListStaged[i].Length; j++)
                    pubListStaged[i][j] = new Paper("How to degenerate your brain " + i + " " + j,
                                       new Person("dimicuss", 19),
                                       new DateTime(rand.Next(2000, 2016), rand.Next(1, 12), rand.Next(1, 28)));

            ResearchTeam resTeamStaged = new ResearchTeam("Brain degeneration",
                                                   "Dimciuss's org",
                                                   1996,
                                                   TimeFrame.TwoYears,
                                                   pubListStaged);
            time.Stop();
            Console.WriteLine(time.Elapsed.TotalMilliseconds);

            Console.Read();

        }
    }
}
