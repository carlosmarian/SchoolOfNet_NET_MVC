using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PessoaModels model)
        {

            ModelState.Remove("Codigo");

            List<PessoaModels> lista = new List<PessoaModels>();

            if (ModelState.IsValid)
            {

                if (Session["ListaPessoas"] != null)
                {
                    lista.AddRange((List<PessoaModels>)Session["ListaPessoas"]);
                }
                model.Codigo = lista.Count;// (new Random()).Next(1, 100);
                lista.Add(model);
                Session["ListaPessoas"] = lista;

                //Enviar objeto para view;
                return View("List", lista);
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Edit (int id)
        {
            if( ( (List<PessoaModels>) Session["ListaPessoas"]).Where(p=>p.Codigo == id).Any())
            {
                //Recuperar objeto com id
                var model = ((List<PessoaModels>)Session["ListaPessoas"]).
                    Where(p => p.Codigo == id).
                    FirstOrDefault();
                //Enviar objeto para view;
                return View("Create", model);
            }

            return View("Create", new PessoaModels());
        }

        [HttpPost]
        public ActionResult Edit(PessoaModels model)
        {
            if(Session["ListaPessoas"] == null)
            {
                return View("List", new List<PessoaModels>());
            }
            if (!((List<PessoaModels>)Session["ListaPessoas"]).Where(p => p.Codigo == model.Codigo).Any())
            {
                return View("List", new List<PessoaModels>());                
            }

            List<PessoaModels> lista = (List<PessoaModels>)Session["ListaPessoas"];
            //Recuperar objeto com id
            var modelBase = lista.
                Where(p => p.Codigo == model.Codigo).
                FirstOrDefault();

            lista[model.Codigo] = model;
            Session["ListaPessoas"] = lista;

            //Enviar objeto para view;
            return View("List", (List<PessoaModels>)Session["ListaPessoas"]);
        }

        public ActionResult Delete(int id)
        {
            if (Session["ListaPessoas"] == null)
            {
                return View("List", new List<PessoaModels>());
            }

            List<PessoaModels> lista = (List<PessoaModels>)Session["ListaPessoas"];

            if (!lista.Where(p => p.Codigo == id).Any())
            {
                return View("List", lista);
            }

            //Recuperar objeto com id
            var modelBase = lista.
                Where(p => p.Codigo == id).
                FirstOrDefault();

            lista.Remove(modelBase);

            Session["ListaPessoas"] = lista;

            return View("List", (List<PessoaModels>)Session["ListaPessoas"]);
        }


        public ActionResult List( )
        {
            if (Session["ListaPessoas"] != null)
            {
                var lista = (List<PessoaModels>)Session["ListaPessoas"];
                return View(lista);
            }
            return View(new List<PessoaModels>());
        }
    }
}