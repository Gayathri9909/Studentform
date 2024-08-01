using StudentApp.Controllers.Admission;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly Studentrepository _repository;

        public StudentController()
        {
            _repository = new Studentrepository();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/InsertStudent
        public ActionResult InsertStudent()
        {
            return View();
        }

        // POST: Student/InsertStudent
        [HttpPost]
        public ActionResult InsertStudent(StudentAdmission obj, HttpPostedFileBase photo, HttpPostedFileBase resume)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Convert uploaded files to Base64 strings
                    if (photo != null && photo.ContentLength > 0)
                    {
                        obj.Photo = ConvertFileToBase64(photo);
                    }

                    if (resume != null && resume.ContentLength > 0)
                    {
                        obj.Resume = ConvertFileToBase64(resume);
                    }

                    string result = _repository.InsertData(obj);
                    TempData["result1"] = result;
                    ModelState.Clear();
                    return RedirectToAction("ShowAllDetails");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View(obj);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while saving data: {ex.Message}");
                return View(obj);
            }
        }

        private string ConvertFileToBase64(HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                return null;
            }

            try
            {
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    byte[] fileBytes = binaryReader.ReadBytes(file.ContentLength);
                    return Convert.ToBase64String(fileBytes);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting file to Base64.", ex);
            }
        }

        // GET: Student/ShowAllDetails
        public ActionResult ShowAllDetails()
        {
            try
            {
                var studentList = _repository.SelectAllData();
                return View(studentList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while retrieving student details: {ex.Message}";
                return View("Error");
            }
        }

        // GET: Student/Details
        [HttpGet]
        public ActionResult Details(string Email)
        {
            try
            {
                var student = _repository.SelectDataByID(Email);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while retrieving student details: {ex.Message}";
                return View("Error");
            }
        }

        // GET: Student/Edit
        public ActionResult Edit(string Email)
        {
            try
            {
                var student = _repository.SelectDataByID(Email);
                if (student == null)
                {
                    return HttpNotFound();
                }
                return View(student);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred while retrieving student details for editing: {ex.Message}";
                return View("Error");
            }
        }

        // POST: Student/Edit
        [HttpPost]
        public ActionResult Edit(StudentAdmission obj, HttpPostedFileBase photo, HttpPostedFileBase resume)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Convert and update photo if a new file is uploaded
                    if (photo != null && photo.ContentLength > 0)
                    {
                        obj.Photo = ConvertFileToBase64(photo);
                    }

                    // Convert and update resume if a new file is uploaded
                    if (resume != null && resume.ContentLength > 0)
                    {
                        obj.Resume = ConvertFileToBase64(resume);
                    }

                    string result = _repository.UpdateData(obj);
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
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while updating data: {ex.Message}");
                return View(obj);
            }
        }

        // GET: Student/Delete
        public ActionResult Delete(string Email)
        {
            try
            {
                string result = _repository.DeleteData(Email);
                TempData["result3"] = result;
                return RedirectToAction("ShowAllDetails");
            }
            catch (Exception ex)
            {
                TempData["result3"] = $"Error: {ex.Message}";
                return RedirectToAction("ShowAllDetails");
            }
        }
    }
}
