using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
    class Team : INameAndCopy, IComparable
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
            return _orgName + "," + _regNumber;
        }


        public int CompareTo(object obj)
        {
            if (((Team)obj).RegNumber > _regNumber)
                return -1;
            else return 1;
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
}
