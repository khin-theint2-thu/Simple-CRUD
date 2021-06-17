using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMiniProject.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Students()
        {
            var data=TempData["Data"];
            if (data != null)
                return View(data);
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Students(Student student)
        {
            if (student.StudentName != null && student.PhoneNo != null)
            {
                if (student.StudentID != 0)
                {
                    using (var context = new MVCEntities())
                    {
                        var data = context.Students.FirstOrDefault(m => m.StudentID == student.StudentID);
                        if (data != null)
                        {
                            data.StudentName = student.StudentName;
                            data.Age = student.Age;
                            data.Gender = student.Gender;
                            data.PhoneNo = student.PhoneNo;
                            data.Email = student.Email;
                            context.SaveChanges();
                            return RedirectToAction("StudentList");
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
                else
                {
                    using (var context = new MVCEntities())
                    {
                        context.Students.Add(student);
                        context.SaveChanges();
                    }
                    ViewBag.Alert = "You have registered.";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult StudentList()
        {
            using(var context=new MVCEntities())
            {
                var data = context.Students.ToList();
                return View(data);
            }
        }

        public ActionResult Delete(int StudentId)
        {
            using (var context = new MVCEntities())
            {
                var data = context.Students.FirstOrDefault(m => m.StudentID == StudentId);
                if(data != null)
                {
                    context.Students.Remove(data);
                    context.SaveChanges();
                    return RedirectToAction("StudentList");
                }else
                return View(data);
            }
        }

        public ActionResult Details(int StudentId)
        {
            using(var context = new MVCEntities())
            {
                var data = context.Students.Where(x => x.StudentID == StudentId).SingleOrDefault();
                TempData["Data"] = data;
                return RedirectToAction("Students");
            }
        }
    }
}