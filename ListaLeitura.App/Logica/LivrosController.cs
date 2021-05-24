using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;
using ListaLeitura.App.HTML;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {

        public string Detalhes(int id)
        { 
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }
        public static Task NovoLivro(HttpContext context)
        {
            var Livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("Autor").ToString()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(Livro);
            return context.Response.WriteAsync("Livro Incluido com Sucesso");
        }


        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.ParaLer.Livros;
            return View("paraler");

        }

        private static string Listagem(string tipo ,IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML(tipo);

           
        
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
           
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("lendo");

        }

        public IActionResult Lidos()
        {
            var _repo = new LivroRepositorioCSV();
            ViewBag.Livros = _repo.Lidos.Livros;
            return View("lidos");

        }

        public string teste()
        {
            return "OK";
        }

    }
}
