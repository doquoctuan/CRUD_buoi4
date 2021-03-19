using DoQuocTuan_5951071118.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoQuocTuan_5951071118.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        string msg;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Employee emp = new Employee();
            emp.Flag = "get";
            DataSet ds = dbop.EmpGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(
                    new Employee
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        Name = dr["name"].ToString(),
                        City = dr["city"].ToString(),
                        State = dr["state"].ToString(),
                        Country = dr["country"].ToString(),
                        Department = dr["department"].ToString(),
                    }
                ); 
            }
            return View(list);

        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] Employee emp)
        {
            try
            {
                emp.Flag = "insert";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = new Employee();
            emp.Id = id;
            emp.Flag = "getid";
            DataSet ds = dbop.EmpGet(emp, out msg);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                emp.Id = Convert.ToInt32(dr["id"]);
                emp.Name = dr["name"].ToString();
                emp.City = dr["city"].ToString();
                emp.State = dr["state"].ToString();
                emp.Country = dr["country"].ToString();
                emp.Department = dr["department"].ToString();
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind] Employee emp)
        {
            try
            {
                emp.Id = id;
                emp.Flag = "update";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id, [Bind] Employee emp)
        {
            try
            {
                emp.Id = id;
                emp.Flag = "delete";
                dbop.Empdml(emp, out msg);
                TempData["msg"] = msg;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
