using SIS.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Models.Repositories
{
    public class CourseRepository
    {
        private List<Course> _courses;

        public CourseRepository()
        {
            // sample data
            _courses = new List<Course>
            {
                new Course { CourseId=1, CourseName="Art History" },
                new Course { CourseId=2, CourseName="Accounting 101" },
                new Course { CourseId=3, CourseName="Biology 101" },
                new Course { CourseId=4, CourseName="Business Law" },
                new Course { CourseId=5, CourseName="C# Fundamentals" },
                new Course { CourseId=6, CourseName="Economics 101" },
                new Course { CourseId=7, CourseName="Java Fundamentals" },
                new Course { CourseId=8, CourseName="Photography" }
            };
        }

        public List<Course> GetAllCourses()
        {
            return _courses;
        }
        public Course GetCourse(int courseId)
        {
            return _courses.Where(i => i.CourseId == courseId).FirstOrDefault();
        }
        public Course GetCourse(string courseName)
        {
            return _courses.Where(i => i.CourseName == courseName).FirstOrDefault();
        }
        public Course AddCourse(string courseName)
        {
            var newCourse = new Course()
            {
                CourseId = _courses.Max(m => m.CourseId) + 1,
                CourseName = courseName
            };
            _courses.Add(newCourse);
            return newCourse;
        }
        public Course EditCourse(Course course)
        {
            var editedCourse = _courses.Where(n => n.CourseId == course.CourseId).FirstOrDefault();
            editedCourse.CourseName = course.CourseName;
            return editedCourse;
        }
        public void RemoveCourse(int id)
        {
            var course = _courses.Where(c => c.CourseId == id).FirstOrDefault();
            _courses.Remove(course);
        }
    }
}
