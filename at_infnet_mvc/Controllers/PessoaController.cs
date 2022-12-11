using at_infnet_mvc.Models;
using at_infnet_mvc.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace at_infnet_mvc.Controllers
{
    public class PessoaController : Controller
    {
                
        public readonly PessoaService service;      

        public PessoaController(PessoaService service)
        {
            
            this.service = service;

        }


        public ActionResult Index()
        {
            
            ObjLista listasIndex = new ObjLista(service.AniversariantesDoDia(), service.OrdenacaoAniversarios());

            return View(listasIndex);
        }

        public ActionResult ListaTodos()  
        {
            return View(service.ListaPessoas());
        }


        public ActionResult Detalhes(int id)
        {
            try
            {
                Pessoa? pessoa = service.BuscaPessoaId(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                return View(pessoa);
            }
            catch (Exception) {
                return NotFound();
            }         
      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Busca(string nome)
        {
           
            return View(service.BuscaPessoa(nome));
        }


        public ActionResult Adicionar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Pessoa pessoa)
        {
            try

            {
                service.AdicionaPessoa(pessoa);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }


        public ActionResult Editar(int id)
        {
            try
            {
                Pessoa? pessoa = service.BuscaPessoaId(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                return View(pessoa);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, Pessoa pessoa)
        {
            try{
                service.EditaPessoa(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }
       
        public ActionResult Deletar(int id)
        {
            Pessoa pessoa = service.BuscaPessoaId(id);
            return View(pessoa);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Pessoa pessoa)
        {
            try
            {
                service.DeletaPessoa(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return BadRequest();
            }                       
          
        }
    }
}

