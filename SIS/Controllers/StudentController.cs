using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIS.Models.Data;
using SIS.Models.Repositories;
using SIS.Models.View_Models;

namespace SIS.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly MajorRepository _majorRepository;
        private readonly StateRepository _stateRepository;


        public StudentController(StudentRepository studentRepository, CourseRepository courseRepository, MajorRepository majorRepository, StateRepository stateRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _majorRepository = majorRepository;
            _stateRepository = stateRepository;
        }
        public IActionResult Index()
        {
            return View(_studentRepository.GetAllStudents());
        }
        public IActionResult Details(int id)
        {
            return View(_studentRepository.GetStudent(id));
        }
        public IActionResult Create()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(_courseRepository.GetAllCourses());
            viewModel.SetMajorItems(_majorRepository.GetAllMajors());
            viewModel.SetStateItems(_stateRepository.GetAllStates());
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(StudentVM newStudent)
        {
            newStudent.Student.Courses = new List<Course>();
            foreach (var courseid in newStudent.SelectedCourseIds)
            {
                newStudent.Student.Courses.Add(_courseRepository.GetCourse(courseid));
            }
            newStudent.Student.Major = _majorRepository.GetMajor(newStudent.Student.Major.MajorId);
            newStudent.Student.Address.State = _stateRepository.GetState(newStudent.Student.Address.State.StateAbbreviation);
            newStudent.Student = _studentRepository.AddStudent(newStudent.Student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var viewModel = new StudentVM()
            {
                Student = _studentRepository.GetStudent(id)
            };
            viewModel.SetCourseItems(_courseRepository.GetAllCourses());
            viewModel.SetMajorItems(_majorRepository.GetAllMajors());
            viewModel.SetStateItems(_stateRepository.GetAllStates());
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentVM editStudent)
        {
            var student = _studentRepository.EditStudent(editStudent.Student);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
