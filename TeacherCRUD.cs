using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpPhase_1EndProject
{
    public static class TeacherCRUD
    {
        
        public static string GetPath()
        {
            string dir = Directory.GetCurrentDirectory();
            String p = dir + "\\RainbowSchoolTeacherData.txt";
            return p;
        }
        public static  void AddTeacher(int id,string name,string cls)
        {
            Teacher t = new Teacher(id, name, cls);
            string path = GetPath();
            string line = t.ToString();
            List<string> l = new List<string>();
            l.Add(line);
            if(File.Exists(path))
            {
                File.AppendAllLines(path, l);
            }
        }
        public static Teacher GetTeacherById(int id)
        {
            string path = GetPath();
            Teacher obj = null;
            if (File.Exists(path))
            {
                string[] content = File.ReadAllLines(path);
                foreach (string line in content)
                {
                    string[] details = line.Split(",");
                    if (id == Convert.ToInt32(details[0]))
                    {
                        obj = new Teacher(Convert.ToInt32(details[0]), details[1], details[2]);
                    }

                }
            }
            return obj;
        }
        public static List<Teacher> GetAllTeachers()
        {
            List<Teacher> list = new List<Teacher>();
            string path = GetPath();
            if(File.Exists(path))
            {
                string[] content = File.ReadAllLines(path);
                foreach (string line in content)
                {
                    string[] details = line.Split(",");
                    Teacher t = new Teacher(Convert.ToInt32(details[0]), details[1], details[2]);
                    list.Add(t);
                }
            }
            return list;
        }
        public static void UpdateTeacher(Teacher t)
        {
            string path = GetPath();
            int id = t.ID;
            List<string> l = new List<string>();
            string[] content = File.ReadAllLines(path);
            StreamWriter writer = File.CreateText(path);
            if (File.Exists(path))
            {
                
                foreach (string line in content)
                {
                    string[] details = line.Split(",");
                    if (id == Convert.ToInt32(details[0]))
                    {
                        writer.WriteLine(details[0].ToString() + "," + t.Name + "," + t.ClassAndSection);
                    }
                    else
                    {
                        writer.WriteLine(details[0].ToString()+","+details[1]+","+details[2]);
                    }
                }
                writer.Close();
            }
        }
    }
}
