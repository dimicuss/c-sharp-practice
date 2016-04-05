using System;
using System.Collections.Generic;
using System.Collections;

namespace OOPLabrab3
{
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string _resTheme;
        private TimeFrame _resTime;
        private List<Person> _perList = new List<Person>();
        private List<Paper> _pubList = new List<Paper>();
        public List<Paper> PubList
        {
            get { return _pubList; }
            set { _pubList = value; }
        }
        public List<Person> PerList
        {
            get { return _perList; }
            set { _perList = value; }
        }
        public Team baseTeam
        {
            get { return new Team(_orgName, _regNumber); }
            set
            {
                _orgName = value.OrgName;
                _regNumber = value.RegNumber;
            }
        }
        public TimeFrame ResTime
        {
            get { return _resTime; }
        }


        public Paper LatestPub
        {
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


        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.OrgName.CompareTo(y.OrgName) > 0)
                return 1;
            else return -1;

        }


        public void AddPapers(params Paper[] papers)
        {
            for (int i = 0; i < papers.Length; i++)
                _pubList.Add(papers[i]);
        }


        public void AddMembers(params Person[] persons)
        {
            for (int i = 0; i < persons.Length; i++)
                _perList.Add(persons[i]);
        }


        public override string ToString()
        {
            var str = _resTheme + "," + _orgName + "," + _regNumber + "," + _resTime + ";\n";

            var PublicationList = _pubList.ToArray();
            var PersonList = _perList.ToArray();

            for (var i = 0; i < PersonList.Length; i++)
                str = str + PersonList[i].ToString();

            for (var i = 0; i < PublicationList.Length; i++)
                str = str + PublicationList[i].ToString();

            return str + "\n";
        }


        public virtual string ToShortString()
        {
            return _orgName + ',' + _regNumber + ',' + _resTheme + ',' + _resTime + ';';
        }


        public override object DeepCopy()
        {
            var obj = new ResearchTeam(_orgName, _resTheme, _regNumber, _resTime);

            List<Paper> clonedPubList = new List<Paper>();
            List<Person> clonedPerList = new List<Person>();


            for (int i = 0; i < _pubList.Count; i++)
            {
                clonedPubList.Add((Paper)_pubList[i].DeepCopy());
            }

            for (int i = 0; i < _perList.Count; i++)
            {
                clonedPerList.Add((Person)_perList[i].DeepCopy());
            }


            obj.PubList = clonedPubList;
            obj.PerList = clonedPerList;

            return obj;
        }


        public IEnumerable GetUnpublicPersons()
        {
            for (int i = 0; i < _perList.Count; i++)
            {
                var personName = _perList[i].GetName();

                for (int j = 0; j < _pubList.Count; j++)
                {
                    var pubAutor = _pubList[j].Autor.GetName();

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

            for (int i = 0; i < _pubList.Count; i++)
            {
                if (_pubList[i].PublicationDate.Year > year)
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
}
