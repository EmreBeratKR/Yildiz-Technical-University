using SimpleApp.Models;
using System;

namespace SimpleApp
{
    public static class LocalDatabase
    {
        private static List<Student> ms_Students;
        private static int ms_StudentIdCounter;


        public static void Init()
        {
            ms_Students = new List<Student>();

            AddStudent(new Student()
            {
                Id = 0,
                FirstName = "Emre Berat",
                LastName = "Kıran",
                Email = "emre@gmail.com"
            });
        }

        public static void AddStudent(Student student)
        {
            student.Id = ms_StudentIdCounter++;
            ms_Students.Add(student);
        }

        public static Student GetStudentByID(int id)
        {
            return ms_Students.FirstOrDefault(e => e.Id == id);
        }

        public static bool TryDeleteStudentByID(int id)
        {
            var index = -1;

            for (int i = 0; i < ms_Students.Count; i++)
            {
                if (ms_Students[i].Id != id) continue;

                index = i; 
                ms_Students.RemoveAt(i);
                break;
            }

            return index >= 0;
        }

        public static bool TryUpdateStudent(Student student)
        {
            for (int i = 0; i < ms_Students.Count; i++)
            {
                if (ms_Students[i].Id != student.Id) continue;

                ms_Students[i] = student;
                return true;
            }

            return false;
        }

        public static void DeleteAllStudents()
        {
            ms_Students.Clear();
        }

        public static IReadOnlyList<Student> GetStudents()
        {
            return ms_Students;
        }
    }
}
