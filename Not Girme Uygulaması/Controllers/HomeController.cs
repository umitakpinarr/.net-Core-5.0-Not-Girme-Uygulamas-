using Microsoft.AspNetCore.Mvc;
using Not_Girme_Uygulaması.Models;
using Not_Girme_Uygulaması.Models.Context;
using Not_Girme_Uygulaması.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Not_Girme_Uygulaması.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            List<students> DbStudents = _databaseContext.students.ToList();
            return View(DbStudents);
        }

        public IActionResult studentAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult studentAdd(students students)
        {
            _databaseContext.students.Add(students);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }


        public IActionResult noteAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult noteAdd(notes notes)
        {
            int ortalama = 0;
            if(notes.Per1 != 0 && notes.Per2 != 0 && notes.Not1 != 0 && notes.Not2 != 0)
            {
                ortalama = (notes.Per1 + notes.Per2 + notes.Not1 + notes.Not2) / 4;
            }
            else if (notes.Per1 == 0 && notes.Per2 == 0 && notes.Not1 != 0 && notes.Not2 == 0)
            {
                ortalama = notes.Not1;
            }
            else if (notes.Per1 == 0 && notes.Per2 == 0 && notes.Not1 != 0 && notes.Not2 != 0)
            {
                ortalama = (notes.Not1 + notes.Not2) / 2;
            }
            else if (notes.Per1 != 0 && notes.Per2 == 0 && notes.Not1 != 0 && notes.Not2 == 0)
            {
                ortalama = (notes.Not1 + notes.Per1) / 2;
            }
            else if (notes.Per1 != 0 && notes.Per2 == 0 && notes.Not1 != 0 && notes.Not2 != 0)
            {
                ortalama = (notes.Not1 + notes.Per1 + notes.Not2) / 3;
            }
            notes.average = ortalama;
            _databaseContext.notes.Add(notes);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult lessonAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult lessonAdd(lessons lessons)
        {
            _databaseContext.lessons.Add(lessons);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult classAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult classAdd(classes classes)
        {
            _databaseContext.classes.Add(classes);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult studentEdit(int Id)
        {
            students DbStudents = _databaseContext.students.Where(x => x.Id == Id).FirstOrDefault();
            return View(DbStudents);
        }

        [HttpPost]
        public IActionResult studentEdit(students students)
        {
            students DbStudents = _databaseContext.students.Where(x => x.Id == students.Id).FirstOrDefault();
            DbStudents.Name = students.Name;
            DbStudents.Surname = students.Surname;
            DbStudents.TC = students.TC;
            DbStudents.No = students.No;
            DbStudents.ClassId = students.ClassId;
            _databaseContext.Update(DbStudents);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult studentDelete(int Id)
        {
            students DbStudents = _databaseContext.students.Where(x => x.Id == Id).FirstOrDefault();
            _databaseContext.Remove(DbStudents);
            _databaseContext.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult classes()
        {

            List<classes> DbClasses = _databaseContext.classes.ToList();
            return View(DbClasses);
        }

        public IActionResult lesson()
        {
            List<lessons> DbLessons = _databaseContext.lessons.ToList();
            return View(DbLessons);
        }

        public IActionResult student()
        {
            List<students> DbStudents = _databaseContext.students.ToList();
            return View(DbStudents);
        }

        public IActionResult notes()
        {

            List<notes> DbNotes = _databaseContext.notes.ToList();
            List<notesViewModel> AllNotes = new List<notesViewModel>();
            foreach (var item in DbNotes)
            {
                notesViewModel notesViewModel = new notesViewModel();

                students students = _databaseContext.students.Where(x => x.No == item.StudentNo).FirstOrDefault();
                lessons DbLessons = _databaseContext.lessons.Where(x => x.Id == item.lessonId).FirstOrDefault();
                notesViewModel.Name = students.Name;
                notesViewModel.Surname = students.Surname;
                notesViewModel.studentNo = students.No;
                notesViewModel.LessonId = DbLessons.Id;
                notesViewModel.LessonName = DbLessons.Name;
                notesViewModel.Not1 = item.Not1;
                notesViewModel.Not2 = item.Not2;
                notesViewModel.Per1 = item.Per1;
                notesViewModel.Per2 = item.Per2;
                notesViewModel.Average = item.average;
                notesViewModel.Id = item.Id;
                AllNotes.Add(notesViewModel);
            }
            
            
            
            
            
            return View(AllNotes);
        }
    }
}
