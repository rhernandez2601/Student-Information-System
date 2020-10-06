using SIS.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SIS.Models.Repositories
{
    public class StudentRepository
    {
        private List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>
            {
                new Student {
                    StudentId=1,
                    FirstName="John",
                    LastName="Doe",
                    GPA=2.5M,
                    Major=new Major { MajorId=1,  MajorName="Art" },
                    Address=new Address {
                        AddressId=1,
                        Street1="123 Main St",
                        City="Akron",
                        State=new State {
                            StateAbbreviation="OH",
                            StateName="Ohio"},
                        PostalCode="44311"
                    },
                    Courses=new List<Course>
                    {
                        new Course { CourseId=1, CourseName="Art History" },
                        new Course { CourseId=8, CourseName="Photography" }
                    }
                },
                new Student {
                    StudentId=2,
                    FirstName="Jane",
                    LastName="Wicks",
                    GPA=3.5M,
                    Major=new Major { MajorId=2,  MajorName="Business" },
                    Address=new Address {
                        AddressId=2,
                        Street1="422 Oak St",
                        Street2="Apartment 305A",
                        City="Mineapolis",
                        State=new State {
                            StateAbbreviation="MN",
                            StateName="Minnesota"},
                        PostalCode="55401"
                    },
                    Courses=new List<Course>
                    {
                        new Course { CourseId=2, CourseName="Accounting 101" },
                        new Course { CourseId=4, CourseName="Business Law" },
                        new Course { CourseId=6, CourseName="Economics 101" },
                    }
                },
                new Student {
                    StudentId=3,
                    FirstName="Megan",
                    LastName="Smith",
                    Major=new Major { MajorId=3,  MajorName="Computer Science" }
                },
            };
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }
        public Student GetStudent(int studentId)
        {
            return _students.Where(s => s.StudentId == studentId).FirstOrDefault();
        }
        public Student AddStudent(Student newStudent)
        {
            newStudent.StudentId = _students.Max(m => m.StudentId) + 1;
            _students.Add(newStudent);
            return newStudent;
        }
        public Student EditStudent(Student student)
        {
            var editStudent = _students.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
            editStudent.FirstName = student.FirstName;
            editStudent.LastName = student.LastName;
            editStudent.GPA = student.GPA;
            editStudent.Address = student.Address;
            editStudent.Major = student.Major;
            editStudent.Courses = student.Courses;
            return editStudent;
        }
        public void DeleteStudent(int id)
        {
            var student = _students.Where(s => s.StudentId == id).FirstOrDefault();
            _students.Remove(student);
        }
    }
}
