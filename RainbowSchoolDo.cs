using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPhase_1EndProject
{
    public class RainbowSchoolDo
    {
        public static void Do()
        {
            string ans;
            Console.WriteLine("============Rainbow School============");
            do
            {
                Console.WriteLine("Choose option");
                Console.WriteLine("1.Add Teacher\n2.Search Teacher By Id\n3.Show Teachers List\n4.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1: SetTeacher();
                        break;
                    case 2: SearchTeacherById();
                        break;
                    case 3: ShowAllTeacher();
                        break;
                    case 4: Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Want to continue?(Type yes/no)");
                ans = Console.ReadLine();
            } while(ans.Equals("yes"));
        }
        public static void SetTeacher()
        {
            Console.WriteLine("Enter Id of a teacher(id should be numbers)");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name of the teacher");
            string name = Console.ReadLine();
            Console.WriteLine("Enter class and section of a teacher");
            string cls = Console.ReadLine();
            TeacherCRUD.AddTeacher(id, name, cls);
        }
        public static void SearchTeacherById()
        {
            Console.WriteLine("Enter id(id should be numbers)");
            int id = Convert.ToInt32(Console.ReadLine());
            Teacher t = TeacherCRUD.GetTeacherById(id);
            if(t==null)
                Console.WriteLine("Id does not exist");
            else
                Console.WriteLine($"Name: {t.Name}\t Class And Section: {t.ClassAndSection}");
        }
        public static void ShowAllTeacher()
        {
            List<Teacher> list = TeacherCRUD.GetAllTeachers();
            if(list.Count==0)
                Console.WriteLine("No data");
            else
                foreach(Teacher t in list)
                    Console.WriteLine($"ID: {t.ID}\tName: {t.Name}\tClass And Section: {t.ClassAndSection}");
        }
    }
}
