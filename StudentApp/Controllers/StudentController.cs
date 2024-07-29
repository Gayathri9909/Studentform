using StudentApp.Controllers.Admission;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/showAllDetails
        public ActionResult showAllDetails()
        {
            StudentAdmission obj = new StudentAdmission();
            Studentrepository objRepository = new Studentrepository();  
            obj.ShowallStudent = objRepository.Selectalldata();
            return View();
        }

        // GET: Student/InsertUser
        public ActionResult InsertStudent()
        {
            return View();
        }

        // POST: Student/InsertUser
        [HttpPost]
        public ActionResult InsertStudent(StudentAdmission obj)
        {
            obj.DateOfBirth=Convert.ToDateTime(obj.DateOfBirth);
            if(ModelState.IsValid)
            try
            {
                // TODO: Add insert logic here
                Studentrepository objDB = new Studentrepository();
                string result=objDB.InsertData(obj);
                    TempData["result1"] = result;
                    ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                    ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int studentId)
        {
            StudentAdmission obj=new StudentAdmission();
            Studentrepository objRepository = new Studentrepository();
            return View(obj.SelectDatabyID(studentId));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentAdmission obj)
        {
            obj.DateOfBirth=Convert.ToDateTime((DateTime)obj.DateOfBirth);
            if(ModelState.IsValid)
            {
                Studentrepository objDB = new Studentrepository();
                string result = objDB.InsertData(obj);
                TempData["result2"] = result;
                ModelState.Clear();

                return RedirectToAction("ShowallStudent");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int StudentId)
        {
            Studentrepository obj=new Studentrepository();
            int result = obj.DeleteData(StudentId);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowallStudent");
        }

      
        
    }
}
