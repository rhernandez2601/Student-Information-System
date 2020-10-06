using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SIS.Models.Data;
using SIS.Models.Repositories;

namespace SIS.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly CourseRepository _courseRepository;

        public CourseController(ILogger<CourseController> logger, CourseRepository courseRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var allCourses = _courseRepository.GetAllCourses();
            return View(allCourses);
        }
        public IActionResult Create()
        {
            var newCourse = new Course();
            return View(newCourse);
        }
        [HttpPost]
        public IActionResult Create(Course newCourse)
        {
            newCourse = _courseRepository.AddCourse(newCourse.CourseName);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var editCourse = _courseRepository.GetCourse(id);
            return View(editCourse);
        }
        [HttpPost]
        public IActionResult Edit(Course editCourse)
        {
            editCourse = _courseRepository.EditCourse(editCourse);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _courseRepository.RemoveCourse(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
