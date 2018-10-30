using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class MvcEmpregadosModel
    {
        public int EmpregadoID { get; set; }

        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Idade é obrigatório")]
        public Nullable<int> Idade { get; set; }
        [Required(ErrorMessage = "Salario é obrigatório")]
        public Nullable<decimal> Salario { get; set; }
    }
}