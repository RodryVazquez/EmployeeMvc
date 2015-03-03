using DatabaseContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABCMvcEmployee.Models
{
    public class EmployeeModel
    {
        /// <summary>
        /// Representa el key del empleado
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Representa el nombre del empleado
        /// </summary>
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Name { get; set; }

        /// <summary>
        /// Representa el apellido del empleado
        /// </summary>
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string LastName { get; set; }

        /// <summary>
        /// Representa el No. Social del empleado
        /// </summary>
        [Display(Name = "No. Social")]
        [Required(ErrorMessage = "el {0} es obligatorio")]
        [RegularExpression(@"[0-9]*\.?[0-9]+")]
        public int SecurityNumber { get; set; }

        /// <summary>
        /// Representa el departamento del empleado
        /// </summary>
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string DepartMent { get; set; }

        /// <summary>
        /// Representa el estado del empleado (Activo|Inactivo)
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///
        /// </summary>
        public void ConvertToEntity(Employee employee)
        {
            employee.EmployeeId = this.EmployeeId;
            employee.Name = this.Name;
            employee.LastName = this.LastName;
            employee.SecurityNumber = this.SecurityNumber;
            employee.Department = this.DepartMent;
        }
    }
}
