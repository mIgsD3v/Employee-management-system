using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IPT102PROJECT.Models;

namespace IPT102PROJECT.Controllers
{
    public class HomeController : Controller
    {
        //Login and Register


        public ActionResult Registerr()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Registerr(Admin admin)
        {
            if (ModelState.IsValid)
            {
                using (Useraccount dbmodel = new Useraccount())
                {
                    dbmodel.Admins.Add(admin);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = admin.Name + "" + "," + "Successfully Registered.";
            }

            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Register(Admin admin)
        {
            if(ModelState.IsValid)
            {
                using (Useraccount dbmodel = new Useraccount())
                {
                    dbmodel.Admins.Add(admin);
                    dbmodel.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = admin.Name + ""  + "Successfully Registered.";
            }

            return View();
        }



       

        //Login



        public ActionResult Loginn()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Loginn(Admin admin)
        {

            using (Useraccount dbmodel = new Useraccount())
            {
                var usr = dbmodel.Admins.FirstOrDefault(u => u.Name == u.Name & u.Password == u.Password);
                if (usr != null)
                {
                    Session["EmployeeID"] = usr.EmployeeID.ToString();
                    Session["Name"] = usr.Name.ToString();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }

            return View();
        }







        //Employee record
        public ActionResult Index()
        {

            using (DBmodels dbmodel = new DBmodels())
            {

                return View(dbmodel.Employees.ToList());

            }
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            using (DBmodels dbmodel = new DBmodels()) 
            {

                return View(dbmodel.Employees.Where(x => x.EmployeeID== id).FirstOrDefault());

            }
                
        }

        public ActionResult Createe()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Createe(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                using (DBmodels dbmodel = new DBmodels())
                {

                    dbmodel.Employees.Add(employee);
                    dbmodel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBmodels dbmodel = new DBmodels())
            {

                return View(dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (DBmodels dbmodel = new DBmodels())
                {

                    dbmodel.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBmodels dbmodel = new DBmodels())
            {

                return View(dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DBmodels dbmodel = new DBmodels())
                {

                    Employee employee = dbmodel.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    dbmodel.Employees.Remove(employee);
                    dbmodel.SaveChanges();

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }





        //ABOUT





        public ActionResult About()
        {
             using (DBsalary dbmodel = new DBsalary())
            {

                return View(dbmodel.Salaries.ToList());

            }
        }

        // GET: Employee/Details/5
       


        // GET: Employee/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create2(Salary salaries)
        {
            try
            {
                // TODO: Add insert logic here
                using (DBsalary dbmodel = new DBsalary())
                {

                    dbmodel.Salaries.Add(salaries);
                    dbmodel.SaveChanges();

                }

                return RedirectToAction("About");
            }
            catch
            {
                return View();
            }
        }
        // GET: Employee/Edit/5
        public ActionResult Edit2(int id)
        {
            using (DBsalary dbmodel = new DBsalary())
            {

                return View(dbmodel.Salaries.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit2(int id, Salary salaries)
        {
            try
            {
                using (DBsalary dbmodel = new DBsalary())
                {

                    dbmodel.Entry(salaries).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("About");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete2(int id)
        {
            using (DBsalary dbmodel = new DBsalary())
            {

                return View(dbmodel.Salaries.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete2(int id, FormCollection collection)
        {
            try
            {
                using (DBsalary dbmodel = new DBsalary())
                {

                    Salary salaries = dbmodel.Salaries.Where(x => x.EmployeeID == id).FirstOrDefault();
                    dbmodel.Salaries.Remove(salaries);
                    dbmodel.SaveChanges();

                }


                return RedirectToAction("About");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details4()
        {

            using (DBpayslip dbmodel = new DBpayslip())
            {

                return View(dbmodel.Payslips.ToList());

            }

        }


        public ActionResult create3()


        {
            return View();
        }



        [HttpPost]
        public ActionResult create3(Payslip Payslips)
        {

            if (Payslips.Basic > 15000)
            {
                Payslips.Tax = Payslips.Basic * 15 / 100;
            }


            else
            {
                Payslips.Tax = 0;
            }

            Payslips.Total = Payslips.Basic - Payslips.Tax;

            using (DBpayslip dbmodel = new DBpayslip())
            {

                dbmodel.Payslips.Add(Payslips);
                dbmodel.SaveChanges();

            }

            return View(Payslips);
        }



        public ActionResult Edit3(int id)
        {
            using (DBpayslip dbmodel = new DBpayslip())
            {

                return View(dbmodel.Payslips.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit3(int id, Payslip Payslips)
        {
            if (Payslips.Basic > 15000)
            {
                Payslips.Tax = Payslips.Basic * 15 / 100;
            }


            else
            {
                Payslips.Tax = 0;
            }

            Payslips.Total = Payslips.Basic - Payslips.Tax;
            try
            {
                using (DBpayslip dbmodel = new DBpayslip())
                {

                    dbmodel.Entry(Payslips).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Details4");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete3(int id)
        {
            using (DBpayslip dbmodel = new DBpayslip())
            {

                return View(dbmodel.Payslips.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete3(int id, FormCollection collection)
        {
            try
            {
                using (DBpayslip dbmodel = new DBpayslip())
                {

                    Payslip payslip = dbmodel.Payslips.Where(x => x.EmployeeID == id).FirstOrDefault();
                    dbmodel.Payslips.Remove(payslip);
                    dbmodel.SaveChanges();

                }


                return RedirectToAction("Details4");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Contact()
        {

            using (DBcontactlist dbmodel = new DBcontactlist())
            {

                return View(dbmodel.Contacts.ToList());

            }
        }

        // GET: Employee/Details/5
      
        public ActionResult Create4()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create4(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here
                using (DBcontactlist dbmodel = new DBcontactlist())
                {

                    dbmodel.Contacts.Add(contact);
                    dbmodel.SaveChanges();

                }

                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit4(int id)
        {
            using (DBcontactlist dbmodel = new DBcontactlist())
            {

                return View(dbmodel.Contacts.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit4(int id, Contact contact)
        {
            try
            {
                using (DBcontactlist dbmodel = new DBcontactlist())
                {

                    dbmodel.Entry(contact).State = System.Data.Entity.EntityState.Modified;
                    dbmodel.SaveChanges();
                }

                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete4(int id)
        {
            using (DBcontactlist dbmodel = new DBcontactlist())
            {

                return View(dbmodel.Contacts.Where(x => x.EmployeeID == id).FirstOrDefault());

            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete4(int id, FormCollection collection)
        {
            try
            {
                using (DBcontactlist dbmodel = new DBcontactlist())
                {

                    Contact contact = dbmodel.Contacts.Where(x => x.EmployeeID == id).FirstOrDefault();
                    dbmodel.Contacts.Remove(contact);
                    dbmodel.SaveChanges();

                }


                return RedirectToAction("Contact");
            }
            catch
            {
                return View();
            }

        }


    }
}


        
