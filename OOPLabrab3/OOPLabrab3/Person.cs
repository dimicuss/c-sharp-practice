using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPLabrab3
{
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


        public virtual object DeepCopy()
        {
            return new Person(Name, Age);
        }


        public override string ToString()
        {
            return Name + "," + Age + ';';
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
}
