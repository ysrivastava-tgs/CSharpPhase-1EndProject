using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPhase_1EndProject
{
    public class Teacher
    {
        public int ID { get;  }
        public string Name { get; }
        public string ClassAndSection { get; }
        public Teacher(int id,string nm,string cls)
        {
            ID = id;
            Name = nm;
            ClassAndSection = cls;
        }

        public override string ToString()
        {
            string str = ID.ToString() + "," + Name + "," + ClassAndSection;
            return str;
        }
    }
}
