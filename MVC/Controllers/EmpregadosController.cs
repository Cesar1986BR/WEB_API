using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmpregadosController : Controller
    {
        // GET: Empregados
        public ActionResult Index()
        {
            //Chama GET pra listar todos Empregaos
            IEnumerable<MvcEmpregadosModel> empregadoLista;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Empregados").Result;
            empregadoLista = response.Content.ReadAsAsync<IEnumerable<MvcEmpregadosModel>>().Result;
            return View(empregadoLista);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new MvcEmpregadosModel());
            }
            else
            {
                //Chama GET pra Editar antes do POST e lista os dados referente ao Id
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Empregados/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcEmpregadosModel>().Result);

            }
       
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcEmpregadosModel emp)
        {
            if(emp.EmpregadoID == 0)
            {
                //Chama POST pra cadastrar
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Empregados", emp).Result;
                TempData["SuccessMessage"] = "Empregado cadastrado com sucesso!";
            }
            else
            { 
                //Chama PUT pra editar
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Empregados/"+emp.EmpregadoID, emp).Result;
                TempData["SuccessMessage"] = "Empregado Alterado com sucesso!";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            //Chama DELETE pra Deletar
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Empregados/" +id.ToString()).Result;
            TempData["DeleteMessage"] = "Deletado com sucesso!";
            return RedirectToAction("Index");
        }


    }
}