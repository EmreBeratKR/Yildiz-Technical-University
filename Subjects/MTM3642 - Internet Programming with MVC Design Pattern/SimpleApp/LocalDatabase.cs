using SimpleApp.Models;
using System.Text.Json;

namespace SimpleApp
{
    public static class LocalDatabase
    {
        private const string SAVE_PATH = "local_database_save.json";


        private static SaveData ms_Data;


        public static void Init()
        {
            Load();
        }

        public static void AddStudent(Student student)
        {
            student.Id = ms_Data.StudentIdCounter++;
            ms_Data.Students.Add(student);
            Save();
        }

        public static Student GetStudentByID(int id)
        {
            return ms_Data.Students.FirstOrDefault(e => e.Id == id);
        }

        public static bool TryDeleteStudentByID(int id)
        {
            var students = ms_Data.Students;
            var index = -1;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id != id) continue;

                index = i;
                students.RemoveAt(i);
                Save();
                break;
            }

            return index >= 0;
        }

        public static bool TryUpdateStudent(Student student)
        {
            var students = ms_Data.Students;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Id != student.Id) continue;

                students[i] = student;
                Save();
                return true;
            }

            return false;
        }

        public static void DeleteAllStudents()
        {
            ms_Data.Students.Clear();
            Save();
        }

        public static IReadOnlyList<Student> GetStudents()
        {
            return ms_Data.Students;
        }


        private static void Load()
        {
            if (!File.Exists(SAVE_PATH))
            {
                ms_Data = new SaveData();
                ms_Data.Students = new List<Student>();
                ms_Data.StudentIdCounter = 0;
                return;
            }

            var jsonString = File.ReadAllText(SAVE_PATH);

            ms_Data = JsonSerializer.Deserialize<SaveData>(jsonString);
        }

        private static void Save()
        {
            var jsonString = JsonSerializer.Serialize(ms_Data);

            File.WriteAllText(SAVE_PATH, jsonString);
        }

        private class SaveData
        {
            public List<Student> Students { get; set; }
            public int StudentIdCounter { get; set; }
        }
    }
}
