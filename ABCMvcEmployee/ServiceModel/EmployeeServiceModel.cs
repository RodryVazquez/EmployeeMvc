using ABCMvcEmployee.Models;
using DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ABCMvcEmployee.ServiceModel
{
    public class EmployeeServiceModel : IDisposable
    {
        /// <summary>
        ///Creamos una variable del tipo de nuestro contexto
        /// </summary>
        protected EmployeeDatabaseEntities entities;

        /// <summary>
        /// Inicializamos el contexto en el contructor
        /// </summary>
        public EmployeeServiceModel()
        {
            this.entities = new EmployeeDatabaseEntities();
        }

        /// <summary>
        /// Liberamos recursos
        /// </summary>
        public void Dispose()
        {
            this.entities.Dispose();
        }

        /// <summary>
        /// Consultamos empleados activos
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllEmployees()
        {
            //Creamos el contenedor de datos
            List<EmployeeModel> employees = new List<EmployeeModel>();
            //Consultamos empleados activos
            var getEmployees = this.entities.Employees.Where(p => p.Active == true);
            //Recorremos los datos
            foreach (var items in getEmployees)
            {
                //Creamos los objetos
                var model = new EmployeeModel()
                {
                    EmployeeId = items.EmployeeId,
                    Name = items.Name,
                    LastName = items.LastName,
                    SecurityNumber = items.SecurityNumber,
                    DepartMent = items.Department,
                    Active = items.Active
                };
                //Añadimos los objetos al contenedor
                employees.Add(model);
            }
            return employees;
        }

        /// <summary>
        /// Crea un nuevo empleado
        /// </summary>
        /// <returns></returns>
        public async Task<int> CreateEmployee(Employee employee)
        {
            if (!employee.Active)
            {
                employee.Active = true;
            }
            this.entities.Employees.Add(employee);
            return await this.entities.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un empleado existente
        /// </summary>
        /// <returns></returns>
        public async Task<int> UpdateEmployee(Employee employee)
        {
            Employee empl = (from p in this.entities.Employees
                             where p.EmployeeId == employee.EmployeeId
                             select p).SingleOrDefault();
            empl.Name = employee.Name;
            empl.LastName = employee.LastName;
            empl.SecurityNumber = employee.SecurityNumber;
            empl.Department = employee.Department;
            return await this.entities.SaveChangesAsync();
        }

        /// <summary>
        /// Consulta un empleado con base a su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeModel GetEmployeeById(int id)
        {
            //Consultamos el objeto con base al Id
            var getByID = this.entities.Employees.Where(p => p.EmployeeId == id).FirstOrDefault();
            //Seteamos a nuestro modelo
            var employeeMod = new EmployeeModel()
            {
                EmployeeId = getByID.EmployeeId,
                Name = getByID.Name,
                LastName = getByID.LastName,
                SecurityNumber = getByID.SecurityNumber,
                DepartMent = getByID.Department,
                Active = getByID.Active
            };
            return employeeMod;
        }

        /// <summary>
        /// Borra un empleado existente
        /// </summary>
        /// <returns></returns>
        public async Task<int> DestroyEmployee(int id)
        {
            Employee empl = (from p in this.entities.Employees
                             where p.EmployeeId == id
                             select p).SingleOrDefault();
            empl.Active = false;
            return await this.entities.SaveChangesAsync();
        }
    }

}