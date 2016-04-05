using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab2
{
    enum TimeFrame : int { Year = 1, TwoYears, Long };

    interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();
    }



    class Person
    {
        private string Name;
        private int Age;


        public string GetName() { return Name; }
        public int GetAge() { return Age; }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var o = obj as Person;

            return (Name == o.Name) && (Age == o.Age);
        }


        public override int GetHashCode()
        {
            return 2 * Name.GetHashCode() + 2 * Age.GetHashCode();
        }


        public virtual Person DeepCopy()
        {
            return new Person(Name, Age);
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
            return Title + ", " + Autor.GetName() + ", " + PublicationDate.ToString();
        }

        public virtual object DeepCopy()
        {
            return new Paper(Title, Autor.DeepCopy(), PublicationDate);
        }
    }





    class Team : INameAndCopy
    {
        protected string _orgName;
        protected int _regNumber;
    
        public string Name
        {
            get { return _orgName; }
            set { _orgName = value; }
        }


        public string OrgName
        {
            get { return _orgName; }
        }



        public int RegNumber
        {
            get { return _regNumber; }
            set
            {
                if (value <= 0) throw new Exception("Value less then zero");
                else _regNumber = value;
            }
        }



        public virtual object DeepCopy()
        {
            return new Team(_orgName, _regNumber);
        }



        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var o = obj as Team;

            return (o._orgName == _orgName) && (o._regNumber == _regNumber);
        }



        public override int GetHashCode()
        {
            return _orgName.GetHashCode() + _regNumber.GetHashCode();
        }



        public override string ToString()
        {
            return _orgName + ", " + _regNumber;
        }



        public Team(string orgName, int regNumber)
        {
            _orgName = orgName;
            _regNumber = regNumber;
        }



        public Team()
        {
            _orgName = "";
            _regNumber = 0;
        }
    }



    
    class ResearchTeam : Team, INameAndCopy
    {
        private string _resTheme;
        private TimeFrame _resTime;
        private ArrayList _perList = new ArrayList();
        private ArrayList _pubList = new ArrayList();
        public ArrayList PubList
        {
            get { return _pubList; }
            set { _pubList = value; }
        }
        public ArrayList PerList
        {
            get { return _perList; }
            set { _perList = value; }
        }   
        public Team baseTeam
        {
            get { return new Team(_orgName, _regNumber);  }
            set
            {
                _orgName = value.OrgName;
                _regNumber = value.RegNumber;
            }
        }
        

        public Paper LatestPub {
            get
            {
                var PublicationList = _pubList.ToArray();
                var a = PublicationList[0] as Paper;

                if (PublicationList.Length > 0)
                {
                    for (var i = 1; i < PublicationList.Length - 1; i++)
                    {
                        var b = PublicationList[i] as Paper;
                        if (a.PublicationDate.CompareTo(b.PublicationDate) > 0)
                            a = PublicationList[i] as Paper;
                    }
                    return a;
                }
                else return null;
            }
        }




        public void AddPapers(params Paper[] papers)
        {
            for(int i = 0; i < papers.Length; i++)
                _pubList.Add(papers[i]);
        }



        public void AddMembers(params Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
                _perList.Add(persons[i]);
        }



        public override string ToString()
        {
            var str = _resTheme + ", " + _orgName + ", " + _regNumber + ", " + _resTime + ": ";

            var PublicationList = _pubList.ToArray();

            for (var i = 0; i < PublicationList.Length; i++)
                str = str + PublicationList[i].ToString();

            return str;
        }



        public string ToShortString()
        {
            return _orgName + ", " + _regNumber + ", " + _resTheme + ", " + _resTime;
        }



        public override object DeepCopy()
        {
            var obj = new ResearchTeam(_orgName, _resTheme, _regNumber, _resTime);

            ArrayList clonedPubList = new ArrayList();
            ArrayList clonedPerList = new ArrayList();


            for (int i = 0; i < _pubList.Count; i++)
            {
                clonedPubList.Add(  ( (Paper)_pubList[i] ).DeepCopy()  );
            }

            for (int i = 0; i < _perList.Count; i++)
            {
                clonedPerList.Add(  ( (Person)_perList[i] ).DeepCopy()  );
            }


            obj.PubList = clonedPubList;
            obj.PerList = clonedPerList;

            return obj;
        }



        public IEnumerable GetUnpublicPersons()
        {
            for (int i = 0; i < _perList.Count; i++)
            {
                var personName = ( (Person) _perList[i] ).GetName();

                for (int j = 0; j < _pubList.Count; j++)
                {
                    var pubAutor = ( (Paper) _pubList[j] ).Autor.GetName();

                    if (personName == pubAutor)
                        break;

                    if (j == _pubList.Count - 1)
                        yield return _perList[i];
                }
            }
        }

        public IEnumerable GetLastPublications(int n)
        {
            var year = DateTime.Now.Year - n;

            for(int i = 0; i < _pubList.Count; i++)
            {
                if (  ( (Paper)_pubList[i] ).PublicationDate.Year > year  )
                {
                    yield return _pubList[i];
                }
            }
        }

        public ResearchTeam(string orgName, string resTheme, int regNmber, TimeFrame resTime)
        {
            _orgName = orgName;
            _resTheme = resTheme;
            _regNumber = regNmber;
            _resTime = resTime;
        }



        public ResearchTeam()
        {
            _orgName = "";
            _resTheme = "";
            _regNumber = 0;
            _resTime = 0;
        }

    }





    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------1
            Random rand = new Random();
            var team1 = new Team("OrgName", 123);
            var team2 = new Team("OrgName", 123);


            Console.WriteLine(team1 == team2);
            Console.WriteLine(team1.Equals(team2));
            Console.WriteLine();


            //--------------------------2
            try { team1.RegNumber = -1; }

            catch(Exception err)
            {
                Console.WriteLine(err.Message + '\n');
            }


            //--------------------------3
            var resTeam = new ResearchTeam("orgName", "resTheme", 123, TimeFrame.Long);
            var pubList = new ArrayList();
            var perList = new ArrayList();


            for(int i = 5; i <= 11; i++)
            {
                pubList.Add(new Paper("title " + i, new Person("Name " + i, 20), new DateTime(rand.Next(2000, 2016),
                                                                                              rand.Next(1, 12),
                                                                                              rand.Next(1, 31))));
            }

            for(int i = 1; i <= 20; i++)
            {
                perList.Add(new Person("Name" + 200, 20));
            }

            resTeam.PerList = perList;
            resTeam.PubList = pubList;

            Console.WriteLine(resTeam.ToString() + '\n');

            //--------------------------4
            Console.WriteLine(resTeam.baseTeam.ToString() + '\n');


            //--------------------------5

            pubList = new ArrayList();
            perList = new ArrayList();


            var copyResTeam = resTeam.DeepCopy();

            for (int i = 7; i <= 13; i++)
            {
                pubList.Add(new Paper("title " + i, new Person("Name " + i, 20), new DateTime(rand.Next(2000, 2016),
                                                                                              rand.Next(1, 12),
                                                                                              rand.Next(1, 30))));
            }

            for (int i = 1; i <= 20; i++)
            {
                perList.Add(new Person("Name " + i, 20));
            }

            resTeam.PerList = perList;
            resTeam.PubList = pubList;

            Console.WriteLine(resTeam.ToString() + '\n');
            Console.WriteLine(copyResTeam.ToString() + '\n');



            //--------------------------6

            foreach(Person person in resTeam.GetUnpublicPersons())
            {
                Console.WriteLine(person.GetName());
            }

            Console.WriteLine();


            //--------------------------7
            foreach (Paper pub in resTeam.GetLastPublications(5))
            {
                Console.WriteLine(pub.PublicationDate);
            }


            Console.Read();

        }
    }

}
