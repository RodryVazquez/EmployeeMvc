using ABCMvcEmployee.Models;
using ABCMvcEmployee.ServiceModel;
using DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ABCMvcEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            using (var employeeService = new EmployeeServiceModel())
            {
                employees = employeeService.GetAllEmployees();
            }
            return View(employees);
        }
        /// <summary>
        /// Mostramos la vista Crear
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Mostramos la vista Editar
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            EmployeeModel model = new EmployeeModel();
            using (var employeeService = new EmployeeServiceModel())
            {
                model = employeeService.GetEmployeeById(id);
            }
            return View(model);
        }
        /// <summary>
        /// Creamos un nuevo empleado
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateEmployee(EmployeeModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                using (var employeeService = new EmployeeServiceModel())
                {
                    var contextObj = new Employee();
                    model.ConvertToEntity(contextObj);
                    await employeeService.CreateEmployee(contextObj);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// Actualizamos un empleado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateEmployee(EmployeeModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                using (var employeeService = new EmployeeServiceModel())
                {
                    var contextObj = new Employee();
                    model.ConvertToEntity(contextObj);
                    await employeeService.UpdateEmployee(contextObj);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        /// <summary>
        /// Borra un empleado existente
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            using (var employeeService = new EmployeeServiceModel())
            {
                await employeeService.DestroyEmployee(id);
            }
            return RedirectToAction("Index");
        }

    }
}