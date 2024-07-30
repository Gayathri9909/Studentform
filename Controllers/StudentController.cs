using StudentApp.Controllers.Admission;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    
            {
                // TODO: Add insert logic here
                Studentrepository objDB = new Studentrepository();
                string result=objDB.InsertData(obj);
                    TempData["result1"] = result;
                    ModelState.Clear();
                return RedirectToAction("showAllDetails");
            }
            else
            {
                    ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details (int StudentId)
        {
            StudentAdmission obj=new StudentAdmission();
            Studentrepository db = new Studentrepository();
            return View(db.SelectDatabyID(StudentId));
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int studentId)
        {
            StudentAdmission obj=new StudentAdmission();
            Studentrepository objRepository = new Studentrepository();
            return View(objRepository.SelectDatabyID(studentId));
        }

        // POST: Student/Edit/5
        /*[HttpPost]
        public ActionResult Edit(StudentAdmission obj)
        {
            obj.DateOfBirth=Convert.ToDateTime(obj.DateOfBirth);
            obj.Photo = Convert.ToBase64String(obj.Photo);
            obj.Resume = Convert.ToBase64String((obj.Resume));
            if (ModelState.IsValid)
            {
                Studentrepository objDB = new Studentrepository();
                string result = objDB.UpdateData(obj);
                TempData["result2"] = result;
                ModelState.Clear();

                return RedirectToAction("ShowallDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }*/
        [HttpPost]
        public ActionResult Edit(StudentAdmission obj, HttpPostedFileBase photo, HttpPostedFileBase resume)
        {
            if (photo != null && photo.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(photo.InputStream))
                {
                    obj.Photo = binaryReader.ReadBytes(photo.ContentLength);
                }
            }

            if (resume != null && resume.ContentLength > 0)
            {
                using (var binaryReader = new BinaryReader(resume.InputStream))
                {
                    obj.Resume = binaryReader.ReadBytes(resume.ContentLength);
                }
            }

            obj.DateOfBirth = Convert.ToDateTime(obj.DateOfBirth);

            if (ModelState.IsValid)
            {
                var objDB = new Studentrepository();
                string result = objDB.UpdateData(obj);
                TempData["result2"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View(obj);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int StudentId)
        {
            Studentrepository obj=new Studentrepository();
            int result = obj.DeleteData(StudentId);
            TempData["result3"] = result;
            ModelState.Clear();
            return RedirectToAction("ShowallDetails");
        }

      
        
    }
}
