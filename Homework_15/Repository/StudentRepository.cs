using Homework_15.Models;

namespace Homework_15.Repository
{
    public static class StudentRepository
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Tom", Age = 19, Status = true, Grade = 7.5, Gender = "Male", Temperament = "Сholeric" },
            new Student { Id = 2, Name = "Bob", Age = 22, Status = false, Grade = 5.9, Gender = "Male", Temperament = "Melancholic" },
            new Student { Id = 3, Name = "Eva", Age = 20, Status = true, Grade = 9.1, Gender = "Female", Temperament = "Sanguine" }
        };

        public static List<Student> GetStudents()
        { 
            return students;
        }

        public static void Add(Student student)
        {
            students.Add(student);
        }

        internal static void Delete(int id)
        {
            var item = students.FirstOrDefault(item => item.Id == id);

            if (item != null)
            { 
                students.Remove(item);
            }
        }

        public static Student? Details(int id)
        {
            var item = students.FirstOrDefault(item => item.Id == id);
            return item;
        }
    }
}
